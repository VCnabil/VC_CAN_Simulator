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
    public partial class UC_WSKI_SteerEnginSliders : UserControl
    {
        string _myTitle;
        int _steerFBK; byte _steerFBK_LO; byte _steerFBK_HI;  //max value 3600
        int _steerCOM; byte _steerCOM_LO; byte _steerCOM_HI;  //max value 3600
        int _enginFBK; byte _enginFBK_LO; byte _enginFBK_HI;  //max value 1000
        int _enginCOM; byte _enginCOM_LO; byte _enginCOM_HI;  //max value 1000
        byte[] _data;
        public UC_WSKI_SteerEnginSliders()
        {
            InitializeComponent();
            _data = new byte[8];
            // Set up the ValueChanged event handlers for the TrackBars
            tb_SteerFBK.ValueChanged += TrackBar_SteerFBK_ValueChanged;
            tb_SteerCOM.ValueChanged += TrackBar_SteerCOM_ValueChanged;
            tb_EnginFBK.ValueChanged += TrackBar_EnginFBK_ValueChanged;
            tb_EnginCOM.ValueChanged += TrackBar_EnginCOM_ValueChanged;
        }
        private void SplitIntoBytes(int value, int maxValue, out byte low, out byte high)
        {
            // Ensure value does not exceed max value
            value = Math.Min(value, maxValue);

            // Convert to bytes
            low = (byte)(value & 0xFF);
            high = (byte)((value >> 8) & 0xFF);
        }


        private void TrackBar_SteerCOM_ValueChanged(object sender, EventArgs e)
        {
            _steerCOM = tb_SteerCOM.Value;
            if (_steerCOM > 3600) _steerCOM = 3600;
            lbl_SteerCOM.Text = (_steerCOM / 10.0).ToString("0.0");
            SplitIntoBytes(_steerCOM, 3600, out _steerCOM_LO, out _steerCOM_HI);
            _data[0] = _steerCOM_LO;
            _data[1] = _steerCOM_HI;
        }
        private void TrackBar_SteerFBK_ValueChanged(object sender, EventArgs e)
        {
            _steerFBK = tb_SteerFBK.Value;
            if (_steerFBK > 3600) _steerFBK = 3600;
            lbl_SteerFBK.Text = (_steerFBK / 10.0).ToString("0.0");
            SplitIntoBytes(_steerFBK, 3600, out _steerFBK_LO, out _steerFBK_HI);
            _data[2] = _steerFBK_LO;
            _data[3] = _steerFBK_HI;

        }

        private void TrackBar_EnginCOM_ValueChanged(object sender, EventArgs e)
        {
            _enginCOM = tb_EnginCOM.Value;
            if (_enginCOM > 1000) _enginCOM = 1000;
            lbl_EnginCOM.Text = (_enginCOM / 10.0).ToString("0.0");
            SplitIntoBytes(_enginCOM, 1000, out _enginCOM_LO, out _enginCOM_HI);
            _data[4] = _enginCOM_LO;
            _data[5] = _enginCOM_HI;
        }


        private void TrackBar_EnginFBK_ValueChanged(object sender, EventArgs e)
        {
            _enginFBK = tb_EnginFBK.Value;
            if (_enginFBK > 1000) _enginFBK = 1000;
            lbl_EnginFBK.Text = (_enginFBK / 10.0).ToString("0.0");
            SplitIntoBytes(_enginFBK, 1000, out _enginFBK_LO, out _enginFBK_HI);
            _data[6] = _enginFBK_LO;
            _data[7] = _enginFBK_HI;
        }



        // Public property to set the title and update lbl_title
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
