using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.UIz.Formz.SingleForm.NomadGui
{
    public class INDIC_PannelData
    {
        // Fields
        private int _buc_0_Int, _buc_1_Int, _buc_2_Int, _buc_3_Int;
        private int _noz_0_Int, _noz_1_Int, _noz_2_Int, _noz_3_Int;
        private int _eng_0_Int, _eng_1_Int, _eng_2_Int, _eng_3_Int;
        // Constructor
        public INDIC_PannelData()
        {
            _buc_0_Int = _buc_1_Int = _buc_2_Int = _buc_3_Int = 0;
            _noz_0_Int = _noz_1_Int = _noz_2_Int = _noz_3_Int = 0;
            _eng_0_Int = _eng_1_Int = _eng_2_Int = _eng_3_Int = 0;
        }

        // Properties
        public int BUC_0_Int { get; set; }
        public int BUC_1_Int { get; set; }
        public int BUC_2_Int { get; set; }
        public int BUC_3_Int { get; set; }
        public int NOZ_0_Int { get; set; }
        public int NOZ_1_Int { get; set; }
        public int NOZ_2_Int { get; set; }
        public int NOZ_3_Int { get; set; }
        public int ENG_0_Int { get; set; }
        public int ENG_1_Int { get; set; }
        public int ENG_2_Int { get; set; }
        public int ENG_3_Int { get; set; }
    }
}
