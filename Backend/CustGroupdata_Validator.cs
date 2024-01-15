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

        List<List<int>> listofGroup_bitList_ints;
        public List<List<int>> GetListofGroup_bitList_ints()
        {
            return listofGroup_bitList_ints;
        }
        Dictionary<int, string> dic_bitlist;
        public Dictionary<int, string> GetDic_bitlist()
        {
            return dic_bitlist;
        }
        List<CustomGroupObj> Valid_GroupObjects;
        public List<CustomGroupObj> GetValid_GroupObjects()
        {
            return Valid_GroupObjects;
        }
        public bool These_Groups_are_VALID { get; private set; }
        public string TheProblemString { get; private set; }
        public CustGroupdata_Validator(List<string> argBitsnames, List<CustomGroupObj> argGroupsCreated) {

            These_Groups_are_VALID = true;
            TheProblemString = "";

            //validate each group
            for (int g = 0; g < argGroupsCreated.Count; g++) {
                if (argGroupsCreated[g].VALID_GROUP) {
                  //a valid list of ints 2,4,6  argGroupsCreated[g].Group_bitList_ints();
                }
                else
                {
                    string issue ="group "+ argGroupsCreated[g].GroupName + " gid: " + argGroupsCreated[g].gID + " IVLD..";
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

            //validate each group's data is unique. no duplicate bitnumbers beween groups
            HashSet<int> hashset_seenInts = new HashSet<int>();

            for (int g = 0; g < argGroupsCreated.Count; g++)
            {
                if (argGroupsCreated[g].VALID_GROUP)
                {
                    //a valid list of ints 2,4,6  argGroupsCreated[g].Group_bitList_ints();
                    List<int> group_bits = argGroupsCreated[g].Group_bitList_ints();
                    for (int i = 0; i < group_bits.Count; i++)
                    {
                        if (hashset_seenInts.Contains(group_bits[i]))
                        {
                            string issue = $"group {argGroupsCreated[g].GroupName} gid: {argGroupsCreated[g].gID} has dup bitnum: {group_bits[i]}"+" present in anothergroup";
                            TheProblemString += issue;
                            These_Groups_are_VALID = false;
                        }
                        else
                        hashset_seenInts.Add(group_bits[i]);
                         
                    }
                }
              
            }


            //validate each group's data vs dic_bitlist's keys (bitnumbers)
            for (int g = 0; g < argGroupsCreated.Count; g++)
            {
                if (argGroupsCreated[g].VALID_GROUP)
                {
                    //a valid list of ints 2,4,6  argGroupsCreated[g].Group_bitList_ints();
                    List<int> group_bits = argGroupsCreated[g].Group_bitList_ints();
                    for (int i = 0; i < group_bits.Count; i++)
                    {
                        if (!dic_bitlist.ContainsKey(group_bits[i]))
                        {
                            string issue = $"group {argGroupsCreated[g].GroupName} gid: {argGroupsCreated[g].gID} has bitnum: {group_bits[i]} not in bitlist";
                            TheProblemString += issue;
                            These_Groups_are_VALID = false;
                        }
                    }
                }
                else
                {
                    string issue = "group " + argGroupsCreated[g].GroupName + " gid: " + argGroupsCreated[g].gID + " IVLD. NOT in bitlist";
                    TheProblemString += issue;
                    These_Groups_are_VALID = false;
                }
            }

            Valid_GroupObjects=new List<CustomGroupObj>();
            for (int g = 0; g < argGroupsCreated.Count; g++)
            {
                if (argGroupsCreated[g].VALID_GROUP)
                {
                    Valid_GroupObjects.Add(argGroupsCreated[g]);
                }
            }
            listofGroup_bitList_ints=new List<List<int>>();
            for (int g = 0; g < Valid_GroupObjects.Count; g++)
            {
                listofGroup_bitList_ints.Add(Valid_GroupObjects[g].Group_bitList_ints());
            }

            //if (!These_Groups_are_VALID) {
            //    argLabel.Text = TheProblemString;
            //    argLabel.ForeColor = System.Drawing.Color.Red;
            //}
        }
    }
}
