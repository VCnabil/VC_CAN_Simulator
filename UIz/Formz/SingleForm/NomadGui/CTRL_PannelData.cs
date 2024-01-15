using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.NomadGui
{
    public class CTRL_PannelData
    {
        // Fields
        private int _steerPOInt, _steerSOInt, _thrustPOInt, _thrustSOInt;
        private int _steerPOFbInt, _steerSOFbInt, _thrustPOFbInt, _thrustSOFbInt;
        private int _steerPIInt, _steerSIInt, _thrustPIInt, _thrustSIInt;
        private int _steerPIFbInt, _steerSIFbInt, _thrustPIFbInt, _thrustSIFbInt;
        private bool _isManned, _isUnmanned, _isRunning, _isRequesting, _isChangover, _isDpSelect;

        public CTRL_PannelData()
        {
            // Initialize all fields to default values
            _steerPOInt = _steerSOInt = _thrustPOInt = _thrustSOInt = 0;
            _steerPOFbInt = _steerSOFbInt = _thrustPOFbInt = _thrustSOFbInt = 0;
            _steerPIInt = _steerSIInt = _thrustPIInt = _thrustSIInt = 0;
            _steerPIFbInt = _steerSIFbInt = _thrustPIFbInt = _thrustSIFbInt = 0;
            _isManned = _isUnmanned = _isRunning = _isRequesting = _isChangover = _isDpSelect = false;
        }
        // Properties (auto-implemented properties are used for simplicity)
        public int Steer_P_O_Int { get; set; }
        public int Steer_S_O_Int { get; set; }
        public int Thrust_P_O_Int { get; set; }
        public int Thrust_S_O_Int { get; set; }
        public int Steer_P_O_Fb_Int { get; set; }
        public int Steer_S_O_Fb_Int { get; set; }
        public int Thrust_P_O_Fb_Int { get; set; }
        public int Thrust_S_O_Fb_Int { get; set; }
        public int Steer_P_I_Int { get; set; }
        public int Steer_S_I_Int { get; set; }
        public int Thrust_P_I_Int { get; set; }
        public int Thrust_S_I_Int { get; set; }
        public int Steer_P_I_Fb_Int { get; set; }
        public int Steer_S_I_Fb_Int { get; set; }
        public int Thrust_P_I_Fb_Int { get; set; }
        public int Thrust_S_I_Fb_Int { get; set; }
        public bool Is_Manned { get; set; }
        public bool Is_Unmanned { get; set; }
        public bool Is_Running { get; set; }
        public bool Is_Requesting { get; set; }
        public bool Is_Changover { get; set; }
        public bool Is_DpSelect { get; set; }
    }
}
