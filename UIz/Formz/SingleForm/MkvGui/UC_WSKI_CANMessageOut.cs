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
    public partial class UC_WSKI_CANMessageOut : UserControl
    {
        private byte[] dataBytes = new byte[8]; // Replace with your actual data or initialize as needed

        public UC_WSKI_CANMessageOut()
        {
            InitializeComponent();
            cb_decHex.CheckedChanged += RbDecHex_CheckedChanged;
        }
        private void RbDecHex_CheckedChanged(object sender, EventArgs e)
        {
            // Call the SetDataBytes method to refresh the display with the current format
            // You can replace 'dataBytes' with your actual byte array
            SetDataBytes(dataBytes);
        }
        public void SetDataBytes(byte[] data)
        {
            if (data.Length >= 8)
            {
                dataBytes = data; // Update the local dataBytes array
                lbl_D0.Text = cb_decHex.Checked ? data[0].ToString() : data[0].ToString("X2");
                lbl_D1.Text = cb_decHex.Checked ? data[1].ToString() : data[1].ToString("X2");
                lbl_D2.Text = cb_decHex.Checked ? data[2].ToString() : data[2].ToString("X2");
                lbl_D3.Text = cb_decHex.Checked ? data[3].ToString() : data[3].ToString("X2");
                lbl_D4.Text = cb_decHex.Checked ? data[4].ToString() : data[4].ToString("X2");
                lbl_D5.Text = cb_decHex.Checked ? data[5].ToString() : data[5].ToString("X2");
                lbl_D6.Text = cb_decHex.Checked ? data[6].ToString() : data[6].ToString("X2");
                lbl_D7.Text = cb_decHex.Checked ? data[7].ToString() : data[7].ToString("X2");
            }
        }

        // Public method to set the lbl_pgn
        public void SetPgn(string pgn)
        {
            lbl_pgn.Text = pgn;
            lbl_pgn.ForeColor = Color.Green;
        }

        // Public method to return the state of rb_transmit
        public bool IsTransmitChecked()
        {
            return cb_transmit.Checked;
        }
    }
}
