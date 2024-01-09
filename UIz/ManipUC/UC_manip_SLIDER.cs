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
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.ManipUC
{
    public partial class UC_manip_SLIDER : UserControl
    {
        Color borderColor;
        bool _is16bits;
        int _cur_INT_Value;
        byte[] my2bytes;
        int _myMin=0;
        int _myMax= 65535;
        int _myMidVal;
        int _myDefVal;
        public UC_manip_SLIDER()
        {
            InitializeComponent();
            _is16bits = true;
            my2bytes = new byte[2];
            Init(2);
        }

        public UC_manip_SLIDER(Ctrl_DataObject argCtrlData)
        {
            InitializeComponent();
            if (argCtrlData == null) {
                MessageBox.Show("null dataobj");
                return;
            }

            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._8_bs))
            {
                MessageBox.Show("cannot be bs");
                return;
            }

            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._8_bG))
            {
                MessageBox.Show("cannot be bG");
                return;
            }

            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._1_By))
            {
                _is16bits = false;
            }
            if (argCtrlData.CTRL_TYOE_STR == EnumToString(CtrlType._2_by))
            {
                _is16bits = true;
            }

           
     
            my2bytes = new byte[2];
            Init(argCtrlData);
        }

        public void Init(Ctrl_DataObject argCtrlData)
        {
            int argBorderColor = argCtrlData.INDEXLO;
            SetBorderColor(argBorderColor);
            // Subscribe to hover events for this control and all child controls
            SubscribeHoverEvents(this);

            tb_Slider.Minimum = argCtrlData.MIN;
             _myMax = argCtrlData.MAX;
            tb_Slider.Maximum = _myMax;
            _myMidVal = (_myMax - _myMin) / 2;
            _myDefVal = argCtrlData.DEF;
            tb_Slider.Value = _myDefVal;

            lbl_min.Text = _myMin.ToString();
            lbl_max.Text = _myMax.ToString();
            lbl_def.Text = _myDefVal.ToString();
            lbl_Desc.Text = argCtrlData.DESC;

            int numSteps = _myMax;   // Number of steps

            // Set the minimum and maximum values
            tb_Slider.Minimum = _myMin;
            tb_Slider.Maximum = _myMax;

            // Calculate and set the tick frequency
            int tickFrequency = (_myMax - _myMin) / numSteps;
            tb_Slider.TickFrequency = tickFrequency;

            // Additional properties
            tb_Slider.SmallChange = 1;  // Change in value for small adjustments, e.g., arrow keys
            tb_Slider.LargeChange = tickFrequency;

            ChangeLayout_16or8Bits();

            Update_Bval_label();
            Update_my2bytes();
        }
        public void Init(int argBorderColor)
        {
            SetBorderColor(argBorderColor);
            // Subscribe to hover events for this control and all child controls
            SubscribeHoverEvents(this);

            tb_Slider.Minimum = _myMin;
            if(!_is16bits)_myMax = 255;
            tb_Slider.Maximum = _myMax;
            _myMidVal = (_myMax - _myMin) / 2;
            _myDefVal = _myMidVal;
            tb_Slider.Value = _myDefVal;

            lbl_min.Text= _myMin.ToString();
            lbl_max.Text= _myMax.ToString();
            lbl_def.Text= _myDefVal.ToString();

    
            int numSteps = _myMax;   // Number of steps

            // Set the minimum and maximum values
            tb_Slider.Minimum = _myMin;
            tb_Slider.Maximum = _myMax;

            // Calculate and set the tick frequency
            int tickFrequency = (_myMax - _myMin) / numSteps;
            tb_Slider.TickFrequency = tickFrequency;

            // Additional properties
            tb_Slider.SmallChange = 1;  // Change in value for small adjustments, e.g., arrow keys
            tb_Slider.LargeChange = tickFrequency;

            ChangeLayout_16or8Bits();

            Update_Bval_label();
            Update_my2bytes();
        }
        void ChangeLayout_16or8Bits() { 
            if(!_is16bits) lbl_byteHIVal.Hide(); 
        }
        #region Commons
        private void Btn_reset_Click(object sender, EventArgs e)
        {
            _cur_INT_Value = _myDefVal;
            tb_Slider.Value = _cur_INT_Value;
            Update_Bval_label();
            Update_my2bytes();
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
            tb_Slider.ValueChanged +=tb_Slider_ValueChanged;

        }

        private void tb_Slider_ValueChanged(object sender, EventArgs e)
        {
            _cur_INT_Value = tb_Slider.Value;
            Update_Bval_label();
            Update_my2bytes();
        }
        void Update_Bval_label()
        {
            if (_is16bits)
            {
                byte lowbyte = (byte)(_cur_INT_Value & 0x00FF);
                byte highbyte = (byte)((_cur_INT_Value & 0xFF00) >> 8);
                my2bytes[0] = lowbyte;
                my2bytes[1] = highbyte;

                lbl_byteLOVal.Text= (_cur_INT_Value & 0x00FF).ToString("X2");
                lbl_byteHIVal.Text = ((_cur_INT_Value & 0xFF00) >> 8).ToString("X2");
            }
            else
            {

                my2bytes[0] = (byte)_cur_INT_Value;
                my2bytes[1] = (byte)_cur_INT_Value;
                lbl_byteLOVal.Text = _cur_INT_Value.ToString("X2");
            }

            lbl_Bval.Text = _cur_INT_Value.ToString("X2");
            lbl_decVal.Text = _cur_INT_Value.ToString("D3");
        }
        void Update_my2bytes()
        {


            if (_is16bits)
            {
                byte lowbyte = (byte)(_cur_INT_Value & 0x00FF);
                byte highbyte = (byte)((_cur_INT_Value & 0xFF00) >> 8);
                my2bytes[0] = lowbyte;
                my2bytes[1] = highbyte;
            }
            else {

                my2bytes[0] = (byte)_cur_INT_Value;
                my2bytes[1] = (byte)_cur_INT_Value;
            }

            //my_refTOCTRL.PlugYourByteHere(_myByteIndexInPayload, my2bytes[0], _myType, _myByteIndexInPayload_secondary, my2bytes[1]);
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
            tb_Slider.ValueChanged -=  tb_Slider_ValueChanged;

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
