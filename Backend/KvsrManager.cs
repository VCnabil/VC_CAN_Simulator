using Kvaser.CanLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
namespace VC_CAN_Simulator.Backend
{
    public class KvsrManager
    {
   
        private static readonly Lazy<KvsrManager> instance = new Lazy<KvsrManager>(() => new KvsrManager());
        private int handle = -1337;
        bool _isOnBus = false;
        int errorsCnt = 0;

        string _errormessage= "";
        public string GetErrorMessage()
        {
            return _errormessage;
        }
        public static KvsrManager Instance
        {
            get
            {
                return instance.Value;
            }
        }
        private KvsrManager()
        {
            handle = -1337;
            _isOnBus = false;
            errorsCnt = 0;
        }
        public bool GetIsOnBus()
        {
            return _isOnBus;
        }
        public void Init()
        {
            if (_isOnBus)
            {
                errorsCnt++;
                _errormessage = "Already on bus " + errorsCnt.ToString() ;
                return;
            }
            handle = -1337;
            Canlib.canInitializeLibrary();
            Canlib.canStatus statusConnected = Canlib.canGetNumberOfChannels(out int numberOfChannels);
            if (statusConnected != 0)
            {
                errorsCnt++;
                _errormessage ="NManager o Kvaser device connected" + errorsCnt.ToString();
                return;
            }
            if (numberOfChannels < 3)
            {
                errorsCnt++;
                _errormessage ="Manager looks like only virtual channels are available " + errorsCnt.ToString();
                return;
            }
            handle = Canlib.canOpenChannel(0, Canlib.canOPEN_ACCEPT_VIRTUAL);
            if (handle != 0)
            {
                errorsCnt++;
                _errormessage ="Manager Failed to open channel" + errorsCnt.ToString();
                return;
            }
            Canlib.canStatus statusSetParams = Canlib.canSetBusParams(handle, Canlib.canBITRATE_250K, 0, 0, 0, 0);
            if (statusSetParams != 0)
            {
                errorsCnt++;
                _errormessage ="Manager Failed to set bus parameters" + errorsCnt.ToString();
                return;
            }
            Canlib.canStatus statusBusOn = Canlib.canBusOn(handle);
            if (statusBusOn != 0)
            {
                errorsCnt++;
                _errormessage ="Manager Failed to set bus on" + errorsCnt.ToString();
                return;
            }
            _isOnBus = true;
        }
        //void ManageMEssages(string argMessage)
        //{
        //    argMessage += " managed";
        //    if (System.Windows.Forms.Application.OpenForms.Count > 0)
        //    {
        //        // Use the first open form to invoke the MessageBox
        //        System.Windows.Forms.Application.OpenForms[0].Invoke(new MethodInvoker(delegate
        //        {
        //            if(kvsrdebugMode)MessageBox.Show(argMessage);
        //        }));
        //    }
        //    else
        //    {
        //        // Fallback if no form is open
        //        if(kvsrdebugMode)MessageBox.Show(argMessage);
        //    }
        //}
        public void Close()
        {
            if (!_isOnBus)
            {
                errorsCnt++;
                _errormessage ="close not onb bus" + errorsCnt.ToString();
                return;
            }
            Canlib.canStatus statusBusOff = Canlib.canBusOff(handle);
            if (statusBusOff != 0)
            {
                errorsCnt++;
                _errormessage ="close Failed to bus off" + errorsCnt.ToString();
                return;
            }
            Canlib.canStatus statusClose = Canlib.canClose(handle);
            if (statusClose != 0)
            {
                errorsCnt++;
                _errormessage ="close Failed to close" + errorsCnt.ToString();
                return;
            }
            _isOnBus = false;
        }
        public int SendPGN_withStatus(int pgn, byte[] data)
        {
            if (!_isOnBus)
            {
                errorsCnt++;
                _errormessage ="Manager not on bus cant write" + errorsCnt.ToString();
                return -1;
            }
            Canlib.canStatus statusWrite = Canlib.canWrite(handle, pgn, data, data.Length, 0);
            if (statusWrite != 0)
            {
                errorsCnt++;
                _errormessage ="Manager Failed to write" + errorsCnt.ToString();
                return -2;
            }
            return 0;
        }
    }
}

/*
 * 
      public void SendPGN(int pgn, byte[] data)
        {
            if (!_isOnBus)
            {
               
                return;
            }
            Canlib.canStatus statusWrite = Canlib.canWrite(handle, pgn, data, data.Length, 0);
            if (statusWrite != 0)
            {
                ManageMEssages("Manager Failed to write");
                return;
            }
        }

 * 
  void CheckStatus(Canlib.canStatus status, string method)
        {
            if (status < 0)
            {
                string errorText;
                Canlib.canGetErrorText(status, out errorText);
                // Check if there's an open form
                if (System.Windows.Forms.Application.OpenForms.Count > 0)
                {
                    // Use the first open form to invoke the MessageBox
                    System.Windows.Forms.Application.OpenForms[0].Invoke(new MethodInvoker(delegate
                    {
                        if(kvsrdebugMode)MessageBox.Show($"{method} failed: {errorText}");
                    }));
                }
                else
                {
                    // Fallback if no form is open
                    if(kvsrdebugMode)MessageBox.Show($"{method} failed: {errorText}");
                }
            }
        }
       
 */