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
    public partial class UC_ERAF_PGN_FF50_Helm_TakeCtrl : UserControl
    {
        int _pgn29 = 0x18FF5000;
        public int GET_PGN()
        {
            return _pgn29;
        }
        byte B0_HelmPos_LowByte = 0x00;
        byte B1_HelmPos_HighByte = 0x00;
        byte B6_takeCtrl_Byte = 0x00;

        byte[] _data;
        public UC_ERAF_PGN_FF50_Helm_TakeCtrl()
        {
            InitializeComponent();

            trackBar1.Minimum = 0;
            trackBar1.Maximum = 1000;
            trackBar1.Value = 500;
            label2.Text = trackBar1.Value.ToString();


            B0_HelmPos_LowByte = (byte)(trackBar1.Value & 0xFF);
            B1_HelmPos_HighByte = (byte)((trackBar1.Value >> 8) & 0xFF);
            _data = new byte[8];
            _data[0] = B0_HelmPos_LowByte;
            _data[1] = B1_HelmPos_HighByte;
            _data[2] = 0x00;
            _data[3] = 0x00;
            _data[4] = 0x00;
            _data[5] = 0x00;
            _data[6] = B6_takeCtrl_Byte;
            _data[7] = 0x00;
            if (checkBox1.Checked)
            {
                B6_takeCtrl_Byte = 0;
            }
            else
            {
                B6_takeCtrl_Byte = 1;
            }



            trackBar1.ValueChanged += new EventHandler(trackBar1_ValueChanged);
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            checkBox2.CheckedChanged += new EventHandler(checkBox2_CheckedChanged);
        }
        public byte[] GET_Data()
        {
            _data[0] = B0_HelmPos_LowByte;
            _data[1] = B1_HelmPos_HighByte;
            _data[2] = 0x00;
            _data[3] = 0x00;
            _data[4] = 0x00;
            _data[5] = 0x00;
            _data[6] = B6_takeCtrl_Byte;
            _data[7] = 0x00;
            return _data;
        }
        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                B6_takeCtrl_Byte = 1;
            }
            else
            {
                B6_takeCtrl_Byte = 0;
            }
        }

        void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //not defined yet Broadcast Com Fault
        }
        void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            B0_HelmPos_LowByte = (byte)(trackBar1.Value & 0xFF);
            B1_HelmPos_HighByte = (byte)((trackBar1.Value >> 8) & 0xFF);

        }

    }
}
