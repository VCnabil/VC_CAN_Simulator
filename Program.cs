using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.UIz.Formz;
using VC_CAN_Simulator.VC_PGNS_DIR.VC_UI;

namespace VC_CAN_Simulator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new VC_PGNjsonGUI());
           Application.Run(new CustomCanGUI());
            //Application.Run(new CanManipForm());
            //Application.Run(new TestingForm());
            // Application.Run(new CanSimForm());
            //Application.Run(new CreateOrModifyProject());
        }
    }
}
