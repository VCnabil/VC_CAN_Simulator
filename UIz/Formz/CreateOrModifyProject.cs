using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        string path_toDIR = "";
        string jsonFileName_Exten = ".json";
        string jsonFileName_noExtension = "";
        string FULL__PATH_FILENAME_EXT = "";
        public CreateOrModifyProject()
        {
            InitializeComponent();
            this.Width = 2900;
            this.Height = 1800;
            jsonFileName_noExtension= SaveFileName;
            _filename = SaveFileName;
            lbl_curFileName.Text = "cur FileName:" + _filename;
            tb_filename.Text = _filename;

            btn_Load.Click += Btn_Load_Click;
            btn_Save.Click += Btn_Save_Click;
            btn_clearAll.Click += Btn_clearAll_Click;
             
            tb_filename.TextChanged += Tb_filename_TextChanged;
            _PROJbUILDER_UC = new PROJECT_Builder_UC();
            _PROJbUILDER_UC.Location = new Point(0, 40);
            Controls.Add(_PROJbUILDER_UC);
             
        }

      

        private Project_DataObject LoadJsonFile(string path_filenameFromMain)
        {
            string json = System.IO.File.ReadAllText(path_filenameFromMain);
            Project_DataObject myPgnList = JsonConvert.DeserializeObject<Project_DataObject>(json);
            return myPgnList;
        }

        private void Btn_clearAll_Click(object sender, EventArgs e)
        {
            _PROJbUILDER_UC.ClearAllPGNSRecursive();
        }

        private void Tb_filename_TextChanged(object sender, EventArgs e)
        {
            _filename = tb_filename.Text;
            jsonFileName_noExtension = tb_filename.Text;
            lbl_curFileName.Text = "cur FileName:" + _filename + jsonFileName_Exten;
            SaveFileName = _filename;
            FULL__PATH_FILENAME_EXT = SaveDirPath + jsonFileName_noExtension + jsonFileName_Exten;
            Set_FullFilePAth(FULL__PATH_FILENAME_EXT);
            if (_filename == "") { 
                btn_Save.Hide();
            }
            else { btn_Save.Show(); }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            _filename = tb_filename.Text;
            jsonFileName_noExtension = tb_filename.Text;
            lbl_curFileName.Text = "cur FileName:" + _filename + jsonFileName_Exten;
            SaveFileName = _filename;
            FULL__PATH_FILENAME_EXT = SaveDirPath + jsonFileName_noExtension + jsonFileName_Exten;
            Set_FullFilePAth(FULL__PATH_FILENAME_EXT);
            Project_DataObject PROJECTTOSAVE= _PROJbUILDER_UC.Make_ProjectDataObject();

           // string _filename_objbuilder = "TEST016";
           // string PATH_dIR = "C:\\___Root_VCI_Projects\\Generic_VC_PGN_SIMULATOR\\genericSim\\GENERICSIM_FILES\\";
           // string path_filenameFromMain= PATH_dIR + _filename_objbuilder + ".json";
      
            string json = JsonConvert.SerializeObject(PROJECTTOSAVE, Formatting.Indented);

            System.IO.File.WriteAllText(Get_FullFilePAth(), json);
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
            _filename = tb_filename.Text;
            jsonFileName_noExtension = tb_filename.Text;
            lbl_curFileName.Text = "cur FileName:" + _filename + jsonFileName_Exten;
            SaveFileName = _filename;
            FULL__PATH_FILENAME_EXT = SaveDirPath + jsonFileName_noExtension + jsonFileName_Exten;
            Set_FullFilePAth(FULL__PATH_FILENAME_EXT);
          
            Project_DataObject PROJECTTOSAVE = LoadJsonFile(Get_FullFilePAth());

            for (int i = 0; i < PROJECTTOSAVE.AllPgnList.Count; i++)
            {
                _PROJbUILDER_UC.AddFromBlueprint(PROJECTTOSAVE.AllPgnList[i].IDpgn, PROJECTTOSAVE.AllPgnList[i].PGN_int, PROJECTTOSAVE.AllPgnList[i].PGN_strHEX, PROJECTTOSAVE.AllPgnList[i].DESCpgn, PROJECTTOSAVE.AllPgnList[i].CtrlList);

            }
        }
    }
}
