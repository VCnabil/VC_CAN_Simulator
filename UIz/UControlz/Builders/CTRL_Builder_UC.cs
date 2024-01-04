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

namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    public partial class CTRL_Builder_UC : UserControl
    {


        CtrlType Cur_ctrlType;
        bool is_slider_onlyFor_1byand2by;
        List<TextBox> _8_bs_relatedtextBoxes;
        List<TextBox> _8_bG_relatedtextBoxes;
        List<string> listGroup1;
        List<string> listGroup2;
        List<string> listRemotes;
        int _id;
        public int ID { get { return _id; } private set { _id = value; } }

        string _dec = string.Empty;
        int _min;
        int _max;
        int _def;

        int _indexLO;
        int _indexHI;

        public CTRL_Builder_UC(int argID)
        {
          
            InitializeComponent();
            _id = argID;
            lbl_id.Text = _id.ToString();
            PopulateComboBox();
            _8_bs_relatedtextBoxes = new List<TextBox>();
            _8_bG_relatedtextBoxes = new List<TextBox>();
            listGroup1 = new List<string>();
            listGroup2 = new List<string>();
            listRemotes = new List<string>();
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

        private void Cb_isSlider_CheckedChanged(object sender, EventArgs e)
        {
            is_slider_onlyFor_1byand2by = cb_isSlider.Checked;
        }

        public event EventHandler Remove_CTRL_ButtonClicked;

        public event EventHandler Type_CTRL_Changed;
        private void OnCtrlTypeChanged()
        {
            Type_CTRL_Changed?.Invoke(this, EventArgs.Empty);
            if (Cur_ctrlType != CtrlType._8_bs) {
                this.bitNamesList_uc1.ClearAll();
                this.bitNamesList_uc1.Show_AddRowButton(false);
            }
            else
            {
                this.bitNamesList_uc1.Show_AddRowButton(true);
            }
        }
        public CtrlType CUR_TYPECtrl { get { return Cur_ctrlType; } private set { Cur_ctrlType = value; } }
        public int IndexLO { get { return _indexLO; } private set { _indexLO = value; } }
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
        public int IndexHI { get { return _indexHI; } private set { _indexHI = value; } }

        public event EventHandler IndexChanged;

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

        public Ctrl_DataObject Make_ctrlDataObject() {

            string strtype = EnumToString(Cur_ctrlType);
            string descript = this.bitNamesList_uc1.Decription;
            Ctrl_DataObject temp = new Ctrl_DataObject(_id, descript, 
                                                        _min, _max, _def,
                                                        IndexLO, IndexHI, 
                                                        strtype, is_slider_onlyFor_1byand2by,
                                                        this.bitNamesList_uc1.GetBitNameDescriptions(), listGroup1, listGroup2, listRemotes);

            return temp;

        }
    }
}
