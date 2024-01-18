using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.VC_PGNS_DIR.VC_UI
{

    public class Root_VC_PGN_Text_Object
    {
        public string ProjectName { get; set; }
        public List<VC_PGN_Text_Object> VC_PGN_Text_Object { get; set; }
    }
    public class VC_PGN_Text_Object
    {
        public VC_PGN vC_PGN { get; set; }
        public VC_PGNData vC_PGNData { get; set; }
    }

    public class VC_PGN
    {
        public string From { get; set; }
        public int VC_PGN_ID { get; set; }
        public uint PGN_32bit { get; set; }
        public string adrs_Port { get; set; }
        public string adrs_Stbd { get; set; }
        public string priority { get; set; }
        public string Sending_Unit_Software_version { get; set; }
        public string info { get; set; }
        public string Configuration { get; set; }
        public string Project { get; set; }

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

    public struct FilterData
    {
        public bool Filter_bool_Pgn { get; set; }
        public string Filter_str_Pgn { get; set; }
        public bool Filter_bool_FromSendingUnit { get; set; }
        public string Filter_str_From { get; set; }
        public bool Filter_bool_Configuration { get; set; }
        public string Filter_str_Configuration { get; set; }
        public bool Filter_bool_Project { get; set; }
        public string Filter_str_Project { get; set; }
    }

    public struct DetailDisplayData {

        public bool Show_bool_Date { get; set; }

        public bool Show_bool_HEAVY { get; set; }


        public bool Show_bool_From { get; set; }

        public bool Show_bool_ID { get; set; }

        public bool Show_bool_PGN32bit { get; set; }

        public bool Show_bool_Addresses { get; set; }

        public bool Show_bool_Priority { get; set; }

        public bool Show_bool_SoftwareVersion { get; set; }


        public bool Show_bool_Info { get; set; }

        public bool Show_bool_Configuration { get; set; }

        public bool Show_bool_Project { get; set; }

        public bool Show_bool_Bytes { get; set; }

        public bool Show_bool_Bits { get; set; }
    }
}
