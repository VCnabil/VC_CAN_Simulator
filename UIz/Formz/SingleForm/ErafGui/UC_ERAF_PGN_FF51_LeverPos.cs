using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.ErafGui
{
    public partial class UC_ERAF_PGN_FF51_LeverPos : UserControl
    {
        int _pgn29 = 0x18FF5100;
        public int GET_PGN()
        {
            return _pgn29;
        }
        byte B0_PortLeverPos_LowByte = 0x00;
        byte B1_PortLeverPos_HighByte = 0x00;
        byte B2_StbdLeverPos_LowByte = 0x00;
        byte B3_StbdLeverPos_HighByte = 0x00;
        byte[] _data;
        public UC_ERAF_PGN_FF51_LeverPos()
        {
            InitializeComponent();

            trackBar1.Minimum = 0;
            trackBar1.Maximum = 1000;
            trackBar1.Value = 500;
            trackBar2.Minimum = 0;
            trackBar2.Maximum = 1000;
            trackBar2.Value = 500;

            label2.Text = trackBar1.Value.ToString();
            B0_PortLeverPos_LowByte = (byte)(trackBar1.Value & 0xFF);
            B1_PortLeverPos_HighByte = (byte)((trackBar1.Value >> 8) & 0xFF);
            label3.Text = trackBar2.Value.ToString();
            B2_StbdLeverPos_LowByte = (byte)(trackBar2.Value & 0xFF);
            B3_StbdLeverPos_HighByte = (byte)((trackBar2.Value >> 8) & 0xFF);
            _data = new byte[8];
            _data[0] = B0_PortLeverPos_LowByte;
            _data[1] = B1_PortLeverPos_HighByte;
            _data[2] = B2_StbdLeverPos_LowByte;
            _data[3] = B3_StbdLeverPos_HighByte;
            _data[4] = 0x00;
            _data[5] = 0x00;
            _data[6] = 0x00;
            _data[7] = 0x00;


            trackBar1.ValueChanged += new EventHandler(trackBar1_ValueChanged);


            trackBar2.ValueChanged += new EventHandler(trackBar2_ValueChanged);
        }
        public byte[] GET_Data()
        {
            _data[0] = B0_PortLeverPos_LowByte;
            _data[1] = B1_PortLeverPos_HighByte;
            _data[2] = B2_StbdLeverPos_LowByte;
            _data[3] = B3_StbdLeverPos_HighByte;
            _data[4] = 0x00;
            _data[5] = 0x00;
            _data[6] = 0x00;
            _data[7] = 0x00;
            return _data;
        }

        void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = trackBar2.Value.ToString();
            B2_StbdLeverPos_LowByte = (byte)(trackBar2.Value & 0xFF);
            B3_StbdLeverPos_HighByte = (byte)((trackBar2.Value >> 8) & 0xFF);

        }
        void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            B0_PortLeverPos_LowByte = (byte)(trackBar1.Value & 0xFF);
            B1_PortLeverPos_HighByte = (byte)((trackBar1.Value >> 8) & 0xFF);

        }
    }
}
