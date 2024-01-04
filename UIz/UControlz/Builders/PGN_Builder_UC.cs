using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.DataObjects;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    public partial class PGN_Builder_UC : UserControl
    {
        int _myPgnUcId = 0;
        public int MyPgnUcId { get { return _myPgnUcId; } private set { _myPgnUcId = value; } }
        bool[] IndecesUsed;
        int _ctrlrs_id = 0;
        public event EventHandler Btn_delete_was_Clicked_Event;
        private const int MaxCtrls = 8; // Maximum number of CTRL_Builder_UC instances
        int ctrl_builder_Width = 0;
        int ctrl_builder_Height = 0;
        List<CTRL_Builder_UC> ctrlBuilderList;

        string str_prio = string.Empty;
        string str_basepgn = string.Empty;
        string str_addres= string.Empty;
        string str_full_PGN= string.Empty;

        string pgnDesc = string.Empty;
        int int_full_PGN = 0;

        public PGN_Builder_UC(int argpgnid, int argpgn, string argpgnStr, string argDescpgn, List<Ctrl_DataObject> argCtrlDOlist)
        {
            InitializeComponent();
            IndecesUsed = new bool[8];
            ctrlBuilderList = new List<CTRL_Builder_UC>();
            Array.Clear(IndecesUsed, 0, IndecesUsed.Length);
            tb_multilineDesc.TextChanged += Tb_multilineDesc_TextChanged;
            btn_AddCtrl.Click += Btn_AddCtrl_Click;
            btn_delte.Click += Btn_deltePGN_Builder_Click;

            tb_prio.TextChanged += Tb_prio_TextChanged;
            tb_basepgn.TextChanged += Tb_basepgn_TextChanged;
            tb_adrs.TextChanged += Tb_adrs_TextChanged;

            if (argpgnStr.Length != 8)
            {
                throw new ArgumentException("Input string must be exactly 8 characters long.");
            }

            // Assuming the input format is always 2 characters for prio, 4 for pgn, and 2 for address
            str_full_PGN = argpgnStr;
            str_prio = str_full_PGN.Substring(0, 2);
            str_basepgn = str_full_PGN.Substring(2, 4);
            str_addres = str_full_PGN.Substring(6, 2);

            tb_prio.Text = str_prio;
            tb_basepgn.Text = str_basepgn;
            tb_adrs.Text = str_addres;
            _myPgnUcId = argpgnid;
            lbl_pgnBuilder_ID.Text += _myPgnUcId;

            tb_multilineDesc.Text = argDescpgn;
            pgnDesc = argDescpgn;

            if (flowLayoutPanel1.Controls.Count < MaxCtrls)
            {
                _ctrlrs_id++;
                var newCtrlBuilder = new CTRL_Builder_UC(argCtrlDOlist[0]);

                AddNewCtrlBuilder(newCtrlBuilder);
            }
        }
        public PGN_Builder_UC(int argpgnid, int argpgn, string argpgnStr, string argDescpgn )
        {
            InitializeComponent();
            IndecesUsed = new bool[8];
            ctrlBuilderList = new List<CTRL_Builder_UC>();
            Array.Clear(IndecesUsed, 0, IndecesUsed.Length);
            tb_multilineDesc.TextChanged += Tb_multilineDesc_TextChanged;
            btn_AddCtrl.Click += Btn_AddCtrl_Click;
            btn_delte.Click += Btn_deltePGN_Builder_Click;

            tb_prio.TextChanged += Tb_prio_TextChanged;
            tb_basepgn.TextChanged += Tb_basepgn_TextChanged;
            tb_adrs.TextChanged += Tb_adrs_TextChanged;

            if (argpgnStr.Length != 8)
            {
                throw new ArgumentException("Input string must be exactly 8 characters long.");
            }

            // Assuming the input format is always 2 characters for prio, 4 for pgn, and 2 for address
            str_full_PGN = argpgnStr;
            str_prio = str_full_PGN.Substring(0, 2);
            str_basepgn = str_full_PGN.Substring(2, 4);
            str_addres = str_full_PGN.Substring(6, 2);

            tb_prio.Text = str_prio;
            tb_basepgn.Text = str_basepgn;
            tb_adrs.Text = str_addres;
            _myPgnUcId = argpgnid;
            lbl_pgnBuilder_ID.Text += _myPgnUcId;

            tb_multilineDesc.Text = argDescpgn;
            pgnDesc = argDescpgn;

          
        }
        public PGN_Builder_UC(int argPgnUcId)
        {
            InitializeComponent();
            IndecesUsed = new bool[8];
            ctrlBuilderList = new List<CTRL_Builder_UC>();
            Array.Clear(IndecesUsed, 0, IndecesUsed.Length);
            tb_multilineDesc.TextChanged += Tb_multilineDesc_TextChanged;
            btn_AddCtrl.Click += Btn_AddCtrl_Click;
            btn_delte.Click += Btn_deltePGN_Builder_Click;

            tb_prio.TextChanged += Tb_prio_TextChanged;
            tb_basepgn.TextChanged += Tb_basepgn_TextChanged;
            tb_adrs.TextChanged += Tb_adrs_TextChanged;

            tb_prio.Text = str_prio;
            tb_basepgn.Text = str_basepgn;
            tb_adrs.Text = str_addres;
            _myPgnUcId = argPgnUcId;
            lbl_pgnBuilder_ID.Text += _myPgnUcId;
        }

        private void Tb_multilineDesc_TextChanged(object sender, EventArgs e)
        {
            pgnDesc = tb_multilineDesc.Text;
        }

        private void Tb_adrs_TextChanged(object sender, EventArgs e)
        {
            str_addres = tb_adrs.Text;
            Update_PGNstr();
        }

        private void Tb_basepgn_TextChanged(object sender, EventArgs e)
        {
            str_basepgn = tb_basepgn.Text;
            Update_PGNstr();
        }

        private void Tb_prio_TextChanged(object sender, EventArgs e)
        {
            str_prio= tb_prio.Text;
            Update_PGNstr();
        }

        void Update_PGNstr() {

            str_full_PGN = str_prio + str_basepgn + str_addres;
            lbl_FullHexPgn.Text = "0x"+ str_full_PGN;
            if (tb_prio.Text != string.Empty && tb_basepgn.Text != string.Empty && tb_adrs.Text != string.Empty)
            {
                int_full_PGN = HexStringToDecimal(str_full_PGN);
                lbl_FullPGN_DEC.Text = "d " + int_full_PGN.ToString();
                lbl_FullPGN_DEC.ForeColor = Color.Black;
            }
            else {
                lbl_FullPGN_DEC.Text = "PGN ERROR ";
                lbl_FullPGN_DEC.ForeColor = Color.Red;
            }
          
        }

        #region Events
        private void Btn_AddCtrl_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count < MaxCtrls)
            {
                _ctrlrs_id++;
                var newCtrlBuilder = new CTRL_Builder_UC(_ctrlrs_id);
  
                AddNewCtrlBuilder(newCtrlBuilder);  
            }
        }
        private void Btn_deltePGN_Builder_Click(object sender, EventArgs e)
        {
            Btn_delete_was_Clicked_Event?.Invoke(this, e);
        }
        private void CtrlBuilder_CtrlTypeChanged(object sender, EventArgs e)
        {
            ValidateCtrlBuilders();
        }
        private void CtrlBuilder_IndexChanged(object sender, EventArgs e)
        {
            ValidateCtrlBuilders();
        }
        private void Ctrl_RemoveButtonClicked(object sender, EventArgs e)
        {
            var ctrl = sender as CTRL_Builder_UC;
            if (ctrl != null)
            {
                RemoveCtrlBuilder(ctrl);
            }    
        }
        #endregion
        private void ValidateCtrlBuilders()
        {
            var indexSet = new HashSet<int>();
            foreach (var ctrlBuilder in ctrlBuilderList)
            {
                if (ctrlBuilder.CUR_TYPECtrl == CtrlType._2_by)
                {
                    if (!indexSet.Add(ctrlBuilder.IndexLO))
                    {

                        lbl_IndexConflicts.Text = "! LO at " + ctrlBuilder.ID;
                        lbl_IndexConflicts.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_IndexConflicts.Text = "OK LO";
                        lbl_IndexConflicts.ForeColor = Color.Black;
                    }

                    if (!indexSet.Add(ctrlBuilder.IndexHI))
                    {

                        lbl_IndexConflicts.Text = "! HI at " + ctrlBuilder.ID;
                        lbl_IndexConflicts.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_IndexConflicts.Text = "OK HI";
                        lbl_IndexConflicts.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (!indexSet.Add(ctrlBuilder.IndexLO))
                    {
                        // Handle index conflict for IndexLO
                        lbl_IndexConflicts.Text = "conf LO  at " + ctrlBuilder.ID;
                        lbl_IndexConflicts.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_IndexConflicts.Text = "OK ";
                        lbl_IndexConflicts.ForeColor = Color.Black;
                    }
                }

            }
        }
        public void AddNewCtrlBuilder(CTRL_Builder_UC newCtrlBuilder)
        {
            // Subscribe to events
            newCtrlBuilder.IndexChanged += CtrlBuilder_IndexChanged;
            newCtrlBuilder.Type_CTRL_Changed += CtrlBuilder_CtrlTypeChanged;
            newCtrlBuilder.Remove_CTRL_ButtonClicked += Ctrl_RemoveButtonClicked;
 
            // Add to the list
            ctrlBuilderList.Add(newCtrlBuilder);
            // Add to the UI if needed
            flowLayoutPanel1.Controls.Add(newCtrlBuilder);
            ValidateCtrlBuilders(); // Validate after adding
        }

        public void RemoveCtrlBuilder(CTRL_Builder_UC ctrlBuilder)
        {
            // Unsubscribe from events
            ctrlBuilder.IndexChanged -= CtrlBuilder_IndexChanged;
            ctrlBuilder.Type_CTRL_Changed -= CtrlBuilder_CtrlTypeChanged;
            ctrlBuilder.Remove_CTRL_ButtonClicked -= Ctrl_RemoveButtonClicked;

            // Remove from the list
            ctrlBuilderList.Remove(ctrlBuilder);

            // Remove from the UI if needed
            flowLayoutPanel1.Controls.Remove(ctrlBuilder);

            btn_AddCtrl.Enabled = true;

            ValidateCtrlBuilders(); // Validate after removing
        }

        public void RemoveAllCtrlBuilder()
        {
            for(int c = ctrlBuilderList.Count-1; c >=0; c--)
            {
                CTRL_Builder_UC ctrltoremove = ctrlBuilderList[c];
                RemoveCtrlBuilder(ctrltoremove);
            }
            _ctrlrs_id = 0;



        }
        public List<Ctrl_DataObject> Make_Listctrls() {

            List<Ctrl_DataObject> mylistOfCtrl_Objs = new List<Ctrl_DataObject>();

            for (int i = 0; i < ctrlBuilderList.Count; i++) {
                mylistOfCtrl_Objs.Add(ctrlBuilderList[i].Make_ctrlDataObject());
            }


            return mylistOfCtrl_Objs;
        }

        public Pgn_DataObject Make_PGNDataObj() {

            Pgn_DataObject tempPgnDataobj = new Pgn_DataObject(_myPgnUcId, int_full_PGN,str_full_PGN, pgnDesc, Make_Listctrls());

            return tempPgnDataobj;
        }
    }
}


/*
   private void CtrlBuilder_IndexChanged(object sender, EventArgs e)
        {
            if (sender is CTRL_Builder_UC ctrl)
            {
                Update_CLEARE_IndecesUsed(ctrl);
                update_Validate_IndecesUsed(ctrl);
            }
        }
        private void NewCtrl_RemoveButtonClicked(object sender, EventArgs e)
        {
            var ctrl = sender as CTRL_Builder_UC;
            if (ctrl != null)
            {
                ctrl.RemoveButtonClicked -= NewCtrl_RemoveButtonClicked;
                ctrl.IndexChanged -= CtrlBuilder_IndexChanged;
                ctrl.CtrlTypeChanged -= CtrlBuilder_CtrlTypeChanged;
                Update_CLEARE_IndecesUsed(ctrl);
                flowLayoutPanel1.Controls.Remove(ctrl);
             
                btn_AddCtrl.Enabled = true;
            }    
        }
 
        private void Btn_AddCtrl_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count < MaxCtrls)
            {
                _ctrlrs_id++;
                var newCtrl = new CTRL_Builder_UC(_ctrlrs_id);
                // Subscribe to the RemoveButtonClicked event
                newCtrl.RemoveButtonClicked += NewCtrl_RemoveButtonClicked;
                newCtrl.IndexChanged += CtrlBuilder_IndexChanged;
                newCtrl.CtrlTypeChanged += CtrlBuilder_CtrlTypeChanged;

                if(newCtrl.CUR_TYPECtrl== CtrlType._2_by)
                {
                    for (int i = 0; i < IndecesUsed.Length-1; i++)
                    {
                        if (!IndecesUsed[i])
                        {
                            newCtrl.Rectify_indexLO(i);
                            IndecesUsed[i] = true;
                            newCtrl.Rectify_indexHI(i+1);
                            IndecesUsed[i+1] = true;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < IndecesUsed.Length; i++)
                    {
                        if (!IndecesUsed[i])
                        {
                            newCtrl.Rectify_indexLO(i);
                            newCtrl.Rectify_indexHI(i);
                            IndecesUsed[i] = true;
                            break;
                        }
                    }
                }
                AllocateIndicesForNewCtrl(newCtrl);

                flowLayoutPanel1.Controls.Add(newCtrl);

                if (flowLayoutPanel1.Controls.Count >= MaxCtrls)
                {
                    btn_AddCtrl.Enabled = false;
                }
            }
            
        }
         private void CtrlBuilder_CtrlTypeChanged(object sender, EventArgs e)
        {
            if (sender is CTRL_Builder_UC ctrl)
            {
                Update_CLEARE_IndecesUsed(ctrl);
                update_Validate_IndecesUsed(ctrl);
            }
        }
 
   private void AllocateIndicesForNewCtrl(CTRL_Builder_UC newCtrl)
        {
            if (newCtrl.CUR_TYPECtrl == CtrlType._2_by)
            {
                for (int i = 0; i < IndecesUsed.Length - 1; i++)
                {
                    if (!IndecesUsed[i] && !IndecesUsed[i + 1])
                    {
                        newCtrl.Rectify_indexLO(i);
                        newCtrl.Rectify_indexHI(i + 1);
                        IndecesUsed[i] = IndecesUsed[i + 1] = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < IndecesUsed.Length; i++)
                {
                    if (!IndecesUsed[i])
                    {
                        newCtrl.Rectify_indexLO(i);
                        newCtrl.Rectify_indexHI(i);
                        IndecesUsed[i] = true;
                        break;
                    }
                }
            }
        }

        private void update_Validate_IndecesUsed(CTRL_Builder_UC argctrl)
        {
            StringBuilder confstr = new StringBuilder();
            bool conflictFound = false;

            foreach (CTRL_Builder_UC ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl.ID != argctrl.ID)
                {
                    // Check for conflicts in both IndexLO and IndexHI for _2_by type controls
                    if (argctrl.CUR_TYPECtrl == CtrlType._2_by)
                    {
                        if ((ctrl.IndexLO == argctrl.IndexLO || ctrl.IndexHI == argctrl.IndexHI) ||
                            (ctrl.CUR_TYPECtrl == CtrlType._2_by && (ctrl.IndexLO == argctrl.IndexHI || ctrl.IndexHI == argctrl.IndexLO)))
                        {
                            confstr.AppendLine($"Conflict with CTRL ID {ctrl.ID} at indices {ctrl.IndexLO}, {ctrl.IndexHI}");
                            conflictFound = true;
                        }
                    }
                    else if (ctrl.IndexLO == argctrl.IndexLO)
                    {
                        confstr.AppendLine($"Conflict with CTRL ID {ctrl.ID} at index {ctrl.IndexLO}");
                        conflictFound = true;
                    }
                }
            }

            if (!conflictFound)
            {
                confstr.Append("No conflicts");
            }

            lbl_IndexConflicts.Text = confstr.ToString();
        }
        private void update_Validate_IndecesUsednew(CTRL_Builder_UC argctrl)
        {
            StringBuilder confstr = new StringBuilder();
            bool conflictFound = false;

            foreach (CTRL_Builder_UC ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl.ID != argctrl.ID)
                {
                    if (ctrl.CUR_TYPECtrl == CtrlType._2_by && argctrl.CUR_TYPECtrl == CtrlType._2_by)
                    {
                        if (ctrl.IndexLO == argctrl.IndexLO || ctrl.IndexHI == argctrl.IndexHI)
                        {
                            confstr.AppendLine($"Conflict with CTRL ID {ctrl.ID} at indices {ctrl.IndexLO}, {ctrl.IndexHI}");
                            conflictFound = true;
                        }
                    }
                    else
                    {
                        if (ctrl.IndexLO == argctrl.IndexLO)
                        {
                            confstr.AppendLine($"Conflict with CTRL ID {ctrl.ID} at index {ctrl.IndexLO}");
                            conflictFound = true;
                        }
                    }
                }
            }

            if (!conflictFound)
            {
                confstr.Append("No conflicts");
            }

            lbl_IndexConflicts.Text = confstr.ToString();
        }
        private void update_Validate_IndecesUsedold(CTRL_Builder_UC argctrl)
        {
            string confstr = "";
            if (argctrl.CUR_TYPECtrl == CtrlType._2_by)
            {
                if (IndecesUsed[argctrl.IndexLO] == true)
                {
                    confstr = "CONF LO index #" + argctrl.IndexLO + " in ctrl " + argctrl.ID + " is already used ";
                }
                if (IndecesUsed[argctrl.IndexHI] == true)
                {
                    confstr += "  CONF HI index #" + argctrl.IndexHI + " in ctrl " + argctrl.ID + " is already used ";
                }
                if (IndecesUsed[argctrl.IndexLO] == false && IndecesUsed[argctrl.IndexHI] == false)
                {
                    confstr = "ok";
                }
            }
            else
            {
                if (IndecesUsed[argctrl.IndexLO] == true)
                {
                    confstr = "Conf index #" + argctrl.IndexLO + " in ctrl " + argctrl.ID + " is already used";
                }
                else
                {
                    confstr = "ok";
                }
            }

            lbl_IndexConflicts.Text = confstr;
        }
        private void Update_CLEARE_IndecesUsed(CTRL_Builder_UC argctrl)
        {
            // Clear indices based on control type
            if (argctrl.CUR_TYPECtrl == CtrlType._2_by)
            {
                IndecesUsed[argctrl.IndexLO] = false;
                IndecesUsed[argctrl.IndexHI] = false;
            }
            else
            {
                IndecesUsed[argctrl.IndexLO] = false;
            }
        }
 
 */