using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.Backend
{
   
    public static class Helpers
    {
        public enum CtrlType
        {
            _8_bs = 0,
            _8_bG = 1,
            _1_By = 2,
            _2_by = 3
        }


        public static string Get_Local_JSON_pgnDfinitions_fullpath() { 
            return   Path.Combine(Application.StartupPath, "_localDataDir", "_Full_descriptions_Root", "__Root_PGN_Definitions_.json");
        }
        public static string Get_Local_SaveTextDir_path()
        {
            return Path.Combine(Application.StartupPath, "_localDataDir", "_SavedTextFiles_Root");
        }



        public static string Get_Local_TEXT_READONLY_pgnDfinitions_fullpath()
        {
            return Path.Combine(Application.StartupPath, "_localDataDir", "_Full_descriptions_Root", "___Root_PGN_Definitions__READONLY.txt");
        }

        public static string _vcErite_textCanOriginalFormat_FileName = "_OriginalCanTextFormat.txt";
        public static string _vcErite_textCanOriginal_FULL_Format_FileName = "_OriginalCanTextFormatFullDescription.txt";

        public static string _vcWrite_samplepgnTXT_FileName = "__AllCleanPGNS_Written.json"; //   "__ALLjsonTxt_AllPgn_.json";
        public static string _vcreadonly_samplepgnTXT_FileName = "____sourceStandardYatchClean_READONLY.txt";// "_Sample_3pgns_READONLY.txt";
        public static string _vcPgnDirPath = @"C:\___Root_VCI_Projects\Generic_VC_PGN_SIMULATOR\genericSim\GENERICSIM_FILES\JsonCanSim\VC_PGNJsonBuilds\";


        static string _saveFileName = "TEST016";
        public static string SaveFileName { get { return _saveFileName; } set { _saveFileName = value; } }

        static string _saveDirPath = @"C:\___Root_VCI_Projects\Generic_VC_PGN_SIMULATOR\genericSim\GENERICSIM_FILES\JsonCanSim\";
        public static string SaveDirPath { get { return _saveDirPath; } private set { _saveDirPath = value; } }

        static string _saveFullFilePath="";
        public static string Get_FullFilePAth() { return _saveFullFilePath; }
        public static void Set_FullFilePAth(  string argFullFilePath) {   _saveFullFilePath= argFullFilePath; }
        private static readonly Color[] colors = new Color[]
        {
                Color.FromArgb(255, 0, 0, 0),       // Black
                Color.FromArgb(255, 150, 60, 60),   // Brown
                Color.FromArgb(255, 255, 0, 0),     // Red
                Color.FromArgb(255, 255, 165, 0),   // Orange
                Color.FromArgb(255, 255, 255, 0),   // Yellow
                Color.FromArgb(255, 0, 128, 0),     // Green
                Color.FromArgb(255, 0, 0, 255),     // Blue
                Color.FromArgb(255, 120, 0, 120),   // Purple
                Color.FromArgb(255, 128, 128, 128)  // Gray
        };
        public static Color GetColorByIndex(int index)
        {
            if (index >= 0 && index < colors.Length)
            {
                return colors[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
        }

        private static readonly string[] MyFonts = new string[]
        {
            "Miriam CLM",       // Black
            "Arial Narrow",
            "Calibri Light",
            "Verdana",
            "Tahoma",
            "Franklin Gothic Medium",
            "Futura Condensed",
            "Segoe UI",
            "Niagara Solid",
        };
        private static string saveFileName;

        public static string GetFontByIndex(int index)
        {
            if (index >= 0 && index < MyFonts.Length)
            {
                return MyFonts[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
        }

        public static (int, string) ParseBitsNamesString(string input)
        {
            int number;
            string text;

            // Split the string at the first period followed by a space
            var parts = input.Split(new[] { ". " }, StringSplitOptions.None);

            if (parts.Length >= 2 && int.TryParse(parts[0], out number))
            {
                // Successfully parsed the number, the rest of the string is the text
                text = input.Substring(parts[0].Length + 2);
            }
            else
            {
                // Handle the case where the string is not in the expected format
                number = -1; // or any default/error value
                text = input;
            }

            if (number > 7) number = 7;
            if (number < 0) number = 0;

            return (number, text);
        }
      
        public static List<int> ConvertToListOfInts(List<string> stringList, out int argErrorNumber, out string errorType)
        {
            List<int> fullInts = new List<int>();
            HashSet<int> seenInts = new HashSet<int>();
            argErrorNumber = -1; // Initialize with a default value indicating no error
            errorType = null; // Initialize with null, indicating no error

            foreach (var item in stringList)
            {
                var stringParts = item.Split(',');

                foreach (var part in stringParts)
                {
                    if (int.TryParse(part, out int number))
                    {
                        if (seenInts.Contains(number))
                        {
                            if (argErrorNumber == -1) // Set argErrorNumber and errorType only if they haven't been set before
                            {
                                argErrorNumber = number;
                                errorType = $"Dup: {number}";
                            }
                           // MessageBox.Show($"Duplicate number found: {number}");
                        }
                        else
                        {
                            fullInts.Add(number);
                            seenInts.Add(number);
                        }
                    }
                    else
                    {
                        if (argErrorNumber == -1) // Set argErrorNumber and errorType only if they haven't been set before
                        {
                            argErrorNumber = -2; // Assuming -2 indicates an invalid number
                            errorType = "Invalid Number";
                        }
                        //MessageBox.Show($"Invalid number: {part}");
                    }
                }
            }

            return fullInts;
        }
        public static string EnumToString(CtrlType argctrl_type)
        {
            return argctrl_type.ToString();
        }

        public static CtrlType StringToEnum(string argctrl_typeString)
        {
            if (Enum.TryParse(argctrl_typeString, out CtrlType ctrl_type))
            {
                return ctrl_type;
            }
            else
            {
                throw new ArgumentException("Invalid string for ctrl_type enum conversion");
            }
        }

        public static int HexStringToDecimal(string hexString)
        {
            try
            {
                return Convert.ToInt32(hexString, 16);
            }
            catch (FormatException)
            {
                //Console.WriteLine("The string is not a valid hexadecimal number.");
                return 0;
            }
            catch (OverflowException)
            {
                //Console.WriteLine("The hexadecimal number is too large to fit in a long.");
                return 0;
            }
        }
    }
}
