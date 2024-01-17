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
        string sourceFilePath_GroudZero;
        string targetFilePath_JSON;
        string light_formatFilePath;
        string FullformatFilePath;

        List<List<string>> ListOfTextPgnBlocks;
        
        public VC_PGNjsonGUI()
        {
            InitializeComponent();
            sourceFilePath_GroudZero = Path.Combine(_vcPgnDirPath, _vcreadonly_samplepgnTXT_FileName);
            targetFilePath_JSON = Path.Combine(_vcPgnDirPath, _vcWrite_samplepgnTXT_FileName);
            light_formatFilePath = Path.Combine(_vcPgnDirPath, _vcErite_textCanOriginalFormat_FileName);
            FullformatFilePath = Path.Combine(_vcPgnDirPath, _vcErite_textCanOriginal_FULL_Format_FileName);
            btn_run.Click += Btn_run_Click;
            btn_run_makeText.Click += Btn_run_makeText_Click;
            textBox1.Text = "";
            textBox1.Text = sourceFilePath_GroudZero;
            textBox2.Text = "";
        }

        private void AddByteDescriptionAndBits(List<string> list, string description, List<string> bits)
        {
            list.Add("            - " + description);
            if (bits.Count == 0)
            {
                list.Add(" ");
                return;
            }

            int bitIndex = 0;
            foreach (var bitLine in bits)
            {
                string fullBitLine = "                    - b" + bitIndex.ToString() + " : " + bitLine;
                list.Add(fullBitLine);
                bitIndex++;
            }

            list.Add(" ");
        }

        void Do_SimpleHEaderFormat() {
            Root_VC_PGN_Text_Object root_VC_PGN_Text_Object = JsonConvert.DeserializeObject<Root_VC_PGN_Text_Object>(File.ReadAllText(targetFilePath_JSON));
             SortVC_PGN_Text_Objects(root_VC_PGN_Text_Object);

            List<string> listOfAllLinesToBeWrittenToText = new List<string>();

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

            int numberofPGN = root_VC_PGN_Text_Object.VC_PGN_Text_Object.Count();

            listOfAllLinesToBeWrittenToText.Add("============================================================================");
            listOfAllLinesToBeWrittenToText.Add("saved on : " + date);
            listOfAllLinesToBeWrittenToText.Add("============================================================================");
            listOfAllLinesToBeWrittenToText.Add("Total " + numberofPGN + " PGNS found");

            StringBuilder sb2 = new StringBuilder();
            foreach (VC_PGN_Text_Object vcpgnt in root_VC_PGN_Text_Object.VC_PGN_Text_Object)
            {

                string linestr = vcpgnt.vC_PGN.VC_PGN_ID+"  "+ vcpgnt.vC_PGNData.PGN + " " + vcpgnt.vC_PGN.PGN_32bit;
                listOfAllLinesToBeWrittenToText.Add(linestr);

                sb2.AppendLine(linestr);
                //listOfAllLinesToBeWrittenToText.Add("============================================================================");
                //listOfAllLinesToBeWrittenToText.Add("( " + vcpgnt.vC_PGN.From + " )    Project: " + vcpgnt.vC_PGN.Project +"  ");
                //listOfAllLinesToBeWrittenToText.Add("============================================================================");
                //listOfAllLinesToBeWrittenToText.Add("    " + vcpgnt.vC_PGNData.PGN + "    ( " + vcpgnt.vC_PGNData.DescritionPGN + " )");
                //listOfAllLinesToBeWrittenToText.Add("");

                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte0 : " + vcpgnt.vC_PGNData.DescritionByte0, vcpgnt.vC_PGNData.Byte0);
                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte1 : " + vcpgnt.vC_PGNData.DescritionByte1, vcpgnt.vC_PGNData.Byte1);
                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte2 : " + vcpgnt.vC_PGNData.DescritionByte2, vcpgnt.vC_PGNData.Byte2);
                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte3 : " + vcpgnt.vC_PGNData.DescritionByte3, vcpgnt.vC_PGNData.Byte3);
                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte4 : " + vcpgnt.vC_PGNData.DescritionByte4, vcpgnt.vC_PGNData.Byte4);
                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte5 : " + vcpgnt.vC_PGNData.DescritionByte5, vcpgnt.vC_PGNData.Byte5);
                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte6 : " + vcpgnt.vC_PGNData.DescritionByte6, vcpgnt.vC_PGNData.Byte6);
                //AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte7 : " + vcpgnt.vC_PGNData.DescritionByte7, vcpgnt.vC_PGNData.Byte7);
            }
            textBox2.Text = "";

            textBox2.Text = sb2.ToString();
         



            // Write to file
            File.WriteAllLines(light_formatFilePath, listOfAllLinesToBeWrittenToText);
        }

        public List<VC_PGN_Text_Object> SortVC_PGN_Text_Objects(Root_VC_PGN_Text_Object rootObject)
        {
            List<VC_PGN_Text_Object> sortedList = rootObject.VC_PGN_Text_Object
                .OrderByDescending(item => item.vC_PGN.VC_PGN_ID)
                .ToList();

            // The sortedList now contains VC_PGN_Text_Object items sorted by the PGN_32bit property
            // You can further process or use sortedList as needed

            return sortedList;
        }
       
        void Do_fullHEaderFormat() {
            Root_VC_PGN_Text_Object root_VC_PGN_Text_Object = JsonConvert.DeserializeObject<Root_VC_PGN_Text_Object>(File.ReadAllText(targetFilePath_JSON));
            List<string> listOfAllLinesToBeWrittenToText = new List<string>();

            foreach (VC_PGN_Text_Object vcpgnt in root_VC_PGN_Text_Object.VC_PGN_Text_Object)
            {
                listOfAllLinesToBeWrittenToText.Add("============================================================================");
                listOfAllLinesToBeWrittenToText.Add("CAN Messages From : " + vcpgnt.vC_PGN.From );
                listOfAllLinesToBeWrittenToText.Add("VC_PGN_ID : "+ vcpgnt.vC_PGN.VC_PGN_ID);
                listOfAllLinesToBeWrittenToText.Add("PGN_32bit : "+ vcpgnt.vC_PGN.PGN_32bit);
                listOfAllLinesToBeWrittenToText.Add("address Port: " + vcpgnt.vC_PGN.adrs_Port);
                listOfAllLinesToBeWrittenToText.Add("address Stbd: " + vcpgnt.vC_PGN.adrs_Stbd);
                listOfAllLinesToBeWrittenToText.Add("priority    : " + vcpgnt.vC_PGN.priority);
                listOfAllLinesToBeWrittenToText.Add("Sending_Unit_Software_version : " + vcpgnt.vC_PGN.Sending_Unit_Software_version);
                listOfAllLinesToBeWrittenToText.Add("info: " + vcpgnt.vC_PGN.info);
                listOfAllLinesToBeWrittenToText.Add("Configuration : " + vcpgnt.vC_PGN.Configuration);
                listOfAllLinesToBeWrittenToText.Add("Project : " + vcpgnt.vC_PGN.Project);
              //  listOfAllLinesToBeWrittenToText.Add("Project : N/A");
                listOfAllLinesToBeWrittenToText.Add("============================================================================");
                listOfAllLinesToBeWrittenToText.Add("    " + vcpgnt.vC_PGNData.PGN + "    ( " + vcpgnt.vC_PGNData.DescritionPGN + " )");
                listOfAllLinesToBeWrittenToText.Add("");

                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte0 : " + vcpgnt.vC_PGNData.DescritionByte0, vcpgnt.vC_PGNData.Byte0);
                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte1 : " + vcpgnt.vC_PGNData.DescritionByte1, vcpgnt.vC_PGNData.Byte1);
                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte2 : " + vcpgnt.vC_PGNData.DescritionByte2, vcpgnt.vC_PGNData.Byte2);
                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte3 : " + vcpgnt.vC_PGNData.DescritionByte3, vcpgnt.vC_PGNData.Byte3);
                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte4 : " + vcpgnt.vC_PGNData.DescritionByte4, vcpgnt.vC_PGNData.Byte4);
                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte5 : " + vcpgnt.vC_PGNData.DescritionByte5, vcpgnt.vC_PGNData.Byte5);
                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte6 : " + vcpgnt.vC_PGNData.DescritionByte6, vcpgnt.vC_PGNData.Byte6);
                AddByteDescriptionAndBits(listOfAllLinesToBeWrittenToText, "Byte7 : " + vcpgnt.vC_PGNData.DescritionByte7, vcpgnt.vC_PGNData.Byte7);
            }

            // Write to file
            File.WriteAllLines(FullformatFilePath, listOfAllLinesToBeWrittenToText);

        }
        private void Btn_run_makeText_Click(object sender, EventArgs e)
        {
            //Do_fullHEaderFormat();
            Do_SimpleHEaderFormat();
        }
        private void Btn_run_Click(object sender, EventArgs e)
        {
            ListOfTextPgnBlocks = Run_test1MyBLockCounting();
            Root_VC_PGN_Text_Object root_VC_PGN_Text_Object = new Root_VC_PGN_Text_Object();
            root_VC_PGN_Text_Object.ProjectName = "VC_PGN";
            root_VC_PGN_Text_Object.VC_PGN_Text_Object = new List<VC_PGN_Text_Object>();
            foreach (var block in ListOfTextPgnBlocks)
            {
                VC_PGN_Text_Object vC_PGN_Text_Object = TurnBlockToDataObject(block);
                root_VC_PGN_Text_Object.VC_PGN_Text_Object.Add(vC_PGN_Text_Object);
            }

            for(int i=0; i< root_VC_PGN_Text_Object.VC_PGN_Text_Object.Count; i++)
            {
                root_VC_PGN_Text_Object.VC_PGN_Text_Object[i].vC_PGN.VC_PGN_ID= 0;// -------------------------------------------------sets all id to 0
                string hexString = root_VC_PGN_Text_Object.VC_PGN_Text_Object[i].vC_PGNData.PGN;
                uint intValue;

                // Remove the '0x' prefix if present
                if (hexString.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    hexString = hexString.Substring(2);
                }

                // Convert the hexadecimal string to an integer
                intValue = Convert.ToUInt32(hexString, 16);
                root_VC_PGN_Text_Object.VC_PGN_Text_Object[i].vC_PGN.PGN_32bit = intValue;
            }

            label1.Text= root_VC_PGN_Text_Object.VC_PGN_Text_Object.Count().ToString();
            string json = JsonConvert.SerializeObject(root_VC_PGN_Text_Object, Formatting.Indented);
            textBox1.Text = json;
            File.WriteAllText(targetFilePath_JSON, json);

        }
        List<string> GetAllLines(string filePath)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace("\t", "    "); // Replace tabs with 4 spaces
                    lines.Add(line);
                }
            }
            return lines;
        }
        List<List<string>> Run_test1MyBLockCounting()
        {
            List<string> allLines = GetAllLines(sourceFilePath_GroudZero);
            string DelimiterBlock = "============================================================================";
            List<List<string>> ALLblocks = new List<List<string>>();
            List<string> _cur_block = new List<string>();
            bool blockStarted = false;

            for (int l = 0; l < allLines.Count; l++)
            {

                if (l < allLines.Count )
                {
                    if (l < allLines.Count - 1) {
                        if (allLines[l] == DelimiterBlock && allLines[l + 1].StartsWith("CAN Messages"))
                        {
                            blockStarted = true;
                        }

                        if (String.IsNullOrWhiteSpace(allLines[l]) && allLines[l + 1].StartsWith("==========="))
                        {
                            blockStarted = false;
                        }

                    }
                    if (l == allLines.Count - 1)
                    {
                            blockStarted = false;
                    }
                }
                else
                {
                    blockStarted = false;
                }

                if (blockStarted)
                {
                    if (_cur_block == null)
                    {
                        _cur_block = new List<string>();
                    }
                    if (!String.IsNullOrWhiteSpace(allLines[l]))
                    {
                        string trimmedString = allLines[l].TrimStart();
                        _cur_block.Add(trimmedString);
                    }
                }
                else
                {
                    if (_cur_block != null)
                    {
                        if (!String.IsNullOrWhiteSpace(allLines[l]))
                        {
                            string trimmedString = allLines[l].TrimStart();
                            _cur_block.Add(trimmedString);
                        }
                        ALLblocks.Add(_cur_block);
                        _cur_block = new List<string>();
                    }
                }
            }
            if (_cur_block.Count > 0)
            {
                ALLblocks.Add(_cur_block);
            }

            label2.Text = ALLblocks.Count().ToString();
            return ALLblocks;
        }
        VC_PGN_Text_Object TurnBlockToDataObject(List<string> argBlock)
        {
            VC_PGN_Text_Object vC_PGN_Text_Object = new VC_PGN_Text_Object();
            VC_PGN vC_PGN = new VC_PGN();
            VC_PGNData vC_PGNData = new VC_PGNData();
            vC_PGN_Text_Object.vC_PGN = vC_PGN;
            vC_PGN_Text_Object.vC_PGNData = vC_PGNData;

            if (argBlock != null && argBlock.Count > 12)
            {
                //=============================================
                vC_PGN.From =                           argBlock[1].Split(':')[1].Trim();
                string stringValue_IDVal =              argBlock[2].Split(':')[1].Trim();
                int idVal = int.TryParse(stringValue_IDVal, out idVal) ? idVal : -1;
                vC_PGN.VC_PGN_ID = idVal;
                string stringValue_PGN_32bit=           argBlock[3].Split(':')[1].Trim();
                uint pgn_32bit = uint.TryParse(stringValue_PGN_32bit, out pgn_32bit) ? pgn_32bit : 0;
                vC_PGN.PGN_32bit = pgn_32bit;
                vC_PGN.adrs_Port =                      argBlock[4].Split(':')[1].Trim();
                vC_PGN.adrs_Stbd =                      argBlock[5].Split(':')[1].Trim();
                vC_PGN.priority =                       argBlock[6].Split(':')[1].Trim();
                vC_PGN.Sending_Unit_Software_version =  argBlock[7].Split(':')[1].Trim();
                vC_PGN.info =                           argBlock[8].Split(':')[1].Trim();
                vC_PGN.Configuration =                  argBlock[9].Split(':')[1].Trim();
                vC_PGN.Project =                        argBlock[10].Split(':')[1].Trim();
                //=============================================
                vC_PGNData.PGN =                        argBlock[12].Split('(')[0].Trim();
                string pattern = @"\(([^)]*)\)";
                Match match = Regex.Match(argBlock[12], pattern);
                vC_PGNData.DescritionPGN = match.Success ? match.Groups[1].Value : ""; ;
           
                int index = 13;
                while (index < argBlock.Count)
                {
                    string line = argBlock[index].Trim();

                    if (line.StartsWith("- Byte"))
                    {
                        int byteNumber = int.TryParse(line.Substring(6).Split(':')[0].Trim(), out byteNumber) ? byteNumber : -1;
                        string byteDescription = line.Contains(":") ? line.Split(':')[1].Trim() : "N/A";
                        List<string> bitTitles = new List<string>();
                        index++; // Move to the next line after Byte line
                        // Collect bit titles if available
                        while (index < argBlock.Count && argBlock[index].Trim().StartsWith("- b"))
                        {
                            string bitLine = argBlock[index].Trim();
                            bitTitles.Add(bitLine.Split(':')[1].Trim());
                            index++;
                        }
                        // Assign data to VC_PGNData
                        if (byteNumber != -1) // Check if byte number was successfully parsed
                        {
                            AssignByteData2(vC_PGNData, byteDescription, bitTitles, byteNumber);
                        }
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            else
            {
                MessageBox.Show(argBlock == null ? "Block is null" : "Block is too small");
            }
            return vC_PGN_Text_Object;
        }



        void AssignByteData2(VC_PGNData vC_PGNData, string argbytedescription, List<string> bitTitles, int argbytenumber)
        {
            switch (argbytenumber)
            {
                case 0:
                    vC_PGNData.DescritionByte0 = argbytedescription;
                    vC_PGNData.Byte0 = bitTitles;
                    break;
                case 1:
                    vC_PGNData.DescritionByte1 = argbytedescription;
                    vC_PGNData.Byte1 = bitTitles;
                    break;
                case 2:
                    vC_PGNData.DescritionByte2 = argbytedescription;
                    vC_PGNData.Byte2 = bitTitles;
                    break;
                case 3:
                    vC_PGNData.DescritionByte3 = argbytedescription;
                    vC_PGNData.Byte3 = bitTitles;
                    break;
                case 4:
                    vC_PGNData.DescritionByte4 = argbytedescription;
                    vC_PGNData.Byte4 = bitTitles;
                    break;
                case 5:
                    vC_PGNData.DescritionByte5 = argbytedescription;
                    vC_PGNData.Byte5 = bitTitles;
                    break;
                case 6:
                    vC_PGNData.DescritionByte6 = argbytedescription;
                    vC_PGNData.Byte6 = bitTitles;
                    break;
                case 7:
                    vC_PGNData.DescritionByte7 = argbytedescription;
                    vC_PGNData.Byte7 = bitTitles;
                    break;
                    // Add additional cases if you have more bytes
            }
        }

    }

    

}


/*  
 *  
        void DisplayBlocks(List<List<string>> argALLblocks)
        {
            string _cur_block = "";
            foreach (var block in argALLblocks)
            {
                foreach (var line in block)
                {
                    _cur_block += line + "\r\n";
                }
                _cur_block += "\r\n";
            }
            textBox1.Text = _cur_block;
        }

        void Display_block_atIndex(int argBlockindex, List<List<string>> argALLblocks)
        {
            string _cur_block = "";
            foreach (var line in argALLblocks[argBlockindex])
            {
                _cur_block += line + "\r\n";
            }
            textBox1.Text = _cur_block;
        }
*/