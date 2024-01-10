﻿using System;
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
    public partial class UC_manip_LABEL : UserControl
    {
        Color borderColor;
        bool _is16bits;
        int _cur_INT_Value;
        byte[] my2bytes;
        int _myMin = 0;
        int _myMax = 65535;
        int _myMidVal;
        int _myDefVal;
        UC_PGN_Controller _myUC_PGN_BASE;
        int my_lo_indx;
        int my_hi_indx;
        public int ID_ctrl { get; private set; }
        //public UC_manip_LABEL()
        //{
        //    InitializeComponent();
        //    _is16bits = true;
        //    my2bytes = new byte[2];
        //    Init(3);
        //}
        //  
        public UC_manip_LABEL(int argid,Ctrl_DataObject argCtrlData, UC_PGN_Controller argUC_PGN_BASE)
        {
            InitializeComponent();
            _myUC_PGN_BASE = argUC_PGN_BASE;
            ID_ctrl = argid;
            my_lo_indx = argCtrlData.INDEXLO;
            my_hi_indx = argCtrlData.INDEXHI;
            if (argCtrlData == null)
            {
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
        /*
           public UC_manip_LABEL(Ctrl_DataObject argCtrlData)
          {
              InitializeComponent();
              if (argCtrlData == null)
              {
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
         */

        public void Init(Ctrl_DataObject argCtrlData)
        {
            int argBorderColor = argCtrlData.INDEXLO;
            SetBorderColor(argBorderColor);
            // Subscribe to hover events for this control and all child controls
            SubscribeHoverEvents(this);

            _myMax = argCtrlData.MAX;
            _myMidVal = (_myMax - _myMin) / 2;
            _myDefVal = argCtrlData.DEF;

            lbl_min.Text = _myMin.ToString();
            lbl_max.Text = _myMax.ToString();
            lbl_def.Text = _myDefVal.ToString();
            lbl_Desc.Text = argCtrlData.DESC;
            ChangeLayout_16or8Bits();

            Update_Bval_label();
            Update_my2bytes();
            tb_RawVAL.Text = _myDefVal.ToString();

        }
        public void Init(int argBorderColor)
        {
            SetBorderColor(argBorderColor);
            // Subscribe to hover events for this control and all child controls
            SubscribeHoverEvents(this);

            if (!_is16bits) _myMax = 255;
            _myMidVal = (_myMax - _myMin) / 2;
            _myDefVal = _myMidVal;

            lbl_min.Text = _myMin.ToString();
            lbl_max.Text = _myMax.ToString();
            lbl_def.Text = _myDefVal.ToString();
            ChangeLayout_16or8Bits();

            Update_Bval_label();
            Update_my2bytes();
            tb_RawVAL.Text = _myDefVal.ToString();

        }
        void Update_Bval_label()
        {
            if (_is16bits)
            {
                byte lowbyte = (byte)(_cur_INT_Value & 0x00FF);
                byte highbyte = (byte)((_cur_INT_Value & 0xFF00) >> 8);
                my2bytes[0] = lowbyte;
                my2bytes[1] = highbyte;

                lbl_byteLOVal.Text = (_cur_INT_Value & 0x00FF).ToString("X2");
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
            else
            {

                my2bytes[0] = (byte)_cur_INT_Value;
                my2bytes[1] = (byte)_cur_INT_Value;
            }
        }
        private void Tb_RawNum_TextChanged(object sender, EventArgs e)
        {
            int number = 0;
            bool result = int.TryParse(tb_RawVAL.Text, out number);

            if (result)
            {

                _cur_INT_Value = number;
                Update_Bval_label();
                Update_my2bytes();
            }
            else
            {
                _cur_INT_Value = 0;
            }
        }
        void ChangeLayout_16or8Bits()
        {
            if (!_is16bits) lbl_byteHIVal.Hide();
        }
        #region Commons
        private void Btn_reset_Click(object sender, EventArgs e)
        {

            _cur_INT_Value = _myDefVal;
            tb_RawVAL.Text = _cur_INT_Value.ToString();
            Update_Bval_label();
            Update_my2bytes();
        }
        void SetBorderColor(int arg_indexByteLo)
        {
            if (arg_indexByteLo > 7) arg_indexByteLo = 7;
            if (arg_indexByteLo < 0) arg_indexByteLo = 0;
            borderColor = GetColorByIndex(arg_indexByteLo);
            if (!_is16bits)
            {
                _myUC_PGN_BASE.Set_Display_LblColorsCodes(my_lo_indx, my_lo_indx, borderColor);
            }
            else
            {
                _myUC_PGN_BASE.Set_Display_LblColorsCodes(my_lo_indx, my_hi_indx, borderColor);
            }



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
            tb_RawVAL.TextChanged += Tb_RawNum_TextChanged;
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
            tb_RawVAL.TextChanged -= Tb_RawNum_TextChanged;
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
