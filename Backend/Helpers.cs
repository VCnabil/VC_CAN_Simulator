using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
