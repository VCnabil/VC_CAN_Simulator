using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.UControlz
{
    public partial class BinNameRow_uc : UserControl
    {
        public event EventHandler Btn_rem_was_Clicked_Event;
        public event EventHandler BitDescription_Changed_Event;
        public string BitDescription
        {
            get { return textBox_bitDescription.Text; }
            set { textBox_bitDescription.Text = value; }
        }
        public BinNameRow_uc()
        {
            InitializeComponent();
            btn_rem.Click += Btn_rem_Click;
            textBox_bitDescription.TextChanged += TextBox_bitDescription_TextChanged;
        }
        private void TextBox_bitDescription_TextChanged(object sender, EventArgs e)
        {
            BitDescription_Changed_Event?.Invoke(this, e);
        }
        private void Btn_rem_Click(object sender, EventArgs e)
        {
            Btn_rem_was_Clicked_Event?.Invoke(this, e);
        }
    }
}
