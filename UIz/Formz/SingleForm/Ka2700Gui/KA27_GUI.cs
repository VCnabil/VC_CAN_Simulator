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

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.Ka2700Gui
{
    public partial class KA27_GUI : Form
    {
        CanManager canManager;
        bool status_loopRunning = false;
        bool increasing = false;
        bool autoMode = false;
        int all_tracker_value = 0;
        int pgn_01PortBucket = 0x0CFF001D;
        int pgn_02PortNozel = 0x0CFF021D;
        int pgn_03StbdNozel = 0x0CFF011D;
        int pgn_04StbdBucket = 0x0CFF031D;
        byte[] data_01_PortBucket;
        byte[] data_02_PortNoz;
        byte[] data_03_StbdNozzle;
        byte[] data_04_StbdBucket;
        public KA27_GUI()
        {
            InitializeComponent();

            data_04_StbdBucket = new byte[8];
            data_03_StbdNozzle = new byte[8];
            data_02_PortNoz = new byte[8];
            data_01_PortBucket = new byte[8];



            TrackBar1_PB.Minimum = 0;
            TrackBar1_PB.Maximum = 512;
            TrackBar1_PB.Value = 250;
            Label1_PB_Val.Text = TrackBar1_PB.Value.ToString();
            TrackBar1_PB.ValueChanged += metroTrackBar_PB_ValueChanged;


            TrackBar2_PN.Minimum = 0;
            TrackBar2_PN.Maximum = 512;
            TrackBar2_PN.Value = 250;
            Label2_PN_Val.Text = TrackBar2_PN.Value.ToString();
            TrackBar2_PN.ValueChanged += metroTrackBar_PN_ValueChanged;



            TrackBar3_SN.Minimum = 0;
            TrackBar3_SN.Maximum = 512;
            TrackBar3_SN.Value = 250;
            Label3_SN_Val.Text = TrackBar3_SN.Value.ToString();
            TrackBar3_SN.ValueChanged += metroTrackBar_SN_ValueChanged;

            TrackBar4_SB.Minimum = 0;
            TrackBar4_SB.Maximum = 512;
            TrackBar4_SB.Value = 250;
            Label4_SB_Val.Text = TrackBar4_SB.Value.ToString();
            TrackBar4_SB.ValueChanged += metroTrackBar_SB_ValueChanged;

             DoMIXlSetupHALVED();
            //DoNormalSetup();

            timerLoop.Tick += LOOP;
            timerLoop.Interval = 100;
            status_loopRunning = false;
            metroLabel_status.Text = "Ready";

            timer1_autoRun.Tick += autoRun;
            timer1_autoRun.Interval = 100;
            autoMode = false;

            metroButtonStart.Click += metroButton_Start_Click;
            metroButtonAUTO.Click += metroButton_Autorun_Click;


            canManager = new CanManager();
            canManager.ListChannels();
            canManager.OpenChannel(0);
            canManager.SetBusParams();
            canManager.GoOnBus();
            //740 1050
            this.Width = 720/2;
            this.Height = 1050/2;
        }

        void DoNormalSetup()
        {

            // 
            // label4_SB
            // 
            this.label4_SB.AutoSize = true;
            this.label4_SB.Location = new System.Drawing.Point(510/2/2, 100/2);
            this.label4_SB.Size = new System.Drawing.Size(124/2, 29/2);
            this.label4_SB.Text = "SB";
            // 
            // label1_PB
            // 
            this.label1_PB.AutoSize = true;
            this.label1_PB.Location = new System.Drawing.Point(10/2, 100/2);
            this.label1_PB.Size = new System.Drawing.Size(124/2, 29/2);
            this.label1_PB.Text = "PB";
            // 
            // label3_SN
            // 
            this.label3_SN.AutoSize = true;
            this.label3_SN.Location = new System.Drawing.Point(360/2, 100/2);
            this.label3_SN.Size = new System.Drawing.Size(126/2, 29/2);
            this.label3_SN.Text = "SN";
            // 
            // label2_PN
            // 
            this.label2_PN.AutoSize = true;
            this.label2_PN.Location = new System.Drawing.Point(160/2, 100/2);
            this.label2_PN.Size = new System.Drawing.Size(126/2, 29/2);
            this.label2_PN.Text = "PN";
            // 
            // TrackBar4_SB
            // 
            this.TrackBar4_SB.Location = new System.Drawing.Point(510/2, 150/2);
            this.TrackBar4_SB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar4_SB.Size = new System.Drawing.Size(101/2, 500/2);
            // 
            // TrackBar1_PB
            // 
            this.TrackBar1_PB.Location = new System.Drawing.Point(10/2, 150/2);
            this.TrackBar1_PB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar1_PB.Size = new System.Drawing.Size(101/2, 500/2);
            // 
            // TrackBar3_SN
            // 
            this.TrackBar3_SN.Location = new System.Drawing.Point(360/2, 150/2);
            this.TrackBar3_SN.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar3_SN.Size = new System.Drawing.Size(101/2, 500/2);
            // 
            // TrackBar2_PN
            // 
            this.TrackBar2_PN.Location = new System.Drawing.Point(160/2, 150/2);
            this.TrackBar2_PN.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar2_PN.Size = new System.Drawing.Size(101/2, 500/2);
            // 
            // Label4_SB_Val
            // 
            this.Label4_SB_Val.AutoSize = true;
            this.Label4_SB_Val.Location = new System.Drawing.Point(510/2, 653/2);
            this.Label4_SB_Val.Size = new System.Drawing.Size(106/2, 29/2);
            this.Label4_SB_Val.Text = "lbl4_sbV";
            // 
            // Label1_PB_Val
            // 
            this.Label1_PB_Val.AutoSize = true;
            this.Label1_PB_Val.Location = new System.Drawing.Point(10/2, 650/2);
            this.Label1_PB_Val.Size = new System.Drawing.Size(102/2, 29/2);
            this.Label1_PB_Val.Text = "lb1_pbV";
            // 
            // Label3_SN_Val
            // 
            this.Label3_SN_Val.AutoSize = true;
            this.Label3_SN_Val.Location = new System.Drawing.Point(360/2, 650/2);
            this.Label3_SN_Val.Size = new System.Drawing.Size(105/2, 29/2);
            this.Label3_SN_Val.Text = "lbl3_snV";
            // 
            // Label2_PN_Val
            // 
            this.Label2_PN_Val.AutoSize = true;
            this.Label2_PN_Val.Location = new System.Drawing.Point(160/2, 650/2);
            this.Label2_PN_Val.Size = new System.Drawing.Size(107/2, 29/2);
            this.Label2_PN_Val.Text = "lbl2_pnV";

        }
        void DoMIXlSetup()
        {

            //*********************************
            // 
            // label4_SB
            // 
            this.label4_SB.AutoSize = true;
            this.label4_SB.Location = new System.Drawing.Point(510, 100);
            this.label4_SB.Size = new System.Drawing.Size(124, 29);
            this.label4_SB.Text = "SB";
            // 
            // label1_PB
            // 
            this.label1_PB.AutoSize = true;
            this.label1_PB.Location = new System.Drawing.Point(10, 100);
            this.label1_PB.Size = new System.Drawing.Size(124, 29);
            this.label1_PB.Text = "PB";
            // 
            // label3_SN
            // 
            this.label3_SN.AutoSize = true;
            this.label3_SN.Location = new System.Drawing.Point(212, 653);//changed
            this.label3_SN.Size = new System.Drawing.Size(126, 29);
            this.label3_SN.Text = "SN";
            // 
            // label2_PN
            // 
            this.label2_PN.AutoSize = true;
            this.label2_PN.Location = new System.Drawing.Point(212, 818);//changed
            this.label2_PN.Size = new System.Drawing.Size(126, 29);
            this.label2_PN.Text = "PN";
            // 
            // TrackBar4_SB
            // 
            this.TrackBar4_SB.Location = new System.Drawing.Point(510, 150);
            this.TrackBar4_SB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar4_SB.Size = new System.Drawing.Size(101, 500);
            // 
            // TrackBar1_PB
            // 
            this.TrackBar1_PB.Location = new System.Drawing.Point(10, 150);
            this.TrackBar1_PB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar1_PB.Size = new System.Drawing.Size(101, 500);
            // 
            // TrackBar3_SN
            // 
            this.TrackBar3_SN.Location = new System.Drawing.Point(15, 860);//changed
            this.TrackBar3_SN.Orientation = System.Windows.Forms.Orientation.Horizontal;//changed
            this.TrackBar3_SN.Size = new System.Drawing.Size(101, 500);
            // 
            // TrackBar2_PN
            // 
            this.TrackBar2_PN.Location = new System.Drawing.Point(15, 714); //changed
            this.TrackBar2_PN.Orientation = System.Windows.Forms.Orientation.Horizontal;//changed
            this.TrackBar2_PN.Size = new System.Drawing.Size(101, 500);
            // 
            // Label4_SB_Val
            // 
            this.Label4_SB_Val.AutoSize = true;
            this.Label4_SB_Val.Location = new System.Drawing.Point(510, 653);
            this.Label4_SB_Val.Size = new System.Drawing.Size(106, 29);
            this.Label4_SB_Val.Text = "lbl4_sbV";
            // 
            // Label1_PB_Val
            // 
            this.Label1_PB_Val.AutoSize = true;
            this.Label1_PB_Val.Location = new System.Drawing.Point(10, 650);
            this.Label1_PB_Val.Size = new System.Drawing.Size(102, 29);
            this.Label1_PB_Val.Text = "lb1_pbV";
            // 
            // Label3_SN_Val
            // 
            this.Label3_SN_Val.AutoSize = true;
            this.Label3_SN_Val.Location = new System.Drawing.Point(513, 871);//changed
            this.Label3_SN_Val.Size = new System.Drawing.Size(105, 29);
            this.Label3_SN_Val.Text = "lbl3_snV";
            // 
            // Label2_PN_Val
            // 
            this.Label2_PN_Val.AutoSize = true;
            this.Label2_PN_Val.Location = new System.Drawing.Point(511, 735);//changed
            this.Label2_PN_Val.Size = new System.Drawing.Size(107, 29);
            this.Label2_PN_Val.Text = "lbl2_pnV";

        }
        void DoNormalSetupHALVED()
        {

            // 
            // label4_SB
            // 
            this.label4_SB.AutoSize = true;
            this.label4_SB.Location = new System.Drawing.Point(510 / 2, 100 / 2);
            this.label4_SB.Size = new System.Drawing.Size(124 / 2, 29 / 2);
            this.label4_SB.Text = "SB";
            // 
            // label1_PB
            // 
            this.label1_PB.AutoSize = true;
            this.label1_PB.Location = new System.Drawing.Point(10 / 2, 100 / 2);
            this.label1_PB.Size = new System.Drawing.Size(124 / 2, 29 / 2);
            this.label1_PB.Text = "PB";
            // 
            // label3_SN
            // 
            this.label3_SN.AutoSize = true;
            this.label3_SN.Location = new System.Drawing.Point(360 / 2, 100 / 2);
            this.label3_SN.Size = new System.Drawing.Size(126 / 2, 29 / 2);
            this.label3_SN.Text = "SN";
            // 
            // label2_PN
            // 
            this.label2_PN.AutoSize = true;
            this.label2_PN.Location = new System.Drawing.Point(160 / 2, 100 / 2);
            this.label2_PN.Size = new System.Drawing.Size(126 / 2, 29 / 2);
            this.label2_PN.Text = "PN";
            // 
            // TrackBar4_SB
            // 
            this.TrackBar4_SB.Location = new System.Drawing.Point(510 / 2, 150 / 2);
            this.TrackBar4_SB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar4_SB.Size = new System.Drawing.Size(101 / 2, 500 / 2);
            // 
            // TrackBar1_PB
            // 
            this.TrackBar1_PB.Location = new System.Drawing.Point(10 / 2, 150 / 2);
            this.TrackBar1_PB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar1_PB.Size = new System.Drawing.Size(101 / 2, 500 / 2);
            // 
            // TrackBar3_SN
            // 
            this.TrackBar3_SN.Location = new System.Drawing.Point(360 / 2, 150 / 2);
            this.TrackBar3_SN.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar3_SN.Size = new System.Drawing.Size(101 / 2, 500 / 2);
            // 
            // TrackBar2_PN
            // 
            this.TrackBar2_PN.Location = new System.Drawing.Point(160 / 2, 150 / 2);
            this.TrackBar2_PN.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar2_PN.Size = new System.Drawing.Size(101 / 2, 500 / 2);
            // 
            // Label4_SB_Val
            // 
            this.Label4_SB_Val.AutoSize = true;
            this.Label4_SB_Val.Location = new System.Drawing.Point(510 / 2, 653 / 2);
            this.Label4_SB_Val.Size = new System.Drawing.Size(106 / 2, 29 / 2);
            this.Label4_SB_Val.Text = "lbl4_sbV";
            // 
            // Label1_PB_Val
            // 
            this.Label1_PB_Val.AutoSize = true;
            this.Label1_PB_Val.Location = new System.Drawing.Point(10 / 2, 650 / 2);
            this.Label1_PB_Val.Size = new System.Drawing.Size(102 / 2, 29 / 2);
            this.Label1_PB_Val.Text = "lb1_pbV";
            // 
            // Label3_SN_Val
            // 
            this.Label3_SN_Val.AutoSize = true;
            this.Label3_SN_Val.Location = new System.Drawing.Point(360 / 2, 650 / 2);
            this.Label3_SN_Val.Size = new System.Drawing.Size(105 / 2, 29 / 2);
            this.Label3_SN_Val.Text = "lbl3_snV";
            // 
            // Label2_PN_Val
            // 
            this.Label2_PN_Val.AutoSize = true;
            this.Label2_PN_Val.Location = new System.Drawing.Point(160 / 2, 650 / 2);
            this.Label2_PN_Val.Size = new System.Drawing.Size(107 / 2, 29 / 2);
            this.Label2_PN_Val.Text = "lbl2_pnV";

        }
        void DoMIXlSetupHALVED()
        {

            //*********************************
            // 
            // label4_SB
            // 
            this.label4_SB.AutoSize = true;
            this.label4_SB.Location = new System.Drawing.Point(510 / 2, 100 / 2);
            this.label4_SB.Size = new System.Drawing.Size(124 / 2, 29 / 2);
            this.label4_SB.Text = "SB";
            // 
            // label1_PB
            // 
            this.label1_PB.AutoSize = true;
            this.label1_PB.Location = new System.Drawing.Point(10 / 2, 100 / 2);
            this.label1_PB.Size = new System.Drawing.Size(124 / 2, 29 / 2);
            this.label1_PB.Text = "PB";
            // 
            // label3_SN
            // 
            this.label3_SN.AutoSize = true;
            this.label3_SN.Location = new System.Drawing.Point(212 / 2, 653 / 2);//changed
            this.label3_SN.Size = new System.Drawing.Size(126 / 2, 29 / 2);
            this.label3_SN.Text = "SN";
            // 
            // label2_PN
            // 
            this.label2_PN.AutoSize = true;
            this.label2_PN.Location = new System.Drawing.Point(212 / 2, 818 / 2);//changed
            this.label2_PN.Size = new System.Drawing.Size(126 / 2, 29 / 2);
            this.label2_PN.Text = "PN";
            // 
            // TrackBar4_SB
            // 
            this.TrackBar4_SB.Location = new System.Drawing.Point(510 / 2, 150 / 2);
            this.TrackBar4_SB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar4_SB.Size = new System.Drawing.Size(101 / 2, 500 / 2);
            // 
            // TrackBar1_PB
            // 
            this.TrackBar1_PB.Location = new System.Drawing.Point(10 / 2, 150 / 2);
            this.TrackBar1_PB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBar1_PB.Size = new System.Drawing.Size(101 / 2, 500 / 2);
            // 
            // TrackBar3_SN
            // 
            this.TrackBar3_SN.Location = new System.Drawing.Point(15 / 2, 860 / 2);//changed
            this.TrackBar3_SN.Orientation = System.Windows.Forms.Orientation.Horizontal;//changed
            this.TrackBar3_SN.Size = new System.Drawing.Size(500 / 2, 101 / 2);//changed
            // 
            // TrackBar2_PN
            // 
            this.TrackBar2_PN.Location = new System.Drawing.Point(15 / 2, 714 / 2); //changed
            this.TrackBar2_PN.Orientation = System.Windows.Forms.Orientation.Horizontal;//changed
            this.TrackBar2_PN.Size = new System.Drawing.Size(500 / 2, 101 / 2);//changed
            // 
            // Label4_SB_Val
            // 
            this.Label4_SB_Val.AutoSize = true;
            this.Label4_SB_Val.Location = new System.Drawing.Point(510 / 2, 653 / 2);
            this.Label4_SB_Val.Size = new System.Drawing.Size(106 / 2, 29 / 2);
            this.Label4_SB_Val.Text = "lbl4_sbV";
            // 
            // Label1_PB_Val
            // 
            this.Label1_PB_Val.AutoSize = true;
            this.Label1_PB_Val.Location = new System.Drawing.Point(10 / 2, 650 / 2);
            this.Label1_PB_Val.Size = new System.Drawing.Size(102 / 2, 29 / 2);
            this.Label1_PB_Val.Text = "lb1_pbV";
            // 
            // Label3_SN_Val
            // 
            this.Label3_SN_Val.AutoSize = true;
            this.Label3_SN_Val.Location = new System.Drawing.Point(513 / 2, 871 / 2);//changed
            this.Label3_SN_Val.Size = new System.Drawing.Size(105 / 2, 29 / 2);
            this.Label3_SN_Val.Text = "lbl3_snV";
            // 
            // Label2_PN_Val
            // 
            this.Label2_PN_Val.AutoSize = true;
            this.Label2_PN_Val.Location = new System.Drawing.Point(511 / 2, 735 / 2);//changed
            this.Label2_PN_Val.Size = new System.Drawing.Size(107 / 2, 29 / 2);
            this.Label2_PN_Val.Text = "lbl2_pnV";

        }
        private void autoRun(object sender, EventArgs e)
        {
            int step = 5; // Change this value to control the speed of movement
            int max = 512;
            int min = 0;

            if (increasing)
            {
                all_tracker_value += step;
                if (all_tracker_value >= max)
                {
                    all_tracker_value = max;
                    increasing = false;
                }
            }
            else
            {
                all_tracker_value -= step;
                if (all_tracker_value <= min)
                {
                    all_tracker_value = min;
                    increasing = true;
                }
            }

            UpdateTrackers(all_tracker_value);
        }

        private void LOOP(object sender, EventArgs e)
        {
            return;
            canManager.SendMessage(0x0CFF031D, data_04_StbdBucket);
            canManager.SendMessage(0x0CFF011D, data_03_StbdNozzle);
            canManager.SendMessage(0x0CFF021D, data_02_PortNoz);
            canManager.SendMessage(0x0CFF021D, data_01_PortBucket);

        }

        private void UpdateTrackers(int value)
        {
            TrackBar1_PB.Value = value;
            TrackBar2_PN.Value = value;
            TrackBar3_SN.Value = value;
            TrackBar4_SB.Value = value;

            Label1_PB_Val.Text = value.ToString();
            Label2_PN_Val.Text = value.ToString();
            Label3_SN_Val.Text = value.ToString();
            Label4_SB_Val.Text = value.ToString();

            data_01_PortBucket[0] = (byte)(value & 0x0FF);
            data_01_PortBucket[1] = (byte)((value >> 8) & 0x0FF);
            data_02_PortNoz[0] = (byte)(value & 0x0FF);
            data_02_PortNoz[1] = (byte)((value >> 8) & 0x0FF);
            data_03_StbdNozzle[0] = (byte)(value & 0x0FF);
            data_03_StbdNozzle[1] = (byte)((value >> 8) & 0x0FF);
            data_04_StbdBucket[0] = (byte)(value & 0x0FF);
            data_04_StbdBucket[1] = (byte)((value >> 8) & 0x0FF);
        }

        private void metroTrackBar_SB_ValueChanged(object sender, EventArgs e)
        {
            if (!autoMode)
            {
                Label4_SB_Val.Text = TrackBar4_SB.Value.ToString();
                data_04_StbdBucket[0] = (byte)(TrackBar4_SB.Value & 0x0FF);
                data_04_StbdBucket[1] = (byte)((TrackBar4_SB.Value >> 8) & 0x0FF);
            }
        }

        private void metroTrackBar_SN_ValueChanged(object sender, EventArgs e)
        {
            if (!autoMode)
            {
                Label3_SN_Val.Text = TrackBar3_SN.Value.ToString();
                data_03_StbdNozzle[0] = (byte)(TrackBar3_SN.Value & 0x0FF);
                data_03_StbdNozzle[1] = (byte)((TrackBar3_SN.Value >> 8) & 0x0FF);
            }
        }

        private void metroTrackBar_PN_ValueChanged(object sender, EventArgs e)
        {
            if (!autoMode)
            {
                Label2_PN_Val.Text = TrackBar2_PN.Value.ToString();
                data_02_PortNoz[0] = (byte)(TrackBar2_PN.Value & 0x0FF);
                data_02_PortNoz[1] = (byte)((TrackBar2_PN.Value >> 8) & 0x0FF);
            }
        }

        private void metroTrackBar_PB_ValueChanged(object sender, EventArgs e)
        {
            if (!autoMode)
            {
                Label1_PB_Val.Text = TrackBar1_PB.Value.ToString();
                data_01_PortBucket[0] = (byte)(TrackBar1_PB.Value & 0x0FF);
                data_01_PortBucket[1] = (byte)((TrackBar1_PB.Value >> 8) & 0x0FF);
            }
        }


        private void metroButton_Start_Click(object sender, EventArgs e)
        {
            if (status_loopRunning)
            {
                timerLoop.Stop();
                status_loopRunning = false;
                metroLabel_status.Text = "Ready";
                metroButtonStart.Text = "Start";
            }
            else
            {
                timerLoop.Start();
                status_loopRunning = true;
                metroLabel_status.Text = "Running";
                metroButtonStart.Text = "Stop";
            }
        }

        private void metroButton_Autorun_Click(object sender, EventArgs e)
        {
            if (autoMode)
            {
                timer1_autoRun.Stop();
                autoMode = false;
                metroButtonAUTO.Text = "Auto On";
            }
            else
            {
                timer1_autoRun.Start();
                autoMode = true;
                metroButtonAUTO.Text = "Auto Off";
            }
        }

        private void Label1_PB_Val_Click(object sender, EventArgs e)
        {
            if (autoMode) return;
            TrackBar1_PB.Value = 250;
        }

        private void Label2_PN_Val_Click(object sender, EventArgs e)
        {
            if (autoMode) return;
            TrackBar2_PN.Value = 250;
        }

        private void Label3_SN_Val_Click(object sender, EventArgs e)
        {
            if (autoMode) return;
            TrackBar3_SN.Value = 250;
        }

        private void Label4_SB_Val_Click(object sender, EventArgs e)
        {
            if (autoMode) return;
            TrackBar4_SB.Value = 250;
        }
    }
}
