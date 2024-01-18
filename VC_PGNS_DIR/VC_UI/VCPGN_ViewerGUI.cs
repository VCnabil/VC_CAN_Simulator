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
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.VC_PGNS_DIR.VC_UI
{
    public partial class VCPGN_ViewerGUI : Form
    {
        bool UserIs_NOTNabil = true;

        DetailDisplayData structDisplay;

        FilterData structFilter;
        VCPGN_listCTRL vCPGN_ListCTRL;
        public VCPGN_ViewerGUI()
        {
            InitializeComponent();
            structDisplay = new DetailDisplayData();
            structFilter = new FilterData();

           
            string _targetFilePath_JSON = Get_Local_JSON_pgnDfinitions_fullpath();
            vCPGN_ListCTRL = new VCPGN_listCTRL(_targetFilePath_JSON);
            label_totalPgnsInDb.Text = vCPGN_ListCTRL.TotalPgnsInJSON.ToString();


            checkBox_ShowDate.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_PgnShowVerbos.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowFrom.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowID.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show32bitpgn.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowAddresses.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_ShowPriority.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Show_Softwareversion.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Info.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Configuration.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_Project.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_BytesShowVerbos.CheckedChanged += CheckBoxs_CheckedChanged;
            checkBox_BitsShowVerbos.CheckedChanged += CheckBoxs_CheckedChanged;

           // checkBox_FilterbySendingUnit.CheckedChanged += cb_CheckedChanged;
         //   checkBox_FilterbyPGN.CheckedChanged += cb_CheckedChanged;
          //  checkBox_FilterbyConfiguration.CheckedChanged += cb_CheckedChanged;
          //  checkBox_FilterbyProject.CheckedChanged += cb_CheckedChanged;

            textBox_Contains_str_Sendingunit.TextChanged += TextBox_From_TextChanged;
            textBox_Contains_str_PGN.TextChanged += TextBox_PGN_TextChanged;
            textBox_Contains_str_Configuration.TextChanged += TextBox_Config_TextChanged;
            textBox_Contains_str_Project.TextChanged += TextBox_Proj_TextChanged;

            checkBox_ShowFrom.Checked = true;
           // checkBox_ShowID.Checked = true;
           // checkBox_Show32bitpgn.Checked = true;
           // checkBox_ShowAddresses.Checked = true;
           // checkBox_ShowPriority.Checked = true;
            checkBox_Configuration.Checked = true;
            checkBox_Project.Checked = true;
           // checkBox_Info.Checked = true;
            checkBox_BytesShowVerbos.Checked = true;
            checkBox_BitsShowVerbos.Checked = true;
           

            button_Display.Click += Button_Display_Click;
            button_Display.Hide();

            if (UserIs_NOTNabil) {
                checkBox_PgnShowVerbos.Hide();

                checkBox_ShowID.Hide();
                checkBox_Show32bitpgn.Hide();
                checkBox_ShowAddresses.Hide();
                checkBox_ShowPriority.Hide();
            }
        }

        private void TextBox_From_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_Sendingunit.Text.Length > 0)
            {
                structFilter.Filter_bool_FromSendingUnit = true;
                structFilter.Filter_str_From = textBox_Contains_str_Sendingunit.Text;
            }
            else {
                structFilter.Filter_bool_FromSendingUnit = false;
            }
                Update_DisplayedPgns();
        }
        private void TextBox_PGN_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_PGN.Text.Length > 0)
            {
                structFilter.Filter_bool_Pgn = true;
                structFilter.Filter_str_Pgn = textBox_Contains_str_PGN.Text;
            }
            else {
                structFilter.Filter_bool_Pgn = false;
            }
                Update_DisplayedPgns();
        }
        private void TextBox_Config_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contains_str_Configuration.Text.Length > 0)
            {
                structFilter.Filter_bool_Configuration = true;

                structFilter.Filter_str_Configuration = textBox_Contains_str_Configuration.Text;
            }
            else {
                structFilter.Filter_bool_Configuration = false;
            }
          
                Update_DisplayedPgns();
        }
        private void TextBox_Proj_TextChanged(object sender, EventArgs e)
        {
            // if    textBox_Contains_str_Project.Text  is not empty
            if (textBox_Contains_str_Project.Text.Length > 0)
            {
                structFilter.Filter_bool_Project = true;
                structFilter.Filter_str_Project = textBox_Contains_str_Project.Text;
            }
            else {
                structFilter.Filter_bool_Project = false;
            }
          
                Update_DisplayedPgns();
           
        }

        private void Button_Display_Click(object sender, EventArgs e)
        {
            //Update_DisplayedPgns();
        }

    //    private void cb_CheckedChanged(object sender, EventArgs e)
     //   {
            //structFilter.Filter_bool_FromSendingUnit = checkBox_FilterbySendingUnit.Checked;
            //structFilter.Filter_bool_Pgn = checkBox_FilterbyPGN.Checked;
            //structFilter.Filter_bool_Configuration = checkBox_FilterbyConfiguration.Checked;
            //structFilter.Filter_bool_Project = checkBox_FilterbyProject.Checked;
            //Update_DisplayedPgns();
       // }

        private void CheckBoxs_CheckedChanged(object sender, EventArgs e)
        {
            structDisplay.Show_bool_Date = checkBox_ShowDate.Checked;
            structDisplay.Show_bool_HEAVY = checkBox_PgnShowVerbos.Checked;
            structDisplay.Show_bool_From = checkBox_ShowFrom.Checked;
            structDisplay.Show_bool_ID = checkBox_ShowID.Checked;
            structDisplay.Show_bool_PGN32bit = checkBox_Show32bitpgn.Checked;
            structDisplay.Show_bool_Addresses = checkBox_ShowAddresses.Checked;
            structDisplay.Show_bool_Priority = checkBox_ShowPriority.Checked;
            structDisplay.Show_bool_SoftwareVersion = checkBox_Show_Softwareversion.Checked;
            structDisplay.Show_bool_Info = checkBox_Info.Checked;
            structDisplay.Show_bool_Configuration = checkBox_Configuration.Checked;
            structDisplay.Show_bool_Project = checkBox_Project.Checked;
            structDisplay.Show_bool_Bytes = checkBox_BytesShowVerbos.Checked;
            structDisplay.Show_bool_Bits = checkBox_BitsShowVerbos.Checked;

            Update_DisplayedPgns();

        }

        void Update_DisplayedPgns() { 
            textBox_Display.Text = vCPGN_ListCTRL.Get_String_toDisplay(structDisplay, structFilter);
            label_MatchesFound.Text = vCPGN_ListCTRL.Get_pgnCountInFilteredList().ToString();
            
        }
    }
}
