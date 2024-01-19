namespace VC_CAN_Simulator.UIz.FormzNavUC
{
    partial class ufc_LoadPreConfiguredForm
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
            this.button_Launch = new System.Windows.Forms.Button();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Launch
            // 
            this.button_Launch.BackColor = System.Drawing.Color.DimGray;
            this.button_Launch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Launch.Font = new System.Drawing.Font("Miriam CLM", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_Launch.Location = new System.Drawing.Point(0, 86);
            this.button_Launch.Name = "button_Launch";
            this.button_Launch.Size = new System.Drawing.Size(350, 34);
            this.button_Launch.TabIndex = 0;
            this.button_Launch.Text = "Run";
            this.button_Launch.UseVisualStyleBackColor = false;
            // 
            // textBox_Info
            // 
            this.textBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBox_Info.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_Info.Font = new System.Drawing.Font("Miriam CLM", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox_Info.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ReadOnly = true;
            this.textBox_Info.Size = new System.Drawing.Size(350, 83);
            this.textBox_Info.TabIndex = 43;
            this.textBox_Info.Text = "Launch App preconfigured for mkv 4";
            // 
            // ufc_LoadPreConfiguredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.textBox_Info);
            this.Controls.Add(this.button_Launch);
            this.Name = "ufc_LoadPreConfiguredForm";
            this.Size = new System.Drawing.Size(350, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Launch;
        private System.Windows.Forms.TextBox textBox_Info;
    }
}
