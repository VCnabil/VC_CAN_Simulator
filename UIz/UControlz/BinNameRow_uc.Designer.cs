namespace VC_CAN_Simulator.UIz.UControlz
{
    partial class BinNameRow_uc
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
            this.textBox_bitDescription = new System.Windows.Forms.TextBox();
            this.btn_rem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_bitDescription
            // 
            this.textBox_bitDescription.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox_bitDescription.Location = new System.Drawing.Point(3, 3);
            this.textBox_bitDescription.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_bitDescription.MaximumSize = new System.Drawing.Size(300, 32);
            this.textBox_bitDescription.Name = "textBox_bitDescription";
            this.textBox_bitDescription.Size = new System.Drawing.Size(299, 32);
            this.textBox_bitDescription.TabIndex = 2;
            this.textBox_bitDescription.Text = "3. Control lever on posiition";
            // 
            // btn_rem
            // 
            this.btn_rem.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_rem.Location = new System.Drawing.Point(308, 3);
            this.btn_rem.Name = "btn_rem";
            this.btn_rem.Size = new System.Drawing.Size(92, 32);
            this.btn_rem.TabIndex = 3;
            this.btn_rem.Text = "rem";
            this.btn_rem.UseVisualStyleBackColor = true;
            // 
            // BinNameRow_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btn_rem);
            this.Controls.Add(this.textBox_bitDescription);
            this.Name = "BinNameRow_uc";
            this.Size = new System.Drawing.Size(400, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_bitDescription;
        private System.Windows.Forms.Button btn_rem;
    }
}
