using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator
{
    public partial class CanSimForm : Form
    {
        public CanSimForm()
        {
            InitializeComponent();

            radioButton1.Parent = groupBox1;
            radioButton2.Parent = groupBox1;
            radioButton3.Parent = groupBox1;

            // Optionally, adjust the location of RadioButtons within the GroupBox
            radioButton1.Location = new Point(10, 20);
            radioButton2.Location = new Point(10, 50);
            radioButton3.Location = new Point(10, 80);

            //groupBox1.Size = new Size(200, 150); // Adjust size as needed

            tableLayoutPanel1.Controls.Add(groupBox1, 1, 1);
            // Add GroupBox to TableLayoutPanel
            // tableLayoutPanel1.Controls.Add(groupBox1, 1, 1); // Adding to cell
        }
    }
}
