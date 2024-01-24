namespace VC_CAN_Simulator.Translators
{
    partial class FormTranslate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_totalPgnsInDb = new System.Windows.Forms.Label();
            this.X1_label1 = new System.Windows.Forms.Label();
            this.label_MatchesFound = new System.Windows.Forms.Label();
            this.X1_label3 = new System.Windows.Forms.Label();
            this.X1_label2 = new System.Windows.Forms.Label();
            this.label_Filter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_totalPgnsInDb
            // 
            this.label_totalPgnsInDb.AutoSize = true;
            this.label_totalPgnsInDb.Location = new System.Drawing.Point(402, 27);
            this.label_totalPgnsInDb.Name = "label_totalPgnsInDb";
            this.label_totalPgnsInDb.Size = new System.Drawing.Size(24, 29);
            this.label_totalPgnsInDb.TabIndex = 3;
            this.label_totalPgnsInDb.Text = "x";
            // 
            // X1_label1
            // 
            this.X1_label1.AutoSize = true;
            this.X1_label1.Location = new System.Drawing.Point(12, 27);
            this.X1_label1.Name = "X1_label1";
            this.X1_label1.Size = new System.Drawing.Size(383, 29);
            this.X1_label1.TabIndex = 2;
            this.X1_label1.Text = "Totale Pgn definitions in database:";
            // 
            // label_MatchesFound
            // 
            this.label_MatchesFound.AutoSize = true;
            this.label_MatchesFound.Location = new System.Drawing.Point(217, 112);
            this.label_MatchesFound.Name = "label_MatchesFound";
            this.label_MatchesFound.Size = new System.Drawing.Size(24, 29);
            this.label_MatchesFound.TabIndex = 25;
            this.label_MatchesFound.Text = "x";
            // 
            // X1_label3
            // 
            this.X1_label3.AutoSize = true;
            this.X1_label3.Location = new System.Drawing.Point(12, 112);
            this.X1_label3.Name = "X1_label3";
            this.X1_label3.Size = new System.Drawing.Size(169, 29);
            this.X1_label3.TabIndex = 24;
            this.X1_label3.Text = "found Matches";
            // 
            // X1_label2
            // 
            this.X1_label2.AutoSize = true;
            this.X1_label2.Location = new System.Drawing.Point(12, 66);
            this.X1_label2.Name = "X1_label2";
            this.X1_label2.Size = new System.Drawing.Size(99, 29);
            this.X1_label2.TabIndex = 26;
            this.X1_label2.Text = "Filterby:";
            // 
            // label_Filter
            // 
            this.label_Filter.AutoSize = true;
            this.label_Filter.Location = new System.Drawing.Point(217, 66);
            this.label_Filter.Name = "label_Filter";
            this.label_Filter.Size = new System.Drawing.Size(24, 29);
            this.label_Filter.TabIndex = 27;
            this.label_Filter.Text = "x";
            // 
            // FormTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1550, 1068);
            this.Controls.Add(this.label_Filter);
            this.Controls.Add(this.X1_label2);
            this.Controls.Add(this.label_MatchesFound);
            this.Controls.Add(this.X1_label3);
            this.Controls.Add(this.label_totalPgnsInDb);
            this.Controls.Add(this.X1_label1);
            this.Name = "FormTranslate";
            this.Text = "FormTranslate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_totalPgnsInDb;
        private System.Windows.Forms.Label X1_label1;
        private System.Windows.Forms.Label label_MatchesFound;
        private System.Windows.Forms.Label X1_label3;
        private System.Windows.Forms.Label X1_label2;
        private System.Windows.Forms.Label label_Filter;
    }
}