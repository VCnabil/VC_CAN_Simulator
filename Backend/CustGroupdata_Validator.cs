using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VC_CAN_Simulator.Backend.Helpers;
namespace VC_CAN_Simulator.Backend
{
    public class CustGroupdata_Validator
    {

        //List<int> fullInts;
        //HashSet<int> seenInts;


        Dictionary<int, string> dic_bitlist;
        public bool These_Groups_are_VALID { get; private set; }
        public string TheProblemString { get; private set; }
        public CustGroupdata_Validator(List<string> argBitsnames, List<CustomGroupObj> argGroupsCreated, System.Windows.Forms.Label argLabel) {

            These_Groups_are_VALID = true;
            TheProblemString = "";

            //validate each group
            for (int g = 0; g < argGroupsCreated.Count; g++) {
                if (argGroupsCreated[g].VALID_GROUP) {
                  //a valid list of ints 2,4,6  argGroupsCreated[g].Group_bitList_ints();
                }
                else
                {
                    string issue = argGroupsCreated[g].GroupName + " id: " + argGroupsCreated[g].gID + " IVLD..";
                    TheProblemString += issue;
                    These_Groups_are_VALID = false;
                }
            }
          

            // coppy all the "0. bit0" "2. alam1 on" ....
            dic_bitlist = new Dictionary<int, string>();
          

            for (int i=0; i< argBitsnames.Count; i++)
            {
                var result=ParseBitsNamesString(argBitsnames[i]);
                int bitnumber= result.Item1;
                string bitdescriptor=result.Item2;

                if (dic_bitlist.ContainsKey(bitnumber))
                {
                    string issue = $"Dup bitnum: {bitnumber}";
                    TheProblemString += issue;
                    These_Groups_are_VALID = false;
                    //Console.WriteLine($"Duplicate bitnumber found: {bitnumber}");
                }
                else
                {
                    dic_bitlist.Add(bitnumber, bitdescriptor);
                }
            
            }

            if (!These_Groups_are_VALID) {
                argLabel.Text = TheProblemString;
                argLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
