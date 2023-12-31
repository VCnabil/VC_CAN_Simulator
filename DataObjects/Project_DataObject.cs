﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.DataObjects
{
    public class Project_DataObject
    {
        string _title;
        public string Title { get { return _title; } private set { _title = value; } }

        List<Pgn_DataObject> _allpgns= new List<Pgn_DataObject>();
        public List<Pgn_DataObject> AllPgnList { get; private set; }


        public Project_DataObject(string argtitle, List<Pgn_DataObject> argPgnlist)
        {
            _title = argtitle;
            AllPgnList = argPgnlist ?? new List<Pgn_DataObject>();

            if (argPgnlist != null)
            {
                for (int i = 0; i < argPgnlist.Count; i++)
                {
                    _allpgns.Add(argPgnlist[i]);
                }
            }
        }
    }
}
