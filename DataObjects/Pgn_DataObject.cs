using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.DataObjects
{
    public  class Pgn_DataObject
    {
        int _pgnid = 0;
        public int IDpgn { get { return _pgnid; } private set { _pgnid = value; } }
        int _pgn;
        public int PGN_int { get { return _pgn; } private set { _pgn = value; } }
        string _pgndesc = string.Empty;

        string _pgnStrhex = string.Empty;
        public string PGN_strHEX { get { return _pgnStrhex; } private set { _pgnStrhex = value; } }
        public string DESCpgn { get { return _pgndesc; } private set { _pgndesc = value; } }

       // List<Ctrl_DataObject> _listOfCtrls = new List<Ctrl_DataObject>();
        public List<Ctrl_DataObject> CtrlList { get; private set; }

        
        public Pgn_DataObject(int argpgnid, int argpgn,string argpgnStr, string argDescpgn, List<Ctrl_DataObject> argListCtrls) {
            _pgnid = argpgnid;
            _pgn = argpgn;
            _pgndesc = argDescpgn;
            _pgnStrhex = argpgnStr;
            CtrlList = new List<Ctrl_DataObject>(); // Initialize CtrlList

            if (argListCtrls != null)
            {
                foreach (var ctrl in argListCtrls)
                {
                    CtrlList.Add(ctrl); // Add to CtrlList instead of _listOfCtrls
                }
            }
        }
    }
}
