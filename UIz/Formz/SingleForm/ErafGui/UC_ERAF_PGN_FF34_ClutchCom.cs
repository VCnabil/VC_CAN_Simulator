using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.ErafGui
{
    public partial class UC_ERAF_PGN_FF34_ClutchCom : UserControl
    {
        int _pgn29 = 0x18FF3400;
        byte B0_clutchComBits = 0x00;
        byte B2_trackbarValue_HighByte = 0x00;
        byte B3_trackbarValue_LowByte = 0x00;

        byte[] _data;
        public UC_ERAF_PGN_FF34_ClutchCom()
        {
            InitializeComponent();
            InitializeComponent();

            radioButton1.Checked = true;
            radioButton4.Checked = true;
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 1000;
            trackBar1.Value = 500;

            label2.Text = trackBar1.Value.ToString();
            B2_trackbarValue_HighByte = (byte)(trackBar1.Value >> 8);
            B3_trackbarValue_LowByte = (byte)(trackBar1.Value & 0xFF);

            Set_bit0_bit1_bit2_bit3_bit4_bit5_of_B0(radioButton1.Checked, radioButton2.Checked, radioButton3.Checked, radioButton4.Checked, radioButton5.Checked, radioButton6.Checked);
            label3.Text = "0x" + B0_clutchComBits.ToString("X2");

            _data = new byte[8];
            _data[0] = B0_clutchComBits;
            _data[1] = 0x00;
            _data[2] = B2_trackbarValue_HighByte;
            _data[3] = B3_trackbarValue_LowByte;
            _data[4] = 0x00;
            _data[5] = 0x00;
            _data[6] = 0x00;
            _data[7] = 0x00;

            radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton4.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton5.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton6.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);


            trackBar1.ValueChanged += new EventHandler(trackBar1_ValueChanged);
        }
        public byte[] GET_Data()
        {
            _data[0] = B0_clutchComBits;
            _data[1] = 0x00;
            _data[2] = B2_trackbarValue_HighByte;
            _data[3] = B3_trackbarValue_LowByte;
            _data[4] = 0x00;
            _data[5] = 0x00;
            _data[6] = 0x00;
            _data[7] = 0x00;
            return _data;

        }
        public int GET_PGN()
        {
            return _pgn29;
        }
        void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            B2_trackbarValue_HighByte = (byte)(trackBar1.Value >> 8);
            B3_trackbarValue_LowByte = (byte)(trackBar1.Value & 0xFF);
        }
        void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            Set_bit0_bit1_bit2_bit3_bit4_bit5_of_B0(radioButton1.Checked, radioButton2.Checked, radioButton3.Checked, radioButton4.Checked, radioButton5.Checked, radioButton6.Checked);
            label3.Text = "0x" + B0_clutchComBits.ToString("X2");
        }

        void Set_bit0_bit1_bit2_bit3_bit4_bit5_of_B0(bool argBit0, bool argBit1, bool argBit2, bool argBit3, bool argBit4, bool argBit5)
        {
            if (argBit0)
                B0_clutchComBits |= 0x01;
            else
                B0_clutchComBits &= 0xFE;

            if (argBit1)
                B0_clutchComBits |= 0x02;
            else
                B0_clutchComBits &= 0xFD;

            if (argBit2)
                B0_clutchComBits |= 0x04;
            else
                B0_clutchComBits &= 0xFB;

            if (argBit3)
                B0_clutchComBits |= 0x08;
            else
                B0_clutchComBits &= 0xF7;

            if (argBit4)
                B0_clutchComBits |= 0x10;
            else
                B0_clutchComBits &= 0xEF;

            if (argBit5)
                B0_clutchComBits |= 0x20;
            else
                B0_clutchComBits &= 0xDF;
        }
    }
}
