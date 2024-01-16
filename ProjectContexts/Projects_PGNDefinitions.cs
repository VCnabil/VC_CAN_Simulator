using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.ProjectContexts
{
    /*
       CAN_interface_spec_PRELIM_Nov-2019
  Station 1 is the Closed Bridge
  Station 2 is the Open Bridge
  
============================================================================
 Alarm and Monitoring Unit
============================================================================
0xFFA0
0xFFA1
            
============================================================================
Open and Closed Bridge SKIM Module
============================================================================
0xFFB0 
0xFFB1   

============================================================================
   LCD  
============================================================================
0xFF11
0xFF12
0xFF13
  
============================================================================
Control Unit
============================================================================
0xFF15
0xFF8C
0xFF8D          
0xFF8F
0xFF90
0xFEA2
0xFEFC
0xFFB2
0xFFB3
     */
    public class Projects_PGNDefinitions
    {


        public List<string> Get_CAN_interface_spec_PRELIM_Nov_2019() {
        return this.Get_CAN_interface_spec_PRELIM_Nov_2019();
        }
        List<string> _project_CAN_interface_spec_PRELIM_Nov_2019;
        public Projects_PGNDefinitions() {
            _project_CAN_interface_spec_PRELIM_Nov_2019 = new List<string>();
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFFA0");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFFA1");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFFB0");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFFB1");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF11");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF12");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF13");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF15");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF8C");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF8D");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF8F");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFF90");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFEA2");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFEFC");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFFB2");
            _project_CAN_interface_spec_PRELIM_Nov_2019.Add("0xFFB3");

        }
    }
}
