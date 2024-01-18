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

        List<VC_PGN_Text_Object> GetFilteredPGNTextObjects(uint argLow, uint argHigh)
        {
            var filteredList = vC_PGN_Text_Objects
                .Where(item => item.vC_PGN.PGN_32bit > argLow && item.vC_PGN.PGN_32bit < argHigh)
                .ToList();

            return filteredList;
        }

        List<VC_PGN_Text_Object> GetFilteredPGNTextObjects_HexPgcContains(string argPGNcontains)
        {
            var filteredList = vC_PGN_Text_Objects
                .Where(item => item.vC_PGNData.PGN.Contains(argPGNcontains)  )
                .ToList();

            return filteredList;
        }

        public string Get_StringOutPut(bool argShowDate, bool argshowHEAVYFormat, bool argShowByteDetail) {
            StringBuilder sbOut   = new StringBuilder();
            List < VC_PGN_Text_Object > filteredList= GetFilteredPGNTextObjects_HexPgcContains("FE");
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

            foreach (VC_PGN_Text_Object vcpgnt in filteredList)
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
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte0 : " + vcpgnt.vC_PGNData.DescritionByte0, vcpgnt.vC_PGNData.Byte0);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte1 : " + vcpgnt.vC_PGNData.DescritionByte1, vcpgnt.vC_PGNData.Byte1);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte2 : " + vcpgnt.vC_PGNData.DescritionByte2, vcpgnt.vC_PGNData.Byte2);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte3 : " + vcpgnt.vC_PGNData.DescritionByte3, vcpgnt.vC_PGNData.Byte3);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte4 : " + vcpgnt.vC_PGNData.DescritionByte4, vcpgnt.vC_PGNData.Byte4);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte5 : " + vcpgnt.vC_PGNData.DescritionByte5, vcpgnt.vC_PGNData.Byte5);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte6 : " + vcpgnt.vC_PGNData.DescritionByte6, vcpgnt.vC_PGNData.Byte6);
                    Build_List_of_BytesAndBitsFor_VC_PGN_Object(sbOut, "Byte7 : " + vcpgnt.vC_PGNData.DescritionByte7, vcpgnt.vC_PGNData.Byte7);
                }
            }



            return sbOut.ToString();   
        }

        private void Build_List_of_BytesAndBitsFor_VC_PGN_Object(StringBuilder argsb, string description, List<string> bits)
        {
            argsb.AppendLine("            - " + description);
            if (bits.Count == 0)
            {
                argsb.AppendLine(" ");
                return;
            }

            int bitIndex = 0;
            foreach (var bitLine in bits)
            {
                string fullBitLine = "                    - b" + bitIndex.ToString() + " : " + bitLine;
                argsb.AppendLine(fullBitLine);
                bitIndex++;
            }

            argsb.AppendLine(" ");
        }
    }
}
