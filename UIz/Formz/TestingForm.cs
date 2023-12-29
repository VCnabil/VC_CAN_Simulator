using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.UIz.UControlz.Builders;

namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class TestingForm : Form
    {
        List<string> list = new List<string>();
        public TestingForm()
        {
            InitializeComponent();
            this.Width = 2900;
            this.Height = 1800;
            list.Add("one");
            list.Add("two");
            list.Add("three");

            PROJECT_Builder_UC p = new PROJECT_Builder_UC();
            p.Location = new Point(0, 0);
            Controls.Add(p);
             
        }
    }
}
