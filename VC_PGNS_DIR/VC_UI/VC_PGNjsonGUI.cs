using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using VC_CAN_Simulator.Backend;
using static System.Windows.Forms.LinkLabel;
using static VC_CAN_Simulator.Backend.Helpers;
namespace VC_CAN_Simulator.VC_PGNS_DIR.VC_UI
{
    public partial class VC_PGNjsonGUI : Form
    {
        string sourceFilePath;
        string targetFilePath;
        List<List<string>> ListOfTextPgnBlocks;
        List<VC_PGN_Text_Object> mylistFromText;
        public VC_PGNjsonGUI()
        {
            InitializeComponent();
            sourceFilePath = Path.Combine(_vcPgnDirPath, _vcreadonly_samplepgnTXT_FileName);
            targetFilePath = Path.Combine(_vcPgnDirPath, _vcWrite_samplepgnTXT_FileName);
            btn_run.Click += Btn_run_Click;
            textBox1.Text = "";
            textBox1.Text = sourceFilePath;
        }

        private void Btn_run_Click(object sender, EventArgs e)
        {
            ListOfTextPgnBlocks = Run_test1MyBLockCounting();
            //Display_block_atIndex(1,ListOfTextPgnBlocks);
            //TurnBlockToDataObject(ListOfTextPgnBlocks[0]);
            Root_VC_PGN_Text_Object root_VC_PGN_Text_Object = new Root_VC_PGN_Text_Object();
            root_VC_PGN_Text_Object.ProjectName = "VC_PGN";
            root_VC_PGN_Text_Object.VC_PGN_Text_Object = new List<VC_PGN_Text_Object>();
            foreach (var block in ListOfTextPgnBlocks)
            {
                VC_PGN_Text_Object vC_PGN_Text_Object = TurnBlockToDataObject(block);
                root_VC_PGN_Text_Object.VC_PGN_Text_Object.Add(vC_PGN_Text_Object);
            }

            label1.Text= root_VC_PGN_Text_Object.VC_PGN_Text_Object.Count().ToString();
            string json = JsonConvert.SerializeObject(root_VC_PGN_Text_Object, Formatting.Indented);
            textBox1.Text = json;
            File.WriteAllText(targetFilePath, json);

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

        List<List<string>> Run_test1MyBLockCountingbad()
        {
            List<string> allLines = GetAllLines(sourceFilePath);
            string DelimiterBlock = "============================================================================";
            List<List<string>> ALLblocks = new List<List<string>>();
            List<string> _cur_block = new List<string>();
            bool blockStarted = false;

            foreach (var line in allLines)
            {
                if (line == DelimiterBlock)
                {
                    if (blockStarted)
                    {
                        // End of current block
                        ALLblocks.Add(new List<string>(_cur_block));
                        _cur_block.Clear();
                    }
                    else
                    {
                        // Start of a new block
                        blockStarted = true;
                    }
                }
                else if (blockStarted)
                {
                    // Add line to current block if it's not empty
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        _cur_block.Add(line.Trim());
                    }
                }
            }

            // Add the last block if it's not empty
            if (_cur_block.Count > 0)
            {
                ALLblocks.Add(_cur_block);
            }

            label2.Text = ALLblocks.Count.ToString();
            return ALLblocks;
        }

        List<List<string>> Run_test1MyBLockCounting()
        {
            List<string> allLines = GetAllLines(sourceFilePath);
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
                vC_PGN.adrs_Port =                      argBlock[2].Split(':')[1].Trim();
                vC_PGN.adrs_Stbd =                      argBlock[3].Split(':')[1].Trim();
                vC_PGN.priority =                       argBlock[4].Split(':')[1].Trim();
                vC_PGN.Sending_Unit_Software_version =  argBlock[5].Split(':')[1].Trim();
                vC_PGN.info =                           argBlock[6].Split(':')[1].Trim();
                vC_PGN.Configuration =                  argBlock[7].Split(':')[1].Trim();
                //=============================================
                vC_PGNData.PGN =                        argBlock[9].Split('(')[0].Trim();
                string pattern = @"\(([^)]*)\)";
                Match match = Regex.Match(argBlock[9], pattern);
                vC_PGNData.DescritionPGN = match.Success ? match.Groups[1].Value : ""; ;
           
                int index = 10;
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


    public class Root_VC_PGN_Text_Object
    {
        public string ProjectName { get; set; }
        public List<VC_PGN_Text_Object> VC_PGN_Text_Object { get; set; }
    }
    public class VC_PGN_Text_Object {
        public VC_PGN vC_PGN { get; set; }
        public VC_PGNData vC_PGNData { get; set; }
    }

    public class VC_PGN
    {
        public string From { get; set; }
        public string adrs_Port { get; set; }
        public string adrs_Stbd { get; set; }
        public string priority { get; set; }
        public string Sending_Unit_Software_version { get; set; }
        public string info { get; set; }
        public string Configuration { get; set; }

    }
    public class VC_PGNData
    {
        public string PGN { get; set; }
        public string DescritionPGN { get; set; }
        public string DescritionByte0 { get; set; }
        public List<string> Byte0 { get; set; }
        public string DescritionByte1 { get; set; }
        public List<string> Byte1 { get; set; }
        public string DescritionByte2 { get; set; }
        public List<string> Byte2 { get; set; }
        public string DescritionByte3 { get; set; }
        public List<string> Byte3 { get; set; }
        public string DescritionByte4 { get; set; }
        public List<string> Byte4 { get; set; }
        public string DescritionByte5 { get; set; }
        public List<string> Byte5 { get; set; }
        public string DescritionByte6 { get; set; }
        public List<string> Byte6 { get; set; }
        public string DescritionByte7 { get; set; }
        public List<string> Byte7 { get; set; }


    }
}