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
        public int ID { get; set; }
        public string DESC { get; set; }
        public int MIN { get; set; }
        public int MAX { get; set; }
        public int DEF { get; set; }
        public int INDEXLO { get; set; }
        public int INDEXHI { get; set; }
        public string CTRL_TYOE_STR { get; set; }
        public bool ISSLIDER { get; set; }
        public List<string> BitsList { get; set; }
        public List<string> Group1List { get; set; }
        public List<string> Group2List { get; set; }
        public List<string> RemoteList { get; set; }
    }
}

        ////int _id=0;
        //public int ID { get; private set; }
        ////string _desc = string.Empty;
        //public string DESC { get; private set; }
        ////int _min;
        //public int MIN { get; private set; }
        ////int _max;
        //public int MAX { get; private set; }
        ////int _def;
        //public int DEF { get; private set; }
        //// int _LOindx;
        //public int INDEXLO { get; private set; }
        ////int _HIindx;
        //public int INDEXHI { get; private set; }
        ////string _ctrlType_str;
        //public string CTRL_TYOE_STR { get; private set; }
        ////bool _isSlider;
        //public bool ISSLIDER { get; private set; }

        //List<string> _8bitsList= new List<string>();
        //public List<string> BitsList { get; private set; }

        //List<string> _group1List = new List<string>();
        //public List<string> Group1List { get; private set; }
       
        //List<string> _group2List = new List<string>();
        //public List<string> Group2List { get; private set; }

        //List<string> _remoteList = new List<string>();
        //public List<string> RemoteList { get; private set; }
      
        //public Ctrl_DataObject(int argid,string argDesc, int argmin, int argmax, int argdef, int argLO, int argHI, string argType, bool argisSlider,
        //    List<string> argBitlist, List<string> arggroup1list, List<string> arggroup2list, List<string> argremotelist) {
        //    ID = argid;
        //    DESC= argDesc;
        //    MIN= argmin;
        //    MAX= argmax;
        //    DEF= argdef;
        //    INDEXLO = argLO;
        //    INDEXHI = argHI;
        //    CTRL_TYOE_STR = argType;
        //    ISSLIDER = argisSlider;

        //    BitsList = argBitlist ?? new List<string>();
        //    Group1List = arggroup1list ?? new List<string>();
        //    Group2List = arggroup2list ?? new List<string>();
        //    RemoteList = argremotelist ?? new List<string>();

         

        //}