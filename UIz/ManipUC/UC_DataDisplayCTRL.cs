using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.ManipUC
{
    public partial class UC_DataDisplayCTRL : UserControl
    {
        byte[] bytes;
        Label[] mLabels;
        Label[] lbl_colors;
        public UC_DataDisplayCTRL()
        {
            InitializeComponent();
            bytes = new byte[8];
            bytes[0] = 0x00;
            bytes[1] = 0x00;
            bytes[2] = 0x00;
            bytes[3] = 0x00;
            bytes[4] = 0x00;
            bytes[5] = 0x00;
            bytes[6] = 0x00;
            bytes[7] = 0x00;
            mLabels = new Label[8];
            mLabels[0] = mlbl_B0;
            mLabels[1] = mlbl_B1;
            mLabels[2] = mlbl_B2;
            mLabels[3] = mlbl_B3;
            mLabels[4] = mlbl_B4;
            mLabels[5] = mlbl_B5;
            mLabels[6] = mlbl_B6;
            mLabels[7] = mlbl_B7;
            lbl_colors = new Label[8];
            lbl_colors[0] = lbl_0;
            lbl_colors[1] = lbl_1;
            lbl_colors[2] = lbl_2;
            lbl_colors[3] = lbl_3;
            lbl_colors[4] = lbl_4;
            lbl_colors[5] = lbl_5;
            lbl_colors[6] = lbl_6;
            lbl_colors[7] = lbl_7;


            for (int i = 0; i < mLabels.Length; i++)
            {
                mLabels[i].Text = bytes[i].ToString("X2");
            }
        }

        public void UpdateDisplay(byte[] data)
        {
            if (data.Length > 0)
            {
                bytes = data;
                for (int i = 0; i < data.Length; i++)
                {
                    mLabels[i].Text = data[i].ToString("X2");
                }
            }
        }
        public void Set_lbl_color(int argIndex, int argindex2, Color argColor)
        {
            lbl_colors[argIndex].BackColor = argColor;
            lbl_colors[argindex2].BackColor = argColor;
        }   
        public void SetTitle_intPgnHex(int argPgn)
        {
            mlbl_Title.Text = "0x " + argPgn.ToString("X");
        }
    }
}
