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
    public partial class PROJECT_Builder_UC : UserControl
    {
        private const int MaxPGNs = 12;
        public PROJECT_Builder_UC()
        {
            InitializeComponent();
            fl_verticalpannel.FlowDirection = FlowDirection.TopDown;

            btn_AddPGN.Click += Btn_AddPGN_Click;

        }

        private void Btn_AddPGN_Click(object sender, EventArgs e)
        {
            if (fl_verticalpannel.Controls.Count < MaxPGNs)
            {
                var newPGN = new PGN_Builder_UC();
                  fl_verticalpannel.Controls.Add(newPGN);
                newPGN.Btn_delete_was_Clicked_Event += NewPGN_RemoveButtonClicked;
                if (fl_verticalpannel.Controls.Count >= MaxPGNs)
                {
                    btn_AddPGN.Enabled = false;
                }
            }
        }

        private void NewPGN_RemoveButtonClicked(object sender, EventArgs e)
        {
            var pgn = sender as PGN_Builder_UC;
            if (pgn != null)
            {
                 fl_verticalpannel.Controls.Remove(pgn);
                pgn.Btn_delete_was_Clicked_Event -= NewPGN_RemoveButtonClicked;
                btn_AddPGN.Enabled = true;
            }
        }
    }
}
