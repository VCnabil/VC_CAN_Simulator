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
        public TestingForm()
        {
            InitializeComponent();
          //  this.bouton1ToolStripMenuItem.Click += new System.EventHandler(this.bouton1ToolStripMenuItem_Click);
            EventsManagerLib.OnHandBroadcast += new EventsManagerLib.EventHandBroadcastHandler(OnHandBroadcastHandler);
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


/*
 

            this.bouton2ToolStripMenuItem.Click += new System.EventHandler(this.bouton2ToolStripMenuItem_Click);
            this.bouton3ToolStripMenuItem.Click += new System.EventHandler(this.bouton3ToolStripMenuItem_Click);

//
         private void bouton2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bouton 2 clicked!");
        }
        private void bouton3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bouton 3 clicked!");
        }

 */