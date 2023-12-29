using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    public partial class PGN_Builder_UC : UserControl
    {
        public event EventHandler Btn_delete_was_Clicked_Event;
        private const int MaxCtrls = 8; // Maximum number of CTRL_Builder_UC instances
        int ctrl_builder_Width = 0;
        int ctrl_builder_Height = 0;
        public PGN_Builder_UC()
        {
            InitializeComponent();
            btn_AddCtrl.Click += Btn_AddCtrl_Click;
            btn_delte.Click += Btn_delte_Click;
        }

        private void Btn_delte_Click(object sender, EventArgs e)
        {
            Btn_delete_was_Clicked_Event?.Invoke(this, e);
        }

        private void Btn_AddCtrl_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count < MaxCtrls)
            {
                var newCtrl = new CTRL_Builder_UC();
                //newCtrl.Width = ctrl_builder_Width;
                //newCtrl.Height = ctrl_builder_Height;

                //            ctrl_builder_Width =newCtrl.Width ;
                //                ctrl_builder_Height = newCtrl.Height;


                // Subscribe to the RemoveButtonClicked event
                newCtrl.RemoveButtonClicked += NewCtrl_RemoveButtonClicked;

                flowLayoutPanel1.Controls.Add(newCtrl);

                if (flowLayoutPanel1.Controls.Count >= MaxCtrls)
                {
                    btn_AddCtrl.Enabled = false;
                }
            }
        }
        private void NewCtrl_RemoveButtonClicked(object sender, EventArgs e)
        {
            
            // Handle the event here
            // Example: Remove the control from the flowLayoutPanel
            var ctrl = sender as CTRL_Builder_UC;
            if (ctrl != null)
            {
                ctrl.RemoveButtonClicked -= NewCtrl_RemoveButtonClicked;
                flowLayoutPanel1.Controls.Remove(ctrl);
                btn_AddCtrl.Enabled = true;
            }
            
            
        }
    }
}
