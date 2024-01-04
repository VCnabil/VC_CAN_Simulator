using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.DataObjects;
using VC_CAN_Simulator.UIz.UControlz.Builders;

namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class CreateOrModifyProject : Form
    {
        string _filename = string.Empty;
        PROJECT_Builder_UC _PROJbUILDER_UC;
        public CreateOrModifyProject()
        {
            InitializeComponent();
            this.Width = 2900;
            this.Height = 1800;
            btn_Load.Click += Btn_Load_Click;
            btn_Save.Click += Btn_Save_Click;
            tb_filename.TextChanged += Tb_filename_TextChanged;
            _PROJbUILDER_UC = new PROJECT_Builder_UC();
            _PROJbUILDER_UC.Location = new Point(0, 40);
            Controls.Add(_PROJbUILDER_UC);
        }

        private void Tb_filename_TextChanged(object sender, EventArgs e)
        {
            _filename = tb_filename.Text;
            if (_filename == "") { 
                btn_Save.Hide();
            }
            else { btn_Save.Show(); }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Project_DataObject PROJECTTOSAVE= _PROJbUILDER_UC.Make_ProjectDataObject();
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
             
        }
    }
}
