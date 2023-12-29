using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    public partial class CTRL_Builder_UC : UserControl
    {
        public event EventHandler RemoveButtonClicked;
        CtrlType Cur_ctrlType;
        public CTRL_Builder_UC()
        {
            InitializeComponent();
            PopulateComboBox();
            Cur_ctrlType = CtrlType._8_bs;
            cb_CtrlType.SelectedIndexChanged += cb_CtrlType_SelectedIndexChanged;
            btn_rem.Click += Btn_rem_Click;
        }

        private void Btn_rem_Click(object sender, EventArgs e)
        {
            RemoveButtonClicked?.Invoke(this, e);
        }

        private void PopulateComboBox()
        {
            cb_CtrlType.Items.Clear();
            foreach (var ctrlType in Enum.GetValues(typeof(CtrlType)))
            {
                cb_CtrlType.Items.Add(ctrlType.ToString());
            }
        }

        private void cb_CtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CtrlType.SelectedItem != null)
            {
                Cur_ctrlType = (CtrlType)Enum.Parse(typeof(CtrlType), cb_CtrlType.SelectedItem.ToString());
            }
        }
    }
}
