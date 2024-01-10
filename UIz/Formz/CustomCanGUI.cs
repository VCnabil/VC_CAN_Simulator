using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.UIz.Formz.SingleForm;
using static VC_CAN_Simulator.Backend.Helpers;
namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class CustomCanGUI : Form
    {
        string path_toDIR= "";
        string jsonFileName_Exten = ".json";
        string jsonFileName_noExtension = "";
        string FULL__PATH_FILENAME_EXT = "";
        public CustomCanGUI()
        {
            InitializeComponent();
            jsonFileName_noExtension = SaveFileName;
            textBox_fileName.Text = jsonFileName_noExtension+ jsonFileName_Exten;
            label1.Text = "SaveFileName";

            btn_load.Click += Btn_loadManip_Click;
            btn_modify.Click += Btn_modCreate_Click;
            btn_MKV.Click += Btn_run_MKV_Click;
            textBox_fileName.TextChanged += TextBox_fileName_TextChanged;
        }

        private void Btn_run_MKV_Click(object sender, EventArgs e)
        {
            using (MKV_GUI form1 = new MKV_GUI())
            {
                form1.ShowDialog();
            }
        }

        private void TextBox_fileName_TextChanged(object sender, EventArgs e)
        {
            jsonFileName_noExtension= textBox_fileName.Text;
            FULL__PATH_FILENAME_EXT = SaveDirPath + jsonFileName_noExtension + jsonFileName_Exten;
            label1.Text = jsonFileName_noExtension;
            label2.Text = FULL__PATH_FILENAME_EXT;
        }

        private void Btn_modCreate_Click(object sender, EventArgs e)
        {
            Set_FullFilePAth(FULL__PATH_FILENAME_EXT);
            using (CreateOrModifyProject form1 = new CreateOrModifyProject())
            {
                form1.ShowDialog();  
            }

        }

        private void Btn_loadManip_Click(object sender, EventArgs e)
        {
            Set_FullFilePAth(FULL__PATH_FILENAME_EXT);
            using (CanManipForm form1 = new CanManipForm())
            {
                form1.ShowDialog();  
            }
        }
    }
}
