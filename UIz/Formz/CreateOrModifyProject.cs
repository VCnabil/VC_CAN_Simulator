using Newtonsoft.Json;
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
using VC_CAN_Simulator.UIz.UControlz.Builders;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class CreateOrModifyProject : Form
    {
        string _filename = string.Empty;
        PROJECT_Builder_UC _PROJbUILDER_UC;
        public CreateOrModifyProject()
        {
            InitializeComponent();
            this.Width = 2900;
            this.Height = 1800;
            btn_Load.Click += Btn_Load_Click;
            btn_Save.Click += Btn_Save_Click;
            btn_clearAll.Click += Btn_clearAll_Click;
            btn_add_testPgn.Click += Btn_add_testPgn_Click;
            tb_filename.TextChanged += Tb_filename_TextChanged;
            _PROJbUILDER_UC = new PROJECT_Builder_UC();
            _PROJbUILDER_UC.Location = new Point(0, 40);
            Controls.Add(_PROJbUILDER_UC);
        }

        private void Btn_add_testPgn_Click(object sender, EventArgs e)
        {
            int pgnId_1= 0;
            string pgnHex_1 = "12FF1229";
            int pgnint_1 = 318706217;
            string pgndescription_1 = "testing load";

            int ctrl_ID_1_0 = 0;
            string strl_desc_1_0 = " an 8 bitter";
            string ctrl_1_0_type = "_8_bs";
            CtrlType theenum_1_0 = StringToEnum(ctrl_1_0_type);
            int min_1_0 = 0;
            int max_1_0 = 255;
            int def_1_0 = 8;
            int indexlo_1_0 = 0;
            int indexhi_1_0 = 0;
            bool isslider_1_0 = false;
            List<string> bitslist_1_0 = new List<string>();
            bitslist_1_0.Add("1. bit1");
            bitslist_1_0.Add("2. bit2");
            bitslist_1_0.Add("5. bit5");

            List<string> group1list_1_0 = new List<string>();
            List<string> group1list_2_0 = new List<string>();
            List<string> remotelist_1_0 = new List<string>();
            remotelist_1_0.Add("1,0,1,0");
            remotelist_1_0.Add("1,1,2,2");


            Ctrl_DataObject temp = new Ctrl_DataObject(ctrl_ID_1_0, strl_desc_1_0,
                                                     min_1_0, max_1_0, def_1_0,
                                                     indexlo_1_0, indexhi_1_0,
                                                     ctrl_1_0_type, isslider_1_0,
                                                     bitslist_1_0, group1list_1_0, group1list_2_0, remotelist_1_0);
            List<Ctrl_DataObject> listctrlDo = new List<Ctrl_DataObject>();
            listctrlDo.Add(temp);

            _PROJbUILDER_UC.AddFromBlueprint(pgnId_1, pgnint_1, pgnHex_1, pgndescription_1, listctrlDo);
        }

        private void Btn_clearAll_Click(object sender, EventArgs e)
        {
            _PROJbUILDER_UC.ClearAllPGNSRecursive();
        }

        private void Tb_filename_TextChanged(object sender, EventArgs e)
        {
            _filename = tb_filename.Text;
            if (_filename == "") { 
                btn_Save.Hide();
            }
            else { btn_Save.Show(); }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Project_DataObject PROJECTTOSAVE= _PROJbUILDER_UC.Make_ProjectDataObject();

            string _filename_objbuilder = "TEST01";
            string PATH_dIR = "C:\\___Root_VCI_Projects\\Generic_VC_PGN_SIMULATOR\\genericSim\\GENERICSIM_FILES\\";
            string path_filenameFromMain= PATH_dIR + _filename_objbuilder + ".json";
      
            string json = JsonConvert.SerializeObject(PROJECTTOSAVE, Formatting.Indented);

            System.IO.File.WriteAllText(path_filenameFromMain, json);
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
             
        }
    }
}
