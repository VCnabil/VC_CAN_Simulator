using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.Backend;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.WskiGui
{
    public partial class WSKI_GUI : Form
    {
        CanManager canManager;
        int _png_SoftwareVersions_CU_A_FF30 = 0x18FFF300;
        int _png_SoftwareVersions_CU_B_FF30 = 0x18FFF301;
        byte[] _data_FFD3_AB;// { 10, 10, 10, 10, 10, 10, 10 }; sysinfo

        int _png_SoftwareVersions_AZM_A_FFCA = 0x18FFCA00;
        int _png_SoftwareVersions_AZM_B_FFCA = 0x18FFCA01;
        byte[] _data_FFCA_AB;// { 10, 10, 10, 10, 10, 10, 10 }; sysinfo

        int _png_SoftwareVersions_cltch_A_FF40 = 0x18FF4000;
        int _png_SoftwareVersions_cltch_B_FF40 = 0x18FF4001;
        byte[] _data_FF40_AB;// { 10, 10, 10, 10, 10, 10, 10 }; sysinfo

        int _png_FFCB_AZM_A_FFCB = 0x18FFCB00;
        int _png_FFCB_AZM_B_FFCB = 0x18FFCB01;
        //from uC_AzimthSliders1


        int _png_FFD1_clucthc_A = 0x18FFD100;
        byte[] _data_FFD1_A;

        int _png_FFD1_clucthc_B = 0x18FFD101;
        byte[] _data_FFD1_B;

        int _png_FFD2_CUfaults_status_A = 0x18FFD200;
        byte[] _data_FFD2_A;

        int _png_FFD2_CUfaults_status_B = 0x18FFD201;
        byte[] _data_FFD2_B;

        int _png_FFD0_steer_throt_A = 0x18FFD000;
        int _png_FFD0_steer_throt_B = 0x18FFD001;
        // from uC_SteerEnginSliders1


        int _png_FF31_clucthc_A = 0x18FF3100;
        byte[] _data_FF31_A;

        int _png_FF31_clucthc_B = 0x18FF3101;
        byte[] _data_FF31_B;




        /*
           uC_FFD0_A.SetDataBytes(uC_SteerEnginSliders1.getData());
            uC_FFD0_B.SetDataBytes(uC_SteerEnginSliders2.getData());
            uC_FFCB_A.SetDataBytes(uC_AzimthSliders1.getData());
            uC_FFCB_B.SetDataBytes(uC_AzimthSliders2.getData());
         */
        bool _AisInControl;
        bool _Aconf_Is_PORT;
        bool _Bconf_Is_PORT;
        bool _A_allowClutch;
        bool _B_allowClutch;

        bool _A_isA = true;
        bool _B_isA = false;


        bool use_ArduinoCAN;
        int _png_FEED_Arduino = 0x18FEED00;
        byte[] _data_FEED_Arduino;
        public WSKI_GUI()
        {
            InitializeComponent();
            canManager = new CanManager();
            canManager.ListChannels();
            canManager.OpenChannel(0);
            canManager.SetBusParams();
            canManager.GoOnBus();

            _AisInControl = true; ;
            _Aconf_Is_PORT = true; ;
            _Bconf_Is_PORT = true; ;
            _A_allowClutch = true;
            _B_allowClutch = true;
            rb_CU_A_intCtrl.Checked = true;
            rb_A_confPORT.Checked = true;
            rb_B_confPORT.Checked = true;
            cb_A_allowClutch.Checked = true;
            cb_B_allowClutch.Checked = true;

            _data_FFD3_AB = new byte[8];// { 10, 10, 10, 10, 10, 10, 10 }; sysinfo
            _data_FFCA_AB = new byte[8];// { 10, 10, 10, 10, 10, 10, 10 }; sysinfo
            _data_FF40_AB = new byte[8];// { 10, 10, 10, 10, 10, 10, 10 }; sysinfo
            _data_FFD2_A = new byte[8];
            _data_FFD2_B = new byte[8];
            _data_FFD1_A = new byte[8];
            _data_FFD1_B = new byte[8];
            _data_FEED_Arduino = new byte[8];
            _data_FF31_A = new byte[8];
            _data_FF31_B = new byte[8];

            byte[] dataBytes = new byte[] { 255, 128, 64, 32, 16, 8, 4, 2 };
            uC_FFD0_A.SetDataBytes(dataBytes);

            // Set the PGN (replace 'pgnString' with your PGN)

            btnToggleTimer.Click += BtnToggleTimer_Click;
            timer1_CanSEND.Tick += Timer1_CanSEND_Tick;

            timer2_sysinfo.Tick += Timer2_CanSendSysinfo_Tick;

            rb_CU_A_intCtrl.CheckedChanged += RadioButton_AB_inCtrl_changed;
            rb_CU_b_intCtrl.CheckedChanged += RadioButton_AB_inCtrl_changed;


            rb_A_confPORT.CheckedChanged += RadioButton_A_CONF_CheckedChanged;
            rb_A_confSTBD.CheckedChanged += RadioButton_A_CONF_CheckedChanged;

            rb_B_confPORT.CheckedChanged += RadioButton_B_CONF_CheckedChanged;
            rb_B_confSTBD.CheckedChanged += RadioButton_B_CONF_CheckedChanged;

            cb_A_allowClutch.CheckedChanged += checkbox_A_allowCluct_Changed;
            cb_B_allowClutch.CheckedChanged += checkbox_B_allowCluct_Changed;

            rb_A_clutchCOM_AHD.CheckedChanged += checkbox_COM_A_Changed;
            rb_A_clutchCOM_AST.CheckedChanged += checkbox_COM_A_Changed;
            rb_A_clutchCOM_DIS.CheckedChanged += checkbox_COM_A_Changed;


            rb_B_clutchCOM_AHD.CheckedChanged += checkbox_COM_B_Changed;
            rb_B_clutchCOM_AST.CheckedChanged += checkbox_COM_B_Changed;
            rb_B_clutchCOM_DIS.CheckedChanged += checkbox_COM_B_Changed;


            rb_A_clutchFBK_AHD.CheckedChanged += checkbox_FBK_A_Changed;
            rb_A_clutchFBK_AST.CheckedChanged += checkbox_FBK_A_Changed;
            rb_A_clutchFBK_DIS.CheckedChanged += checkbox_FBK_A_Changed;


            rb_B_clutchFBK_AHD.CheckedChanged += checkbox_FBK_B_Changed;
            rb_B_clutchFBK_AST.CheckedChanged += checkbox_FBK_B_Changed;
            rb_B_clutchFBK_DIS.CheckedChanged += checkbox_FBK_B_Changed;

            rb_A_clutchCOM_AHD.Checked = true;
            rb_B_clutchCOM_AHD.Checked = true;

            rb_A_clutchFBK_AHD.Checked = true;
            rb_B_clutchFBK_AHD.Checked = true;

            /**/

            rb_A_clutchCOM_AHD2.CheckedChanged += checkbox_COM_A_Changed2;
            rb_A_clutchCOM_AST2.CheckedChanged += checkbox_COM_A_Changed2;
            rb_A_clutchCOM_DIS2.CheckedChanged += checkbox_COM_A_Changed2;


            rb_B_clutchCOM_AHD2.CheckedChanged += checkbox_COM_B_Changed2;
            rb_B_clutchCOM_AST2.CheckedChanged += checkbox_COM_B_Changed2;
            rb_B_clutchCOM_DIS2.CheckedChanged += checkbox_COM_B_Changed2;


            rb_A_clutchFBK_AHD2.CheckedChanged += checkbox_FBK_A_Changed2;
            rb_A_clutchFBK_AST2.CheckedChanged += checkbox_FBK_A_Changed2;
            rb_A_clutchFBK_DIS2.CheckedChanged += checkbox_FBK_A_Changed2;


            rb_B_clutchFBK_AHD2.CheckedChanged += checkbox_FBK_B_Changed2;
            rb_B_clutchFBK_AST2.CheckedChanged += checkbox_FBK_B_Changed2;
            rb_B_clutchFBK_DIS2.CheckedChanged += checkbox_FBK_B_Changed2;

            /**/
            rb_A_clutchCOM_AHD2.Checked = true;
            rb_B_clutchCOM_AHD2.Checked = true;

            rb_A_clutchFBK_AHD2.Checked = true;
            rb_B_clutchFBK_AHD2.Checked = true;

            //the data displayers UC_CAN_MESSAGEOUT
            uC_FFD0_A.SetPgn("FF D0 a");
            uC_FFD0_B.SetPgn("FF D0 b");
            uC_FFD1_A.SetPgn("FF D1 a");
            uC_FFD1_B.SetPgn("FF D1 b");

            uC_FFD2_A.SetPgn("FFD2 custat a");
            uC_FFD2_B.SetPgn("FFD2 custat b");

            uC_FFCB_A.SetPgn("FFCB A");
            uC_FFCB_B.SetPgn("FFCB B");

            uC_FFD3_A.SetPgn("FFD3 A");//sysinfo Control Unit A Software
            uC_FFD3_B.SetPgn("FFD3 B");//sysinfo Control Unit B Software
            uC_FFCA_A.SetPgn("FFCA A");//sysinfo AZM A Software
            uC_FFCA_B.SetPgn("FFCA B");//sysinfo AZM B Software
            uC_FF40_A.SetPgn("FF40 A");//sysinfo AZM A Software
            uC_FF40_B.SetPgn("FF40 B");//sysinfo AZM B Software

            uC_FF31_A.SetPgn("FF 31 a");
            uC_FF31_B.SetPgn("FF 31 b");

            //the controls azm
            uC_SteerEnginSliders1.SetTitle = "AZM A";
            uC_SteerEnginSliders2.SetTitle = "AZM B";

            uC_AzimthSliders1.SetTitle = "CU A";
            uC_AzimthSliders2.SetTitle = "CU B";

            uC_FFD0_A.SetDataBytes(uC_SteerEnginSliders1.getData());
            uC_FFD0_B.SetDataBytes(uC_SteerEnginSliders2.getData());
            uC_FFCB_A.SetDataBytes(uC_AzimthSliders1.getData());
            uC_FFCB_B.SetDataBytes(uC_AzimthSliders2.getData());

            cb_useInternal_A.CheckedChanged += chekbox_useArduino_Changed;

        }

        #region onCheckboxes

        private void chekbox_useArduino_Changed(object sender, EventArgs e)
        {
            use_ArduinoCAN = cb_useInternal_A.Checked;

            if (use_ArduinoCAN)
            {
                _data_FEED_Arduino[4] = 0;
                canManager.SendMessage(_png_FEED_Arduino, _data_FEED_Arduino);
            }
            else
            {

                _data_FEED_Arduino[4] = 1;
                canManager.SendMessage(_png_FEED_Arduino, _data_FEED_Arduino);
            }
        }



        private void checkbox_COM_A_Changed2(object sender, EventArgs e)
        {
            // byte B0 = 0;
            byte Byte0_A = 0;


            set_BitAtIndexREF(ref Byte0_A, 1, rb_A_clutchCOM_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 3, rb_A_clutchCOM_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 5, rb_A_clutchCOM_DIS2.Checked);

            set_BitAtIndexREF(ref Byte0_A, 0, rb_A_clutchFBK_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 2, rb_A_clutchFBK_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 4, rb_A_clutchFBK_DIS2.Checked);


            _data_FF31_A[0] = Byte0_A;
        }
        private void checkbox_FBK_A_Changed2(object sender, EventArgs e)
        {
            // byte B1 = 0;
            byte Byte0_A = 0;
            set_BitAtIndexREF(ref Byte0_A, 1, rb_A_clutchCOM_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 3, rb_A_clutchCOM_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 5, rb_A_clutchCOM_DIS2.Checked);

            set_BitAtIndexREF(ref Byte0_A, 0, rb_A_clutchFBK_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 2, rb_A_clutchFBK_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 4, rb_A_clutchFBK_DIS2.Checked);


            _data_FF31_A[0] = Byte0_A;
        }
        private void checkbox_COM_B_Changed2(object sender, EventArgs e)
        {
            byte Byte0_A = 0;


            set_BitAtIndexREF(ref Byte0_A, 1, rb_B_clutchCOM_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 3, rb_B_clutchCOM_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 5, rb_B_clutchCOM_DIS2.Checked);

            set_BitAtIndexREF(ref Byte0_A, 0, rb_B_clutchFBK_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 2, rb_B_clutchFBK_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 4, rb_B_clutchFBK_DIS2.Checked);

            _data_FF31_B[0] = Byte0_A;
        }
        private void checkbox_FBK_B_Changed2(object sender, EventArgs e)
        {
            byte Byte0_A = 0;


            set_BitAtIndexREF(ref Byte0_A, 1, rb_B_clutchCOM_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 3, rb_B_clutchCOM_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 5, rb_B_clutchCOM_DIS2.Checked);

            set_BitAtIndexREF(ref Byte0_A, 0, rb_B_clutchFBK_AHD2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 2, rb_B_clutchFBK_AST2.Checked);
            set_BitAtIndexREF(ref Byte0_A, 4, rb_B_clutchFBK_DIS2.Checked);

            _data_FF31_B[0] = Byte0_A;
        }


        /**/


        private void checkbox_COM_A_Changed(object sender, EventArgs e)
        {
            byte B0 = 0;
            if (rb_A_clutchCOM_AHD.Checked) { B0 = 1; }
            if (rb_A_clutchCOM_AST.Checked) { B0 = 2; }
            if (rb_A_clutchCOM_DIS.Checked) { B0 = 4; }

            _data_FFD1_A[0] = B0;
        }


        private void checkbox_FBK_A_Changed(object sender, EventArgs e)
        {
            byte B1 = 0;
            if (rb_A_clutchFBK_AHD.Checked) { B1 = 1; }
            if (rb_A_clutchFBK_AST.Checked) { B1 = 2; }
            if (rb_A_clutchFBK_DIS.Checked) { B1 = 4; }
            _data_FFD1_A[1] = B1;
        }

        private void checkbox_COM_B_Changed(object sender, EventArgs e)
        {
            byte B2 = 0;
            if (rb_B_clutchCOM_AHD.Checked) { B2 = 1; }
            if (rb_B_clutchCOM_AST.Checked) { B2 = 2; }
            if (rb_B_clutchCOM_DIS.Checked) { B2 = 4; }
            _data_FFD1_B[0] = B2;
        }



        private void checkbox_FBK_B_Changed(object sender, EventArgs e)
        {
            byte B3 = 0;
            if (rb_B_clutchFBK_AHD.Checked) { B3 = 1; }
            if (rb_B_clutchFBK_AST.Checked) { B3 = 2; }
            if (rb_B_clutchFBK_DIS.Checked) { B3 = 4; }
            _data_FFD1_B[1] = B3;
        }

        private void checkbox_A_allowCluct_Changed(object sender, EventArgs e)
        {
            _A_allowClutch = cb_A_allowClutch.Checked;
        }

        private void checkbox_B_allowCluct_Changed(object sender, EventArgs e)
        {
            _B_allowClutch = cb_B_allowClutch.Checked;
        }

        private void RadioButton_AB_inCtrl_changed(object sender, EventArgs e)
        {
            _AisInControl = rb_CU_A_intCtrl.Checked;
        }

        private void RadioButton_A_CONF_CheckedChanged(object sender, EventArgs e)
        {
            _Aconf_Is_PORT = rb_A_confPORT.Checked;
        }

        private void RadioButton_B_CONF_CheckedChanged(object sender, EventArgs e)
        {
            _Bconf_Is_PORT = rb_B_confPORT.Checked;
        }
        private void BtnToggleTimer_Click(object sender, EventArgs e)
        {
            // Toggle the timer's state
            timer1_CanSEND.Enabled = !timer1_CanSEND.Enabled;
            timer2_sysinfo.Enabled = !timer2_sysinfo.Enabled;

            // Change button color based on timer state
            btnToggleTimer.BackColor = timer1_CanSEND.Enabled ? Color.Green : SystemColors.Control;

            if (timer1_CanSEND.Enabled == true)
            {
                timer1_CanSEND.Start();

            }
            else
            {
                timer1_CanSEND.Stop();

            }

            if (timer2_sysinfo.Enabled == true)
            {
                timer2_sysinfo.Start();

            }
            else
            {
                timer2_sysinfo.Stop();

            }
        }

        #endregion
        private void Timer2_CanSendSysinfo_Tick(object sender, EventArgs e)
        {


            canManager.SendMessage(_png_SoftwareVersions_CU_A_FF30, _data_FFD3_AB);
            canManager.SendMessage(_png_SoftwareVersions_CU_B_FF30, _data_FFD3_AB);
            canManager.SendMessage(_png_SoftwareVersions_AZM_A_FFCA, _data_FFCA_AB);
            canManager.SendMessage(_png_SoftwareVersions_AZM_B_FFCA, _data_FFCA_AB);
            canManager.SendMessage(_png_SoftwareVersions_cltch_A_FF40, _data_FF40_AB);
            canManager.SendMessage(_png_SoftwareVersions_cltch_B_FF40, _data_FF40_AB);

        }
        private void Timer1_CanSEND_Tick(object sender, EventArgs e)
        {
            setysinfo();

            set_AZM_FFCB();
            //d3 is sysinfo
            if (!use_ArduinoCAN)
            {
                canManager.SendMessage(_png_FFCB_AZM_A_FFCB, uC_AzimthSliders1.getData());
                canManager.SendMessage(_png_FFCB_AZM_B_FFCB, uC_AzimthSliders2.getData());
            }
            set_Steer_FFD0();
            canManager.SendMessage(_png_FFD0_steer_throt_A, uC_SteerEnginSliders1.getData());
            canManager.SendMessage(_png_FFD0_steer_throt_B, uC_SteerEnginSliders2.getData());

            set_FFD1_();
            canManager.SendMessage(_png_FFD1_clucthc_A, _data_FFD1_A);
            canManager.SendMessage(_png_FFD1_clucthc_B, _data_FFD1_B);

            set_FFD2_inctrl();
            canManager.SendMessage(_png_FFD2_CUfaults_status_A, _data_FFD2_A);
            canManager.SendMessage(_png_FFD2_CUfaults_status_B, _data_FFD2_B);

            set_FF31();
            canManager.SendMessage(_png_FF31_clucthc_A, _data_FF31_A);
            canManager.SendMessage(_png_FF31_clucthc_B, _data_FF31_B);

            Setup_FFCC();//do it 
            //send can 


        }
        void setysinfo()
        {





            byte A_CU_MajorLW = 0x50; byte A_CU_MajorHI = 0x01;
            byte A_CU_MinorLW = 0x40; byte A_CU_MinorHI = 0x02;
            byte A_CU_RevLW = 0x30; byte A_CU_RevHI = 0x03;
            _data_FFD3_AB[0] = A_CU_MajorLW;
            _data_FFD3_AB[1] = A_CU_MajorHI;
            _data_FFD3_AB[2] = A_CU_MinorLW;
            _data_FFD3_AB[3] = A_CU_MinorHI;
            _data_FFD3_AB[4] = A_CU_RevLW;
            _data_FFD3_AB[5] = A_CU_RevHI;


            byte A_AZM_MajorLW = 0x52; byte A_AZM_MajorHI = 0x01;
            byte A_AZM_MinorLW = 0x43; byte A_AZM_MinorHI = 0x02;
            byte A_AZM_RevLW = 0x26; byte A_AZM_RevHI = 0x03;
            _data_FFCA_AB[0] = A_AZM_MajorLW;
            _data_FFCA_AB[1] = A_AZM_MajorHI;
            _data_FFCA_AB[2] = A_AZM_MinorLW;
            _data_FFCA_AB[3] = A_AZM_MinorHI;
            _data_FFCA_AB[4] = A_AZM_RevLW;
            _data_FFCA_AB[5] = A_AZM_RevHI;



            byte AcltchMajorLW = 0x46; byte AcltchMajorHI = 0x01;
            byte AcltchMinorLW = 0x4A; byte AcltchMinorHI = 0x02;
            byte AcltchRevLW = 0x3D; byte AcltchRevHI = 0x08;
            _data_FF40_AB[0] = AcltchMajorLW;
            _data_FF40_AB[1] = AcltchMajorHI;
            _data_FF40_AB[2] = AcltchMinorLW;
            _data_FF40_AB[3] = AcltchMinorHI;
            _data_FF40_AB[4] = AcltchRevLW;
            _data_FF40_AB[5] = AcltchRevHI;


            // [A] 0xFF40 - PW - Clutch Panel Faults and Versions (0xFF40)

            //      SendWord(A_Clutch_MajorSWVersion_TextBox.Text, msg(0), msg(1))
            //       SendWord(A_Clutch_MinorSWVersion_TextBox.Text, msg(2), msg(3))
            //       SendWord(A_Clutch_SWRevision_TextBox.Text, msg(4), msg(5))
            //       If(A_CheckBox_Clutch_Fault1.Checked = True) Then SETBIT(msg(6), 0)
            //       If(A_CheckBox_Clutch_Fault2.Checked = True) Then SETBIT(msg(6), 1)
            //       If(A_CheckBox_Clutch_Fault3.Checked = True) Then SETBIT(msg(6), 2)
            //       If(A_CheckBox_Clutch_Fault4.Checked = True) Then SETBIT(msg(6), 3)
            //       If(A_CheckBox_Clutch_Fault5.Checked = True) Then SETBIT(msg(6), 4)
            //       If(A_CheckBox_Clutch_Fault6.Checked = True) Then SETBIT(msg(6), 5)
            //       If(A_CheckBox_Clutch_Fault7.Checked = True) Then SETBIT(msg(6), 6)
            //       If(A_CheckBox_Clutch_Fault8.Checked = True) Then SETBIT(msg(6), 7)

            uC_FFD3_A.SetDataBytes(_data_FFD3_AB);//sysinfo Control Unit A Software
            uC_FFD3_B.SetDataBytes(_data_FFD3_AB);//sysinfo Control Unit B Software
            uC_FFCA_A.SetDataBytes(_data_FFCA_AB);//sysinfo AZM A Software
            uC_FFCA_B.SetDataBytes(_data_FFCA_AB);//sysinfo AZM B Software
            uC_FF40_A.SetDataBytes(_data_FF40_AB);//sysinfo AZM A Software
            uC_FF40_B.SetDataBytes(_data_FF40_AB);//sysinfo AZM B Software

        }


        void set_FF31()
        {
            uC_FF31_A.SetDataBytes(_data_FF31_A);
            uC_FF31_B.SetDataBytes(_data_FF31_B);

        }

        void set_Steer_FFD0()
        {
            uC_FFD0_A.SetDataBytes(uC_SteerEnginSliders1.getData());
            uC_FFD0_B.SetDataBytes(uC_SteerEnginSliders2.getData());

        }

        void set_AZM_FFCB()
        {

            uC_FFCB_A.SetDataBytes(uC_AzimthSliders1.getData());
            uC_FFCB_B.SetDataBytes(uC_AzimthSliders2.getData());
        }
        //needs faults checkmarks 

        void set_FFD1_()
        {
            uC_FFD1_A.SetDataBytes(_data_FFD1_A);
            uC_FFD1_B.SetDataBytes(_data_FFD1_B);
        }

        void set_FFD2_inctrl()
        {

            byte Byte0_A = 0;
            byte Byte0_B = 0;

            set_BitAtIndexREF(ref Byte0_A, 0, _AisInControl);
            set_BitAtIndexREF(ref Byte0_A, 1, !_Aconf_Is_PORT);
            set_BitAtIndexREF(ref Byte0_A, 2, !_A_isA);
            set_BitAtIndexREF(ref Byte0_A, 3, _A_allowClutch);

            set_BitAtIndexREF(ref Byte0_B, 0, !_AisInControl);
            set_BitAtIndexREF(ref Byte0_B, 1, !_Bconf_Is_PORT);
            set_BitAtIndexREF(ref Byte0_B, 2, !_B_isA);
            set_BitAtIndexREF(ref Byte0_B, 3, _B_allowClutch);

            _data_FFD2_A[0] = Byte0_A;
            _data_FFD2_A[1] = 0;
            _data_FFD2_A[2] = 0;
            _data_FFD2_A[3] = 0;
            _data_FFD2_A[4] = 0;
            _data_FFD2_A[5] = 0;
            _data_FFD2_A[6] = 0;
            _data_FFD2_A[7] = 0;

            _data_FFD2_B[0] = Byte0_B;
            _data_FFD2_B[1] = 0;
            _data_FFD2_B[2] = 0;
            _data_FFD2_B[3] = 0;
            _data_FFD2_B[4] = 0;
            _data_FFD2_B[5] = 0;
            _data_FFD2_B[6] = 0;
            _data_FFD2_B[7] = 0;

            uC_FFD2_A.SetDataBytes(_data_FFD2_A);
            uC_FFD2_B.SetDataBytes(_data_FFD2_B);
        }
        void Setup_FFCC() { }

        //[A] 0xFFCC - PW - Linearized Azimuth Commands (0xFFCC)
        //       SendWord(A_TrackBar_LinearizedLin.Value, msg(0), msg(1))
        //       SendWord(A_TrackBar_LinearizedRot.Value, msg(2), msg(3))


        void set_BitAtIndexREF(ref byte _bval, int bitIndex, bool onOff)
        {
            if (bitIndex < 0 || bitIndex > 7)
                throw new ArgumentOutOfRangeException("bitIndex", "Bit index must be between 0 and 7.");

            if (onOff)
            {
                _bval |= (byte)(1 << bitIndex); // Set the bit to 1
            }
            else
            {
                _bval &= (byte)~(1 << bitIndex); // Set the bit to 0
            }
        }
        void set_BitAtIndex(out byte _bval, int bitIndex, bool onOff)
        {
            _bval = 0; // Initialize _bval
            if (bitIndex < 0 || bitIndex > 7)
                throw new ArgumentOutOfRangeException("bitIndex", "Bit index must be between 0 and 7.");

            if (onOff)
            {
                _bval |= (byte)(1 << bitIndex); // Set the bit to 1
            }
            else
            {
                _bval &= (byte)~(1 << bitIndex); // Set the bit to 0
            }

        }


        // [A] FFDO  PW - Control Unit - Command & Feedback #1
        //      D0          D1          D2          D3          D4          D5          D6          D7
        //      SteerComLW  SteerComHI  SteerFbkLW  SteerFbkHI  EnginComLW  EnginComHI  EnginFbkLW  EnginFbkHI         maxsteer3600 and maxengin1000


        // [A] 0xFFD1 - PW - Control Unit - Command & Feedback #2
        //      D0              D1          D2          D3          D4          D5          D6          D7
        //       b0 cltchcmd     b0 cltchfbk
        //       b1 cltchcmd     b1 cltchfbk
        //       b2 cltchcmd     b2 cltchfbk


        //  [A] 0xFFD2 - PW - Control Unit Fault & Status (0xFFD2)
        //      D0              D1          D2          D3          D4          D5          D6          D7
        //                       b0          b0          b0
        //                       b1          b1          b1
        //                       b2          b2          b2
        //                       b3          b3          b3
        //                       b4          b4          b4
        //                       b5          b5          b5
        //                       b6          b6          b6
        //                       b7          b7          b7


        // [A] 0xFFD3 - PW  - Control Unit Sw Version (0xFFD3)
        //      D0              D1            D2            D3              D4              D5          D6          D7
        //      A_CU_MajorLW    A_CU_MajorHI  A_CU_MinorLW  A_CU_MinorHI    A_CU_RevLW    A_CU_RevHI


        // [A] 0xFFCA - PW  - Azimuth Sw Version (0xFFCA)
        //      D0              D1            D2          D3          D4          D5          D6          D7
        //      A_AZM_MajorLW   A_AZM_MajorHI  A_AZM_MinorLW  A_AZM_MinorHI  A_AZM_RevLW    A_AZM_RevHI


        // [A] 0xFFCB - PW - Raw Azimuth Commands (0xFFCB)
        //      D0              D1            D2          D3          D4          D5          D6          D7



        // [A] 0xFF40 - PW - Clutch Panel Faults and Versions (0xFF40)

        //      SendWord(A_Clutch_MajorSWVersion_TextBox.Text, msg(0), msg(1))
        //       SendWord(A_Clutch_MinorSWVersion_TextBox.Text, msg(2), msg(3))
        //       SendWord(A_Clutch_SWRevision_TextBox.Text, msg(4), msg(5))
        //       If(A_CheckBox_Clutch_Fault1.Checked = True) Then SETBIT(msg(6), 0)
        //       If(A_CheckBox_Clutch_Fault2.Checked = True) Then SETBIT(msg(6), 1)
        //       If(A_CheckBox_Clutch_Fault3.Checked = True) Then SETBIT(msg(6), 2)
        //       If(A_CheckBox_Clutch_Fault4.Checked = True) Then SETBIT(msg(6), 3)
        //       If(A_CheckBox_Clutch_Fault5.Checked = True) Then SETBIT(msg(6), 4)
        //       If(A_CheckBox_Clutch_Fault6.Checked = True) Then SETBIT(msg(6), 5)
        //       If(A_CheckBox_Clutch_Fault7.Checked = True) Then SETBIT(msg(6), 6)
        //       If(A_CheckBox_Clutch_Fault8.Checked = True) Then SETBIT(msg(6), 7)

    }
}

