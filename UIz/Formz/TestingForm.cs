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
using VC_CAN_Simulator.UIz.ManipUC;
using VC_CAN_Simulator.UIz.UControlz.Builders;
using static VC_CAN_Simulator.Backend.Helpers;

namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class TestingForm : Form
    {
        List<string> list = new List<string>();
        public TestingForm()
        {
            Ctrl_DataObject _8bit_Label=new Ctrl_DataObject();
            _8bit_Label.ID = 0;
            _8bit_Label.MIN= 0;
            _8bit_Label.MAX = 255;
            _8bit_Label.DEF = 127;
            _8bit_Label.DESC = "8 bit label";
            _8bit_Label.ISSLIDER = false;
            _8bit_Label.CTRL_TYOE_STR = EnumToString(CtrlType._1_By);
            _8bit_Label.INDEXLO = 3;
            _8bit_Label.INDEXHI = 3;

            Ctrl_DataObject _16bit_Label = new Ctrl_DataObject();
            _16bit_Label.ID = 0;
            _16bit_Label.MIN = 0;
            _16bit_Label.MAX = 9000;
            _16bit_Label.DEF = 1885;
            _16bit_Label.DESC = "16 bit label";
            _16bit_Label.ISSLIDER = false;
            _16bit_Label.CTRL_TYOE_STR = EnumToString(CtrlType._2_by);
            _16bit_Label.INDEXLO = 3;
            _16bit_Label.INDEXHI = 5;

            Ctrl_DataObject _8bit_Slider = new Ctrl_DataObject();
            _8bit_Slider.ID = 1;
            _8bit_Slider.MIN = 0;
            _8bit_Slider.MAX = 255;
            _8bit_Slider.DEF = 127;
            _8bit_Slider.DESC = "8 bit slider";
            _8bit_Slider.ISSLIDER = true;
            _8bit_Slider.CTRL_TYOE_STR = EnumToString(CtrlType._1_By);
            _8bit_Slider.INDEXLO = 0;
            _8bit_Slider.INDEXHI = 0;

            Ctrl_DataObject _16bit_Slider = new Ctrl_DataObject();
            _16bit_Slider.ID = 0;
            _16bit_Slider.MIN = 0;
            _16bit_Slider.MAX = 1000;
            _16bit_Slider.DEF = 521;
            _16bit_Slider.DESC = "16 bit slider";
            _16bit_Slider.ISSLIDER = true;
            _16bit_Slider.CTRL_TYOE_STR = EnumToString(CtrlType._2_by);
            _16bit_Slider.INDEXLO = 5;
            _16bit_Slider.INDEXHI = 6;


            List<string> BilList_A = new List<string>();
            BilList_A.Add("0. bit0 alarm");
            BilList_A.Add("1. bit1 alarm");
          //  BilList_A.Add("2. bit2 alarm");
            BilList_A.Add("3. bit3 alarm");
            BilList_A.Add("4. bit4 alarm");
           // BilList_A.Add("5. bit5 alarm");
            BilList_A.Add("6. bit6 alarm");
            BilList_A.Add("7. bit7 alarm");
            List<string> Groups1 = new List<string>();
            Groups1.Add("0,4,6");
            List<string> Groups2 = new List<string>();
            Groups2.Add("1,4,7");

            Ctrl_DataObject _bitsA_ = new Ctrl_DataObject();
            _bitsA_.ID = 0;
            _bitsA_.MIN = 0;
            _bitsA_.MAX = 255;
            _bitsA_.DEF = 0;
            _bitsA_.DESC = "8 bits yall";
            _bitsA_.ISSLIDER = false;
            _bitsA_.CTRL_TYOE_STR = EnumToString(CtrlType._8_bG);
            _bitsA_.INDEXLO = 6;
            _bitsA_.INDEXHI = 6;
            _bitsA_.BitsList = BilList_A;
            _bitsA_.Group1List = Groups1;
            _bitsA_.Group2List = Groups2;



            InitializeComponent();


            UC_manip8_bG bG = new UC_manip8_bG(_bitsA_);
            bG.Location = new Point(0, 140);
            Controls.Add(bG);

            //UC_manip8_bs bs = new UC_manip8_bs(_bitsA_);
            //bs.Location = new Point(0, 40);
            //Controls.Add(bs);
            return;

            //UC_manip8_bs bs= new UC_manip8_bs();
            //bs.Location = new Point(0, 40);
            //Controls.Add(bs);


            //UC_manip8_bG bG = new UC_manip8_bG();
            //bG.Location = new Point(0, 140);
            //Controls.Add(bG);

            //UC_manip_SLIDER gs8 = new UC_manip_SLIDER(_8bit_Slider);
            //gs8.Location = new Point(0, 240);
            //Controls.Add(gs8);

            UC_manip_SLIDER gs16 = new UC_manip_SLIDER();
            gs16.Location = new Point(0, 340);
            Controls.Add(gs16);


            //UC_manip_LABEL gl8 = new UC_manip_LABEL();
            //gl8.Location = new Point(0, 440);
            //Controls.Add(gl8);

            UC_manip_LABEL gl16 = new UC_manip_LABEL();
            gl16.Location = new Point(0, 540);
            Controls.Add(gl16);

        }
    }
}
