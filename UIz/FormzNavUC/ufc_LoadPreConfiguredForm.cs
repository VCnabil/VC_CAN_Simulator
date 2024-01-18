using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.FormzNavUC
{
    public partial class ufc_LoadPreConfiguredForm : UserControl
    {

        private Form _myFormToLaunch;
        private Func<Form> _formCreator;
        string _buttonString = "Launch";

        public ufc_LoadPreConfiguredForm()
        {
            InitializeComponent();
            button_Launch.Click += Button_Launch_Click;
            button_Launch.Text = _buttonString;
        }

        public void InitUC(string argInfo, Func<Form> formCreator, string argButtonText)
        {
            textBox_Info.Text = argInfo;
            _formCreator = formCreator;
            _buttonString = argButtonText;
            button_Launch.Text = _buttonString;
        }

        public ufc_LoadPreConfiguredForm(string argInfo, Func<Form> formCreator, string argButtonText)
        {
            InitializeComponent();
            button_Launch.Click += Button_Launch_Click;
            textBox_Info.Text = argInfo;
            _formCreator = formCreator;
            _buttonString = argButtonText;
            button_Launch.Text = _buttonString;
        }

        private void Button_Launch_Click(object sender, EventArgs e)
        {
            _myFormToLaunch = _formCreator();
            _myFormToLaunch.ShowDialog();
        }
    }
}
