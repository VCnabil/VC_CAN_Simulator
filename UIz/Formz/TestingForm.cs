using Kvaser.CanLib;
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
using VC_CAN_Simulator.DataObjects;
using VC_CAN_Simulator.UIz.Formz.SingleGUIs;
using VC_CAN_Simulator.UIz.ManipUC;
using VC_CAN_Simulator.UIz.ManipUC.BuildersManips;
using VC_CAN_Simulator.UIz.UControlz.Builders;
using static VC_CAN_Simulator.Backend.Helpers;
namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class TestingForm : Form
    {
        private bool debugMode = false;
        int frameCount = 0;
        public TestingForm()
        {
            InitializeComponent();
            EventsManagerLib.OnHandBroadcast += new EventsManagerLib.EventHandBroadcastHandler(OnHandBroadcastHandler);
            timer0_TestForm.Tick += new EventHandler(LOOP_Tick);
            timer0_TestForm.Interval = 400;
            timer0_TestForm.Start();
            timer0_TestForm.Enabled = false;
            

            // Example: Using KvsrManager's method or properties
            // var result = KvsrManager.Instance.SomeMethod();
            checkBox_LoopRunning.CheckedChanged += new EventHandler(checkBox_LoopRunning_CheckedChanged);
            button1_initcan.Click += new EventHandler(button1_initcan_Click);
            button1_KillCan.Click += new EventHandler(button1_KillCan_Click);
        }


        bool CheckifOnCan() {
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
            if(checkBox_LoopRunning.Checked)
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

            if (!CheckifOnCan()) {
                KvsrManager.Instance.Close();
                CheckifOnCan();
            }

            byte[] testarra = new byte[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

            int stat = KvsrManager.Instance.SendPGN_withStatus(0x18FEEF, testarra);
            if(stat != 0)
            {
                if (debugMode)  MessageBox.Show("Failed to send PGN!!!!1");
                KvsrManager.Instance.Close();
                CheckifOnCan();
            }
            label1_errors.Text = "";

        }
       
    
        private void OnHandBroadcastHandler(string arg_strval, int arg_intval, bool arg_Bool0)
        {
            label1.Text = arg_strval;
            label2.Text = arg_intval.ToString();
            if (arg_Bool0)
            {
                label2.BackColor = Color.Red;
            }
            else
            {
                label2.BackColor = Color.White;
            }
        }
        private void bouton1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bouton 1 clicked!");
            Form fooForm = new Foo_GUI();
            fooForm.ShowDialog();
        }

        private void bouton3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}


 