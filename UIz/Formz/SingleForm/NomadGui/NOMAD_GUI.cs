using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.NomadGui
{
    //CLR_dot_NEt_FRAMEWORK
    public partial class NOMAD_GUI : Form
    {
 
        private bool isReceiving = false;
        private bool Global_UseFilter = false;
        private int counter = 1;  // Counter for message numbering
	    private int maxLines = 10;
        private int sendRateInfo = 500;
        private bool isSendingSysInfo_FF8C = false;
        private bool isSending_FF22_FF23 = false;
        private bool isSending_KeepAlives = false;
        CTRL_PannelData CTRLPANNEL;
        INDIC_PannelData INDICPANNEL;
        AxioShell axioInstance;
        public NOMAD_GUI()
        {
            InitializeComponent();
            CTRLPANNEL = new CTRL_PannelData();
            INDICPANNEL = new INDIC_PannelData();
            axioInstance = new AxioShell();
            radioButton_manned.Checked = true;
            radioButton_ChangeOver.Checked = true;
            radioButton_Ready.Checked = true;



            tkb_Thrust_P_IB.Minimum = 0;
            tkb_Thrust_P_IB.Maximum = 2000;
            tkb_Thrust_P_IB.Value = 0;
            tkb_Thrust_S_IB.Minimum = 0;
            tkb_Thrust_S_IB.Maximum = 2000;
            tkb_Thrust_S_IB.Value = 0;
            tkb_Thrust_fb_P_IB.Minimum = 0;
            tkb_Thrust_fb_P_IB.Maximum = 2000;
            tkb_Thrust_fb_P_IB.Value = 0;
            tkb_Thrust_fb_S_IB.Minimum = 0;
            tkb_Thrust_fb_S_IB.Maximum = 2000;
            tkb_Thrust_fb_S_IB.Value = 0;

            tkb_Steer_P_IB.Minimum = 0;
            tkb_Steer_P_IB.Maximum = 1000;
            tkb_Steer_P_IB.Value = 500;
            tkb_Steer_S_IB.Minimum = 0;
            tkb_Steer_S_IB.Maximum = 1000;
            tkb_Steer_S_IB.Value = 500;
            tkb_Steer_fb_P_IB.Minimum = 0;
            tkb_Steer_fb_P_IB.Maximum = 1000;
            tkb_Steer_fb_P_IB.Value = 500;
            tkb_Steer_fb_S_IB.Minimum = 0;
            tkb_Steer_fb_S_IB.Maximum = 1000;
            tkb_Steer_fb_S_IB.Value = 500;

            //obs
            tkb_Thrust_P_OB.Minimum = 0;
            tkb_Thrust_P_OB.Maximum = 2000;
            tkb_Thrust_P_OB.Value = 0;
            tkb_Thrust_S_OB.Minimum = 0;
            tkb_Thrust_S_OB.Maximum = 2000;
            tkb_Thrust_S_OB.Value = 0;
            tkb_Thrust_fb_P_OB.Minimum = 0;
            tkb_Thrust_fb_P_OB.Maximum = 2000;
            tkb_Thrust_fb_P_OB.Value = 0;
            tkb_Thrust_fb_S_OB.Minimum = 0;
            tkb_Thrust_fb_S_OB.Maximum = 2000;
            tkb_Thrust_fb_S_OB.Value = 0;

            tkb_Steer_P_OB.Minimum = 0;
            tkb_Steer_P_OB.Maximum = 1000;
            tkb_Steer_P_OB.Value = 500;
            tkb_Steer_S_OB.Minimum = 0;
            tkb_Steer_S_OB.Maximum = 1000;
            tkb_Steer_S_OB.Value = 500;
            tkb_Steer_fb_P_OB.Minimum = 0;
            tkb_Steer_fb_P_OB.Maximum = 1000;
            tkb_Steer_fb_P_OB.Value = 500;
            tkb_Steer_fb_S_OB.Minimum = 0;
            tkb_Steer_fb_S_OB.Maximum = 1000;
            tkb_Steer_fb_S_OB.Value = 500;

            tkb_indic_buk0.Minimum = 0;
            tkb_indic_buk1.Minimum = 0;
            tkb_indic_noz0.Minimum = 0;
            tkb_indic_noz1.Minimum = 0;
            tkb_indic_buk2.Minimum = 0;
            tkb_indic_buk3.Minimum = 0;
            tkb_indic_noz2.Minimum = 0;
            tkb_indic_noz3.Minimum = 0;
            tkb_indic_eng0.Minimum = 0;
            tkb_indic_eng1.Minimum = 0;
            tkb_indic_eng2.Minimum = 0;
            tkb_indic_eng3.Minimum = 0;

            tkb_indic_buk0.Maximum = 250;
            tkb_indic_buk1.Maximum = 250;
            tkb_indic_noz0.Maximum = 250;
            tkb_indic_noz1.Maximum = 250;
            tkb_indic_buk2.Maximum = 250;
            tkb_indic_buk3.Maximum = 250;
            tkb_indic_noz2.Maximum = 250;
            tkb_indic_noz3.Maximum = 250;
            tkb_indic_eng0.Maximum = 100;
            tkb_indic_eng1.Maximum = 100;
            tkb_indic_eng2.Maximum = 100;
            tkb_indic_eng3.Maximum = 100;

            tkb_indic_buk0.Value = 0;
            tkb_indic_buk1.Value = 125;
            tkb_indic_noz0.Value = 0;
            tkb_indic_noz1.Value = 125;
            tkb_indic_buk2.Value = 0;
            tkb_indic_buk3.Value = 125;
            tkb_indic_noz2.Value = 0;
            tkb_indic_noz3.Value = 125;
            tkb_indic_eng0.Value = 0;
            tkb_indic_eng1.Value = 0;
            tkb_indic_eng2.Value = 0;
            tkb_indic_eng3.Value = 0;


            tkb_Thrust_fb_S_IB.Enabled = false;
            tkb_Thrust_fb_P_IB.Enabled = false;
            tkb_Steer_fb_P_IB.Enabled = false;
            tkb_Steer_fb_S_IB.Enabled = false;
            tkb_Thrust_fb_S_OB.Enabled = false;
            tkb_Thrust_fb_P_OB.Enabled = false;
            tkb_Steer_fb_P_OB.Enabled = false;
            tkb_Steer_fb_S_OB.Enabled = false;

            tb_Prio_22.MaxLength = 2;
            tb_Prio_23.MaxLength = 2;
            tb_pgn_22.MaxLength = 4;
            tb_pgn_23.MaxLength = 4;
            tb_addr_22.MaxLength = 2;
            tb_addr_23.MaxLength = 2;

            tb_Prio_22.Text = "18";
            tb_Prio_23.Text = "18";
            tb_pgn_22.Text = "FF22";
            tb_pgn_23.Text = "FF23";
            tb_addr_22.Text = "00";
            tb_addr_23.Text = "00";
            tb_sysinfo_byt0_b0.Text = "0";
            tb_sysinfo_byt0_b1.Text = "0";
            tb_sysinfo_byt0_b2.Text = "0";
            tb_sysinfo_byt0_b3.Text = "0";
            tb_sysinfo_byt0_b4.Text = "0";
            tb_sysinfo_byt0_b5.Text = "0";
            tb_sysinfo_byt0_b6.Text = "0";
            tb_sysinfo_byt0_b7.Text = "0";
            tb_sysinfo_byt1_b0.Text = "0";
            tb_sysinfo_byt1_b1.Text = "0";
            tb_sysinfo_byt1_b2.Text = "0";
            tb_sysinfo_byt1_b3.Text = "0";
            tb_sysinfo_byt1_b4.Text = "0";
            tb_sysinfo_byt1_b5.Text = "0";
            tb_sysinfo_byt1_b6.Text = "0";
            tb_sysinfo_byt1_b7.Text = "0";
            tb_sysinfo_byt2_100.Text = "0";
            tb_sysinfo_byt3_100.Text = "0";
            tb_sysinfo_byt4_100.Text = "0";
            tb_sysinfo_byt5_b1.Text = "0";
            tb_sysinfo_byt5_b2.Text = "0";
            tb_sysinfo_byt6_100.Text = "0";
            tb_sysinfo_byt7_b0.Text = "0";
            tb_sysinfo_byt7_b1.Text = "0";
            tb_sysinfo_byt7_b2.Text = "0";
            tb_sysinfo_byt7_b4.Text = "0";
            tb_sysinfo_byt7_b5.Text = "0";
            tb_sysinfo_byt7_b6.Text = "0";

            tb_sysinfo_byt0_b0.MaxLength = 1;
            tb_sysinfo_byt0_b1.MaxLength = 1;
            tb_sysinfo_byt0_b2.MaxLength = 1;
            tb_sysinfo_byt0_b3.MaxLength = 1;
            tb_sysinfo_byt0_b4.MaxLength = 1;
            tb_sysinfo_byt0_b5.MaxLength = 1;
            tb_sysinfo_byt0_b6.MaxLength = 1;
            tb_sysinfo_byt0_b7.MaxLength = 1;
            tb_sysinfo_byt1_b0.MaxLength = 1;
            tb_sysinfo_byt1_b1.MaxLength = 1;
            tb_sysinfo_byt1_b2.MaxLength = 1;
            tb_sysinfo_byt1_b3.MaxLength = 1;
            tb_sysinfo_byt1_b4.MaxLength = 1;
            tb_sysinfo_byt1_b5.MaxLength = 1;
            tb_sysinfo_byt1_b6.MaxLength = 1;
            tb_sysinfo_byt1_b7.MaxLength = 1;
            tb_sysinfo_byt2_100.MaxLength = 3;
            tb_sysinfo_byt3_100.MaxLength = 3;
            tb_sysinfo_byt4_100.MaxLength = 3;
            tb_sysinfo_byt5_b1.MaxLength = 1;
            tb_sysinfo_byt5_b2.MaxLength = 1;
            tb_sysinfo_byt6_100.MaxLength = 3;
            tb_sysinfo_byt7_b0.MaxLength = 1;
            tb_sysinfo_byt7_b1.MaxLength = 1;
            tb_sysinfo_byt7_b2.MaxLength = 1;
            tb_sysinfo_byt7_b4.MaxLength = 1;
            tb_sysinfo_byt7_b5.MaxLength = 1;
            tb_sysinfo_byt7_b6.MaxLength = 1;

            lbl_CombinedPGN_22.Text = "0x" + tb_Prio_22.Text + tb_pgn_22.Text + tb_addr_23.Text;
            lbl_CombinedPGN_23.Text = "0x" + tb_Prio_23.Text + tb_pgn_23.Text + tb_addr_23.Text;

            cmbx_ActiveStation.Items.Add("None");
            cmbx_ActiveStation.Items.Add("Forward");
            cmbx_ActiveStation.Items.Add("AFT");
            cmbx_ActiveStation.Items.Add("Unknown");
            cmbx_ActiveStation.SelectedIndex = 3;
            cmbx_ActiveStation.SelectedIndexChanged += new System.EventHandler(this.On_cmbx_ActiveStation_IndexChanged);

            cmbx_OperatingMode.Items.Add("Docking");
            cmbx_OperatingMode.Items.Add("Transit");
            cmbx_OperatingMode.Items.Add("Autopilot");
            cmbx_OperatingMode.Items.Add("Unknown");
            cmbx_OperatingMode.SelectedIndex = 3;
            cmbx_OperatingMode.SelectedIndexChanged += new System.EventHandler(this.On_cmbx_OperationMode_IndexChanged);

            cmbx_ActiveSystem.Items.Add("System A");
            cmbx_ActiveSystem.Items.Add("System B");
            cmbx_ActiveSystem.Items.Add("Mismatch");
            cmbx_ActiveSystem.Items.Add("Unknown");
            cmbx_ActiveSystem.SelectedIndex = 3;
            cmbx_ActiveSystem.SelectedIndexChanged += new System.EventHandler(this.On_cmbx_ActiveSystem_IndexChanged);

            cmbx_Controls.Items.Add("Separate Azimuth");
            cmbx_Controls.Items.Add("Combined Azimuth");
            cmbx_Controls.Items.Add("Joystick/Tiller");
            cmbx_Controls.Items.Add("Unknown");
            cmbx_Controls.SelectedIndex = 3;
            cmbx_Controls.SelectedIndexChanged += new System.EventHandler(this.On_cmbx_Controls_IndexChanged);

            btn_BuildFullPGN_22.Click += new System.EventHandler(this.btn_BuildFullPGN_Click_22);
            btn_BuildFullPGN_23.Click += new System.EventHandler(this.btn_BuildFullPGN_Click_23);
            btn_Receive.Click += new System.EventHandler(this.btn_ToggleReceive_Click);
            _btn_ToggleSending.Click += new System.EventHandler(this.btn_ToggleSending_Click);
            btn_mode_send.Click += new System.EventHandler(this.btn_mode_send_Click);
            btn_hand_ack_send.Click += new System.EventHandler(this.btn_hand_ack_send_Click);
            btn_hand_syn_send.Click += new System.EventHandler(this.btn_hand_syn_send_Click);
            btn_sysinfo_toggsend.Click += new System.EventHandler(this.btn_SendSysInfo_Click);
            btn_keepAlive.Click += new System.EventHandler(this.btn_keepalive_Click);
            btn_filter.Click += new System.EventHandler(this.btn_filter_Click);

            tkb_indic_buk0.Scroll += new System.EventHandler(this.On_indic_buk0_Scroll);
            tkb_indic_buk1.Scroll += new System.EventHandler(this.On_indic_buk1_Scroll);
            tkb_indic_buk2.Scroll += new System.EventHandler(this.On_indic_buk2_Scroll);
            tkb_indic_buk3.Scroll += new System.EventHandler(this.On_indic_buk3_Scroll);
            tkb_indic_noz0.Scroll += new System.EventHandler(this.On_indic_noz0_Scroll);
            tkb_indic_noz1.Scroll += new System.EventHandler(this.On_indic_noz1_Scroll);
            tkb_indic_noz2.Scroll += new System.EventHandler(this.On_indic_noz2_Scroll);
            tkb_indic_noz3.Scroll += new System.EventHandler(this.On_indic_noz3_Scroll);
            tkb_indic_eng0.Scroll += new System.EventHandler(this.On_indic_eng0_Scroll);
            tkb_indic_eng1.Scroll += new System.EventHandler(this.On_indic_eng1_Scroll);
            tkb_indic_eng2.Scroll += new System.EventHandler(this.On_indic_eng2_Scroll);
            tkb_indic_eng3.Scroll += new System.EventHandler(this.On_indic_eng3_Scroll);
            tkb_Thrust_P_IB.Scroll += new System.EventHandler(this.On_Thrust_P_IB_Scroll);
            tkb_Thrust_S_IB.Scroll += new System.EventHandler(this.On_Thrust_S_IB_Scroll);
            tkb_Steer_P_IB.Scroll += new System.EventHandler(this.On_Steer_P_IB_Scroll);
            tkb_Steer_S_IB.Scroll += new System.EventHandler(this.On_Steer_S_IB_Scroll);
            tkb_Thrust_P_OB.Scroll += new System.EventHandler(this.On_Thrust_P_OB_Scroll);
            tkb_Thrust_S_OB.Scroll += new System.EventHandler(this.On_Thrust_S_OB_Scroll);
            tkb_Steer_P_OB.Scroll += new System.EventHandler(this.On_Steer_P_OB_Scroll);
            tkb_Steer_S_OB.Scroll += new System.EventHandler(this.On_Steer_S_OB_Scroll);


            tb_DisplayCANS.TextChanged += new System.EventHandler(this.tb_Display_TextChanged);
            tb_DisplaySENDS.TextChanged += new System.EventHandler(this.tb_DisplaySENDS_TextChanged);

            tb_info_rate_val.Text = "400";
            sendRateInfo = Convert.ToInt32(tb_info_rate_val.Text);

            timer_Info_FF08_Rate.Interval = sendRateInfo;
            timer_keepAlive.Interval = 1100;
            timer_receive.Interval = 100;  // Set timer interval to 100 ms
            timer_Screen.Interval = 250;
            timer_Send.Interval = 300;

            timer_Info_FF08_Rate.Tick += new System.EventHandler(this.OnTimer_SendInfo_ScreenTick);
            timer_keepAlive.Tick += new System.EventHandler(this.OnTimer_KeepAlive_Tick);
            timer_receive.Tick += new System.EventHandler(this.OnTimer_ReceiveTick);
            timer_Screen.Tick += new System.EventHandler(this.OnTimer_ScreenTick);
            timer_Send.Tick += new System.EventHandler(this.OnTimer_Send_Tick);

            timer_Screen.Start();

        }

       

        void bigInit() {







        



        



     

         

      


        }
        #region OnCombobox

        private void On_cmbx_ActiveStation_IndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbx_ActiveStation.SelectedIndex;
            lbl_Selection.Text = "Selected ActiveStation Index: " + selectedIndex.ToString();
        }

        private void On_cmbx_OperationMode_IndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbx_OperatingMode.SelectedIndex;
            lbl_Selection.Text = "Selected OperationMode Index: " + selectedIndex.ToString();
        }

        private void On_cmbx_ActiveSystem_IndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbx_ActiveSystem.SelectedIndex;
            lbl_Selection.Text = "Selected ActiveSystem Index: " + selectedIndex.ToString();
        }

        private void On_cmbx_Controls_IndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbx_Controls.SelectedIndex;
            lbl_Selection.Text = "Selected Control Index: " + selectedIndex.ToString();
        }

        #endregion

        #region OnScrol

        private void On_indic_buk0_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.BUC_0_Int = tkb_indic_buk0.Value;
            lbl_buck0_val.Text = INDICPANNEL.BUC_0_Int.ToString();
        }

        private void On_indic_buk1_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.BUC_1_Int = tkb_indic_buk1.Value;
            lbl_buck1_val.Text = INDICPANNEL.BUC_1_Int.ToString();
        }

        private void On_indic_buk2_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.BUC_2_Int = tkb_indic_buk2.Value;
            lbl_buck2_val.Text = INDICPANNEL.BUC_2_Int.ToString();
        }

        private void On_indic_buk3_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.BUC_3_Int = tkb_indic_buk3.Value;
            lbl_buck3_val.Text = INDICPANNEL.BUC_3_Int.ToString();
        }

        private void On_indic_noz0_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.NOZ_0_Int = tkb_indic_noz0.Value;
            lbl_noz0_val.Text = INDICPANNEL.NOZ_0_Int.ToString();
        }

        private void On_indic_noz1_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.NOZ_1_Int = tkb_indic_noz1.Value;
            lbl_noz1_val.Text = INDICPANNEL.NOZ_1_Int.ToString();
        }

        private void On_indic_noz2_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.NOZ_2_Int = tkb_indic_noz2.Value;
            lbl_noz2_val.Text = INDICPANNEL.NOZ_2_Int.ToString();
        }

        private void On_indic_noz3_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.NOZ_3_Int = tkb_indic_noz3.Value;
            lbl_noz3_val.Text = INDICPANNEL.NOZ_3_Int.ToString();
        }

        private void On_indic_eng0_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.ENG_0_Int = tkb_indic_eng0.Value;
            lbl_eng0_val.Text = INDICPANNEL.ENG_0_Int.ToString();
        }

        private void On_indic_eng1_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.ENG_1_Int = tkb_indic_eng1.Value;
            lbl_eng1_val.Text = INDICPANNEL.ENG_1_Int.ToString();
        }

        private void On_indic_eng2_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.ENG_2_Int = tkb_indic_eng2.Value;
            lbl_eng2_val.Text = INDICPANNEL.ENG_2_Int.ToString();
        }

        private void On_indic_eng3_Scroll(object sender, EventArgs e)
        {
            INDICPANNEL.ENG_3_Int = tkb_indic_eng3.Value;
            lbl_eng3_val.Text = INDICPANNEL.ENG_3_Int.ToString();
        }

        private void On_Thrust_P_IB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Thrust_P_I_Int = tkb_Thrust_P_IB.Value;
            lbl_thrustVal_P_IB.Text = CTRLPANNEL.Thrust_P_I_Int.ToString();
        }

        private void On_Thrust_S_IB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Thrust_S_I_Int = tkb_Thrust_S_IB.Value;
            lbl_thrustVal_S_IB.Text = CTRLPANNEL.Thrust_S_I_Int.ToString();
        }

        private void On_Steer_P_IB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Steer_P_I_Int = tkb_Steer_P_IB.Value;
            lbl_SteerVal_P_IB.Text = CTRLPANNEL.Steer_P_I_Int.ToString();
        }

        private void On_Steer_S_IB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Steer_S_I_Int = tkb_Steer_S_IB.Value;
            lbl_SteerVal_S_IB.Text = CTRLPANNEL.Steer_S_I_Int.ToString();
        }

        private void On_Thrust_P_OB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Thrust_P_O_Int = tkb_Thrust_P_OB.Value;
            lbl_thrustVal_P_OB.Text = CTRLPANNEL.Thrust_P_O_Int.ToString();
        }

        private void On_Thrust_S_OB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Thrust_S_O_Int = tkb_Thrust_S_OB.Value;
            lbl_thrustVal_S_OB.Text = CTRLPANNEL.Thrust_S_O_Int.ToString();
        }

        private void On_Steer_P_OB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Steer_P_O_Int = tkb_Steer_P_OB.Value;
            lbl_SteerVal_P_OB.Text = CTRLPANNEL.Steer_P_O_Int.ToString();
        }

        private void On_Steer_S_OB_Scroll(object sender, EventArgs e)
        {
            CTRLPANNEL.Steer_S_O_Int = tkb_Steer_S_OB.Value;
            lbl_SteerVal_S_OB.Text = CTRLPANNEL.Steer_S_O_Int.ToString();
        }

        #endregion

        #region BuildFilterPGN
        private void btn_BuildFullPGN_Click_22(object sender, EventArgs e)
        {
            string prio = tb_Prio_22.Text;
            string pgn = tb_pgn_22.Text;
            string addr = tb_addr_22.Text;
            if (string.IsNullOrEmpty(prio) || string.IsNullOrEmpty(pgn) || string.IsNullOrEmpty(addr))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }
            if (prio.Length != 2 || pgn.Length != 4 || addr.Length != 2)
            {
                MessageBox.Show("Invalid lengths for fields. Prio must be 2, PGN must be 4, and Addr must be 2.");
                return;
            }
            string combinedPGN = "0x" + prio + pgn + addr;
            lbl_CombinedPGN_22.Text = combinedPGN;
            UInt32 PGNval = 0;
            if (UInt32.TryParse(combinedPGN.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out PGNval))
            {
                axioInstance.UpdateCurSendingPGN_22(PGNval);
            }
            else
            {
                MessageBox.Show("Failed to convert to ULONG.");
            }
        }

        private void btn_BuildFullPGN_Click_23(object sender, EventArgs e)
        {
            string prio = tb_Prio_23.Text;
            string pgn = tb_pgn_23.Text;
            string addr = tb_addr_23.Text;
            if (string.IsNullOrEmpty(prio) || string.IsNullOrEmpty(pgn) || string.IsNullOrEmpty(addr))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }
            if (prio.Length != 2 || pgn.Length != 4 || addr.Length != 2)
            {
                MessageBox.Show("Invalid lengths for fields. Prio must be 2, PGN must be 4, and Addr must be 2.");
                return;
            }
            string combinedPGN = "0x" + prio + pgn + addr;
            lbl_CombinedPGN_23.Text = combinedPGN;
            UInt32 PGNval = 0;
            if (UInt32.TryParse(combinedPGN.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out PGNval))
            {
                axioInstance.UpdateCurSendingPGN_23(PGNval);
            }
            else
            {
                MessageBox.Show("Failed to convert to ULONG.");
            }
        }
        #endregion

        #region Timer_Rec
        private void OnTimer_ScreenTick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void OnTimer_Send_Tick(object sender, EventArgs e)
        {
            UpdateSEND_CTRLPANNEL_VALS();
            UpdateSEND_INDICPANNEL_VALS();
        }

        private void OnTimer_KeepAlive_Tick(object sender, EventArgs e)
        {
            axioInstance.CustomSendKeepAlives();
        }

        private void OnTimer_SendInfo_ScreenTick(object sender, EventArgs e)
        {
            axioInstance.Send_SORED_sysInfo();
        }

        private void UpdateSEND_CTRLPANNEL_VALS()
        {
            axioInstance.Send_ALL_PS_IO_COMS(CTRLPANNEL.Thrust_P_I_Int, CTRLPANNEL.Steer_P_I_Int, CTRLPANNEL.Thrust_S_I_Int, CTRLPANNEL.Steer_S_I_Int, CTRLPANNEL.Thrust_P_O_Int, CTRLPANNEL.Steer_P_O_Int, CTRLPANNEL.Thrust_S_O_Int, CTRLPANNEL.Steer_S_O_Int);
        }

        private void UpdateSEND_INDICPANNEL_VALS()
        {
            axioInstance.Send_indications(INDICPANNEL.BUC_0_Int, INDICPANNEL.BUC_1_Int, INDICPANNEL.NOZ_0_Int, INDICPANNEL.NOZ_1_Int, INDICPANNEL.ENG_0_Int, INDICPANNEL.ENG_0_Int);
        }

        private void OnTimer_ReceiveTick(object sender, EventArgs e)
        {
            if (isReceiving)
            {
                counter++;
                axioInstance.RunReceiveMessage_UpdateLocalDataBytes();
                UpdateFeedbacks();
                return;
            }
        }

        private void UpdateDisplay()
        {
            string nativeStr = axioInstance.GetMessageString();
            string managedStr = new string(nativeStr.ToCharArray());
            string formattedCounter = string.Format("{0,5}", counter);
            tb_DisplayCANS.AppendText(formattedCounter + " " + managedStr + "\r\n");
        }

        private void UpdateFeedbacks()
        {
            int val_L = axioInstance.Get_test_Thrust_Scale5000_out2000Feedback_L();
            int val_R = axioInstance.Get_test_Thrust_Scale5000_out2000Feedback_R();
            int val_L_steer = axioInstance.Get_test_Steer_Scale10000_out1000Feedback_L();
            int val_R_steer = axioInstance.Get_test_Steer_Scale10000_out1000Feedback_R();
            tkb_Thrust_fb_P_IB.Value = val_L;
            tkb_Thrust_fb_S_IB.Value = val_R;
            lbl_trustFBval_P_IB.Text = val_L.ToString();
            lbl_trustFBval_S_IB.Text = val_R.ToString();
            tkb_Steer_fb_P_IB.Value = val_L_steer;
            tkb_Steer_fb_S_IB.Value = val_R_steer;
            lbl_SteerFBval_P_IB.Text = val_L_steer.ToString();
            lbl_SteerFBval_S_IB.Text = val_R_steer.ToString();
        }

        private void btn_ToggleReceive_Click(object sender, EventArgs e)
        {
            isReceiving = !isReceiving;
            if (isReceiving)
            {
                timer_receive.Start();
                btn_Receive.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                timer_receive.Stop();
                btn_Receive.BackColor = System.Drawing.Color.White;
            }
        }

        private void btn_ToggleSending_Click(object sender, EventArgs e)
        {
            isSending_FF22_FF23 = !isSending_FF22_FF23;
            if (isSending_FF22_FF23)
            {
                timer_Send.Start();
                _btn_ToggleSending.BackColor = System.Drawing.Color.Green;
                _btn_ToggleSending.Text = "is sending at " + timer_Send.Interval.ToString();
            }
            else
            {
                timer_Send.Stop();
                _btn_ToggleSending.BackColor = System.Drawing.Color.White;
                _btn_ToggleSending.Text = "is NOT sending";
            }
        }

        private void tb_Display_TextChanged(object sender, EventArgs e)
        {
            string[] lines = tb_DisplayCANS.Lines;
            if (lines.Length > maxLines)
            {
                string[] newLines = new string[maxLines];
                Array.Copy(lines, lines.Length - maxLines, newLines, 0, maxLines);
                tb_DisplayCANS.Lines = newLines;
                tb_DisplayCANS.SelectionStart = tb_DisplayCANS.Text.Length;
                tb_DisplayCANS.ScrollToCaret();
            }
        }

        private void tb_DisplaySENDS_TextChanged(object sender, EventArgs e)
        {
            string[] lines = tb_DisplaySENDS.Lines;
            if (lines.Length > maxLines)
            {
                string[] newLines = new string[maxLines];
                Array.Copy(lines, lines.Length - maxLines, newLines, 0, maxLines);
                tb_DisplaySENDS.Lines = newLines;
                tb_DisplaySENDS.SelectionStart = tb_DisplaySENDS.Text.Length;
                tb_DisplaySENDS.ScrollToCaret();
            }
        }
        #endregion

        private void btn_keepalive_Click(object sender, EventArgs e)
        {
            isSending_KeepAlives = !isSending_KeepAlives;
            if (isSending_KeepAlives)
            {
                timer_keepAlive.Start();
                btn_keepAlive.BackColor = System.Drawing.Color.Green;
                btn_keepAlive.Text = "stayig alive" + timer_Send.Interval.ToString();
            }
            else
            {
                timer_keepAlive.Stop();
                btn_keepAlive.BackColor = System.Drawing.Color.White;
                btn_keepAlive.Text = "stopped";
            }
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            string prio = tb_Prio_22.Text;
            string pgn = tb_pgn_22.Text;
            string addr = tb_addr_22.Text;
            if (string.IsNullOrEmpty(prio) || string.IsNullOrEmpty(pgn) || string.IsNullOrEmpty(addr))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }
            if (prio.Length != 2 || pgn.Length != 4 || addr.Length != 2)
            {
                MessageBox.Show("Invalid lengths for fields. Prio must be 2, PGN must be 4, and Addr must be 2.");
                return;
            }
            Global_UseFilter = !Global_UseFilter;
            if (Global_UseFilter)
            {
                btn_filter.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                btn_filter.BackColor = System.Drawing.Color.White;
            }
        }

        private void btn_mode_send_Click(object sender, EventArgs e)
        {
        }

        private void btn_hand_ack_send_Click(object sender, EventArgs e)
        {
            bool changoverbitbalue = false;
            if (radioButton_ChangeOver.Checked == true) { changoverbitbalue = true; }
            axioInstance.Send_changeoverRequ(changoverbitbalue);
        }

        private void btn_hand_syn_send_Click(object sender, EventArgs e)
        {
        }

        private void btn_SendSysInfo_Click(object sender, EventArgs e)
        {
            isSendingSysInfo_FF8C = !isSendingSysInfo_FF8C;
            if (isSendingSysInfo_FF8C)
            {
                sendRateInfo = System.Convert.ToInt32(tb_info_rate_val.Text);
                timer_Info_FF08_Rate.Interval = sendRateInfo;
                timer_Info_FF08_Rate.Start();
                btn_sysinfo_toggsend.BackColor = System.Drawing.Color.Green;
                btn_sysinfo_toggsend.Text = "send FF8C at " + sendRateInfo.ToString();
            }
            else
            {
                timer_Info_FF08_Rate.Stop();
                btn_sysinfo_toggsend.BackColor = System.Drawing.Color.White;
                btn_sysinfo_toggsend.Text = "is NOT sending sysinfo";
            }
        }

        private void btn_sysinfo_convert_Click(object sender, EventArgs e)
        {
            string sysinfo_Byte0_str = "";
            if (tb_sysinfo_byt0_b0.Text != "0") tb_sysinfo_byt0_b0.Text = "1";
            if (tb_sysinfo_byt0_b1.Text != "0") tb_sysinfo_byt0_b1.Text = "1";
            if (tb_sysinfo_byt0_b2.Text != "0") tb_sysinfo_byt0_b2.Text = "1";
            if (tb_sysinfo_byt0_b3.Text != "0") tb_sysinfo_byt0_b3.Text = "1";
            if (tb_sysinfo_byt0_b4.Text != "0") tb_sysinfo_byt0_b4.Text = "1";
            if (tb_sysinfo_byt0_b5.Text != "0") tb_sysinfo_byt0_b5.Text = "1";
            if (tb_sysinfo_byt0_b6.Text != "0") tb_sysinfo_byt0_b6.Text = "1";
            if (tb_sysinfo_byt0_b7.Text != "0") tb_sysinfo_byt0_b7.Text = "1";
            if (tb_sysinfo_byt1_b0.Text != "0") tb_sysinfo_byt1_b0.Text = "1";
            if (tb_sysinfo_byt1_b1.Text != "0") tb_sysinfo_byt1_b1.Text = "1";
            if (tb_sysinfo_byt1_b2.Text != "0") tb_sysinfo_byt1_b2.Text = "1";
            if (tb_sysinfo_byt1_b3.Text != "0") tb_sysinfo_byt1_b3.Text = "1";
            if (tb_sysinfo_byt1_b4.Text != "0") tb_sysinfo_byt1_b4.Text = "1";
            if (tb_sysinfo_byt1_b5.Text != "0") tb_sysinfo_byt1_b5.Text = "1";
            if (tb_sysinfo_byt1_b6.Text != "0") tb_sysinfo_byt1_b6.Text = "1";
            if (tb_sysinfo_byt1_b7.Text != "0") tb_sysinfo_byt1_b7.Text = "1";
            if (tb_sysinfo_byt5_b1.Text != "0") tb_sysinfo_byt5_b1.Text = "1";
            if (tb_sysinfo_byt5_b2.Text != "0") tb_sysinfo_byt5_b2.Text = "1";
            if (tb_sysinfo_byt7_b0.Text != "0") tb_sysinfo_byt7_b0.Text = "1";
            if (tb_sysinfo_byt7_b1.Text != "0") tb_sysinfo_byt7_b1.Text = "1";
            if (tb_sysinfo_byt7_b2.Text != "0") tb_sysinfo_byt7_b2.Text = "1";
            if (tb_sysinfo_byt7_b4.Text != "0") tb_sysinfo_byt7_b4.Text = "1";
            if (tb_sysinfo_byt7_b5.Text != "0") tb_sysinfo_byt7_b5.Text = "1";
            if (tb_sysinfo_byt7_b6.Text != "0") tb_sysinfo_byt7_b6.Text = "1";
            string B0_ = tb_sysinfo_byt0_b7.Text +
                tb_sysinfo_byt0_b6.Text +
                tb_sysinfo_byt0_b5.Text +
                tb_sysinfo_byt0_b4.Text +
                tb_sysinfo_byt0_b3.Text +
                tb_sysinfo_byt0_b2.Text +
                tb_sysinfo_byt0_b1.Text +
                tb_sysinfo_byt0_b0.Text;
            string B1_ = tb_sysinfo_byt1_b7.Text +
                tb_sysinfo_byt1_b6.Text +
                tb_sysinfo_byt1_b5.Text +
                tb_sysinfo_byt1_b4.Text +
                tb_sysinfo_byt1_b3.Text +
                tb_sysinfo_byt1_b2.Text +
                tb_sysinfo_byt1_b1.Text +
                tb_sysinfo_byt1_b0.Text;
            string B2_ = tb_sysinfo_byt2_100.Text;
            string B3_ = tb_sysinfo_byt3_100.Text;
            string B4_ = tb_sysinfo_byt4_100.Text;
            string B5_ = "00000" + tb_sysinfo_byt5_b2.Text + tb_sysinfo_byt5_b1.Text + "0";
            string B6_ = tb_sysinfo_byt6_100.Text;
            string B7_ = "0" +
                tb_sysinfo_byt7_b6.Text +
                tb_sysinfo_byt7_b5.Text +
                tb_sysinfo_byt7_b4.Text +
                "0" +
                tb_sysinfo_byt7_b2.Text +
                tb_sysinfo_byt7_b1.Text +
                tb_sysinfo_byt7_b0.Text;
            byte byte0= 0;
            byte byte1= 0;
            byte byte2= 0;
            byte byte3= 0;
            byte byte4= 0;
            byte byte5= 0;
            byte byte6= 0;
            byte byte7= 0;

            for (int i = 0; i < 8; i++) { if (B0_[i] == '1') { byte0 |= (byte)(1 << (7 - i)); } }
            for (int i = 0; i < 8; i++) { if (B1_[i] == '1') { byte1 |= (byte)(1 << (7 - i)); } }
            byte2 = System.Convert.ToByte(B2_); if (byte2 > 100) byte2 = 100;
            byte3 = System.Convert.ToByte(B3_); if (byte3 > 100) byte3 = 100;
            byte4 = System.Convert.ToByte(B4_); if (byte4 > 100) byte4 = 100;
            for (int i = 0; i < 8; i++) { if (B5_[i] == '1') { byte5 |= (byte)(1 << (7 - i)); } }
            byte6 = System.Convert.ToByte(B6_); if (byte6 > 100) byte6 = 100;
            for (int i = 0; i < 8; i++) { if (B7_[i] == '1') { byte7 |= (byte)(1 << (7 - i)); } }
            lbl_sysinfo_byt0_val.Text = byte0.ToString();
            lbl_sysinfo_byt1_val.Text = byte1.ToString();
            lbl_sysinfo_byt2_val.Text = byte2.ToString();
            lbl_sysinfo_byt3_val.Text = byte3.ToString();
            lbl_sysinfo_byt4_val.Text = byte4.ToString();
            lbl_sysinfo_byt5_val.Text = byte5.ToString();
            lbl_sysinfo_byt6_val.Text = byte6.ToString();
            lbl_sysinfo_byt7_val.Text = byte7.ToString();
            axioInstance.STORE_sysInfo(byte0, byte1, byte2, byte3, byte4, byte5, byte6, byte7);
        }

        private void On_rateChanged(object sender, EventArgs e)
        {
            sendRateInfo = System.Convert.ToInt32(tb_info_rate_val.Text);
        }



    }
}
   