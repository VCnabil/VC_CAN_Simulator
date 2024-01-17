using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using VC_CAN_Simulator.Backend;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static VC_CAN_Simulator.Backend.Helpers;
namespace VC_CAN_Simulator.VC_PGNS_DIR.VC_UI
{
    public partial class VC_PGNjsonGUI : Form
    {

        SeriDeseriSort_BasicIO seriDeseriSort_BasicIO;


        public VC_PGNjsonGUI()
        {
            InitializeComponent();

            string _sourceFilePath_GroudZero = Path.Combine(_vcPgnDirPath, _vcreadonly_samplepgnTXT_FileName);
            string _targetFilePath_JSON = Path.Combine(_vcPgnDirPath, _vcWrite_samplepgnTXT_FileName);
            string _light_formatFilePath = Path.Combine(_vcPgnDirPath, _vcErite_textCanOriginalFormat_FileName);
            string _fullformatFilePath = Path.Combine(_vcPgnDirPath, _vcErite_textCanOriginal_FULL_Format_FileName);
            seriDeseriSort_BasicIO = new SeriDeseriSort_BasicIO(_sourceFilePath_GroudZero, _targetFilePath_JSON, _light_formatFilePath, _fullformatFilePath);
            btn_Gzero_toJson.Click += Btn_Deserialize;
            btn_makeText_fromJson.Click += Btn_run_makeText_Click;
            textBox1.Text = "";
            textBox1.Text = _sourceFilePath_GroudZero;
            textBox2.Text = "";
        }

        private void Btn_run_makeText_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";

            textBox2.Text = seriDeseriSort_BasicIO.Deserialize_JsonFormat_Sort_by_pgnIn();

        }
        private void Btn_Deserialize(object sender, EventArgs e)
        {
            seriDeseriSort_BasicIO.Serialize_GroundZeroTextFile_To_JSON();
        }
 
    }

    

}

 