using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.ManipUC.MicroUnits
{
    public partial class uc_microRadioButton : UserControl
    {
        public int ID { get; private set; }
        public event EventHandler RadioButtonChecked;
        public uc_microRadioButton(int iD)
        {
            InitializeComponent();
            ID = iD;
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Invoke the public event when radioButton1 is checked
            if (radioButton1.Checked)
            {
                RadioButtonChecked?.Invoke(this, e);
            }
        }
    }
}

