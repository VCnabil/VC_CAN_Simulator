namespace VC_CAN_Simulator.UIz.UControlz
{
    partial class BitNamesList_uc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_addrow = new System.Windows.Forms.Button();
            this.label_conflicts = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_addrow
            // 
            this.btn_addrow.Font = new System.Drawing.Font("Miriam CLM", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_addrow.Location = new System.Drawing.Point(0, 0);
            this.btn_addrow.Name = "btn_addrow";
            this.btn_addrow.Size = new System.Drawing.Size(90, 35);
            this.btn_addrow.TabIndex = 4;
            this.btn_addrow.Text = "Add";
            this.btn_addrow.UseVisualStyleBackColor = true;
            // 
            // label_conflicts
            // 
            this.label_conflicts.AutoSize = true;
            this.label_conflicts.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_conflicts.ForeColor = System.Drawing.Color.Red;
            this.label_conflicts.Location = new System.Drawing.Point(3, 38);
            this.label_conflicts.Name = "label_conflicts";
            this.label_conflicts.Size = new System.Drawing.Size(96, 27);
            this.label_conflicts.TabIndex = 5;
            this.label_conflicts.Text = "conflicts:";
            // 
            // textBox_description
            // 
            this.textBox_description.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox_description.Location = new System.Drawing.Point(102, 0);
            this.textBox_description.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_description.MaximumSize = new System.Drawing.Size(290, 30);
            this.textBox_description.MaxLength = 30;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(290, 30);
            this.textBox_description.TabIndex = 6;
            this.textBox_description.Text = "description";
            this.textBox_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_description.WordWrap = false;
            // 
            // BitNamesList_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label_conflicts);
            this.Controls.Add(this.btn_addrow);
            this.Name = "BitNamesList_uc";
            this.Size = new System.Drawing.Size(400, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_addrow;
        private System.Windows.Forms.Label label_conflicts;
        private System.Windows.Forms.TextBox textBox_description;
    }
}
