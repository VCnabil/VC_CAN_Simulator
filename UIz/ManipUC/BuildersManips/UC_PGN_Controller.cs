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

        private void Cb_allowSend_CheckedChanged(object sender, EventArgs e)
        {
            AllowSending = cb_allowSend.Checked;
        }
    }
}
