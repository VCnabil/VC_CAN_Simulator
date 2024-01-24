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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VC_CAN_Simulator.UIz.FormzNavUC
{
    public partial class ucf_KvaserCanModule : UserControl
    {
        int frameCount = 0;
        public ucf_KvaserCanModule()
        {
            InitializeComponent();
            timer0_TestForm.Tick += new EventHandler(LOOP_Tick);
            timer0_TestForm.Interval = 400;
            timer0_TestForm.Start();
            timer0_TestForm.Enabled = false;

            checkBox_LoopRunning.CheckedChanged += new EventHandler(checkBox_LoopRunning_CheckedChanged);
            button1_initcan.Click += new EventHandler(button1_initcan_Click);
            button1_KillCan.Click += new EventHandler(button1_KillCan_Click);
            textBox_Rate.TextChanged += new EventHandler(textBox_Rate_TextChanged);
        }

        private void textBox_Rate_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Rate.Text, out int newInterval) && newInterval >= 100 && newInterval <= 6000)
            {
                timer0_TestForm.Interval = newInterval;
            }
        }

        bool CheckifOnCan()
        {
            if (KvsrManager.Instance.GetIsOnBus())
            {
                lbl_bussStatus.BackColor = Color.Green;
                return true;
            }
            else
            {
                lbl_bussStatus.BackColor = Color.Red;
                return false;
            }
        }
        private void button1_initcan_Click(object sender, EventArgs e)
        {
            KvsrManager.Instance.Init();
            CheckifOnCan();
        }
        private void button1_KillCan_Click(object sender, EventArgs e)
        {
            KvsrManager.Instance.Close();
            CheckifOnCan();
        }

        private void checkBox_LoopRunning_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_LoopRunning.Checked)
            {
                timer0_TestForm.Enabled = true;
            }
            else
            {
                timer0_TestForm.Enabled = false;
            }
        }

        private void LOOP_Tick(object sender, EventArgs e)
        {
            label1_errors.Text = KvsrManager.Instance.GetErrorMessage();
            frameCount++;
            label4.Text = frameCount.ToString();
            if (!CheckifOnCan())
            {
                KvsrManager.Instance.Close();
                CheckifOnCan();
            }

            byte[] testarra = new byte[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

            int stat = KvsrManager.Instance.SendPGN_withStatus(0x18FEEF29, testarra);
            if (stat != 0)
            {
                KvsrManager.Instance.Close();
                CheckifOnCan();
            }
            label1_errors.Text = "";

        }


    }
}
