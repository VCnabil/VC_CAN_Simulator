using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.Backend;
using VC_CAN_Simulator.DataObjects;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.ManipUC
{
    public partial class UC_manip8_bG : UserControl
    {
        Color borderColor;
        int _cur_INT_Value;
        byte[] my2bytes;
        #region _8_bG

        private int maxWidth = 250;
        private int rbHeight = 15;
        private int maxHeight = 80;
        private int groupeUIwidth;
        private RadioButton lastCheckedRadioButton;

        List<CustomGroupObj> customGroupData;
        CustomGroupObj group1;
        CustomGroupObj group2;
        CustomGroupObj group3;
        CustomGroupObj group4;
        // List<int> allGroups_bits_used;

        CustGroupdata_Validator validator;

        #endregion

        public UC_manip8_bG()
        {
            InitializeComponent();
            my2bytes = new byte[2];
            
            InitGroups(2, 2);
            Init(3);
        }

        public UC_manip8_bG(Ctrl_DataObject argCtrlData)
        {
            InitializeComponent();
            my2bytes = new byte[2];
           

            if (argCtrlData == null)
            {
                MessageBox.Show("null dataobj");
                return;
            }
            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._1_By))
            {
                MessageBox.Show("cannot be 1by");
                return;
            }

            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._2_by))
            {
                MessageBox.Show("cannot be 2by ");
                return;
            }
            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._8_bs))
            {
                MessageBox.Show("cannot be bs ");
                return;
            }
        

            if (argCtrlData.Group1List == null)
            {
                MessageBox.Show("grouplist 1 is null!");
                return;
            }
            if (argCtrlData.Group2List == null)
            {
                MessageBox.Show("grouplist 2 is null!");
                return;
            }
            if (argCtrlData.Group1List.Count() > 0)
            {
                group1 = new CustomGroupObj(1,"gro 1", argCtrlData.Group1List[0]);
                
                
            }
            if (argCtrlData.Group2List.Count() > 0)
            {
                group2 = new CustomGroupObj(2,"gro 2", argCtrlData.Group2List[0]);
            }
           
            customGroupData = new List<CustomGroupObj>();
            if(group1 != null)
                customGroupData.Add(group1);
            if(group2 != null)
                customGroupData.Add(group2);
            if(group3 != null)
                customGroupData.Add(group3);
            if(group4 != null)
                customGroupData.Add(group4);

            if (argCtrlData.BitsList == null)
            {
                MessageBox.Show("Bitlist is null!");
                return;
            }

            validator = new CustGroupdata_Validator(argCtrlData.BitsList, customGroupData, this.lbl_Desc);

            if (!validator.These_Groups_are_VALID) { return; }


            //get rbs and events and calcvalue
            //InitGroups(numberofGroups, 2);
            Init(3);
        }
        public void Init(int argBorderColor)
        {
            SetBorderColor(argBorderColor);
            // Subscribe to hover events for this control and all child controls
            SubscribeHoverEvents(this);
        }

        #region _8_bGFuncs
        int CalgGroupWidth(int numberofgroups) {

            if (numberofgroups > 4)numberofgroups = 4;
            if (numberofgroups < 0) numberofgroups = 0;

            if (numberofgroups == 0) groupeUIwidth= 1;
            if (numberofgroups == 1) groupeUIwidth = 120;
            if (numberofgroups == 2) groupeUIwidth = 100;
            if (numberofgroups == 3) groupeUIwidth = 70;
            if (numberofgroups > 3) groupeUIwidth = 52;

            return groupeUIwidth;


        }
        public void InitGroups(int argNumberofGroups, int numberofRBperGroup)
        {
            if (argNumberofGroups == 0) return;

            groupeUIwidth = CalgGroupWidth(argNumberofGroups);
            lbl_Bval.Text = groupeUIwidth.ToString();

            int marginLeft= 2;
            int marginTop= 4;
            float fontSize = 7.0f; // Set the desired font size here
            string fontFamily = GetFontByIndex(0);// Desired font family
            for (int i = 0; i < argNumberofGroups; i++)
            {
                GroupBox groupBox = new GroupBox
                {
                    Text = "gb_"+i.ToString(),
                    Width = groupeUIwidth,
                    Height = maxHeight,
                    Location = new Point(groupeUIwidth * i+ marginLeft, marginTop)
                };
                this.Controls.Add(groupBox);
                groupBox.Font = new Font(fontFamily, fontSize); // Set font size
                for (int j = 0; j < numberofRBperGroup; j++)
                {
                    RadioButton radioButton = new RadioButton
                    {
                        Text = $"rb{j + 1}",
                        Location = new Point(2, rbHeight + j * rbHeight),
                        AutoSize = true,
                        Checked = j == 0 // First radio button enabled
                    };
                    radioButton.Font = new Font(fontFamily, fontSize); // Set font size
                    radioButton.CheckedChanged += RadioButton_CheckedChanged;
                    groupBox.Controls.Add(radioButton);
                }
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                lastCheckedRadioButton = radioButton;
                // Handle the radio button change here
                // For example, you can use lastCheckedRadioButton to get the currently selected radio button
            }
        }
        #endregion
        
        #region Commons
        private void Btn_reset_Click(object sender, EventArgs e)
        {


        }
        void SetBorderColor(int arg_indexByteLo)
        {
            if (arg_indexByteLo > 7) arg_indexByteLo = 7;
            if (arg_indexByteLo < 0) arg_indexByteLo = 0;
            borderColor = GetColorByIndex(arg_indexByteLo);




            this.Invalidate();
        }
        private void UC_manip8_bs_Paint(object sender, PaintEventArgs e)
        {
            using (Pen borderPen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            }

        }
        private void SubscribeHoverEvents(Control control)
        {
            this.Paint += UC_manip8_bs_Paint;
            btn_reset.Click += Btn_reset_Click;

            control.MouseEnter += UC_manip8_bs_MouseEnter;
            control.MouseLeave += UC_manip8_bs_MouseLeave;

            foreach (Control child in control.Controls)
            {
                SubscribeHoverEvents(child);
            }
        }
        private void UnsubscribeHoverEvents(Control control)
        {
            this.Paint -= UC_manip8_bs_Paint;
            btn_reset.Click -= Btn_reset_Click;
            control.MouseEnter -= UC_manip8_bs_MouseEnter;
            control.MouseLeave -= UC_manip8_bs_MouseLeave;

            foreach (Control child in control.Controls)
            {
                UnsubscribeHoverEvents(child);
            }
        }
        private void UC_manip8_bs_MouseEnter(object sender, EventArgs e)
        {
            lbl_Bval.Font = new Font(lbl_Bval.Font, FontStyle.Bold);
        }
        private void UC_manip8_bs_MouseLeave(object sender, EventArgs e)
        {
            lbl_Bval.Font = new Font(lbl_Bval.Font, FontStyle.Regular);
        }
        public void DisposeMe()
        {
            if (true)
            {
                // Unsubscribe from all events
                UnsubscribeHoverEvents(this);
            }
            base.Dispose(true);
        }
        #endregion

    }
}
