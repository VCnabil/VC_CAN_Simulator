using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VC_CAN_Simulator.UIz.Formz.SingleForm;
using VC_CAN_Simulator.UIz.Formz.SingleForm.ErafGui;
using VC_CAN_Simulator.UIz.Formz.SingleForm.Ka2700Gui;
using VC_CAN_Simulator.UIz.Formz.SingleForm.NomadGui;
using VC_CAN_Simulator.UIz.Formz.SingleForm.WskiGui;
using VC_CAN_Simulator.UIz.FormzNavUC;

namespace VC_CAN_Simulator.UIz.Formz
{
    public partial class MainGUI : Form
    {
       
        ufc_LoadPreConfiguredForm ufc_LoadPreConf_MkV;
        string _info_mkvGui = "PreConfigured MkV Gui. use to test mkv pv780_101_1001 rev 6804";

        ufc_LoadPreConfiguredForm ufc_LoadPreConf_ERAF;
        string _info_ErafGui = "for one time ";

        ufc_LoadPreConfiguredForm ufc_LoadPreConf_KA2700;
        string _info_KA2700Gui = "For testing displays using kvaser ";

        ufc_LoadPreConfiguredForm ufc_LoadPreConf_NOMAD;
        string _info_MOADGui = "PreConfigured MOMAD Gui. more info to come..";

        ufc_LoadPreConfiguredForm ufc_LoadPreConf_Wronowski;
        string _info_WronowskiGui = "PreConfigured MkV Gui. for wronowski ... needs leanup";

        int cursorY = 0;
        int lastUCHeight = 0;
        public MainGUI()
        {
            InitializeComponent();
            Point _point;


            ufc_LoadPreConf_MkV = new ufc_LoadPreConfiguredForm(_info_mkvGui, () => new  MKV_GUI() , "Run MKV");
            lastUCHeight= ufc_LoadPreConf_MkV.Height;
             _point = new Point(0, cursorY);
            ufc_LoadPreConf_MkV.Location = _point;
            Controls.Add(ufc_LoadPreConf_MkV);
            cursorY += lastUCHeight ;


            ufc_LoadPreConf_ERAF = new ufc_LoadPreConfiguredForm(_info_ErafGui, () => new ERAF_GUI(), "Run ERAF");
            lastUCHeight = ufc_LoadPreConf_ERAF.Height;
             _point = new Point(0, cursorY);
            ufc_LoadPreConf_ERAF.Location = _point;
            Controls.Add(ufc_LoadPreConf_ERAF);
            cursorY += lastUCHeight;

            ufc_LoadPreConfiguredForm ufc_LoadPreConf_KA2700 = new ufc_LoadPreConfiguredForm(_info_KA2700Gui, () => new KA27_GUI(), "Run KA2700");
            lastUCHeight = ufc_LoadPreConf_KA2700.Height;
             _point = new Point(0, cursorY);
            ufc_LoadPreConf_KA2700.Location = _point;
            Controls.Add(ufc_LoadPreConf_KA2700);
            cursorY += lastUCHeight;
            ufc_LoadPreConfiguredForm ufc_LoadPreConf_NOMAD = new ufc_LoadPreConfiguredForm(_info_MOADGui, () => new NOMAD_GUI(), "Run NOMAD");
            lastUCHeight = ufc_LoadPreConf_NOMAD.Height;
             _point = new Point(0, cursorY);
            ufc_LoadPreConf_NOMAD.Location = _point;
            Controls.Add(ufc_LoadPreConf_NOMAD);
            cursorY += lastUCHeight;
                
            ufc_LoadPreConfiguredForm ufc_LoadPreConf_Wronowski = new ufc_LoadPreConfiguredForm(_info_WronowskiGui, () => new WSKI_GUI(), "Run WRONOWSKI");
            lastUCHeight = ufc_LoadPreConf_Wronowski.Height;
             _point = new Point(0, cursorY);
            ufc_LoadPreConf_Wronowski.Location = _point;
            Controls.Add(ufc_LoadPreConf_Wronowski);
            cursorY += lastUCHeight;
          

        }
    }
}
