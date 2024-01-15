using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.MkvGui
{
    public partial class UC_WSKI_AzimthSliders : UserControl
    {
        string _myTitle;
        byte _RawLin_LO; // D0
        byte _RawLin_HI; // D1
        byte _RawRot1_LO; // D2
        byte _RawRot1_HI; // D3
        byte _RawRot2_LO; // D4
        byte _RawRot2_HI; // D5
        byte _faults;     // D6
        byte _calMode;    //D7

        byte[] _data;
        public UC_WSKI_AzimthSliders()
        {
            InitializeComponent();
            _data = new byte[8];
            cb_flt_sens1.CheckedChanged += (s, e) => set_faultsBitAtIndex(0, cb_flt_sens1.Checked);
            cb_flt_sens2.CheckedChanged += (s, e) => set_faultsBitAtIndex(1, cb_flt_sens2.Checked);
            cb_flt_Linsens.CheckedChanged += (s, e) => set_faultsBitAtIndex(2, cb_flt_Linsens.Checked);
            cb_flt_Rotsens1CAL.CheckedChanged += (s, e) => set_faultsBitAtIndex(3, cb_flt_Rotsens1CAL.Checked);
            cb_flt_Rotsens2CAL.CheckedChanged += (s, e) => set_faultsBitAtIndex(4, cb_flt_Rotsens2CAL.Checked);
            cb_flt_LinsensCAL.CheckedChanged += (s, e) => set_faultsBitAtIndex(5, cb_flt_LinsensCAL.Checked);
            cb_CalibMode.CheckedChanged += cb_CalibMode_CheckedChanged;

            tb_RawThrustLin.ValueChanged += TrackBar_RawLin_ValueChanged;
            tb_RawRot1.ValueChanged += TrackBar_RawRot1_ValueChanged;
            tb_RawRot2.ValueChanged += TrackBar_RawRot2_ValueChanged;
        }
        private void SplitIntoBytes(int value, int maxValue, out byte low, out byte high)
        {
            // Ensure value does not exceed max value
            value = Math.Min(value, maxValue);

            // Convert to bytes
            low = (byte)(value & 0xFF);
            high = (byte)((value >> 8) & 0xFF);
        }

        private void TrackBar_RawLin_ValueChanged(object sender, EventArgs e)
        {
            int temp_rawLinVal = tb_RawThrustLin.Value;
            if (temp_rawLinVal > 4095) temp_rawLinVal = 4095;
            lbl_RawThrustLin.Text = temp_rawLinVal.ToString();
            SplitIntoBytes(temp_rawLinVal, 4095, out _RawLin_LO, out _RawLin_HI);

            _data[0] = _RawLin_LO;
            _data[1] = _RawLin_HI;
        }

        private void TrackBar_RawRot1_ValueChanged(object sender, EventArgs e)
        {
            int temp_rawRot1Val = tb_RawRot1.Value;
            if (temp_rawRot1Val > 4095) temp_rawRot1Val = 4095;
            lbl_RawRot1.Text = temp_rawRot1Val.ToString();
            SplitIntoBytes(temp_rawRot1Val, 4095, out _RawRot1_LO, out _RawRot1_HI);
            _data[2] = _RawRot1_LO;
            _data[3] = _RawRot1_HI;
        }

        private void TrackBar_RawRot2_ValueChanged(object sender, EventArgs e)
        {
            int temp_rawRot2Val = tb_RawRot2.Value;
            if (temp_rawRot2Val > 4095) temp_rawRot2Val = 4095;
            lbl__RawRot2.Text = temp_rawRot2Val.ToString();
            SplitIntoBytes(temp_rawRot2Val, 4095, out _RawRot2_LO, out _RawRot2_HI);
            _data[4] = _RawRot2_LO;
            _data[5] = _RawRot2_HI;
        }
        private void cb_CalibMode_CheckedChanged(object sender, EventArgs e)
        {
            _calMode = cb_CalibMode.Checked ? (byte)0x1 : (byte)0x0;
            _data[7] = _calMode;
        }
        void set_faultsBitAtIndex(int bitIndex, bool onOff)
        {
            if (bitIndex < 0 || bitIndex > 7)
                throw new ArgumentOutOfRangeException("bitIndex", "Bit index must be between 0 and 7.");

            if (onOff)
                _faults |= (byte)(1 << bitIndex); // Set the bit to 1
            else
                _faults &= (byte)~(1 << bitIndex); // Set the bit to 0

            _data[6] = _faults;
        }

        public string SetTitle
        {
            get { return _myTitle; }
            set
            {
                _myTitle = value;
                lbl_title.Text = _myTitle;
            }
        }


        public byte[] getData() { return this._data; }
    }
}
