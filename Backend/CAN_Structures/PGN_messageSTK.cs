using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC_CAN_Simulator.Backend.CAN_Structures
{
    public struct PGN_messageSTK
    {
        public int PGN { get; set; }
        public int address { get; set; }
        public int priority { get; set; }
        public int FullPGN { get; private set; }
        public string PGN_Name { get; set; }
        public string PGN_Description { get; set; }
        public byte[] bytes { get; set; }
        public PGN_messageSTK(int pgn, int address, int priority, string pgnName, string pgnDescription, byte[] bytes)
        {
            FullPGN = 0; // Temporary assignment to satisfy the struct's initialization requirements
            PGN = pgn;
            this.address = address;
            this.priority = priority;
            PGN_Name = pgnName;
            PGN_Description = pgnDescription;
            this.bytes = bytes;
            FullPGN = CombinePGN(priority, pgn, address);
        }

        int CombinePGN(int prio, int pgn, int address)
        {
            int shiftedPrio = prio << 24;
            int shiftedPgn = pgn << 8;
            int result = shiftedPrio | shiftedPgn | address;

            return result;
        }
        void DecomposePGN(int fullPgn, out int priority, out int pgn, out int address)
        {
            // Extract priority by shifting 24 bits to the right
            priority = (fullPgn >> 24) & 0xFF;

            // Extract PGN by shifting 8 bits to the right and applying a mask
            pgn = (fullPgn >> 8) & 0xFFFF;

            // Extract address by applying a mask
            address = fullPgn & 0xFF;
        }

        public ushort Map(uint x, uint inMin, uint inMax, uint outMin, uint outMax)
        {
            // Ensure x is within the input range
            x = Math.Max(inMin, Math.Min(x, inMax));

            // Calculate the mapped value
            uint returnVal = (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

            // Ensure the result fits in a ushort
            returnVal = Math.Min(returnVal, ushort.MaxValue);

            return (ushort)returnVal;
        }
    }
    public enum State
    {
        NORMAL_MODE,
        CALIBRATION_MODE
    }
    public struct signal
    {
        public ushort Min { get; set; }
        public ushort Mid { get; set; }
        public ushort Max { get; set; }
        public ushort Raw { get; set; }
        public ushort Scaled { get; set; }
        public ushort OutOfRange { get; set; }
    };
}
