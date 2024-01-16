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

            if (argpgnStr.Length != 10)
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

            for (int ctrlI = 0; ctrlI < argCtrlDOlist.Count; ctrlI++) {
                if (flowLayoutPanel1.Controls.Count < MaxCtrls)
                {
                    var newCtrlBuilder = new CTRL_Builder_UC(argCtrlDOlist[ctrlI]);

                    AddNewCtrlBuilder(newCtrlBuilder);
                }
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
            newCtrlBuilder.IndexChanged += CtrlBuilder_IndexChanged;
            newCtrlBuilder.Type_CTRL_Changed += CtrlBuilder_CtrlTypeChanged;
            newCtrlBuilder.Remove_CTRL_ButtonClicked += Ctrl_RemoveButtonClicked;
            ctrlBuilderList.Add(newCtrlBuilder);
            flowLayoutPanel1.Controls.Add(newCtrlBuilder);
            ValidateCtrlBuilders(); 
        }
        public void RemoveCtrlBuilder(CTRL_Builder_UC ctrlBuilder)
        {
            ctrlBuilder.IndexChanged -= CtrlBuilder_IndexChanged;
            ctrlBuilder.Type_CTRL_Changed -= CtrlBuilder_CtrlTypeChanged;
            ctrlBuilder.Remove_CTRL_ButtonClicked -= Ctrl_RemoveButtonClicked;
            ctrlBuilderList.Remove(ctrlBuilder);
            flowLayoutPanel1.Controls.Remove(ctrlBuilder);
            btn_AddCtrl.Enabled = true;
            ValidateCtrlBuilders();
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
            Pgn_DataObject tempPgnDataobj = new Pgn_DataObject();
            tempPgnDataobj.IDpgn = _myPgnUcId;
            tempPgnDataobj.DESCpgn = pgnDesc;
            tempPgnDataobj.PGN_int = int_full_PGN;
            tempPgnDataobj.PGN_strHEX = str_full_PGN;
            tempPgnDataobj.CtrlList = Make_Listctrls();
            return tempPgnDataobj;
        }
    }
}