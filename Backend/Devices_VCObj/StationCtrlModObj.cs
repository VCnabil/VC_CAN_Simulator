using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VC_CAN_Simulator.Backend.CAN_Structures;

namespace VC_CAN_Simulator.Backend.Devices_VCObj
{
    public class StationCtrlModObj
    {

        public int StationID { get; private set; }
        public string StationName { get; private set; }
        public int SW_VERSION_MAJOR { get; private set; }
        public int SW_VERSION_MINOR { get; private set; }
        public int SW_VERSION_REVISION { get; private set; }
        public int CAN_SOURCE_ADDRESS { get; private set; }

        PGN_messageSTK pGN_Message_FF50;// Helm
        PGN_messageSTK pGN_Message_FF51;// Thrust Lever port and Stbd
        PGN_messageSTK pGN_Message_FF52;// TRim & Roll

        PGN_messageSTK pGN_Message_FF54;// Software Version + Helm Min/Max
        PGN_messageSTK pGN_Message_FF55;// Levers Min/Max

        PGN_messageSTK pGN_Message_FF33;// Message to Clutch Panel #3
        PGN_messageSTK pGN_Message_FF36;// Message to control unit with station 3 idle knob information

        PGN_messageSTK pGN_Message_FF53;// CAN RECEIVE packets
        PGN_messageSTK pGN_Message_FF34;// CAN RECEIVE packets
        PGN_messageSTK pGN_Message_FF30;// CAN RECEIVE packets
        bool can_Fault=false;
        bool can_Fault_FF53 = false;
        bool can_Fault_FF34 = false;
        bool can_Fault_FF30 = false;
        private ushort ledBlinkCntr = 0;
        private signal Helm;
        private signal Port_Lever;
        private signal Stbd_Lever;
        private signal Idle_Knob;
        private const int I2C_NUMBYTES = 24;
        ushort[] parameters;
        ushort[] idle_knob_parameters;
        State RSC_Mode; //normalmode
        bool CalibrationFault = false;
        bool OldStyleRemoteStationController = false;

        public StationCtrlModObj() {
            parameters=new ushort[I2C_NUMBYTES];
            idle_knob_parameters = new ushort[14];
            Helm = new signal();
            Port_Lever = new signal();
            Stbd_Lever = new signal();
            Idle_Knob = new signal();
            RSC_Mode = State.NORMAL_MODE;

            can_Fault = true;
            can_Fault_FF53 = true;
            can_Fault_FF34 = true;
            can_Fault_FF30 = true;
               


        }
        public void SetParameters(signal Helm, signal Port_Lever, signal Stbd_Lever)
        {
            // Helm
            parameters[0] = (ushort)(Helm.Min & 0x00FF); // Helm.Min LO byte
            parameters[1] = (ushort)(Helm.Min >> 8);    // Helm.Min HI byte
            parameters[2] = (ushort)(Helm.Mid & 0x00FF); // Helm.Mid LO byte
            parameters[3] = (ushort)(Helm.Mid >> 8);    // Helm.Mid HI byte
            parameters[4] = (ushort)(Helm.Max & 0x00FF); // Helm.Max LO byte
            parameters[5] = (ushort)(Helm.Max >> 8);    // Helm.Max HI byte

            // Port_Lever
            parameters[6] = (ushort)(Port_Lever.Min & 0x00FF); // Port_Lever.Min LO byte
            parameters[7] = (ushort)(Port_Lever.Min >> 8);     // Port_Lever.Min HI byte
            parameters[8] = (ushort)(Port_Lever.Mid & 0x00FF); // Port_Lever.Mid LO byte
            parameters[9] = (ushort)(Port_Lever.Mid >> 8);     // Port_Lever.Mid HI byte
            parameters[10] = (ushort)(Port_Lever.Max & 0x00FF); // Port_Lever.Max LO byte
            parameters[11] = (ushort)(Port_Lever.Max >> 8);    // Port_Lever.Max HI byte

            // Stbd_Lever
            parameters[12] = (ushort)(Stbd_Lever.Min & 0x00FF); // Stbd_Lever.Min LO byte
            parameters[13] = (ushort)(Stbd_Lever.Min >> 8);     // Stbd_Lever.Min HI byte
            parameters[14] = (ushort)(Stbd_Lever.Mid & 0x00FF); // Stbd_Lever.Mid LO byte
            parameters[15] = (ushort)(Stbd_Lever.Mid >> 8);     // Stbd_Lever.Mid HI byte
            parameters[16] = (ushort)(Stbd_Lever.Max & 0x00FF); // Stbd_Lever.Max LO byte
            parameters[17] = (ushort)(Stbd_Lever.Max >> 8);    // Stbd_Lever.Max HI byte

            // Idle_Knob
            parameters[18] = (ushort)(Idle_Knob.Min & 0x00FF); // Idle_Knob.Min LO byte
            parameters[19] = (ushort)(Idle_Knob.Min >> 8);     // Idle_Knob.Min HI byte
            parameters[20] = (ushort)(Idle_Knob.Mid & 0x00FF); // Idle_Knob.Mid LO byte
            parameters[21] = (ushort)(Idle_Knob.Mid >> 8);     // Idle_Knob.Mid HI byte
            parameters[22] = (ushort)(Idle_Knob.Max & 0x00FF); // Idle_Knob.Max LO byte
            parameters[23] = (ushort)(Idle_Knob.Max >> 8);    // Idle_Knob.Max HI byte

      
        }
        public void LoadSignals()
        {
            // Helm
            Helm.Min = (ushort)((parameters[1] << 8) | parameters[0]);
            Helm.Mid = (ushort)((parameters[3] << 8) | parameters[2]);
            Helm.Max = (ushort)((parameters[5] << 8) | parameters[4]);

            // Port_Lever
            Port_Lever.Min = (ushort)((parameters[7] << 8) | parameters[6]);
            Port_Lever.Mid = (ushort)((parameters[9] << 8) | parameters[8]);
            Port_Lever.Max = (ushort)((parameters[11] << 8) | parameters[10]);

            // Stbd_Lever
            Stbd_Lever.Min = (ushort)((parameters[13] << 8) | parameters[12]);
            Stbd_Lever.Mid = (ushort)((parameters[15] << 8) | parameters[14]);
            Stbd_Lever.Max = (ushort)((parameters[17] << 8) | parameters[16]);

            // Idle_Knob
            Idle_Knob.Min = (ushort)((parameters[19] << 8) | parameters[18]);
            Idle_Knob.Mid = (ushort)((parameters[21] << 8) | parameters[20]);
            Idle_Knob.Max = (ushort)((parameters[23] << 8) | parameters[22]);

        }
    }
}
