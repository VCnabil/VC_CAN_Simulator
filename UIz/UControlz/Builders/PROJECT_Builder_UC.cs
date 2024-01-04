using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.DataObjects;

namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    public partial class PROJECT_Builder_UC : UserControl
    {
        private const int MaxPGNs = 12;
        List<PGN_Builder_UC> listOf_PGN_UCs_InProject;
        int _pgnIdcnt = 0;
        public PROJECT_Builder_UC()
        {
            InitializeComponent();
            listOf_PGN_UCs_InProject = new List<PGN_Builder_UC>();
            fl_verticalpannel.FlowDirection = FlowDirection.TopDown;

            btn_AddPGN.Click += Btn_AddPGN_Click;

        }

        private void Btn_AddPGN_Click(object sender, EventArgs e)
        {
            if (fl_verticalpannel.Controls.Count < MaxPGNs)
            {
                var newPGN = new PGN_Builder_UC(_pgnIdcnt);
                _pgnIdcnt++;
                fl_verticalpannel.Controls.Add(newPGN);
                newPGN.Btn_delete_was_Clicked_Event += NewPGN_RemoveButtonClicked;
                listOf_PGN_UCs_InProject.Add(newPGN);
                if (fl_verticalpannel.Controls.Count >= MaxPGNs)
                {
                    btn_AddPGN.Enabled = false;
                }
            }
        }
        //public void AddFromBlueprint(int argpgnid, int argpgn, string argpgnStr, string argDescpgn, List<Ctrl_DataObject> argListCtrls)
        public void AddFromBlueprint(int argpgnid, int argpgn, string argpgnStr, string argDescpgn, List<Ctrl_DataObject> argCtrlDOlist ) {

            if (fl_verticalpannel.Controls.Count < MaxPGNs)
            {

                var newPGN = new PGN_Builder_UC( argpgnid,  argpgn,  argpgnStr,  argDescpgn, argCtrlDOlist);
                 
                fl_verticalpannel.Controls.Add(newPGN);
                newPGN.Btn_delete_was_Clicked_Event += NewPGN_RemoveButtonClicked;
                listOf_PGN_UCs_InProject.Add(newPGN);
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
                RemovePGNbuilder(pgn);
                
            }
        }
        void RemovePGNbuilder(PGN_Builder_UC argPgnBuilder) {
            fl_verticalpannel.Controls.Remove(argPgnBuilder);
            argPgnBuilder.Btn_delete_was_Clicked_Event -= NewPGN_RemoveButtonClicked;
            btn_AddPGN.Enabled = true;
            listOf_PGN_UCs_InProject.Remove(argPgnBuilder);
        }

        public void ClearAllPGNSRecursive() {

            for (int i = 0; i < listOf_PGN_UCs_InProject.Count; i++)
            {
                listOf_PGN_UCs_InProject[i].RemoveAllCtrlBuilder();
            }
            for (int r = listOf_PGN_UCs_InProject.Count-1;r>=0; r--)
            {
                RemovePGNbuilder(listOf_PGN_UCs_InProject[r]);
            }
            _pgnIdcnt = 0;

        }
        public Project_DataObject Make_ProjectDataObject() {

            List<Pgn_DataObject> templistargPgnlist = new List<Pgn_DataObject>();
           
            for (int i = 0; i < listOf_PGN_UCs_InProject.Count; i++) {
                templistargPgnlist.Add(listOf_PGN_UCs_InProject[i].Make_PGNDataObj());
            }
            Project_DataObject temp_Project_DataObj = new Project_DataObject("ssrs", templistargPgnlist);

            return temp_Project_DataObj;
        }
    }
}
