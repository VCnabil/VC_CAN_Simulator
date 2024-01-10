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

namespace VC_CAN_Simulator.UIz.Formz.SingleForm
{
    public partial class MKV_GUI : Form
    {
        List<CheckBox> all_faults_boxes;
        List<CheckBox> all_Propper_boxes;
        private int decimalVal_D0_A;
        private int decimalVal_D1_A;
        private int decimalVal_D2_A;
        private int decimalVal_D3_A;
        private int decimalVal_D4_A;
        private int decimalVal_D0_B;
        private int decimalVal_D1_B;
        private int decimalVal_D2_B;
        private int decimalVal_D3_B;
        private int decimalVal_D4_B;

        private int PortSpeedVar;
        private int StbdSpeedVar;

        private int PortBucketVar;
        private int StbdBucketVar;

        private int PortNozVar;
        private int StbdNozVar;


        // Local boolean variables to track power states
        //  private bool isUnitAPowered = false;
        //   private bool isUnitBPowered = false;
        private bool _KILL_A = false;
        private bool _KILL_B = false;


        private int decimalhpu_A_D0;
        private int decimalhpu_A_D2;
        private int decimalhpu_A_D3;
        private int decimalhpu_B_D0;
        private int decimalhpu_B_D2;
        private int decimalhpu_B_D3;


        private int decimal_MTU_A_D0;
        private int decimal_MTU_B_D0;

        private bool increasing_PS = true;
        private bool increasing_SS = true;

        private bool increasing_PB = true;
        private bool increasing_SB = true;

        private bool increasing_PN = true;
        private bool increasing_SN = true;

        bool runAutoThrottles = false;
        int throttle_autoValue = 0;
        private enum StationInControl
        {
            OpenBridge,
            MainBridge,
            Unknown
        }

        private enum UnitInControl
        {
            UnitA,
            UnitB,
            Unknown
        }
        // Private fields to hold the selected values
        private StationInControl _selectedStationInControl;
        private UnitInControl _selectedUnitInControl;
        CanManager canManager;
        private byte[] data;
        int _png = 0x18FFBB00;

        int _png_SoftwareVersions_CU_A_FF90 = 0x18FF9000;
        int _png_SoftwareVersions_CU_B_FF90 = 0x18FF9001;
        byte[] _byteArray_SoftwareVersions;

        int _png_SoftwareVersions_AM_A_FFA0 = 0x18FFA001;
        int _png_SoftwareVersions_AM_B_FFA0 = 0x18FFA002;
        byte[] _byteArra_AM_softVersion;

        int _png_SoftwareVersions_CIM_FFAA = 0x18FFAA00;
        byte[] _byteArra_CIM_softVersion;

        int _png_FF8C_cuINctrl_StaInctrl_throttle_00 = 0x18FF8C00;
        int _png_FF8C_cuINctrl_StaInctrl_throttle_01 = 0x18FF8C01;
        byte[] _bar_FF8C_cuINctrl_StaInctrl_throttle_00;
        byte[] _bar_FF8C_cuINctrl_StaInctrl_throttle_01;

        int _png_FF8D_faults_00 = 0x18FF8D00;
        int _png_FF8D_faults_01 = 0x18FF8D01;
        byte[] _bar_FF8D_Faults_00;
        byte[] _bar_FF8D_Faults_01;

        int _png_FEFC_FB_nozBuk_00 = 0x18FEFC00;
        int _png_FEFC_FB_nozBuk_01 = 0x18FEFC01;
        byte[] _bar_FEFC_FB_nozBuk_00;
        byte[] _bar_FEFC_FB_nozBuk_01;

        int _png_FFA1_FB_hpualams_01 = 0x18FFA101;
        int _png_FFA1_FB_hpualams_02 = 0x18FFA102;
        byte[] _bar_FFA1_FB_hpualams_01;
        byte[] _bar_FFA1_FB_hpualams_02;


        int _png_FFA2_MTU_01 = 0x18FFA201;
        int _png_FFA2_MTU_02 = 0x18FFA202;
        byte[] _bar_FFA2_MTU_01;
        byte[] _bar_FFA2_MTU_02;
        public MKV_GUI()
        {
            InitializeComponent();
            slider_port_Speed.Value = 50;
            slider_stbd_Speed.Value = 50;
            slider_port_Noz.Value = 125;
            slider_stbd_Noz.Value = 125;
            slider_port_Bucket.Value = 125;
            slider_stbd_Bucket.Value = 125;

            // Update labels with initial value
            lbl_port_Speed.Text = "50";
            lbl_stbd_Speed.Text = "50";
            lbl_port_Noz.Text = "125";
            lbl_stbd_Noz.Text = "125";
            lbl_port_bucket.Text = "125";
            lbl_stbd_bucket.Text = "125";
            lbl_ffa2_A.Text = "0";
            lbl_ffa2_B.Text = "0";

            timer100.Interval = 100;
            timer100.Tick += Timer100_Tick;

            timer60.Interval = 60;
            timer60.Tick += Timer60_Tick;

            timerauto0.Interval = 50;
            timerauto0.Tick += TimerAuto0_Tick;


            timerauto1.Interval = 12;
            timerauto1.Tick += TimerAuto1_Tick;

            timerread.Interval = 100;
            timerread.Tick += TimerREAD_Tick;

            _byteArray_SoftwareVersions = new byte[8] { 0x64, 0x03, 0x00, 0x01, 0x00, 0, 0, 0 };
            _byteArra_AM_softVersion = new byte[8] { 0x02, 0x01, 0x39, 0x05, 0x09, 0x00, 0, 0 };
            _byteArra_CIM_softVersion = new byte[8] { 250, 0, 50, 0x64, 0x39, 0x05, 0x2D, 0x00 };
            _bar_FF8C_cuINctrl_StaInctrl_throttle_00 = new byte[8];
            _bar_FF8C_cuINctrl_StaInctrl_throttle_01 = new byte[8];
            _bar_FEFC_FB_nozBuk_00 = new byte[8];
            _bar_FEFC_FB_nozBuk_01 = new byte[8];

            _bar_FF8D_Faults_00 = new byte[8];
            _bar_FF8D_Faults_01 = new byte[8];

            _bar_FFA1_FB_hpualams_01 = new byte[8];
            _bar_FFA1_FB_hpualams_02 = new byte[8];

            _bar_FFA2_MTU_01 = new byte[8];
            _bar_FFA2_MTU_02 = new byte[8];

            canManager = new CanManager();
            canManager.ListChannels();
            canManager.OpenChannel(0);
            canManager.SetBusParams();
            canManager.GoOnBus();



            btnToggleTimer.Click += BtnToggleTimer_Click;

            // Subscribe to Button Click events
            btn_controlUnitA_powered.Click += Btn_controlUnitA_powered_Click;
            btn_controlUnitB_powered.Click += Btn_controlUnitB_powered_Click;


            // Assign event handlers
            slider_port_Speed.ValueChanged += Slider_port_Speed_ValueChanged;
            slider_stbd_Speed.ValueChanged += Slider_stbd_Speed_ValueChanged;
            slider_port_Noz.ValueChanged += Slider_port_Noz_ValueChanged;
            slider_stbd_Noz.ValueChanged += Slider_stbd_Noz_ValueChanged;
            slider_port_Bucket.ValueChanged += Slider_port_Bucket_ValueChanged;
            slider_stbd_Bucket.ValueChanged += Slider_stbd_Bucket_ValueChanged;

            rb_Sta_Main.Checked = true;
            _selectedStationInControl = StationInControl.MainBridge;

            rb_cu_A.Checked = true;
            _selectedUnitInControl = UnitInControl.UnitA;

            Update_STA_LabelWithCurrentState();
            Update_CU_LabelWithCurrentState();

            // Assign event handlers
            rb_Sta_Main.CheckedChanged += OnRB_STA_CheckedChanged;
            rb_Sta_Open.CheckedChanged += OnRB_STA_CheckedChanged;
            rb_sta_unknown.CheckedChanged += OnRB_STA_CheckedChanged;


            rb_cu_A.CheckedChanged += OnRB_CU_CheckedChanged;
            rb_cu_B.CheckedChanged += OnRB_CU_CheckedChanged;
            rb_cu_unknown.CheckedChanged += OnRB_CU_CheckedChanged;

            data = new byte[8];


            lbl_D0_A.Text = decimalVal_D0_A.ToString();
            lbl_D0_B.Text = decimalVal_D0_B.ToString();
            lbl_D1_A.Text = decimalVal_D1_A.ToString();
            lbl_D1_B.Text = decimalVal_D1_B.ToString();
            lbl_D2_A.Text = decimalVal_D2_A.ToString();
            lbl_D2_B.Text = decimalVal_D2_B.ToString();
            lbl_D3_A.Text = decimalVal_D3_A.ToString();
            lbl_D3_B.Text = decimalVal_D3_B.ToString();
            lbl_D4_A.Text = decimalVal_D4_A.ToString();
            lbl_D4_B.Text = decimalVal_D4_B.ToString();
            cbA_D0_0.CheckedChanged += Checkbox_D0_A_CheckedChanged;
            cbA_D0_1.CheckedChanged += Checkbox_D0_A_CheckedChanged;
            cbB_D0_0.CheckedChanged += Checkbox_D0_B_CheckedChanged;
            cbB_D0_1.CheckedChanged += Checkbox_D0_B_CheckedChanged;
            cbA_D1_0.CheckedChanged += Checkbox_D1_A_CheckedChanged;
            cbA_D1_1.CheckedChanged += Checkbox_D1_A_CheckedChanged;
            cbA_D1_2.CheckedChanged += Checkbox_D1_A_CheckedChanged;
            cbB_D1_0.CheckedChanged += Checkbox_D1_B_CheckedChanged;
            cbB_D1_1.CheckedChanged += Checkbox_D1_B_CheckedChanged;
            cbB_D1_2.CheckedChanged += Checkbox_D1_B_CheckedChanged;
            cbA_D2_0.CheckedChanged += Checkbox_D2_A_CheckedChanged;
            cbA_D2_1.CheckedChanged += Checkbox_D2_A_CheckedChanged;
            cbA_D2_2.CheckedChanged += Checkbox_D2_A_CheckedChanged;
            cbB_D2_0.CheckedChanged += Checkbox_D2_B_CheckedChanged;
            cbB_D2_1.CheckedChanged += Checkbox_D2_B_CheckedChanged;
            cbB_D2_2.CheckedChanged += Checkbox_D2_B_CheckedChanged;
            cbA_D3_0.CheckedChanged += Checkbox_D3_A_CheckedChanged;
            cbA_D3_1.CheckedChanged += Checkbox_D3_A_CheckedChanged;
            cbA_D3_2.CheckedChanged += Checkbox_D3_A_CheckedChanged;
            cbA_D3_3.CheckedChanged += Checkbox_D3_A_CheckedChanged;
            cbB_D3_0.CheckedChanged += Checkbox_D3_B_CheckedChanged;
            cbB_D3_1.CheckedChanged += Checkbox_D3_B_CheckedChanged;
            cbB_D3_2.CheckedChanged += Checkbox_D3_B_CheckedChanged;
            cbB_D3_3.CheckedChanged += Checkbox_D3_B_CheckedChanged;
            cbA_D4_0.CheckedChanged += Checkbox_D4_A_CheckedChanged;
            cbA_D4_1.CheckedChanged += Checkbox_D4_A_CheckedChanged;
            cbA_D4_2.CheckedChanged += Checkbox_D4_A_CheckedChanged;
            cbA_D4_3.CheckedChanged += Checkbox_D4_A_CheckedChanged;
            cbB_D4_0.CheckedChanged += Checkbox_D4_B_CheckedChanged;
            cbB_D4_1.CheckedChanged += Checkbox_D4_B_CheckedChanged;
            cbB_D4_2.CheckedChanged += Checkbox_D4_B_CheckedChanged;
            cbB_D4_3.CheckedChanged += Checkbox_D4_B_CheckedChanged;

            cbhpuA_D0_0.CheckedChanged += OncHPUbox_D0_A_CheckedChanged;
            cbhpuA_D0_1.CheckedChanged += OncHPUbox_D0_A_CheckedChanged;
            cbhpuA_D0_2.CheckedChanged += OncHPUbox_D0_A_CheckedChanged;
            cbhpuA_D0_3.CheckedChanged += OncHPUbox_D0_A_CheckedChanged;
            cbhpuA_D2_0.CheckedChanged += OncHPUbox_D2_A_CheckedChanged;
            cbhpuA_D2_1.CheckedChanged += OncHPUbox_D2_A_CheckedChanged;
            cbhpuA_D2_2.CheckedChanged += OncHPUbox_D2_A_CheckedChanged;
            cbhpuA_D2_3.CheckedChanged += OncHPUbox_D2_A_CheckedChanged;
            cbhpuA_D3_0.CheckedChanged += OncHPUbox_D3_A_CheckedChanged;
            cbhpuA_D3_1.CheckedChanged += OncHPUbox_D3_A_CheckedChanged;


            cbhpuB_D0_0.CheckedChanged += OncHPUbox_D0_B_CheckedChanged;
            cbhpuB_D0_1.CheckedChanged += OncHPUbox_D0_B_CheckedChanged;
            cbhpuB_D0_2.CheckedChanged += OncHPUbox_D0_B_CheckedChanged;
            cbhpuB_D0_3.CheckedChanged += OncHPUbox_D0_B_CheckedChanged;
            cbhpuB_D2_0.CheckedChanged += OncHPUbox_D2_B_CheckedChanged;
            cbhpuB_D2_1.CheckedChanged += OncHPUbox_D2_B_CheckedChanged;
            cbhpuB_D2_2.CheckedChanged += OncHPUbox_D2_B_CheckedChanged;
            cbhpuB_D2_3.CheckedChanged += OncHPUbox_D2_B_CheckedChanged;
            cbhpuB_D3_0.CheckedChanged += OncHPUbox_D3_B_CheckedChanged;
            cbhpuB_D3_1.CheckedChanged += OncHPUbox_D3_B_CheckedChanged;

            cbMTU_A_D0_0.CheckedChanged += Onc_MTU_box_D0_A_CheckedChanged;
            cbMTU_A_D0_1.CheckedChanged += Onc_MTU_box_D0_A_CheckedChanged;
            cbMTU_A_D0_2.CheckedChanged += Onc_MTU_box_D0_A_CheckedChanged;
            cbMTU_B_D0_0.CheckedChanged += Onc_MTU_box_D0_B_CheckedChanged;
            cbMTU_B_D0_1.CheckedChanged += Onc_MTU_box_D0_B_CheckedChanged;
            cbMTU_B_D0_2.CheckedChanged += Onc_MTU_box_D0_B_CheckedChanged;

            all_faults_boxes = new List<CheckBox>
                            {
                                cbA_D0_0, cbA_D0_1, cbB_D0_0, cbB_D0_1,
                                cbA_D1_0, cbA_D1_1, cbA_D1_2, cbB_D1_0, cbB_D1_1, cbB_D1_2,
                                cbA_D2_0, cbA_D2_1, cbA_D2_2, cbB_D2_0, cbB_D2_1, cbB_D2_2,
                                cbA_D3_0, cbA_D3_1, cbA_D3_2, cbA_D3_3, cbB_D3_0, cbB_D3_1, cbB_D3_2, cbB_D3_3,
                                cbA_D4_0, cbA_D4_1, cbA_D4_2, cbA_D4_3, cbB_D4_0, cbB_D4_1, cbB_D4_2, cbB_D4_3,
                                /*
                                cbhpuA_D0_0, cbhpuA_D0_1, cbhpuA_D0_2, cbhpuA_D0_3, cbhpuA_D2_0, cbhpuA_D2_1, cbhpuA_D2_2, cbhpuA_D2_3,
                                cbhpuA_D3_0, cbhpuA_D3_1, cbhpuB_D0_0, cbhpuB_D0_1, cbhpuB_D0_2, cbhpuB_D0_3,
                                cbhpuB_D2_0, cbhpuB_D2_1, cbhpuB_D2_2, cbhpuB_D2_3, cbhpuB_D3_0, cbhpuB_D3_1,*/

                            };
            all_Propper_boxes = new List<CheckBox>
                            {
                               cbMTU_A_D0_0,cbMTU_B_D0_0,cbMTU_A_D0_1,cbMTU_B_D0_1,cbhpuA_D2_2,cbhpuB_D2_2,cbMTU_A_D0_2, cbMTU_B_D0_2
                            };

            cbALL.CheckedChanged += OncbAllCheckedChanged;
            cbALLMTUs.CheckedChanged += OncbAllPropperCheckedChanged;
            cbALLMTUs.Checked = true;


            cb_auto0.CheckedChanged += Oncb_auto0_CheckedChanged;

            cbRandSlider.CheckedChanged += Oncb_Rand_CheckedChanged;

            timerread.Start();
        }

        int x = 0;
        private void TimerREAD_Tick(object sender, EventArgs e)
        {
            x++;
            if (x > 65534) x = 0;
            int rez12data0 = 0;
            int rez12data1 = 0;
            int rez12data2 = 0;
            int rez12data3 = 0;
            byte[] ddaa = canManager.RGetdatas();
            // label1.Text = ddaa[0].ToString() + " " + ddaa[1].ToString() + " " +ddaa[2].ToString() + " "+ ddaa[3].ToString() +" " ;
            //int rez12 = (((int)(ddaa[1] & 0x3F) << 8) | ddaa[0]) >> 2;

            lblD0.Text = ddaa[0].ToString();
            lblD1.Text = ddaa[1].ToString();
            lblD2.Text = ddaa[2].ToString();
            lblD3.Text = ddaa[3].ToString();
            lblD4.Text = ddaa[4].ToString();
            lblD5.Text = ddaa[5].ToString();
            lblD6.Text = ddaa[6].ToString();
            lblD7.Text = ddaa[7].ToString();

            rez12data0 = (((int)(ddaa[1] & 0x3F) << 8) | ddaa[0]) >> 2;
            lblData0.Text = rez12data0.ToString();

            rez12data1 = (((int)(ddaa[3] & 0x3F) << 8) | ddaa[2]) >> 2;
            lblData1.Text = rez12data1.ToString();

            rez12data2 = (((int)(ddaa[5] & 0x3F) << 8) | ddaa[4]) >> 2;
            lblData2.Text = rez12data2.ToString();

            rez12data3 = (((int)(ddaa[7] & 0x3F) << 8) | ddaa[6]) >> 2;
            lblData3.Text = rez12data3.ToString();

            label_002.Text = canManager.getid();
        }
        private void Oncb_Rand_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRandSlider.Checked == true)
            {
                Random random = new Random();
                int randomValue_port_Speed = random.Next((int)slider_port_Speed.Minimum, (int)slider_port_Speed.Maximum + 1);
                int randomValue_Stbd_Speed = random.Next((int)slider_stbd_Speed.Minimum, (int)slider_stbd_Speed.Maximum + 1);
                int randomValue_port_Buk = random.Next((int)slider_port_Bucket.Minimum, (int)slider_port_Bucket.Maximum + 1);
                int randomValue_Stbd_Buk = random.Next((int)slider_stbd_Bucket.Minimum, (int)slider_stbd_Bucket.Maximum + 1);
                int randomValue_port_Noz = random.Next((int)slider_port_Noz.Minimum, (int)slider_port_Noz.Maximum + 1);
                int randomValue_Stbd_Noz = random.Next((int)slider_stbd_Noz.Minimum, (int)slider_stbd_Noz.Maximum + 1);
                // Set the slider's value to the random number
                slider_port_Speed.Value = randomValue_port_Speed;
                slider_stbd_Speed.Value = randomValue_Stbd_Speed;
                slider_port_Bucket.Value = randomValue_port_Buk;
                slider_stbd_Bucket.Value = randomValue_Stbd_Buk;
                slider_port_Noz.Value = randomValue_port_Noz;
                slider_stbd_Noz.Value = randomValue_Stbd_Noz;
                lbl_port_Speed.Text = randomValue_port_Speed.ToString();
                lbl_stbd_Speed.Text = randomValue_Stbd_Speed.ToString();
                lbl_port_bucket.Text = randomValue_port_Buk.ToString();
                lbl_stbd_bucket.Text = randomValue_Stbd_Buk.ToString();
                lbl_port_Noz.Text = randomValue_port_Noz.ToString();
                lbl_stbd_Noz.Text = randomValue_Stbd_Noz.ToString();
            }
            else
            {
                slider_port_Speed.Value = 50;
                slider_stbd_Speed.Value = 50;
                slider_port_Noz.Value = 125;
                slider_stbd_Noz.Value = 125;
                slider_port_Bucket.Value = 125;
                slider_stbd_Bucket.Value = 125;
                // Update labels with initial value
                lbl_port_Speed.Text = "50";
                lbl_stbd_Speed.Text = "50";
                lbl_port_Noz.Text = "125";
                lbl_stbd_Noz.Text = "125";
                lbl_port_bucket.Text = "125";
                lbl_stbd_bucket.Text = "125";
            }
        }
        private void Oncb_auto0_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_auto0.Checked == true)
            {
                timerauto0.Start();
                timerauto1.Start();
                slider_port_Speed.Enabled = false;  // Disable manual control
                slider_stbd_Speed.Enabled = false;
                slider_port_Bucket.Enabled = false;
                slider_stbd_Bucket.Enabled = false;
                slider_port_Noz.Enabled = false;
                slider_stbd_Noz.Enabled = false;
            }
            else
            {
                timerauto0.Stop();
                timerauto1.Stop();
                slider_port_Speed.Enabled = true;   // Enable manual control
                slider_stbd_Speed.Enabled = true;
                slider_port_Bucket.Enabled = true;
                slider_stbd_Bucket.Enabled = true;
                slider_port_Noz.Enabled = true;
                slider_stbd_Noz.Enabled = true;
            }
        }
        //timer for auto throttle

        private void TimerAuto1_Tick(object sender, EventArgs e)
        {

            if (increasing_PB)
            {
                if (slider_port_Bucket.Value < slider_port_Bucket.Maximum)
                {
                    slider_port_Bucket.Value++;
                }
                else
                {
                    increasing_PB = false;
                }
            }
            else
            {
                if (slider_port_Bucket.Value > slider_port_Bucket.Minimum)
                {
                    slider_port_Bucket.Value--;
                }
                else
                {
                    increasing_PB = true;
                }
            }
            if (increasing_SB)
            {
                if (slider_stbd_Bucket.Value < slider_stbd_Bucket.Maximum)
                {
                    slider_stbd_Bucket.Value++;
                }
                else
                {
                    increasing_SB = false;
                }
            }
            else
            {
                if (slider_stbd_Bucket.Value > slider_stbd_Bucket.Minimum)
                {
                    slider_stbd_Bucket.Value--;
                }
                else
                {
                    increasing_SB = true;
                }
            }
            if (increasing_PN)
            {
                if (slider_port_Noz.Value < slider_port_Noz.Maximum)
                {
                    slider_port_Noz.Value++;
                }
                else
                {
                    increasing_PN = false;
                }
            }
            else
            {
                if (slider_port_Noz.Value > slider_port_Noz.Minimum)
                {
                    slider_port_Noz.Value--;
                }
                else
                {
                    increasing_PN = true;
                }
            }
            if (increasing_SN)
            {
                if (slider_stbd_Noz.Value < slider_stbd_Noz.Maximum)
                {
                    slider_stbd_Noz.Value++;
                }
                else
                {
                    increasing_SN = false;
                }
            }
            else
            {
                if (slider_stbd_Noz.Value > slider_stbd_Noz.Minimum)
                {
                    slider_stbd_Noz.Value--;
                }
                else
                {
                    increasing_SN = true;
                }
            }
        }

        private void TimerAuto0_Tick(object sender, EventArgs e)
        {
            if (increasing_PS)
            {
                if (slider_port_Speed.Value < slider_port_Speed.Maximum)
                {
                    slider_port_Speed.Value++;
                }
                else
                {
                    increasing_PS = false;
                }
            }
            else
            {
                if (slider_port_Speed.Value > slider_port_Speed.Minimum)
                {
                    slider_port_Speed.Value--;
                }
                else
                {
                    increasing_PS = true;
                }
            }
            if (increasing_SS)
            {
                if (slider_stbd_Speed.Value < slider_stbd_Speed.Maximum)
                {
                    slider_stbd_Speed.Value++;
                }
                else
                {
                    increasing_SS = false;
                }
            }
            else
            {
                if (slider_stbd_Speed.Value > slider_stbd_Speed.Minimum)
                {
                    slider_stbd_Speed.Value--;
                }
                else
                {
                    increasing_SS = true;
                }
            }

        }



        private void Timer60_Tick(object sender, EventArgs e)
        {
            Update_FF8C_throt_incontrol();
            sendData_FF8C_throt_incontrol();


            Update_FF8D_faults();
            SendData_FF8D_faults();

            Update_FEFC_FB_nozBuk();
            SendData_FEFC_FB_NozBuk();

            Update_FFA1_hpualarm();
            SendFFA1_HPUalarm();

            Update_FFA2_MTU();
            SendFFA2_MTU();

        }


        private void OncbAllCheckedChanged(object sender, EventArgs e)
        {
            foreach (var checkbox in all_faults_boxes)
            {
                checkbox.Checked = cbALL.Checked;
            }
        }
        private void OncbAllPropperCheckedChanged(object sender, EventArgs e)
        {
            foreach (var checkbox in all_Propper_boxes)
            {
                checkbox.Checked = cbALLMTUs.Checked;
            }
        }


        private void Onc_MTU_box_D0_A_CheckedChanged(object sender, EventArgs e)
        {
            decimal_MTU_A_D0 = 0;
            if (cbMTU_A_D0_0.Checked) decimal_MTU_A_D0 |= 1 << 0;
            if (cbMTU_A_D0_1.Checked) decimal_MTU_A_D0 |= 1 << 1;
            if (cbMTU_A_D0_2.Checked) decimal_MTU_A_D0 |= 1 << 2;
            lbl_ffa2_A.Text = decimal_MTU_A_D0.ToString();
        }
        private void Onc_MTU_box_D0_B_CheckedChanged(object sender, EventArgs e)
        {
            decimal_MTU_B_D0 = 0;
            if (cbMTU_B_D0_0.Checked) decimal_MTU_B_D0 |= 1 << 0;
            if (cbMTU_B_D0_1.Checked) decimal_MTU_B_D0 |= 1 << 1;
            if (cbMTU_B_D0_2.Checked) decimal_MTU_B_D0 |= 1 << 2;

            lbl_ffa2_B.Text = decimal_MTU_B_D0.ToString();
        }
        private void OncHPUbox_D0_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalhpu_A_D0 = 0;
            if (cbhpuA_D0_3.Checked) decimalhpu_A_D0 |= 1 << 0;
            if (cbhpuA_D0_2.Checked) decimalhpu_A_D0 |= 1 << 1;
            if (cbhpuA_D0_1.Checked) decimalhpu_A_D0 |= 1 << 2;
            if (cbhpuA_D0_0.Checked) decimalhpu_A_D0 |= 1 << 3;

        }

        private void OncHPUbox_D2_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalhpu_A_D2 = 0;
            if (cbhpuA_D2_0.Checked) decimalhpu_A_D2 |= 1 << 0;
            if (cbhpuA_D2_1.Checked) decimalhpu_A_D2 |= 1 << 1;
            if (cbhpuA_D2_2.Checked) decimalhpu_A_D2 |= 1 << 2;
            if (cbhpuA_D2_3.Checked) decimalhpu_A_D2 |= 1 << 3;
        }

        private void OncHPUbox_D3_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalhpu_A_D3 = 0;
            if (cbhpuA_D3_0.Checked) decimalhpu_A_D3 |= 1 << 0;
            if (cbhpuA_D3_1.Checked) decimalhpu_A_D3 |= 1 << 1;

        }
        private void OncHPUbox_D0_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalhpu_B_D0 = 0;
            if (cbhpuB_D0_3.Checked) decimalhpu_B_D0 |= 1 << 0;
            if (cbhpuB_D0_2.Checked) decimalhpu_B_D0 |= 1 << 1;
            if (cbhpuB_D0_1.Checked) decimalhpu_B_D0 |= 1 << 2;
            if (cbhpuB_D0_0.Checked) decimalhpu_B_D0 |= 1 << 3;
        }

        private void OncHPUbox_D2_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalhpu_B_D2 = 0;
            if (cbhpuB_D2_0.Checked) decimalhpu_B_D2 |= 1 << 0;
            if (cbhpuB_D2_1.Checked) decimalhpu_B_D2 |= 1 << 1;
            if (cbhpuB_D2_2.Checked) decimalhpu_B_D2 |= 1 << 2;
            if (cbhpuB_D2_3.Checked) decimalhpu_B_D2 |= 1 << 3;
        }

        private void OncHPUbox_D3_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalhpu_B_D3 = 0;
            if (cbhpuB_D3_0.Checked) decimalhpu_B_D3 |= 1 << 0;
            if (cbhpuB_D3_1.Checked) decimalhpu_B_D3 |= 1 << 1;

        }



        #region Checkboxes Fails FF8D
        private void Checkbox_D0_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D0_A = 0;
            if (cbA_D0_0.Checked) decimalVal_D0_A |= 1 << 0;
            if (cbA_D0_1.Checked) decimalVal_D0_A |= 1 << 3;
            lbl_D0_A.Text = decimalVal_D0_A.ToString();
        }
        private void Checkbox_D0_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D0_B = 0;
            if (cbB_D0_0.Checked) decimalVal_D0_B |= 1 << 0;
            if (cbB_D0_1.Checked) decimalVal_D0_B |= 1 << 3;
            lbl_D0_B.Text = decimalVal_D0_B.ToString();
        }

        private void Checkbox_D1_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D1_A = 0;
            if (cbA_D1_0.Checked) decimalVal_D1_A |= 1 << 0;
            if (cbA_D1_1.Checked) decimalVal_D1_A |= 1 << 1;
            if (cbA_D1_2.Checked) decimalVal_D1_A |= 1 << 2;
            lbl_D1_A.Text = decimalVal_D1_A.ToString();
        }
        private void Checkbox_D1_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D1_B = 0;
            if (cbB_D1_0.Checked) decimalVal_D1_B |= 1 << 0;
            if (cbB_D1_1.Checked) decimalVal_D1_B |= 1 << 1;
            if (cbB_D1_2.Checked) decimalVal_D1_B |= 1 << 2;
            lbl_D1_B.Text = decimalVal_D1_B.ToString();
        }
        private void Checkbox_D2_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D2_A = 0;
            if (cbA_D2_0.Checked) decimalVal_D2_A |= 1 << 0;
            if (cbA_D2_1.Checked) decimalVal_D2_A |= 1 << 1;
            if (cbA_D2_2.Checked) decimalVal_D2_A |= 1 << 2;
            lbl_D2_A.Text = decimalVal_D2_A.ToString();
        }
        private void Checkbox_D2_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D2_B = 0;
            if (cbB_D2_0.Checked) decimalVal_D2_B |= 1 << 0;
            if (cbB_D2_1.Checked) decimalVal_D2_B |= 1 << 1;
            if (cbB_D2_2.Checked) decimalVal_D2_B |= 1 << 2;
            lbl_D2_B.Text = decimalVal_D2_B.ToString();
        }


        private void Checkbox_D3_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D3_A = 0;
            if (cbA_D3_0.Checked) decimalVal_D3_A |= 1 << 0;
            if (cbA_D3_1.Checked) decimalVal_D3_A |= 1 << 1;
            if (cbA_D3_2.Checked) decimalVal_D3_A |= 1 << 2;
            if (cbA_D3_3.Checked) decimalVal_D3_A |= 1 << 3;
            lbl_D3_A.Text = decimalVal_D3_A.ToString();
        }
        private void Checkbox_D3_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D3_B = 0;
            if (cbB_D3_0.Checked) decimalVal_D3_B |= 1 << 0;
            if (cbB_D3_1.Checked) decimalVal_D3_B |= 1 << 1;
            if (cbB_D3_2.Checked) decimalVal_D3_B |= 1 << 2;
            if (cbB_D3_3.Checked) decimalVal_D3_B |= 1 << 3;
            lbl_D3_B.Text = decimalVal_D3_B.ToString();
        }


        private void Checkbox_D4_A_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D4_A = 0;
            if (cbA_D4_0.Checked) decimalVal_D4_A |= 1 << 0;
            if (cbA_D4_1.Checked) decimalVal_D4_A |= 1 << 1;
            if (cbA_D4_2.Checked) decimalVal_D4_A |= 1 << 2;
            if (cbA_D4_3.Checked) decimalVal_D4_A |= 1 << 3;
            lbl_D4_A.Text = decimalVal_D4_A.ToString();
        }
        private void Checkbox_D4_B_CheckedChanged(object sender, EventArgs e)
        {
            decimalVal_D4_B = 0;
            if (cbB_D4_0.Checked) decimalVal_D4_B |= 1 << 0;
            if (cbB_D4_1.Checked) decimalVal_D4_B |= 1 << 1;
            if (cbB_D4_2.Checked) decimalVal_D4_B |= 1 << 2;
            if (cbB_D4_3.Checked) decimalVal_D4_B |= 1 << 3;
            lbl_D4_B.Text = decimalVal_D4_B.ToString();
        }
        #endregion

        #region sliders
        private void Slider_port_Speed_ValueChanged(object sender, EventArgs e)
        {
            PortSpeedVar = slider_port_Speed.Value;
            lbl_port_Speed.Text = PortSpeedVar.ToString();
        }

        private void Slider_stbd_Speed_ValueChanged(object sender, EventArgs e)
        {
            StbdSpeedVar = slider_stbd_Speed.Value;
            lbl_stbd_Speed.Text = StbdSpeedVar.ToString();
        }
        private void Slider_port_Noz_ValueChanged(object sender, EventArgs e)
        {
            PortNozVar = slider_port_Noz.Value;
            lbl_port_Noz.Text = PortNozVar.ToString();
        }

        private void Slider_stbd_Noz_ValueChanged(object sender, EventArgs e)
        {
            StbdNozVar = slider_stbd_Noz.Value;
            lbl_stbd_Noz.Text = StbdNozVar.ToString();
        }

        private void Slider_port_Bucket_ValueChanged(object sender, EventArgs e)
        {
            PortBucketVar = slider_port_Bucket.Value;
            lbl_port_bucket.Text = PortBucketVar.ToString();
        }

        private void Slider_stbd_Bucket_ValueChanged(object sender, EventArgs e)
        {
            StbdBucketVar = slider_stbd_Bucket.Value;
            lbl_stbd_bucket.Text = StbdBucketVar.ToString();
        }
        #endregion


        private void OnRB_STA_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Sta_Main.Checked)
            {
                _selectedStationInControl = StationInControl.MainBridge;
            }
            else if (rb_Sta_Open.Checked)
            {
                _selectedStationInControl = StationInControl.OpenBridge;
            }
            else if (rb_sta_unknown.Checked)
            {
                _selectedStationInControl = StationInControl.Unknown;
            }

            Update_STA_LabelWithCurrentState();
        }
        private void Update_STA_LabelWithCurrentState()
        {
            labelStationInControl.Text = _selectedStationInControl.ToString();
        }
        private void OnRB_CU_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cu_A.Checked)
            {
                _selectedUnitInControl = UnitInControl.UnitA;
            }
            else if (rb_cu_B.Checked)
            {
                _selectedUnitInControl = UnitInControl.UnitB;
            }
            else if (rb_cu_unknown.Checked)
            {
                _selectedUnitInControl = UnitInControl.Unknown;
            }

            Update_CU_LabelWithCurrentState();
        }
        private void Update_CU_LabelWithCurrentState()
        {
            labelUnitInControl.Text = _selectedUnitInControl.ToString();
        }

        private void BtnToggleTimer_Click(object sender, EventArgs e)
        {
            // Toggle the timer's state
            timer100.Enabled = !timer100.Enabled;
            timer60.Enabled = !timer60.Enabled;

            // Change button color based on timer state
            btnToggleTimer.BackColor = timer100.Enabled ? Color.Green : SystemColors.Control;
        }

        private void Timer100_Tick(object sender, EventArgs e)
        {
            sendData_sysinfo();
        }



        private void sendData_sysinfo()
        {
            canManager.SendMessage(_png_SoftwareVersions_CU_A_FF90, _byteArray_SoftwareVersions);
            canManager.SendMessage(_png_SoftwareVersions_CU_B_FF90, _byteArray_SoftwareVersions);
            canManager.SendMessage(_png_SoftwareVersions_AM_A_FFA0, _byteArra_AM_softVersion);
            canManager.SendMessage(_png_SoftwareVersions_AM_B_FFA0, _byteArra_AM_softVersion);
            canManager.SendMessage(_png_SoftwareVersions_CIM_FFAA, _byteArra_CIM_softVersion);
        }

        private void Btn_controlUnitA_powered_Click(object sender, EventArgs e)
        {
            _KILL_A = !_KILL_A;
            btn_controlUnitA_powered.BackColor = _KILL_A ? Color.Red : SystemColors.Control;
        }
        private void Btn_controlUnitB_powered_Click(object sender, EventArgs e)
        {
            _KILL_B = !_KILL_B;
            btn_controlUnitB_powered.BackColor = _KILL_B ? Color.Red : SystemColors.Control;
        }




        #region FF8D

        // //*****************************************************************************
        // 3.3 Control Unit A: System Faults (holding address = 400003 )            (Ref. 0xFF8D Byte 0)  
        // 0 Auto Calibration Fault
        // 1 reserved
        // 2 reserved
        // 3 A&M Unit Communication Failure
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D00 	D0 D1 D2 D3 D4 D5 D6 D7 
        // 						1                      			[A] Calibration
        // 						8                      			[A] Control Unit: Alarm & Monitoring Unit Comm.
        // 						10								[A] Clutch Enable Switches Disconnected
        // //*****************************************************************************
        // 3.8 Control Unit B: System Faults (holding address = 400008)             (Ref. 0xFF8D Byte 0)
        // 0 Auto Calibration Fault
        // 1 reserved
        // 2 reserved
        // 3 A&M Unit Communication Failure
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D01 	D0 D1 D2 D3 D4 D5 D6 D7 
        // 						1                      	[B] Calibration
        // 						8                      	[B] Control Unit: Alarm & Monitoring Unit Comm.
        // 						10						[B] Clutch Enable Switches Disconnected


        // //*****************************************************************************
        // 3.4 Control Unit A: Main Bridge Station Faults (holding address = 400004)(Ref. 0xFF8D Byte 1)
        // 0 Helm Fault
        // 1 PORT Control Lever Fault
        // 2 STBD Control Lever Fault
        // 3 reserved
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D00 	D0 D1 D2 D3 D4 D5 D6 D7 
        // 							1 						[A] Main Bridge: Helm Signal
        // 							8                      	[A] Main Bridge: Port Azimuth Lever Signal
        // 							10						[A] Main Bridge: Stbd Azimuth Lever Signal
        // //*****************************************************************************
        // 3.9 Control Unit B: Main Bridge Station Faults (holding address = 400009)(Ref. 0xFF8D Byte 1)
        // 0 Helm Fault
        // 1 PORT Control Lever Fault
        // 2 STBD Control Lever Fault
        // 3 reserved
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D01 	D0 D1 D2 D3 D4 D5 D6 D7 
        // 							1 						[B] Main Bridge: Helm Signal
        // 							8                      	[B] Main Bridge: Port Azimuth Lever Signal
        // 							10						[B] Main Bridge: Stbd Azimuth Lever Signal

        // //*****************************************************************************
        // 3.5 Control Unit A: Open Bridge Station Faults (holding address = 400005)(Ref. 0xFF8D Byte 2)
        // 0 Helm Fault
        // 1 PORT Control Lever Fault
        // 2 STBD Control Lever Fault
        // 3 reserved
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D00 	D0  D1 D2  D3   D4  D5  D6  D7 
        // 							    1 						[A]  Helm Fault
        // 							    8                      	[A]  PORT Control Lever Fault
        // 							    10						[A]  STBD Control Lever Fault
        // //*****************************************************************************
        // 3.10 Control Unit B: Open Bridge Station Faults (holding address = 400010)(Ref. 0xFF8D Byte 2)
        // 0 Helm Fault
        // 1 PORT Control Lever Fault
        // 2 STBD Control Lever Fault
        // 3 reserved
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D01 	D0  D1 D2  D3   D4  D5  D6  D7 
        // 							    1 						[B]  Helm Fault
        // 							    8                      	[B]  PORT Control Lever Fault
        // 							    10						[B]  STBD Control Lever Fault


        // //*****************************************************************************
        // 3.6 Control Unit A: Feedback Sensor Faults (holding address = 400006)(Ref. 0xFF8D Byte 3)
        // 0 PORT Nozzle Feedback Fault
        // 1 STBD Nozzle Feedback Fault
        // 2 PORT Bucket Feedback Fault
        // 3 STBD Bucket Feedback Fault
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D00 	D0  D1 D2  D3   D4  D5  D6  D7 
        // 							        1 					[A] PORT Nozzle Feedback Fault
        // 							        8                   [A] STBD Nozzle Feedback Fault
        // 							        10					[A] PORT Bucket Feedback Fault
        // 							        20					[A] STBD Bucket Feedback Fault
        // //*****************************************************************************
        // 3.11 Control Unit B: Feedback Sensor Faults (holding address = 400011)(Ref. 0xFF8D Byte 3)
        // 0 PORT Nozzle Feedback Fault
        // 1 STBD Nozzle Feedback Fault
        // 2 PORT Bucket Feedback Fault
        // 3 STBD Bucket Feedback Fault
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D01 	D0  D1 D2  D3   D4  D5  D6  D7 
        // 							        1 					[B] PORT Nozzle Feedback Fault
        // 							        8                   [B] STBD Nozzle Feedback Fault
        // 							        10					[B] PORT Bucket Feedback Fault
        // 							        20					[B] STBD Bucket Feedback Fault

        // //*****************************************************************************
        // 3.7 Control Unit A: Non-Follow-Up Faults (holding address = 400007)(Ref. 0xFF8D Byte 4)
        // 0 PORT Nozzle Non-Follow-Up
        // 1 STBD Nozzle Non-Follow-Up
        // 2 PORT Bucket Non-Follow-Up
        // 3 STBD Bucket Non-Follow-Up
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D00 	D0  D1 D2  D3   D4  D5  D6  D7 
        // 							            1 				[A] PORT Nozzle Non-Follow-Up
        // 							            8               [A] STBD Nozzle Non-Follow-Up
        // 							            10			    [A] PORT Bucket Non-Follow-Up
        // 							            20				[A] STBD Bucket Non-Follow-Up
        // //*****************************************************************************
        // 3.12 Control Unit B: Non-Follow-Up Faults (holding address = 400012)(Ref. 0xFF8D Byte 4)
        // 0 PORT Nozzle Non-Follow-Up
        // 1 STBD Nozzle Non-Follow-Up
        // 2 PORT Bucket Non-Follow-Up
        // 3 STBD Bucket Non-Follow-Up
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // sending 18FF8D01 	D0  D1 D2  D3   D4  D5  D6  D7 
        // 							            1 				[B] PORT Nozzle Non-Follow-Up
        // 							            8               [B] STBD Nozzle Non-Follow-Up
        // 							            10			    [B] PORT Bucket Non-Follow-Up
        // 							            20				[B] STBD Bucket Non-Follow-Up

        void Update_FF8D_faults()
        {

            _bar_FF8D_Faults_00[0] = (byte)decimalVal_D0_A;
            _bar_FF8D_Faults_01[0] = (byte)decimalVal_D0_B;
            _bar_FF8D_Faults_00[1] = (byte)decimalVal_D1_A;
            _bar_FF8D_Faults_01[1] = (byte)decimalVal_D1_B;
            _bar_FF8D_Faults_00[2] = (byte)decimalVal_D2_A;
            _bar_FF8D_Faults_01[2] = (byte)decimalVal_D2_B;
            _bar_FF8D_Faults_00[3] = (byte)decimalVal_D3_A;
            _bar_FF8D_Faults_01[3] = (byte)decimalVal_D3_B;
            _bar_FF8D_Faults_00[4] = (byte)decimalVal_D4_A;
            _bar_FF8D_Faults_01[4] = (byte)decimalVal_D4_B;


        }

        #endregion


        #region FEFC

        //*****************************************************************************    FEFC
        // 3.13 PORT Steering Nozzle Feedback (holding address = 4000013)
        // 3.14 STBD Steering Nozzle Feedback (holding address = 4000014)
        // 3.15 PORT Reversing Bucket Feedback (holding address = 4000015)
        // 3.16 STBD Reversing Bucket Feedback (holding address = 4000016)
        // 0_Port_B0_Port_BuckFB;
        // 2_Port_B2_Stbd_NozzFB;
        // 3_Port_B3_Port_NozzFB;
        // 5_Port_B5_Stbd_BuckFB;
        // sending 18FEFC00     D0  D1  D2  D3  D4  D5  D6  D7       
        //                      \       \   \       \__________ STBD Bucket Feedback 5_Port_B5_Stbd_BuckFB
        //                       \       \   \_________________ PORT Nozzle Feedback 3_Port_B3_Port_NozzFB    
        //                        \       \____________________ STBD Nozzle Feedback 2_Port_B2_Stbd_NozzFB
        //                         \___________________________ PORT Bucket Feedback 0_Port_B0_Port_BuckFB
        //
        // sending 18FEFC01	   || same
        void Update_FEFC_FB_nozBuk()
        {

            int _Port_B5_Stbd_BuckFB = slider_stbd_Bucket.Value;
            int _Port_B3_Port_NozzFB = slider_port_Noz.Value;
            int _Port_B2_Stbd_NozzFB = slider_stbd_Noz.Value;
            int _Port_B0_Port_BuckFB = slider_port_Bucket.Value;
            _bar_FEFC_FB_nozBuk_00[0] = (byte)_Port_B0_Port_BuckFB;
            _bar_FEFC_FB_nozBuk_00[2] = (byte)_Port_B2_Stbd_NozzFB;
            _bar_FEFC_FB_nozBuk_00[3] = (byte)_Port_B3_Port_NozzFB;
            _bar_FEFC_FB_nozBuk_00[5] = (byte)_Port_B5_Stbd_BuckFB;

            _bar_FEFC_FB_nozBuk_01[0] = (byte)_Port_B0_Port_BuckFB;
            _bar_FEFC_FB_nozBuk_01[2] = (byte)_Port_B2_Stbd_NozzFB;
            _bar_FEFC_FB_nozBuk_01[3] = (byte)_Port_B3_Port_NozzFB;
            _bar_FEFC_FB_nozBuk_01[5] = (byte)_Port_B5_Stbd_BuckFB;
        }
        #endregion



        #region FF8C

        //*****************************************************************************    FF8C
        // 3.17 PORT Throttle Demand (holding address = 4000017)
        // 3.18 STBD Throttle Demand (holding address = 4000018)
        //sending 18FF8C00      D0                      D1                          D2  D3  D4  D5  D6  D7
        //                      |                       7 6 5 4 3 2 1 0  <-bits     \   \           \__________ station in controle is it 1 and 2 or 0 ans 1 ?
        //                      |                       | | | | | | | |_             \   \_____________________ Stbd Engin Speed
        //                      |                       | | | | | | |___ activeCU     \________________________ Port Engin Speed
        //                      |                       | | | | | |_____ 
        //                      |                       | | | | |_______ 
        //                      |                       | | | |_________
        //                      |                       | | |___________
        //                      |                       | |_____________
        //                      |                       |_______________
        //                      7 6 5 4 3 2 1 0            
        //                      | | | | | | | |_                
        //                      | | | | | | |___ 
        //                      | | | | | |_____ 
        //                      | | | | |_______ 
        //                      | | | |_________
        //                      | | |___________
        //                      | |_____________ PORT Clutch Engagement is BLOCKED
        //                      |_______________ STBD Clutch Engagement is BLOCKED


        void Update_FF8C_throt_incontrol()
        {

            int speed_Port = slider_port_Speed.Value;
            int speed_Stbdt = slider_stbd_Speed.Value;

            bool _portclutchBlocked = cb_port_clutchBlocked.Checked;
            bool _stbdclutchBlocked = cb_stbd_clutchBlocked.Checked;
            byte _blok_val = 0;

            if (_portclutchBlocked && _stbdclutchBlocked)
            {
                _blok_val = 192;
            }
            else
            if (_portclutchBlocked && !_stbdclutchBlocked)
            {
                _blok_val = 64;
            }
            else
            if (!_portclutchBlocked && _stbdclutchBlocked)
            {
                _blok_val = 128;
            }
            else
            {
                _blok_val = 0;
            }

            _bar_FF8C_cuINctrl_StaInctrl_throttle_00[2] = (byte)speed_Port;
            _bar_FF8C_cuINctrl_StaInctrl_throttle_01[2] = (byte)speed_Port;

            _bar_FF8C_cuINctrl_StaInctrl_throttle_00[3] = (byte)speed_Stbdt;
            _bar_FF8C_cuINctrl_StaInctrl_throttle_01[3] = (byte)speed_Stbdt;


            _bar_FF8C_cuINctrl_StaInctrl_throttle_00[0] = _blok_val;
            _bar_FF8C_cuINctrl_StaInctrl_throttle_01[0] = _blok_val;


            if (_selectedStationInControl == StationInControl.MainBridge)
            {

                _bar_FF8C_cuINctrl_StaInctrl_throttle_00[6] = 1;
                _bar_FF8C_cuINctrl_StaInctrl_throttle_01[6] = 1;

                if (_selectedUnitInControl == UnitInControl.UnitA)
                {
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_00[1] = 2;
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_01[1] = 1;
                }
                else
                if (_selectedUnitInControl == UnitInControl.UnitB)
                {
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_00[1] = 1;
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_01[1] = 2;
                }
                else
                {
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_00[1] = 0;
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_01[1] = 0;
                }
            }
            else
            if (_selectedStationInControl == StationInControl.OpenBridge)
            {
                _bar_FF8C_cuINctrl_StaInctrl_throttle_00[6] = 2;
                _bar_FF8C_cuINctrl_StaInctrl_throttle_01[6] = 2;
                if (_selectedUnitInControl == UnitInControl.UnitA)
                {
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_00[1] = 2;
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_01[1] = 1;
                }
                else
                if (_selectedUnitInControl == UnitInControl.UnitB)
                {
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_00[1] = 1;
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_01[1] = 2;
                }
                else
                {
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_00[1] = 0;
                    _bar_FF8C_cuINctrl_StaInctrl_throttle_01[1] = 0;
                }
            }
            else
            {
                _bar_FF8C_cuINctrl_StaInctrl_throttle_00[6] = 0;
                _bar_FF8C_cuINctrl_StaInctrl_throttle_01[6] = 0;
            }





        }

        #endregion


        #region FFA1


        void Update_FFA1_hpualarm()
        {

            _bar_FFA1_FB_hpualams_01[0] = (byte)decimalhpu_A_D0;
            _bar_FFA1_FB_hpualams_01[2] = (byte)decimalhpu_A_D2;
            _bar_FFA1_FB_hpualams_01[3] = (byte)decimalhpu_A_D3;

            _bar_FFA1_FB_hpualams_02[0] = (byte)decimalhpu_B_D0;
            _bar_FFA1_FB_hpualams_02[2] = (byte)decimalhpu_B_D2;
            _bar_FFA1_FB_hpualams_02[3] = (byte)decimalhpu_B_D3;
        }
        // //***************************************************************************** FFA1
        // 4.1 PORT HPU Status and Alarms (holding address = 400051)
        // 0 N/A
        // 1 N/A
        // 2 PORT Hydraulic Oil Pressure Low
        // 3 PORT Hydraulic Oil Level Low
        // 4 PORT Hydraulic Oil Flow Low
        // 5 PORT Hydraulic Oil Temp High
        // 6 PORT Lube Oil Pressure Low
        // 7 PORT Lube Oil Change Over Activated
        //double d_A_Port_Hydro;
        //smRead( VariableIDs.J1939_INFPB___Port_A_M_Unit_Low_Hydraulic_Press, d_A_Port_Hydro );
        //sending 18FFA100      D0                          D1      D2                                  D3                          D4  D5  D6 D7
        //                      3 2 1 0  <-bits                     3 2 1 0  <-bits                     2 1 0  <-bits         
        //                      | | | |_ Change Over Press          | | | |_ Low Oil Level              | | |_ Changeover Valve Activated 
        //                      | | |___ LowHydraulicPress          | | |___ Low Lube Oil Press         | |___ LO Pump Running Wirebreak
        //                      | |_____ High Temp                  | |_____ LO Pump Running            
        //                      |_______ Low Oil Flow               |_______ LO Pump Fault              
        //                        


        // //*****************************************************************************
        // 4.2 STBD HPU Status and Alarms (holding address = 400052)
        // Bit Message
        // 0 N/A
        // 1 N/A
        // 2 STBD Hydraulic Oil Pressure Low
        // 3 STBD Hydraulic Oil Level Low
        // 4 STBD Hydraulic Oil Flow Low
        // 5 STBD Hydraulic Oil Temp High
        // 6 STBD Lube Oil Pressure Low
        // 7 STBD Lube Oil Change Over Activated
        //sending 18FFA101      D0                          D1      D2                                  D3                          D4  D5  D6 D7
        //                      3 2 1 0  <-bits                     3 2 1 0  <-bits                     2 1 0  <-bits         
        //                      | | | |_ Change Over Press          | | | |_ Low Oil Level              | | |_ Changeover Valve Activated 
        //                      | | |___ LowHydraulicPress          | | |___ Low Lube Oil Press         | |___ LO Pump Running Wirebreak
        //                      | |_____ High Temp                  | |_____ LO Pump Running            
        //                      |_______ Low Oil Flow               |_______ LO Pump Fault              








        // //*****************************************************************************
        // 4.3 PORT LO Pump (holding address = 400053)
        // 0 Supervisory Alarm  ??????????????????????????????????????????????????????????
        // 1 LO Pump Running5   LO Pump Running
        // 2 LO Pump Thermal Overload  ??????????????????????????????????????????????????????????
        // 3 Clutch Engage Blocked - LO Pump Not Running 
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // //*****************************************************************************
        // 4.4 STBD LO Pump (holding address = 400054)
        // 0 Supervisory Alarm ??????????????????????????????????????????????????????????
        // 1 LO Pump Running
        // 2 LO Pump Thermal Overload  ??????????????????????????????????????????????????????????
        // 3 Clutch Engage Blocked - LO Pump Not Running
        // 4 reserved
        // 5 reserved
        // 6 reserved
        // 7 reserved
        // //*****************************************************************************

        // Stbd_AM_CommFailure

        //*****************************************************************************    FFA2 MTU
        //sending 18FFA200      D0                      D1        

        //                      7 6 5 4 3 2 1 0            
        //                      | | | | | | | |_        enginrunning        
        //                      | | | | | | |___        enginlocal remote
        //                      | | | | | |_____       clutch window
        //                      | | | | |_______ 
        //                      | | | |_________
        //                      | | |___________
        //                      | |_____________  
        //                      |_______________  


        void Update_FFA2_MTU()
        {

            _bar_FFA2_MTU_01[0] = (byte)decimal_MTU_A_D0;


            _bar_FFA2_MTU_02[0] = (byte)decimal_MTU_B_D0;

        }

        #endregion

        private void sendData_FF8C_throt_incontrol()
        {


            if (_KILL_A && _KILL_B)
            {
                return;
                // _bar_FF8C_cuINctrl_StaInctrl_throttle_00[6] = 0;
            }
            else
            if (_KILL_A && !_KILL_B)
            {
                canManager.SendMessage(_png_FF8C_cuINctrl_StaInctrl_throttle_01, _bar_FF8C_cuINctrl_StaInctrl_throttle_01);
                // _bar_FF8C_cuINctrl_StaInctrl_throttle_01[6] = 0;
            }
            else
                  if (!_KILL_A && _KILL_B)
            { canManager.SendMessage(_png_FF8C_cuINctrl_StaInctrl_throttle_00, _bar_FF8C_cuINctrl_StaInctrl_throttle_00); }

            else
            {

                canManager.SendMessage(_png_FF8C_cuINctrl_StaInctrl_throttle_01, _bar_FF8C_cuINctrl_StaInctrl_throttle_01);
                canManager.SendMessage(_png_FF8C_cuINctrl_StaInctrl_throttle_00, _bar_FF8C_cuINctrl_StaInctrl_throttle_00);

            }


            //if (_selectedUnitInControl != UnitInControl.Unknown && _selectedStationInControl != StationInControl.Unknown)
            //{

            //}
            //else
            //{


            //}
            // Your sendData implementation here



        }

        void SendData_FF8D_faults()
        {

            //Update_FF8D_faults();

            canManager.SendMessage(_png_FF8D_faults_00, _bar_FF8D_Faults_00);
            canManager.SendMessage(_png_FF8D_faults_01, _bar_FF8D_Faults_01);
        }

        void SendData_FEFC_FB_NozBuk()
        {

            canManager.SendMessage(_png_FEFC_FB_nozBuk_00, _bar_FEFC_FB_nozBuk_00);
            canManager.SendMessage(_png_FEFC_FB_nozBuk_01, _bar_FEFC_FB_nozBuk_01);
        }


        void SendFFA1_HPUalarm()
        {


            canManager.SendMessage(_png_FFA1_FB_hpualams_01, _bar_FFA1_FB_hpualams_01);
            canManager.SendMessage(_png_FFA1_FB_hpualams_02, _bar_FFA1_FB_hpualams_02);

            //  int _png_FFA1_FB_hpualams_00 = 0x18FFA100;
            // int _png_FFA1_FB_hpualams_01 = 0x18FFA101;
        }

        void SendFFA2_MTU()
        {

            canManager.SendMessage(_png_FFA2_MTU_01, _bar_FFA2_MTU_01);
            canManager.SendMessage(_png_FFA2_MTU_02, _bar_FFA2_MTU_02);
        }
    }
}

