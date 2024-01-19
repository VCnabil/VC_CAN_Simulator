using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.NomadGui
{
    public  class AxioShell
    {
        private uint _cur_SendingPGN_22;
        private uint _cur_SendingPGN_23;
        private int _BaudRate;
        private int _DeviceIndex;
        private string resultString;
        private string Incomming_FullPGN_String;

 

        byte[] bptr_inc_FF00;
        byte[] _DATA_BytesIncomming_FF00 = { 0x04, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 };
        byte[] bptr_inc_FF01;
        byte[] _DATA_BytesIncomming_FF01 = { 0x04, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 }; //<------------------
        byte[] bptr_inc_FF10;
        byte[] _DATA_BytesIncomming_FF10 = { 0x04, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 };
        byte[] bptr_inc_FF11;
        byte[] _DATA_BytesIncomming_FF11 = { 0x04, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 };

        byte[] bptr_inc_FF02; //temp for feedbacks 
        byte[] _DATA_BytesIncomming_FF02 = { 0x04, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 };  //<------------------

        byte[] bptr_inc_FF03; //temp for sending
        byte[] _DATA_BytesIncomming_FF03 = { 0x01, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 };//<------------------

        uint _port_com_PGN = 0x18FF2200;
        byte[] bptr_port_com_FF22; //PORT REMOTE COMMANDS
        byte[] _DATA_PORT_COM_FF22 = { 0x01, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 };

        uint _stbd_com_PGN = 0x18FF2300;
        byte[] bptr_stbd_com_FF23; //STBD REMOTE COMMANDS
        byte[] _DATA_STBD_COM_FF23 = { 0x01, 0x02, 0x03, 0x04, 0x05, 0xFF, 0xD0, 0x07 };

        uint _changeover_com_PGN = 0x18FF2300;
        byte[] bptr_changeover_com_FF21; //only set first bit in the first byte
        byte[] _DATA_CHANGOVER_COM_FF21 = { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        uint _sysinfo_PGN = 0x18FF8C00;
        byte[] bptr_sysinfo_FF8C; //only set the first bit in the first byte
        byte[] _DATA_SYSINFO_FF8C = { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public AxioShell()
        {
            Incomming_FullPGN_String = "";
        }
        public string GetMessageString()
        {
            // Method code here
            return Incomming_FullPGN_String;
        }

        public void RunReceiveMessage_UpdateLocalDataBytes()
        {
            uint _latestFULLPGN = 122542;

            string frameid_hx, priority_hx, pgn_hx, addr_hx;
            ExtractComponentsFromFrameID(_latestFULLPGN, out frameid_hx, out priority_hx, out pgn_hx, out addr_hx);

            Incomming_FullPGN_String = $"{frameid_hx} {priority_hx} {pgn_hx} {addr_hx} ;";

            if (pgn_hx == "FF00")
            {
                for (int i = 0; i < 8; i++)
                {
                    _DATA_BytesIncomming_FF00[i] = 0;//(int)USBCANMessage.CANFrame.Data[i];
                }
            }
            else if (pgn_hx == "FF01")
            {
                for (int i = 0; i < 8; i++)
                {
                    _DATA_BytesIncomming_FF01[i] = 0;//(int)USBCANMessage.CANFrame.Data[i];
                }
            }
            else if (pgn_hx == "FF10")
            {
                for (int i = 0; i < 8; i++)
                {
                    _DATA_BytesIncomming_FF10[i] = 0;//(int)USBCANMessage.CANFrame.Data[i];
                }
            }
            else if (pgn_hx == "FF11")
            {
                for (int i = 0; i < 8; i++)
                {
                    _DATA_BytesIncomming_FF11[i] = 0;//(int)USBCANMessage.CANFrame.Data[i];
                }
            }
            else if (pgn_hx == "FF02")
            {
                for (int i = 0; i < 8; i++)
                {
                    _DATA_BytesIncomming_FF02[i] = 0;//(int)USBCANMessage.CANFrame.Data[i];
                }
            }
        }

        public void ExtractComponentsFromFrameID(uint frameid, out string frameid_hx, out string priority_hx, out string pgn_hx, out string addr_hx)
        {

            // Convert frameid to hexadecimal string
            frameid_hx = "0x" + frameid.ToString("X8");

            // Extract priority, pgn, and address components
            priority_hx = frameid_hx.Substring(2, 2);
            pgn_hx = frameid_hx.Substring(4, 4);
            addr_hx = frameid_hx.Substring(8, 2);
        }

        public int Get_test_Thrust_Scale5000_out2000Feedback_L()
        {
            // Extract the last two bytes
            byte byte1 = _DATA_BytesIncomming_FF02[5];
            byte byte2 = _DATA_BytesIncomming_FF02[4];

            // Combine them into a single integer
            int combined = (byte1 << 8) | byte2;
            if (combined > 5000)
                combined = 5000;

            int inputMin = 0;
            int inputMax = 5000;
            int outputMin = 0;
            int outputMax = 2000;

            int outputValue = ((combined - inputMin) * (outputMax - outputMin)) / (inputMax - inputMin) + outputMin;
            return outputValue;
        }

        public int Get_test_Thrust_Scale5000_out2000Feedback_R()
        {
            // Extract the last two bytes
            byte byte1 = _DATA_BytesIncomming_FF02[7];
            byte byte2 = _DATA_BytesIncomming_FF02[6];

            // Combine them into a single integer
            int combined = (byte1 << 8) | byte2;
            if (combined > 5000)
                combined = 5000;

            int inputMin = 0;
            int inputMax = 5000;
            int outputMin = 0;
            int outputMax = 2000;

            int outputValue = ((combined - inputMin) * (outputMax - outputMin)) / (inputMax - inputMin) + outputMin;
            return outputValue;
        }

       public int Get_test_Steer_Scale10000_out1000Feedback_L()
        {
            // Extract the last two bytes
            byte byte1 = _DATA_BytesIncomming_FF02[1];
            byte byte2 = _DATA_BytesIncomming_FF02[0];

            // Combine them into a single integer
            int combined = (byte1 << 8) | byte2;
            if (combined > 1000)
                combined = 1000;

            int inputMin = 0;
            int inputMax = 1000;
            int outputMin = 0;
            int outputMax = 1000;

            int outputValue = combined;
            return outputValue;
        }

        public int Get_test_Steer_Scale10000_out1000Feedback_R()
        {
            // Extract the last two bytes
            byte byte1 = _DATA_BytesIncomming_FF02[3];
            byte byte2 = _DATA_BytesIncomming_FF02[2];

            // Combine them into a single integer
            int combined = (byte1 << 8) | byte2;
            if (combined > 1000)
                combined = 1000;

            int inputMin = 0;
            int inputMax = 10000;
            int outputMin = 0;
            int outputMax = 1000;

            int outputValue = combined;
            return outputValue;
        }



        public void UpdateCurSendingPGN(uint argNewPGN)
        {
            // Method code here
        }
        public void UpdateCurSendingPGN_22(uint argNewPGN_22)
        {
            _cur_SendingPGN_22 = argNewPGN_22;
        }
        public void UpdateCurSendingPGN_23(uint argNewPGN_23)
        {
            _cur_SendingPGN_23 = argNewPGN_23;
        }




        public string Get_curPGN_asSTR()
        {
            MessageBox.Show("Get_curPGN_asSTR");
            // Method code here
            return "";
        }

        public void Send_changeoverRequ(bool argONOFF)
        {
            MessageBox.Show("Send_changeoverRequ");
           // CANFrame CANFrame = new CANFrame();
           // Array.Clear(CANFrame.Data, 0, CANFrame.Data.Length);

          //  CANFrame.bEIdFlag = true; // Extended CAN frames 
           // CANFrame.bLength = 8;
           // CANFrame.ulID = _changeover_com_PGN;

            if (argONOFF == true)
            {
                _DATA_CHANGOVER_COM_FF21[0] = 1;
            }
            else
            {
                _DATA_CHANGOVER_COM_FF21[0] = 0;
            }

            for (int j = 0; j < 8; j++)
            {
              //  CANFrame.Data[j] = _DATA_CHANGOVER_COM_FF21[j];
            }

           // dwResult = USBCANSendCANFrame(hDeviceHandle, ref CANFrame, IntPtr.Zero);
        }


        public void Send_test()
        {
            // Method code here
        }
        public void Send_Both_PS_coms(int arg_P_thrust, int arg_P_steer, int arg_S_thrust, int arg_S_steer)
        {
            // Method code here
        }

        public void Send_ALL_PS_IO_COMS(int arg_P_I_thrust, int arg_P_I_steer, int arg_S_I_thrust, int arg_S_I_steer, int arg_P_O_thrust, int arg_P_O_steer, int arg_S_O_thrust, int arg_S_O_steer)
        {
           // MessageBox.Show("Send_ALL_PS_IO_COMS");
            // Filter input values
            arg_P_I_thrust = Math.Min(2000, Math.Max(0, arg_P_I_thrust));
            arg_P_I_steer = Math.Min(1000, Math.Max(0, arg_P_I_steer));
            arg_S_I_thrust = Math.Min(2000, Math.Max(0, arg_S_I_thrust));
            arg_S_I_steer = Math.Min(1000, Math.Max(0, arg_S_I_steer));
            arg_P_O_thrust = Math.Min(2000, Math.Max(0, arg_P_O_thrust));
            arg_P_O_steer = Math.Min(1000, Math.Max(0, arg_P_O_steer));
            arg_S_O_thrust = Math.Min(2000, Math.Max(0, arg_S_O_thrust));
            arg_S_O_steer = Math.Min(1000, Math.Max(0, arg_S_O_steer));

            byte _P_I_thrust_HB = (byte)((arg_P_I_thrust >> 8) & 0xFF);
            byte _P_I_thrust_lb = (byte)(arg_P_I_thrust & 0xFF);

            byte _P_I_steer_HB = (byte)((arg_P_I_steer >> 8) & 0xFF);
            byte _P_I_steer_lb = (byte)(arg_P_I_steer & 0xFF);

            byte _P_O_thrust_HB = (byte)((arg_P_O_thrust >> 8) & 0xFF);
            byte _P_O_thrust_lb = (byte)(arg_P_O_thrust & 0xFF);

            byte _P_O_steer_HB = (byte)((arg_P_O_steer >> 8) & 0xFF);
            byte _P_O_steer_lb = (byte)(arg_P_O_steer & 0xFF);

            byte _S_I_thrust_HB = (byte)((arg_S_I_thrust >> 8) & 0xFF);
            byte _S_I_thrust_lb = (byte)(arg_S_I_thrust & 0xFF);

            byte _S_I_steer_HB = (byte)((arg_S_I_steer >> 8) & 0xFF);
            byte _S_I_steer_lb = (byte)(arg_S_I_steer & 0xFF);

            byte _S_O_thrust_HB = (byte)((arg_S_O_thrust >> 8) & 0xFF);
            byte _S_O_thrust_lb = (byte)(arg_S_O_thrust & 0xFF);

            byte _S_O_steer_HB = (byte)((arg_S_O_steer >> 8) & 0xFF);
            byte _S_O_steer_lb = (byte)(arg_S_O_steer & 0xFF);

            // Fill arrays
            _DATA_PORT_COM_FF22[0] = _P_O_thrust_lb;
            _DATA_PORT_COM_FF22[1] = _P_O_thrust_HB;
            _DATA_PORT_COM_FF22[2] = _P_I_thrust_lb;
            _DATA_PORT_COM_FF22[3] = _P_I_thrust_HB;
            _DATA_PORT_COM_FF22[4] = _P_O_steer_lb;
            _DATA_PORT_COM_FF22[5] = _P_O_steer_HB;
            _DATA_PORT_COM_FF22[6] = _P_I_steer_lb;
            _DATA_PORT_COM_FF22[7] = _P_I_steer_HB;

            _DATA_STBD_COM_FF23[0] = _S_I_thrust_lb;
            _DATA_STBD_COM_FF23[1] = _S_I_thrust_HB;
            _DATA_STBD_COM_FF23[2] = _S_O_thrust_lb;
            _DATA_STBD_COM_FF23[3] = _S_O_thrust_HB;
            _DATA_STBD_COM_FF23[4] = _S_I_steer_lb;
            _DATA_STBD_COM_FF23[5] = _S_I_steer_HB;
            _DATA_STBD_COM_FF23[6] = _S_O_steer_lb;
            _DATA_STBD_COM_FF23[7] = _S_O_steer_HB;

            // First message STBD
           // CANFrame CANFrame1 = new CANFrame();
           // Array.Clear(CANFrame1.Data, 0, CANFrame1.Data.Length);

           // CANFrame1.bEIdFlag = true;
           //// CANFrame1.bLength = 8;
            //CANFrame1.ulID = _cur_SendingPGN_22;

            //for (int j = 0; j < 8; j++)
            //{
               // CANFrame1.Data[j] = _DATA_PORT_COM_FF22[j];
            //}

          //  dwResult = USBCANSendCANFrame(hDeviceHandle, ref CANFrame1, IntPtr.Zero);

            // Second message STBD
          //  CANFrame CANFrame2 = new CANFrame();
            //Array.Clear(CANFrame2.Data, 0, CANFrame2.Data.Length);

            //CANFrame2.bEIdFlag = true;
            //CANFrame2.bLength = 8;
            //CANFrame2.ulID = _cur_SendingPGN_23;

            //for (int j = 0; j < 8; j++)
            //{
            //    CANFrame2.Data[j] = _DATA_STBD_COM_FF23[j];
            //}

           // dwResult = USBCANSendCANFrame(hDeviceHandle, ref CANFrame2, IntPtr.Zero);
        }





        public void Send_sysInfo(byte argb0, byte argb1, byte argb2, byte argb3, byte argb4, byte argb5, byte argb6, byte argb7)
        {
            // Method code here
        }

        public void STORE_sysInfo(byte argb0, byte argb1, byte argb2, byte argb3, byte argb4, byte argb5, byte argb6, byte argb7)
        {
            _DATA_SYSINFO_FF8C[0] = argb0;
            _DATA_SYSINFO_FF8C[1] = argb1;
            _DATA_SYSINFO_FF8C[2] = argb2;
            _DATA_SYSINFO_FF8C[3] = argb3;
            _DATA_SYSINFO_FF8C[4] = argb4;
            _DATA_SYSINFO_FF8C[5] = argb5;
            _DATA_SYSINFO_FF8C[6] = argb6;
            _DATA_SYSINFO_FF8C[7] = argb7;
        }

        public void Send_SORED_sysInfo()
        {
           // MessageBox.Show("Send_SORED_sysInfo");  
            //CANFrame CANFrame = new CANFrame();
            //Array.Clear(CANFrame.Data, 0, CANFrame.Data.Length);

            //CANFrame.bEIdFlag = true;
            //CANFrame.bLength = 8;
            //CANFrame.ulID = _sysinfo_PGN;

            //for (int j = 0; j < 8; j++)
            //{
            //    CANFrame.Data[j] = _DATA_SYSINFO_FF8C[j];
            //}

            //dwResult = USBCANSendCANFrame(hDeviceHandle, ref CANFrame, IntPtr.Zero);
        }

        public void CustomSendKeepAlives()
        {
            byte[] _DATA_keepalve_00 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_01 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_10 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_11 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_02 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_03 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_12 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_13 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_04 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_05 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_06 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] _DATA_keepalve_07 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            SendKeepAliveMessage(0x18FF8C00, _DATA_keepalve_00);
            SendKeepAliveMessage(0x18FF8C01, _DATA_keepalve_01);
            SendKeepAliveMessage(0x18FF8C10, _DATA_keepalve_10);
            SendKeepAliveMessage(0x18FF8C11, _DATA_keepalve_11);
            SendKeepAliveMessage(0x0CFFA002, _DATA_keepalve_02);
            SendKeepAliveMessage(0x0CFFA003, _DATA_keepalve_03);
            SendKeepAliveMessage(0x0CFFA012, _DATA_keepalve_12);
            SendKeepAliveMessage(0x0CFFA013, _DATA_keepalve_13);
            SendKeepAliveMessage(0x0CFFA004, _DATA_keepalve_04);
            SendKeepAliveMessage(0x0CFFA005, _DATA_keepalve_05);
            SendKeepAliveMessage(0x0CFFA006, _DATA_keepalve_06);
            SendKeepAliveMessage(0x0CFFA007, _DATA_keepalve_07);
        }
        void SendKeepAliveMessage(uint ulID, byte[] data)
        {
            //CANFrame CANFrame = new CANFrame();
            //Array.Clear(CANFrame.Data, 0, CANFrame.Data.Length);

            //CANFrame.bEIdFlag = true;
            //CANFrame.bLength = 8;
            //CANFrame.ulID = ulID;

            //for (int j = 0; j < 8; j++)
            //{
            //    CANFrame.Data[j] = data[j];
            //}

            //dwResult = USBCANSendCANFrame(hDeviceHandle, ref CANFrame, IntPtr.Zero);
        }
        public void Send_indications(int argbuc0, int argbuc1, int argnoz0, int argnoz1, int argeng0, int argeng1)
        {
            // Method code here
        }

        public void SendRaw(uint argfullPGN, byte b0, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7)
        {
            // Method code here
        }

        private int Connect_0()
        {
            // Method code here
            return 0;
        }

        private int Closing_Z()
        {
            // Method code here
            return 0;
        }

     
       
    }
}
