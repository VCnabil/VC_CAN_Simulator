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
namespace VC_CAN_Simulator.UIz.ManipUC.BuildersManips
{
    // as each uc_manip 's CUR_VAL is updated, they each use their ref to this uc_PGN_CTRL which then calls its DisplayObject to pass the values through.
    //this ctrl can be used a s a man in the middle, collecting and updatin his data array for the form to run can write on its timer
    public partial class UC_PGN_Controller : UserControl
    {
        public bool AllowSending { get; private set;}
        public int MyPGN_ID { get; private set; }
        public int MyPGN_INT { get; private set; }
        public string MyPGN_STRHEX { get; private set; }

        public byte[] MYdata_bytes { get; private set;}

        Pgn_DataObject _mycopy_PGN_DO;
        int ctrlidCnt = 0;
        public UC_PGN_Controller(Pgn_DataObject argPGN_DO)
        {
            InitializeComponent();
            cb_allowSend.CheckedChanged += Cb_allowSend_CheckedChanged;
            cb_allowSend.Checked = true;
            AllowSending = true;
            MYdata_bytes= new byte[8];
            _mycopy_PGN_DO = argPGN_DO;
            MyPGN_ID = argPGN_DO.IDpgn;
            MyPGN_INT = argPGN_DO.PGN_int;
            MyPGN_STRHEX = argPGN_DO.PGN_strHEX;
            uC_DataDisplayCTRL1.SetTitle_intPgnHex(MyPGN_INT);
           
            foreach (var ctrl in argPGN_DO.CtrlList)
            {
                CtrlType ctrlType = StringToEnum(ctrl.CTRL_TYOE_STR);
                //switch case depending on ctrlType
                switch (ctrlType) { 
                    case CtrlType._8_bs:
                        UC_manip8_bs bs = new UC_manip8_bs(ctrlidCnt,ctrl, this);
                        flowLayoutPanel1.Controls.Add(bs);
                        ctrlidCnt++;
                        break;
                    case CtrlType._8_bG:
                        UC_manip8_bG bg = new UC_manip8_bG(ctrlidCnt, ctrl, this);
                        flowLayoutPanel1.Controls.Add(bg);
                        ctrlidCnt++;
                        break;
                       case CtrlType._1_By:
                        if (ctrl.ISSLIDER)
                        {
                            UC_manip_SLIDER by = new UC_manip_SLIDER(ctrlidCnt, ctrl, this);
                            flowLayoutPanel1.Controls.Add(by);
                            ctrlidCnt++;
                            break;
                        }
                        else { 
                            UC_manip_LABEL by = new UC_manip_LABEL(ctrlidCnt, ctrl    , this);
                            flowLayoutPanel1.Controls.Add(by);
                            ctrlidCnt++;
                            break;
                        }
                        
                      case CtrlType._2_by:
                        if (ctrl.ISSLIDER)
                        {
                            UC_manip_SLIDER by = new UC_manip_SLIDER(ctrlidCnt, ctrl, this);
                            flowLayoutPanel1.Controls.Add(by);
                            ctrlidCnt++;
                            break;
                        }
                        else
                        {
                            UC_manip_LABEL by = new UC_manip_LABEL(ctrlidCnt, ctrl, this);
                            flowLayoutPanel1.Controls.Add(by);
                            ctrlidCnt++;
                            break;
                        }
                        
                        default:
                        break;
                }
            }
        }

        public void Set_Display_LblColorsCodes(int argIndex, int argindex2, Color argColor) {
            uC_DataDisplayCTRL1.Set_lbl_color(argIndex, argindex2, argColor);
        }
        public void Set_2bytes(int argIndex1, int argIndex2, byte argByte1, byte argByte2)
        { 
            uC_DataDisplayCTRL1.Set_2_Bytes(argIndex1 , argIndex2, argByte1, argByte2);
            MYdata_bytes[argIndex1] = argByte1;
            MYdata_bytes[argIndex2] = argByte2;

            string debugstr= "";

            for (int x = 0; x < 8; x++) {
                debugstr+= MYdata_bytes[x].ToString("X2") + " ";
            }
           lbl_debug.Text = debugstr;
        }

        private void Cb_allowSend_CheckedChanged(object sender, EventArgs e)
        {
            AllowSending = cb_allowSend.Checked;
        }
    }
}
