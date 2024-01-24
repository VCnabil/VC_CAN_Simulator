using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.VC_PGNS_DIR.VC_UI;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.Translators
{
    public partial class FormTranslate : Form
    {
        string _newSavedTextFileName_plusExt = "";
        string _fullpathTo_SavedTextFile = "";
        VCPGN_listCTRL vCPGN_ListCTRL;
        FilterData structFilter;
        List<VC_PGN_Text_Object> List_ToDressIntoCTRLs;
        public FormTranslate()
        {
            InitializeComponent();


            string _targetFilePath_JSON = Get_Local_JSON_pgnDfinitions_fullpath();
            vCPGN_ListCTRL = new VCPGN_listCTRL(_targetFilePath_JSON);
            structFilter = new FilterData();
            structFilter.Filter_str_Project = "CCM";
            structFilter.Filter_bool_Project = true;
            label_Filter.Text = "project CCM";

            List_ToDressIntoCTRLs = vCPGN_ListCTRL.Get_String_FilteredList_OBJ(structFilter);
            label_MatchesFound.Text = List_ToDressIntoCTRLs.Count.ToString();
            label_totalPgnsInDb.Text = vCPGN_ListCTRL.TotalPgnsInJSON.ToString();
        }

    }
}
