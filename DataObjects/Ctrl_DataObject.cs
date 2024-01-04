using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.DataObjects
{
    public class Ctrl_DataObject
    {
        int _id=0;
        public int ID { get { return _id; } private set { _id = value; } }
        string _desc = string.Empty;
        public string DESC { get { return _desc; } private set { _desc = value; } }
        int _min;
        public int MIN { get { return _min; } private set { _min = value; } }
        int _max;
        public int MAX { get { return _max; } private set { _max = value; } }
        int _def;
        public int DEF { get { return _def; } private set { _def = value; } }
        int _LOindx;
        public int INDEXLO { get { return _LOindx; } private set { _LOindx = value; } }
        int _HIindx;
        public int INDEXHI { get { return _HIindx; } private set { _HIindx = value; } }
        string _ctrlType_str;
        public string CTRL_TYOE_STR { get { return _ctrlType_str; } private set { _ctrlType_str = value; } }
        bool _isSlider;
        public bool ISSLIDER { get { return _isSlider; } private set { _isSlider = value; } }

        List<string> _8bitsList= new List<string>();
        public List<string> BitsList { get; private set; }

        List<string> _group1List = new List<string>();
        public List<string> Group1List { get; private set; }
       
        List<string> _group2List = new List<string>();
        public List<string> Group2List { get; private set; }

        List<string> _remoteList = new List<string>();
        public List<string> RemoteList { get; private set; }
      
        public Ctrl_DataObject(int argid,string argDesc, int argmin, int argmax, int argdef, int argLO, int argHI, string argType, bool argisSlider,
            List<string> argBitlist, List<string> arggroup1list, List<string> arggroup2list, List<string> argremotelist) {
            _id= argid;
            _desc= argDesc;
            _min= argmin;
            _max= argmax;
            _def= argdef;
            _LOindx = argLO;
            _HIindx = argHI;
            _ctrlType_str = argType;
            _isSlider = argisSlider;

            BitsList = argBitlist ?? new List<string>();
            Group1List = arggroup1list ?? new List<string>();
            Group2List = arggroup2list ?? new List<string>();
            RemoteList = argremotelist ?? new List<string>();

         

        }
    }
}
