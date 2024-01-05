using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.DataObjects
{
    public class Project_DataObject
    {
        public string Title { get;    set; }
        public List<Pgn_DataObject> AllPgnList { get;   set; }

    }
}