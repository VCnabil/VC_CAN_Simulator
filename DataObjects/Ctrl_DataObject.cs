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
        public List<string> GET_8bitsList() { return _8bitsList; }

        List<string> _group1List = new List<string>();
        public List<string> GET_Group1List() { return _group1List; }
        List<string> _group2List = new List<string>();
        public List<string> GET_Group2List() { return _group2List; }
        List<string> _remoteList = new List<string>();
        public List<string> GET_RemoteList() { return _remoteList; }
        public Ctrl_DataObject(int argid,string argDesc, int argmin, int argmax, int argdef, int argLO, int argHI, string argType, bool argisSlider, List<string> argBitlist, List<string> arggroup1list, List<string> arggroup2list, List<string> argremotelist) {
            _id= argid;
            _desc= argDesc;
            _min= argmin;
            _max= argmax;
            _def= argdef;
            _LOindx = argLO;
            _HIindx = argHI;
            _ctrlType_str = argType;
            _isSlider = argisSlider;

            if (argBitlist != null) {
                for (int i = 0; i < argBitlist.Count; i++) {
                    _8bitsList.Add(argBitlist[i]);
                }
            }

            if (arggroup1list != null)
            {
                for (int i = 0; i < arggroup1list.Count; i++)
                {
                    _group1List.Add(arggroup1list[i]);
                }
            }

            if (arggroup2list != null)
            {
                for (int i = 0; i < arggroup2list.Count; i++)
                {
                    _group2List.Add(arggroup2list[i]);
                }
            }
            if (argremotelist != null)
            {
                for (int i = 0; i < argremotelist.Count; i++)
                {
                    _remoteList.Add(argremotelist[i]);
                }
            }

        }
    }
}
