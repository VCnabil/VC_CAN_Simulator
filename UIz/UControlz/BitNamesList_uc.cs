﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_CAN_Simulator.UIz.UControlz
{
    public partial class BitNamesList_uc : UserControl
    {
        public event EventHandler Btn_addrow_was_Clicked_Event;
        private List<BinNameRow_uc> binNameRows ;
        private const int maxRows = 8;
        private const int rowHeight = 20;
        private const int startY = 30;


        public BitNamesList_uc()
        {
            InitializeComponent();
            binNameRows = new List<BinNameRow_uc>();
            btn_addrow.Click += Btn_addrow_Click;
        }
        private void Btn_addrow_Click(object sender, EventArgs e)
        {
            AddNewRow();
            Btn_addrow_was_Clicked_Event?.Invoke(this, e);
        }

        private void AddNewRow()
        {
            if (binNameRows.Count < maxRows)
            {
                var newRow = new BinNameRow_uc();
                newRow.Location = new Point(0, startY + binNameRows.Count * rowHeight);
                newRow.Btn_rem_was_Clicked_Event += BinNameRow_Removed;
                newRow.BitDescription = "";
                Controls.Add(newRow);
                binNameRows.Add(newRow);

                if (binNameRows.Count == maxRows)
                {
                    btn_addrow.Enabled = false;
                }
                newRow.BitDescription_Changed_Event += (sender, e) => CheckForBitConflicts();

            }
        }
        private void BinNameRow_Removed(object sender, EventArgs e)
        {
            var rowToRemove = sender as BinNameRow_uc;
            if (rowToRemove != null)
            {
                Controls.Remove(rowToRemove);
                binNameRows.Remove(rowToRemove);
                rowToRemove.Btn_rem_was_Clicked_Event -= BinNameRow_Removed;

                // Adjust the location of remaining rows
                for (int i = 0; i < binNameRows.Count; i++)
                {
                    binNameRows[i].Location = new Point(0, startY + i * rowHeight);
                }

                if (!btn_addrow.Enabled && binNameRows.Count < maxRows)
                {
                    btn_addrow.Enabled = true;
                }
            }
            CheckForBitConflicts();
        }

        public List<string> GetBitNameDescriptions()
        {
            return binNameRows.Select(row => row.BitDescription).ToList();
        }
        public void SetBitNameDescriptions(List<string> bitNameDescriptions)
        {

            int listSize = bitNameDescriptions.Count;
            if (listSize > maxRows)
            {
                listSize = maxRows;
            }

            while (binNameRows.Count < listSize)
            {
                AddNewRow();
            }

            for (int i = 0; i < listSize; i++)
            {
                binNameRows[i].BitDescription = bitNameDescriptions[i];
            }
        }

        public void CheckForBitConflicts()
        {
            label_conflicts.Text = "ok: ";
            label_conflicts.ForeColor = Color.Black;
            var bitNumbers = new Dictionary<int, List<int>>(); // Key: bit number, Value: list of row indices with this bit number

            for (int i = 0; i < binNameRows.Count; i++)
            {
                string description = binNameRows[i].BitDescription;
                int bitNumber = ParseBitNumber(description);
                if (bitNumber != -1)
                {
                    if (!bitNumbers.ContainsKey(bitNumber))
                    {
                        bitNumbers[bitNumber] = new List<int>();
                    }
                    bitNumbers[bitNumber].Add(i);
                }
            }

            var conflicts = bitNumbers.Where(kvp => kvp.Value.Count > 1);
            foreach (var conflict in conflicts)
            {
                string conflictMessage = $"Conflict on bit {conflict.Key} in items: {string.Join(", ", conflict.Value.Select(index => index + 1))}";
                // Handle the conflict (e.g., show a message to the user)
              //  MessageBox.Show(conflictMessage, "Label Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              label_conflicts.Text = conflictMessage;
                label_conflicts.ForeColor = Color.Red;
            }
        }
        public void ClearAll()
        {
            foreach (var row in binNameRows)
            {
                row.Btn_rem_was_Clicked_Event -= BinNameRow_Removed;
                Controls.Remove(row);
            }

            binNameRows.Clear();

            btn_addrow.Enabled = true;
        }
        private int ParseBitNumber(string description)
        {
            var parts = description.Split(new[] { '.' }, 2);
            if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int bitNumber))
            {
                return bitNumber;
            }
            return -1;
        }
      

    }
}