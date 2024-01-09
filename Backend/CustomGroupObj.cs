using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.Backend
{
    public class CustomGroupObj
    {
        public int gID { get; private set; }
        public string GroupName { get; private set; }
        public int NumberOfEntries { get; private set; }

        public bool VALID_GROUP { get; private set; }
        public int argErrorNumber {  get; private set; }
        public string errorType { get; private set; }

        HashSet<int> hashset_seenInts;
        List<int> seenIntsList;
        public List<int> Group_bitList_ints() {
            return this.seenIntsList;
        }
        public CustomGroupObj(int arg_groupID, string argGroupName,  string arg_0_1_2)
        {
            gID=arg_groupID;
            VALID_GROUP = true;
            hashset_seenInts =new HashSet<int>();
            seenIntsList=new List<int>();
            argErrorNumber = -1; // old OUT Initialize with a default value indicating no error
            errorType = null; // old OUT Initialize with null, indicating no error
            var stringParts = arg_0_1_2.Split(',');
            foreach (var part in stringParts)
            {
                if (int.TryParse(part, out int number))
                {
                    if (hashset_seenInts.Contains(number))
                    {
                        if (argErrorNumber == -1) // Set argErrorNumber and errorType only if they haven't been set before
                        {
                            argErrorNumber = number;
                            errorType = $"Dp: {number}";
                            VALID_GROUP = false;
                        }
                        VALID_GROUP = false;
                        // MessageBox.Show($"Duplicate number found: {number}");
                    }
                    else
                    {
                        hashset_seenInts.Add(number);
                        seenIntsList.Add(number);
                        
                    }
                }
                else
                {
                    if (argErrorNumber == -1) // Set argErrorNumber and errorType only if they haven't been set before
                    {
                        argErrorNumber = -2; // Assuming -2 indicates an invalid number
                        errorType = "Invalid Number";
                        VALID_GROUP=false;
                    }
                    
                }
            }
        }
        //public Dictionary<int, string> Get_DIC_entries() {
        //    return this.dicentriesBits;   
        //}
        //public List<int>  GetEntries_Keys()
        //{
        //    return this.dicentriesBits.Keys.ToList();
        //}
        //public List<string> GetEntries_Values()
        //{
        //    return this.dicentriesBits.Values.ToList();
        //}

    }
}
