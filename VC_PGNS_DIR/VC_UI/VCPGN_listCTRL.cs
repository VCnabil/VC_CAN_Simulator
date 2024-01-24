using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VC_CAN_Simulator.VC_PGNS_DIR.VC_UI
{
    public class VCPGN_listCTRL
    {

        string targetFilePath_JSON;
        List<VC_PGN_Text_Object> vC_PGN_Text_Objects;

        public int TotalPgnsInJSON { get { return vC_PGN_Text_Objects.Count; } }

        private int PgnsInFilteredList = 0;
        public int Get_pgnCountInFilteredList() { return PgnsInFilteredList; }
         
        public VCPGN_listCTRL(string argtargetFilePath_JSON)
        {
            this.targetFilePath_JSON = argtargetFilePath_JSON;

            //check if target file exists

            if (!File.Exists(targetFilePath_JSON))
            {
                MessageBox.Show("Json File does not exist: " + targetFilePath_JSON);
                return;
            }
            Root_VC_PGN_Text_Object _root_VC_PGN_OBJ = JsonConvert.DeserializeObject<Root_VC_PGN_Text_Object>(File.ReadAllText(targetFilePath_JSON));
            if (_root_VC_PGN_OBJ == null)
            {
                MessageBox.Show("Json File is empty: " + targetFilePath_JSON);
                return;
            }   

            vC_PGN_Text_Objects = _root_VC_PGN_OBJ.VC_PGN_Text_Object;


        }


        public List<VC_PGN_Text_Object> Get_String_FilteredList_OBJ(FilterData argFilterdata)
        {
            List<VC_PGN_Text_Object> filteredList = GetFilteredby_Boolean(
                argFilterdata.Filter_bool_Pgn, argFilterdata.Filter_str_Pgn,
                argFilterdata.Filter_bool_FromSendingUnit, argFilterdata.Filter_str_From,
                argFilterdata.Filter_bool_Configuration, argFilterdata.Filter_str_Configuration,
                argFilterdata.Filter_bool_Project, argFilterdata.Filter_str_Project
                );
            PgnsInFilteredList = filteredList.Count;
            return filteredList;
        }

        #region Filters

        List<VC_PGN_Text_Object> GetFilteredby_Boolean( bool arg_byPGN, string argPGNcontains, bool arg_byFrom, string argFROMcontains, bool arg_byConfiguration, string argCONFIGcontains, bool arg_byProject, string argPROJECTcontains)
        {
            IEnumerable<VC_PGN_Text_Object> filteredList = vC_PGN_Text_Objects;

            if (arg_byPGN)
            {
                filteredList = filteredList.Where(item => item.vC_PGNData.PGN.Contains(argPGNcontains));
            }

            if (arg_byFrom)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.From.Contains(argFROMcontains));
            }

            if (arg_byConfiguration)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.Configuration.Contains(argCONFIGcontains));
            }

            if (arg_byProject)
            {
                filteredList = filteredList.Where(item => item.vC_PGN.Project.Contains(argPROJECTcontains));
            }

            return filteredList.ToList();
        }



        public string Get_String_toDisplay(DetailDisplayData argDisplay, FilterData argFilterdata) {
            StringBuilder sbOut = new StringBuilder();
            List<VC_PGN_Text_Object> filteredList = GetFilteredby_Boolean(
                argFilterdata.Filter_bool_Pgn, argFilterdata.Filter_str_Pgn,
                argFilterdata.Filter_bool_FromSendingUnit, argFilterdata.Filter_str_From,
                argFilterdata.Filter_bool_Configuration, argFilterdata.Filter_str_Configuration,
                argFilterdata.Filter_bool_Project, argFilterdata.Filter_str_Project
                );

            if (argDisplay.Show_bool_Date)
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string hour = DateTime.Now.Hour.ToString();
                string minute = DateTime.Now.Minute.ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append(month);
                sb.Append("/");
                sb.Append(day);
                sb.Append("/");
                sb.Append(year);
                sb.Append(" st ");

                sb.Append(hour);
                sb.Append(":");
                sb.Append(minute);
                sb.Append(":");
                sb.Append("00");
                string date = sb.ToString();
                sbOut.AppendLine("============================================================================");
                sbOut.AppendLine("created on : " + date);
                sbOut.AppendLine("============================================================================");
            }

            foreach (VC_PGN_Text_Object vcpgnt in filteredList)
            {

                if (argDisplay.Show_bool_HEAVY)
                {
                    sbOut.AppendLine("============================================================================");
                    sbOut.AppendLine("CAN Messages From : " + vcpgnt.vC_PGN.From);
                    sbOut.AppendLine("VC_PGN_ID : " + vcpgnt.vC_PGN.VC_PGN_ID);
                    sbOut.AppendLine("PGN_32bit : " + vcpgnt.vC_PGN.PGN_32bit);
                    sbOut.AppendLine("address Port: " + vcpgnt.vC_PGN.adrs_Port);
                    sbOut.AppendLine("address Stbd: " + vcpgnt.vC_PGN.adrs_Stbd);
                    sbOut.AppendLine("priority    : " + vcpgnt.vC_PGN.priority);
                    sbOut.AppendLine("Sending_Unit_Software_version : " + vcpgnt.vC_PGN.Sending_Unit_Software_version);
                    sbOut.AppendLine("info: " + vcpgnt.vC_PGN.info);
                    sbOut.AppendLine("Configuration : " + vcpgnt.vC_PGN.Configuration);
                    sbOut.AppendLine("Project : " + vcpgnt.vC_PGN.Project);
                    sbOut.AppendLine("============================================================================");
                    sbOut.AppendLine("    " + vcpgnt.vC_PGNData.PGN + "    ( " + vcpgnt.vC_PGNData.DescritionPGN + " )");
                    sbOut.AppendLine("");
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte0 : " + vcpgnt.vC_PGNData.DescritionByte0, vcpgnt.vC_PGNData.Byte0, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte1 : " + vcpgnt.vC_PGNData.DescritionByte1, vcpgnt.vC_PGNData.Byte1, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte2 : " + vcpgnt.vC_PGNData.DescritionByte2, vcpgnt.vC_PGNData.Byte2, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte3 : " + vcpgnt.vC_PGNData.DescritionByte3, vcpgnt.vC_PGNData.Byte3, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte4 : " + vcpgnt.vC_PGNData.DescritionByte4, vcpgnt.vC_PGNData.Byte4, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte5 : " + vcpgnt.vC_PGNData.DescritionByte5, vcpgnt.vC_PGNData.Byte5, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte6 : " + vcpgnt.vC_PGNData.DescritionByte6, vcpgnt.vC_PGNData.Byte6, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte7 : " + vcpgnt.vC_PGNData.DescritionByte7, vcpgnt.vC_PGNData.Byte7, true);
                }
                else
                {
                    sbOut.AppendLine("============================================================================");
                    if(argDisplay.Show_bool_From) sbOut.AppendLine("CAN Messages From : " + vcpgnt.vC_PGN.From);
                    if (argDisplay.Show_bool_ID) sbOut.AppendLine("VC_PGN_ID : " + vcpgnt.vC_PGN.VC_PGN_ID);
                    if (argDisplay.Show_bool_PGN32bit) sbOut.AppendLine("PGN_32bit : " + vcpgnt.vC_PGN.PGN_32bit);
                    if (argDisplay.Show_bool_Addresses) sbOut.AppendLine("address Port: " + vcpgnt.vC_PGN.adrs_Port);
                    if (argDisplay.Show_bool_Addresses) sbOut.AppendLine("address Stbd: " + vcpgnt.vC_PGN.adrs_Stbd);
                    if (argDisplay.Show_bool_Priority) sbOut.AppendLine("priority    : " + vcpgnt.vC_PGN.priority);
                    if (argDisplay.Show_bool_SoftwareVersion) sbOut.AppendLine("Sending_Unit_Software_version : " + vcpgnt.vC_PGN.Sending_Unit_Software_version);
                    if (argDisplay.Show_bool_Info) sbOut.AppendLine("info: " + vcpgnt.vC_PGN.info);
                    if (argDisplay.Show_bool_Configuration) sbOut.AppendLine("Configuration : " + vcpgnt.vC_PGN.Configuration);
                    if (argDisplay.Show_bool_Project) sbOut.AppendLine("Project : " + vcpgnt.vC_PGN.Project);
                    sbOut.AppendLine("============================================================================");
                    sbOut.AppendLine("    " + vcpgnt.vC_PGNData.PGN + "    ( " + vcpgnt.vC_PGNData.DescritionPGN + " )");
                    sbOut.AppendLine("");
                    if (argDisplay.Show_bool_Bytes)
                    {
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte0 : " + vcpgnt.vC_PGNData.DescritionByte0, vcpgnt.vC_PGNData.Byte0, argDisplay.Show_bool_Bits);
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte1 : " + vcpgnt.vC_PGNData.DescritionByte1, vcpgnt.vC_PGNData.Byte1, argDisplay.Show_bool_Bits);
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte2 : " + vcpgnt.vC_PGNData.DescritionByte2, vcpgnt.vC_PGNData.Byte2, argDisplay.Show_bool_Bits);
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte3 : " + vcpgnt.vC_PGNData.DescritionByte3, vcpgnt.vC_PGNData.Byte3, argDisplay.Show_bool_Bits);
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte4 : " + vcpgnt.vC_PGNData.DescritionByte4, vcpgnt.vC_PGNData.Byte4, argDisplay.Show_bool_Bits);
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte5 : " + vcpgnt.vC_PGNData.DescritionByte5, vcpgnt.vC_PGNData.Byte5, argDisplay.Show_bool_Bits);
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte6 : " + vcpgnt.vC_PGNData.DescritionByte6, vcpgnt.vC_PGNData.Byte6, argDisplay.Show_bool_Bits);
                        Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte7 : " + vcpgnt.vC_PGNData.DescritionByte7, vcpgnt.vC_PGNData.Byte7, argDisplay.Show_bool_Bits);
                    }
                }

            }

            PgnsInFilteredList= filteredList.Count;

            return sbOut.ToString();

        }
        #endregion

        public string Get_StringOutPut(bool argShowDate, bool argshowHEAVYFormat, bool argShowByteDetail) {
            StringBuilder sbOut   = new StringBuilder();
             
            if (argShowDate) {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string hour = DateTime.Now.Hour.ToString();
                string minute = DateTime.Now.Minute.ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append(month);
                sb.Append("/");
                sb.Append(day);
                sb.Append("/");
                sb.Append(year);
                sb.Append(" st ");

                sb.Append(hour);
                sb.Append(":");
                sb.Append(minute);
                sb.Append(":");
                sb.Append("00");
                string date = sb.ToString();
                sbOut.AppendLine("============================================================================");
                sbOut.AppendLine("created on : " + date);
                sbOut.AppendLine("============================================================================");
            }

            foreach (VC_PGN_Text_Object vcpgnt in vC_PGN_Text_Objects)
            {

                if (argshowHEAVYFormat)
                {
                    sbOut.AppendLine("============================================================================");
                    sbOut.AppendLine("CAN Messages From : " + vcpgnt.vC_PGN.From);
                    sbOut.AppendLine("VC_PGN_ID : " + vcpgnt.vC_PGN.VC_PGN_ID);
                    sbOut.AppendLine("PGN_32bit : " + vcpgnt.vC_PGN.PGN_32bit);
                    sbOut.AppendLine("address Port: " + vcpgnt.vC_PGN.adrs_Port);
                    sbOut.AppendLine("address Stbd: " + vcpgnt.vC_PGN.adrs_Stbd);
                    sbOut.AppendLine("priority    : " + vcpgnt.vC_PGN.priority);
                    sbOut.AppendLine("Sending_Unit_Software_version : " + vcpgnt.vC_PGN.Sending_Unit_Software_version);
                    sbOut.AppendLine("info: " + vcpgnt.vC_PGN.info);
                    sbOut.AppendLine("Configuration : " + vcpgnt.vC_PGN.Configuration);
                    sbOut.AppendLine("Project : " + vcpgnt.vC_PGN.Project);
                    sbOut.AppendLine("============================================================================");
                    sbOut.AppendLine("    " + vcpgnt.vC_PGNData.PGN + "    ( " + vcpgnt.vC_PGNData.DescritionPGN + " )");
                    sbOut.AppendLine("");
                }
                else {

                    sbOut.AppendLine("============================================================================");
                    sbOut.AppendLine("CAN Messages From : " + vcpgnt.vC_PGN.From);
                    sbOut.AppendLine("Sending_Unit_Software_version : " + vcpgnt.vC_PGN.Sending_Unit_Software_version);
                    sbOut.AppendLine("Configuration : " + vcpgnt.vC_PGN.Configuration);
                    sbOut.AppendLine("Project : " + vcpgnt.vC_PGN.Project);
                    sbOut.AppendLine("============================================================================");
                    sbOut.AppendLine("    " + vcpgnt.vC_PGNData.PGN + "    ( " + vcpgnt.vC_PGNData.DescritionPGN + " )");
                    sbOut.AppendLine("");
                }
                if (argShowByteDetail)
                {
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte0 : " + vcpgnt.vC_PGNData.DescritionByte0, vcpgnt.vC_PGNData.Byte0,true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte1 : " + vcpgnt.vC_PGNData.DescritionByte1, vcpgnt.vC_PGNData.Byte1, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte2 : " + vcpgnt.vC_PGNData.DescritionByte2, vcpgnt.vC_PGNData.Byte2, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte3 : " + vcpgnt.vC_PGNData.DescritionByte3, vcpgnt.vC_PGNData.Byte3, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte4 : " + vcpgnt.vC_PGNData.DescritionByte4, vcpgnt.vC_PGNData.Byte4, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte5 : " + vcpgnt.vC_PGNData.DescritionByte5, vcpgnt.vC_PGNData.Byte5, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte6 : " + vcpgnt.vC_PGNData.DescritionByte6, vcpgnt.vC_PGNData.Byte6, true);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte7 : " + vcpgnt.vC_PGNData.DescritionByte7, vcpgnt.vC_PGNData.Byte7, true);
                }
            }



            return sbOut.ToString();   
        }

        private void Build_List_of_BytesAndBitsFor_VC_PGN_Object(StringBuilder argsb, string description, List<string> bits, bool argShowBits)
        {
            argsb.AppendLine("            - " + description);
            if (bits.Count == 0)
            {
                argsb.AppendLine(" ");
                return;
            }

            if (argShowBits)
            {
                int bitIndex = 0;
                foreach (var bitLine in bits)
                {
                    string fullBitLine = "                    - b" + bitIndex.ToString() + " : " + bitLine;
                    argsb.AppendLine(fullBitLine);
                    bitIndex++;
                }
            }

            argsb.AppendLine(" ");
        }
    }
}
