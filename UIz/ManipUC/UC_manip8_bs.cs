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
using VC_CAN_Simulator.UIz.ManipUC.BuildersManips;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.ManipUC
{
    public partial class UC_manip8_bs : UserControl
    {
        Color borderColor;
        public int CU_VALUE_INT { get; private set; }

         
        bool _isHexFormat;
        byte[] my2bytes;
        #region _8_bs
        CheckBox[] myCbs;
        UC_PGN_Controller _myUC_PGN_BASE;
        int my_lo_indx;
        int my_hi_indx;
        public int ID_ctrl { get; private set; }
        #endregion
       


        public UC_manip8_bs(int argid, Ctrl_DataObject argCtrlData, UC_PGN_Controller argUC_PGN_BASE)
        {
            InitializeComponent();
            ID_ctrl = argid;
            _myUC_PGN_BASE = argUC_PGN_BASE;
            my_lo_indx = argCtrlData.INDEXLO;
            my_hi_indx = argCtrlData.INDEXHI;
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
            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._8_bG))
            {
                MessageBox.Show("cannot be bG ");
                return;
            }


            _isHexFormat = true;
            my2bytes = new byte[2];



            Init(argCtrlData);
        }
        
        public void Init(Ctrl_DataObject argCtrlData)
        {
            int argBorderColor = argCtrlData.INDEXLO;
            SetBorderColor(argBorderColor);

            // Subscribe to hover events for this control and all child controls
            SubscribeHoverEvents(this);
            lbl_Desc.Text = argCtrlData.DESC;
            set_myBits_ifApplies(argCtrlData.BitsList);
            Update_Bval_label();
            Update_my2bytes();
        }

        void set_myBits_ifApplies(List<string> argBitDescriptions)
        {
            for (int x = 0; x < myCbs.Length; x++) {
                myCbs[x].Text = "";
                myCbs[x].Enabled = false;
                myCbs[x].Hide();
            }
            for (int i = 0; i < argBitDescriptions.Count; i++)
            {
                int bitnumber = 0;
                string bitDescriptor = "";
                var result = ParseBitsNamesString(argBitDescriptions[i]);
                bitnumber = result.Item1;
                bitDescriptor = result.Item2;
                myCbs[bitnumber].Show();
                myCbs[bitnumber].Enabled = true;
                myCbs[bitnumber].Text = bitDescriptor;
            }
        }
        //public void Init(int argBorderColor) {

        //    SetBorderColor(argBorderColor);
        //    // Subscribe to hover events for this control and all child controls
        //    SubscribeHoverEvents(this);
        //    Update_Bval_label();
        //    Update_my2bytes();
        //}
        void cb_bit_changed(object sender, EventArgs e)
        {
            // _cur_INT_Value is the value of the byte set by the cb_b0 to cb_b7 representing bit 0 to bit 8 of the byte    
            CU_VALUE_INT = 0;
            if (cb_b0.Checked) { CU_VALUE_INT += 1; }
            if (cb_b1.Checked) { CU_VALUE_INT += 2; }
            if (cb_b2.Checked) { CU_VALUE_INT += 4; }
            if (cb_b3.Checked) { CU_VALUE_INT += 8; }
            if (cb_b4.Checked) { CU_VALUE_INT += 16; }
            if (cb_b5.Checked) { CU_VALUE_INT += 32; }
            if (cb_b6.Checked) { CU_VALUE_INT += 64; }
            if (cb_b7.Checked) { CU_VALUE_INT += 128; }
            Update_Bval_label();
            Update_my2bytes();

        }

        #region Commons
        private void Btn_reset_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 8; x++)
            {
                if (myCbs[x].Enabled)
                    myCbs[x].Checked = false;
            }

            CU_VALUE_INT = 0;

            Update_Bval_label();
            Update_my2bytes();

        }
        void Update_Bval_label()
        {
            if (_isHexFormat)
            {
                lbl_Bval.Text = CU_VALUE_INT.ToString("X2");
            }
            else
            {
                lbl_Bval.Text = CU_VALUE_INT.ToString("D3");
            }
        }
        void Update_my2bytes()
        {
            my2bytes[0] = (byte)CU_VALUE_INT;
            my2bytes[1] = (byte)CU_VALUE_INT;
             
            _myUC_PGN_BASE.Set_2bytes(my_lo_indx, my_lo_indx, my2bytes[0], my2bytes[0]);
        }
        void SetBorderColor(int arg_indexByteLo)
        {
            if (arg_indexByteLo > 7) arg_indexByteLo = 7;
            if (arg_indexByteLo < 0) arg_indexByteLo = 0;
            borderColor = GetColorByIndex(arg_indexByteLo);
            _myUC_PGN_BASE.Set_Display_LblColorsCodes(my_lo_indx,my_lo_indx, borderColor);



            this.Invalidate();
        }
        private void UC_manip8_bs_Paint(object sender, PaintEventArgs e)
        {
            using (Pen borderPen = new Pen(borderColor, 4))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width, this.Height);
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
            myCbs = new CheckBox[8];
            myCbs[0] = cb_b0;
            myCbs[1] = cb_b1;
            myCbs[2] = cb_b2;
            myCbs[3] = cb_b3;
            myCbs[4] = cb_b4;
            myCbs[5] = cb_b5;
            myCbs[6] = cb_b6;
            myCbs[7] = cb_b7;
            cb_b0.CheckedChanged +=  cb_bit_changed;
            cb_b1.CheckedChanged += cb_bit_changed;
            cb_b2.CheckedChanged += cb_bit_changed;
            cb_b3.CheckedChanged += cb_bit_changed;
            cb_b4.CheckedChanged += cb_bit_changed;
            cb_b5.CheckedChanged += cb_bit_changed;
            cb_b6.CheckedChanged += cb_bit_changed;
            cb_b7.CheckedChanged += cb_bit_changed;
            btn_reset.Click +=  Btn_reset_Click;
            /*
            cb_b0.CheckedChanged += new EventHandler(cb_bit_changed);
            cb_b1.CheckedChanged += new EventHandler(cb_bit_changed);
            cb_b2.CheckedChanged += new EventHandler(cb_bit_changed);
            cb_b3.CheckedChanged += new EventHandler(cb_bit_changed);
            cb_b4.CheckedChanged += new EventHandler(cb_bit_changed);
            cb_b5.CheckedChanged += new EventHandler(cb_bit_changed);
            cb_b6.CheckedChanged += new EventHandler(cb_bit_changed);
            cb_b7.CheckedChanged += new EventHandler(cb_bit_changed);
            btn_reset.Click += new EventHandler(Btn_reset_Click);
            */
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

            cb_b0.CheckedChanged -= cb_bit_changed;
            cb_b1.CheckedChanged -= cb_bit_changed;
            cb_b2.CheckedChanged -= cb_bit_changed;
            cb_b3.CheckedChanged -= cb_bit_changed;
            cb_b4.CheckedChanged -= cb_bit_changed;
            cb_b5.CheckedChanged -= cb_bit_changed;
            cb_b6.CheckedChanged -= cb_bit_changed;
            cb_b7.CheckedChanged -= cb_bit_changed;
            btn_reset.Click -= Btn_reset_Click;
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
