using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.DataObjects;
using static VC_CAN_Simulator.Backend.Helpers;
using System.Text.RegularExpressions;

namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    public partial class CTRL_Builder_UC : UserControl
    {
        int _id;
        public int ID { get { return _id; } private set { _id = value; } }
        string _dec = string.Empty;
        int _min;
        int _max;
        int _def;
        int _indexLO;
        int _indexHI;
        CtrlType Cur_ctrlType;
        public CtrlType CUR_TYPECtrl { get { return Cur_ctrlType; } private set { Cur_ctrlType = value; } }
        bool is_slider_onlyFor_1byand2by;
        List<TextBox> _8_bs_relatedtextBoxes;
        List<TextBox> _8_bG_relatedtextBoxes;
        List<string> _listGroup1;
        List<string> _listGroup2;
        List<string> _listRemotes;
        public int IndexLO { get { return _indexLO; }  set { _indexLO = value; } }
        public int IndexHI { get { return _indexHI; }  set { _indexHI = value; } }
        public CTRL_Builder_UC(Ctrl_DataObject argCtrlDO)
        {

            InitializeComponent();


            _8_bs_relatedtextBoxes = new List<TextBox>();
            _8_bG_relatedtextBoxes = new List<TextBox>();

            _8_bG_relatedtextBoxes.Add(tb_group1);
            _8_bG_relatedtextBoxes.Add(tb_group2);
            _8_bs_relatedtextBoxes.Add(tb_remote1);
            _8_bs_relatedtextBoxes.Add(tb_remote2);
            _8_bs_relatedtextBoxes.Add(tb_remote3);
            _8_bs_relatedtextBoxes.Add(tb_remote4);

 


            _id = argCtrlDO.ID;
            _min = argCtrlDO.MIN;
            _max = argCtrlDO.MAX;
            _def = argCtrlDO.DEF;
            _indexLO = argCtrlDO.INDEXLO;
            _indexHI = argCtrlDO.INDEXHI;
            _dec = argCtrlDO.DESC;
            is_slider_onlyFor_1byand2by = argCtrlDO.ISSLIDER;
            cb_isSlider.Checked = is_slider_onlyFor_1byand2by;
            

            lbl_id.Text = _id.ToString();
            tb_min.Text = _min.ToString();
            tb_max.Text = _max.ToString();
            tb_DefDec.Text = _def.ToString();
            tb_indexLO.Text = _indexLO.ToString();
            tb_indexHI.Text = _indexHI.ToString();
            this.bitNamesList_uc1.SetDescription_fromBlueprint(_dec);

            _listGroup1 = argCtrlDO.Group1List;
            _listGroup2 = argCtrlDO.Group2List;
            _listRemotes = argCtrlDO.RemoteList;
            if (_listGroup1 != null)
            {
                if (_listGroup1.Count > 0)
                {
                    tb_group1.Text = _listGroup1[0];
                }
            }
            if (_listGroup2 != null)
            {
                if (_listGroup2.Count > 0)
                {
                    tb_group2.Text = _listGroup2[0];
                }
            }
            if (_listRemotes != null)
            {
                if (_listRemotes.Count > 0)
                {
                    for (int r = 0; r < _listRemotes.Count; r++)
                    {
                        if (r == 0)
                        {
                            tb_remote1.Text = _listRemotes[r];
                        }
                        if (r == 1)
                        {
                            tb_remote2.Text = _listRemotes[r];
                        }
                        if (r == 2)
                        {
                            tb_remote3.Text = _listRemotes[r];
                        }
                        if (r == 3)
                        {
                            tb_remote4.Text = _listRemotes[r];
                        }
                    }

                }
            }


       



            PopulateComboBox();
            Cur_ctrlType = StringToEnum(argCtrlDO.CTRL_TYOE_STR);
            cb_CtrlType.SelectedIndex = (int)Cur_ctrlType;

           Showhide_Uielements_by_curtypeSeletion();
           //PresetValues_by_curTypeSelection();
            updateTextboxes();


            btn_validategroups.Click += Btn_validategroups_Click;
            cb_CtrlType.SelectedIndexChanged += cb_CtrlType_SelectedIndexChanged;
            btn_rem.Click += Btn_rem_Click;
            tb_indexLO.TextChanged += Tb_indexLO_TextChanged;
            tb_indexHI.TextChanged += Tb_indexHI_TextChanged;
            cb_isSlider.CheckedChanged += Cb_isSlider_CheckedChanged;

        }
        public CTRL_Builder_UC(int argID)
        {
          
            InitializeComponent();
            _id = argID;
            lbl_id.Text = _id.ToString();
            PopulateComboBox();
            _8_bs_relatedtextBoxes = new List<TextBox>();
            _8_bG_relatedtextBoxes = new List<TextBox>();
   
            _8_bG_relatedtextBoxes.Add(tb_group1);
            _8_bG_relatedtextBoxes.Add(tb_group2);
            _8_bs_relatedtextBoxes.Add(tb_remote1);
            _8_bs_relatedtextBoxes.Add(tb_remote2);
            _8_bs_relatedtextBoxes.Add(tb_remote3);
            _8_bs_relatedtextBoxes.Add(tb_remote4);
            //label_groupconflicts
            Cur_ctrlType = CtrlType._8_bs;
            btn_validategroups.Click += Btn_validategroups_Click;
            cb_CtrlType.SelectedIndexChanged += cb_CtrlType_SelectedIndexChanged;
            btn_rem.Click += Btn_rem_Click;
            tb_indexLO.TextChanged += Tb_indexLO_TextChanged;
            tb_indexHI.TextChanged += Tb_indexHI_TextChanged;
            cb_isSlider.CheckedChanged += Cb_isSlider_CheckedChanged;

            Showhide_Uielements_by_curtypeSeletion();
            PresetValues_by_curTypeSelection();
            updateTextboxes();
        }

        #region EventsAndHandlers

        public event EventHandler Remove_CTRL_ButtonClicked;
        public event EventHandler IndexChanged;
        public event EventHandler Type_CTRL_Changed;
        private void OnCtrlTypeChanged()
        {
            Type_CTRL_Changed?.Invoke(this, EventArgs.Empty);

            if (Cur_ctrlType == CtrlType._8_bs || Cur_ctrlType == CtrlType._8_bG) {
                this.bitNamesList_uc1.Show_AddRowButton(true);
            }
           
            else

            {
                this.bitNamesList_uc1.ClearAll();
                this.bitNamesList_uc1.Show_AddRowButton(false);
            }
           
        }
        private void Cb_isSlider_CheckedChanged(object sender, EventArgs e)
        {
            is_slider_onlyFor_1byand2by = cb_isSlider.Checked;
        }
        private void OnIndexChanged()
        {
            IndexChanged?.Invoke(this, EventArgs.Empty);
        }
        private void Tb_indexHI_TextChanged(object sender, EventArgs e)
        {
            _indexHI = int.TryParse(tb_indexHI.Text, out int result) ? result : 0;
            if(_indexHI > 7)
            {
                _indexHI = 7;
            }
            if (Cur_ctrlType == CtrlType._2_by) { 
                
                OnIndexChanged();
            }
        }
        private void Tb_indexLO_TextChanged(object sender, EventArgs e)
        {
            _indexLO = int.TryParse(tb_indexLO.Text, out int result) ? result : 0;
            if (_indexLO > 7)
            {
                _indexLO = 7;
            }
            OnIndexChanged();
        }
        private void Btn_validategroups_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Btn_rem_Click(object sender, EventArgs e)
        {
            Remove_CTRL_ButtonClicked?.Invoke(this, e);
        }

        #endregion
        private void PopulateComboBox()
        {
            cb_CtrlType.Items.Clear();
            foreach (var ctrlType in Enum.GetValues(typeof(CtrlType)))
            {
                cb_CtrlType.Items.Add(ctrlType.ToString());
            }
        }
        private void updateTextboxes()
        {
            tb_min.Text = _min.ToString();
            tb_max.Text = _max.ToString();
            tb_DefDec.Text = _def.ToString();
            tb_indexLO.Text = _indexLO.ToString();
            tb_indexHI.Text = _indexHI.ToString();
        }
        private void PresetValues_by_curTypeSelection()
        {
            switch (Cur_ctrlType)
            {
                case CtrlType._8_bs:
                    _min = 0;
                    _max = 255;
                    _def = 0;
                    _indexLO = 0;
                    _indexHI = 0;
                    break;
                case CtrlType._8_bG:
                    _min = 0;
                    _max = 255;
                    _def = 0;
                    _indexLO = 0;
                    _indexHI = 0;
                    break;
                case CtrlType._1_By:
                    _min = 0;
                    _max = 255;
                    _def = 100;
                    _indexLO = 0;
                    _indexHI = 0;
                    break;
                case CtrlType._2_by:
                    _min = 0;
                    _max = 1000;
                    _def = 500;
                    _indexLO = 0;
                    _indexHI = 1;
                    break;
                default:
                    break;
            }
        }
        private void Showhide_Uielements_by_curtypeSeletion() {
            switch (Cur_ctrlType)
            {
                case CtrlType._8_bs:
                    label_groupconflicts.Hide();
                    btn_validategroups.Hide();
                    tb_indexLO.Show();
                    tb_indexHI.Hide();
                    cb_isSlider.Hide();
                    foreach (var tb in _8_bG_relatedtextBoxes)
                    {
                        tb.Hide();
                    }
                    foreach (var tb in _8_bs_relatedtextBoxes)
                    {
                        tb.Show();
                    }
                    break;
                case CtrlType._8_bG:
                    label_groupconflicts.Show();
                    btn_validategroups.Show();
                    tb_indexLO.Show();
                    tb_indexHI.Hide();
                    cb_isSlider.Hide();
                    foreach (var tb in _8_bs_relatedtextBoxes)
                    {
                        tb.Hide();
                    }
                    foreach (var tb in _8_bG_relatedtextBoxes)
                    {
                        tb.Show();
                    }
                    break;
                case CtrlType._1_By:
                    label_groupconflicts.Hide();
                    btn_validategroups.Hide();
                    tb_indexLO.Show();
                    tb_indexHI.Hide();
                    cb_isSlider.Show();
                    foreach (var tb in _8_bs_relatedtextBoxes)
                    {
                        tb.Hide();
                    }
                    foreach (var tb in _8_bG_relatedtextBoxes)
                    {
                        tb.Hide();
                    }
                    break;
                case CtrlType._2_by:
                    label_groupconflicts.Hide();
                    btn_validategroups.Hide();
                    tb_indexLO.Show();
                    tb_indexHI.Show();
                    cb_isSlider.Show();
                    foreach (var tb in _8_bs_relatedtextBoxes)
                    {
                        tb.Hide();
                    }
                    foreach (var tb in _8_bG_relatedtextBoxes)
                    {
                        tb.Hide();
                    }

                    break;
                default:
                    break;
            }
        }
        private void cb_CtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CtrlType.SelectedItem != null)
            {
                Cur_ctrlType = (CtrlType)Enum.Parse(typeof(CtrlType), cb_CtrlType.SelectedItem.ToString());
                Showhide_Uielements_by_curtypeSeletion();
                PresetValues_by_curTypeSelection();
                updateTextboxes();
                OnCtrlTypeChanged();
            }
        }

        bool Valide_GroupText(string grouptext) {
            if (String.IsNullOrEmpty(grouptext)) { return false; }

            // Regular expression for matching a comma-separated list of numbers
            // Pattern explanation:
            // ^ - Start of the string
            // \d+ - One or more digits
            // (,\d+)* - Zero or more occurrences of a comma followed by one or more digits
            // $ - End of the string
            string pattern = @"^\d+(,\d+)*$";

            return Regex.IsMatch(grouptext, pattern);
        }
        public Ctrl_DataObject Make_ctrlDataObject() {
            string strtype = EnumToString(Cur_ctrlType);
            string descript = this.bitNamesList_uc1.Decription;
            _listGroup1 = new List<string>();
            _listGroup2 = new List<string>();
            _listRemotes = new List<string>();

            if ( Cur_ctrlType == CtrlType._8_bG) {
                if(Valide_GroupText(tb_group1.Text)) _listGroup1.Add(tb_group1.Text);
                if (Valide_GroupText(tb_group2.Text)) _listGroup2.Add(tb_group2.Text);
            }
            if (Cur_ctrlType == CtrlType._8_bs) {
                if (Valide_GroupText(tb_remote1.Text)) _listRemotes.Add(tb_remote1.Text);
                if (Valide_GroupText(tb_remote2.Text)) _listRemotes.Add(tb_remote2.Text);
                if (Valide_GroupText(tb_remote3.Text)) _listRemotes.Add(tb_remote3.Text);
                if (Valide_GroupText(tb_remote4.Text)) _listRemotes.Add(tb_remote4.Text);
            }
 
            Ctrl_DataObject temp = new Ctrl_DataObject();
            temp.ID = _id;
            temp.DESC = descript;
            temp.MIN = _min;
            temp.MAX = _max;
            temp.DEF = _def;
            temp.INDEXLO = _indexLO;
            temp.INDEXHI = _indexHI;
            temp.CTRL_TYOE_STR = strtype;
            temp.ISSLIDER = is_slider_onlyFor_1byand2by;
            temp.BitsList = this.bitNamesList_uc1.GetBitNameDescriptions();
            temp.Group1List = _listGroup1;
            temp.Group2List = _listGroup2;
            temp.RemoteList = _listRemotes;
            return temp;
        }
    }
}
/*
         public void Rectify_indexLO(int arg)
        {
            _indexLO = arg;
            updateTextboxes();
        }
        public void Rectify_indexHI(int arg)
        {
            _indexHI = arg;
            updateTextboxes();
        }
 */