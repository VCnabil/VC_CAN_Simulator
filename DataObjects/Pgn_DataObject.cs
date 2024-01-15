using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.DataObjects
{
    public  class Pgn_DataObject
    {
        public int IDpgn { get; set; }
        public int PGN_int { get; set; }
        public string PGN_strHEX { get; set; }
        public string DESCpgn { get; set; }
        public List<Ctrl_DataObject> CtrlList { get; set; }
    }
}

/*
        //int _pgnid = 0;
        public int IDpgn { get; private set; }
        //int _pgn;
        public int PGN_int { get; private set; }
        //string _pgndesc = string.Empty;

        //string _pgnStrhex = string.Empty;
        public string PGN_strHEX { get; private set; }
        public string DESCpgn { get; private set; }

        // List<Ctrl_DataObject> _listOfCtrls = new List<Ctrl_DataObject>();
        public List<Ctrl_DataObject> CtrlList { get; private set; }

        public Pgn_DataObject( )
        {
             
        }
        public Pgn_DataObject(int argpgnid, int argpgn,string argpgnStr, string argDescpgn, List<Ctrl_DataObject> argListCtrls) {
            IDpgn = argpgnid;
            PGN_int = argpgn;
            PGN_strHEX = argDescpgn;
            DESCpgn = argpgnStr;
            CtrlList = new List<Ctrl_DataObject>(); // Initialize CtrlList

            if (argListCtrls != null)
            {
                foreach (var ctrl in argListCtrls)
                {
                    CtrlList.Add(ctrl); // Add to CtrlList instead of _listOfCtrls
                }
            }
        }
 */