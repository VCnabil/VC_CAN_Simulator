﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.Backend;
using VC_CAN_Simulator.DataObjects;
using VC_CAN_Simulator.UIz.ManipUC;
using VC_CAN_Simulator.UIz.ManipUC.BuildersManips;
using VC_CAN_Simulator.UIz.UControlz.Builders;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class CanManipForm : Form
    {
        bool _loopIsRunning;
        CanManager canManager;
        Dictionary<int, UC_PGN_Controller> Dict_active_PGNcontroller;
        public CanManipForm()
        {
            #region TEST
            /*
            Ctrl_DataObject _8bit_Label = new Ctrl_DataObject();
            _8bit_Label.ID = 0;
            _8bit_Label.MIN = 0;
            _8bit_Label.MAX = 255;
            _8bit_Label.DEF = 127;
            _8bit_Label.DESC = "8 bit label";
            _8bit_Label.ISSLIDER = false;
            _8bit_Label.CTRL_TYOE_STR = EnumToString(CtrlType._1_By);
            _8bit_Label.INDEXLO = 0;
            _8bit_Label.INDEXHI = 0;

            Ctrl_DataObject _16bit_Label = new Ctrl_DataObject();
            _16bit_Label.ID = 1;
            _16bit_Label.MIN = 0;
            _16bit_Label.MAX = 9000;
            _16bit_Label.DEF = 1885;
            _16bit_Label.DESC = "16 bit label";
            _16bit_Label.ISSLIDER = false;
            _16bit_Label.CTRL_TYOE_STR = EnumToString(CtrlType._2_by);
            _16bit_Label.INDEXLO = 1;
            _16bit_Label.INDEXHI = 2;

            Ctrl_DataObject _8bit_Slider = new Ctrl_DataObject();
            _8bit_Slider.ID = 2;
            _8bit_Slider.MIN = 0;
            _8bit_Slider.MAX = 255;
            _8bit_Slider.DEF = 127;
            _8bit_Slider.DESC = "8 bit slider";
            _8bit_Slider.ISSLIDER = true;
            _8bit_Slider.CTRL_TYOE_STR = EnumToString(CtrlType._1_By);
            _8bit_Slider.INDEXLO = 3;
            _8bit_Slider.INDEXHI = 3;

            Ctrl_DataObject _16bit_Slider = new Ctrl_DataObject();
            _16bit_Slider.ID = 3;
            _16bit_Slider.MIN = 0;
            _16bit_Slider.MAX = 1000;
            _16bit_Slider.DEF = 521;
            _16bit_Slider.DESC = "16 bit slider";
            _16bit_Slider.ISSLIDER = true;
            _16bit_Slider.CTRL_TYOE_STR = EnumToString(CtrlType._2_by);
            _16bit_Slider.INDEXLO = 4;
            _16bit_Slider.INDEXHI = 5;


            List<string> BilList_A = new List<string>();
            BilList_A.Add("0. bit0 yo");
            BilList_A.Add("1. bit1 idk");
            //  BilList_A.Add("2. bit2 alarm");
            BilList_A.Add("3. bit3 mama");
            BilList_A.Add("4. bit4 man");
            // BilList_A.Add("5. bit5 alarm");
            BilList_A.Add("6. bit6 sofat");
            BilList_A.Add("7. bit7 whatever");
            List<string> Groups1 = new List<string>();
            Groups1.Add("0,3,6");
            //Groups1.Add("");
            List<string> Groups2 = new List<string>();
            Groups2.Add("1,4,7");


            Ctrl_DataObject _bitsA_ = new Ctrl_DataObject();
            _bitsA_.ID = 4;
            _bitsA_.MIN = 0;
            _bitsA_.MAX = 255;
            _bitsA_.DEF = 0;
            _bitsA_.DESC = "8 bits yall";
            _bitsA_.ISSLIDER = false;
            _bitsA_.CTRL_TYOE_STR = EnumToString(CtrlType._8_bG);
            _bitsA_.INDEXLO = 7;
            _bitsA_.INDEXHI = 7;
            _bitsA_.BitsList = BilList_A;
            _bitsA_.Group1List = Groups1;
            _bitsA_.Group2List = Groups2;

            Pgn_DataObject pgnobj = new Pgn_DataObject();
            pgnobj.IDpgn = 0;
            pgnobj.PGN_int = 0x18FEF100;
            pgnobj.PGN_strHEX = "18FEF100";
            pgnobj.DESCpgn = "Engine 1";
            pgnobj.CtrlList = new List<Ctrl_DataObject>();
            pgnobj.CtrlList.Add(_8bit_Label);
            pgnobj.CtrlList.Add(_16bit_Label);
            pgnobj.CtrlList.Add(_8bit_Slider);
            pgnobj.CtrlList.Add(_16bit_Slider);
            pgnobj.CtrlList.Add(_bitsA_);
            */
            #endregion



            //Pgn_DataObject pgnobj = new Pgn_DataObject();
            //pgnobj.IDpgn = 0;
            //pgnobj.PGN_int = 0x18FEF100;
            //pgnobj.PGN_strHEX = "18FEF100";
            //pgnobj.DESCpgn = "Engine 1";
            //pgnobj.CtrlList = new List<Ctrl_DataObject>();
            //pgnobj.CtrlList.Add(_8bit_Label);
            //pgnobj.CtrlList.Add(_16bit_Label);
            //pgnobj.CtrlList.Add(_8bit_Slider);
            //pgnobj.CtrlList.Add(_16bit_Slider);
            //pgnobj.CtrlList.Add(_bitsA_);

            InitializeComponent();
            this.Width = 2400/2;
            this.Height = 1580/2;

            canManager = new CanManager();
            canManager.ListChannels();
            canManager.OpenChannel(0);
            canManager.SetBusParams();
            canManager.GoOnBus();

            timer1_Loop.Tick += Timer1_Loop_Tick;
            timer1_Loop.Interval = 200;
            timer1_Loop.Enabled = false;
            btn_StartStop.Click += Btn_StartStop_Click;
            _loopIsRunning = false;

            Dict_active_PGNcontroller = new Dictionary<int, UC_PGN_Controller>();

            Project_DataObject PROJECTTOSAVE = LoadJsonFile(Get_FullFilePAth());
            int apgntestheight = 0;
            for (int i = 0; i < PROJECTTOSAVE.AllPgnList.Count; i++)
            {
                Pgn_DataObject pgnobj = PROJECTTOSAVE.AllPgnList[i];
                UC_PGN_Controller pgntest = new UC_PGN_Controller(pgnobj);
                int PGNint = pgntest.MyPGN_INT;
                Dict_active_PGNcontroller.Add(PGNint, pgntest);
                apgntestheight = pgntest.Height;
                this.flowLayoutPanel1.Controls.Add(pgntest);
            }
            this.flowLayoutPanel1.Width = this.Width-50;
            this.flowLayoutPanel1.Height = apgntestheight+10;
        }

        private Project_DataObject LoadJsonFile(string path_filenameFromMain)
        {
            string json = System.IO.File.ReadAllText(path_filenameFromMain);
            Project_DataObject myPgnList = JsonConvert.DeserializeObject<Project_DataObject>(json);
            return myPgnList;
        }

        private void Btn_StartStop_Click(object sender, EventArgs e)
        {
            _loopIsRunning = !_loopIsRunning; // Toggle the state of the loop running flag

            if (_loopIsRunning)
            {
                btn_StartStop.BackColor = Color.Green; // Set button color to green when loop is running
                timer1_Loop.Enabled = true; // Start the timer
                lbl_status.Text = "Running"; // Set the status label to running
            }
            else
            {
                btn_StartStop.BackColor = Color.Red; // Set button color to red when loop is stopped
                timer1_Loop.Enabled = false; // Stop the timer
                lbl_status.Text = "Stopped"; // Set the status label to stopped
            }
        }

        private void Timer1_Loop_Tick(object sender, EventArgs e)
        {

            foreach (KeyValuePair<int, UC_PGN_Controller> entry in Dict_active_PGNcontroller)
            {
                int pgn = entry.Key;
                byte[] data = entry.Value.MYdata_bytes;
                if(entry.Value.AllowSending)
                canManager.SendMessage(pgn, data);
            }
        }
    }
}
