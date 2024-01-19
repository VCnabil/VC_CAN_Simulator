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
namespace VC_CAN_Simulator.UIz.Formz.SingleGUIs
{
    public partial class Foo_GUI : Form
    {
        bool texbixIsEmpty;
        int num = 0;
        public Foo_GUI()
        {
            InitializeComponent();
            button1.Text = "CC=" + num.ToString();
            button1.Click += new System.EventHandler(this.button1_Click);
            textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.FormClosing += new FormClosingEventHandler(FooForm_FormClosing);
            textBox1.Text = "";
            texbixIsEmpty = true;
            label1.Text = textBox1.Text;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            num++;
            button1.Text = "CC=" + num.ToString();
            if (textBox1.Text.Length > 0)
            {
                texbixIsEmpty = false;
            }
            else
            {
                texbixIsEmpty = true;
            }
            EventsManagerLib.CallHandBroadcast(button1.Text, num, texbixIsEmpty);
        }
        private void FooForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventsManagerLib.CallHandBroadcast("CLosing ", 0, true);
        }
    }
}