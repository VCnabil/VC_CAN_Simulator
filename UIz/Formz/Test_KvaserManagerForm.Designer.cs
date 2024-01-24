namespace VC_CAN_Simulator.UIz.Formz
{
    partial class Test_KvaserManagerForm
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
            this.ucf_KvaserCanModule1 = new VC_CAN_Simulator.UIz.FormzNavUC.ucf_KvaserCanModule();
            this.SuspendLayout();
            // 
            // ucf_KvaserCanModule1
            // 
            this.ucf_KvaserCanModule1.Location = new System.Drawing.Point(12, 24);
            this.ucf_KvaserCanModule1.Name = "ucf_KvaserCanModule1";
            this.ucf_KvaserCanModule1.Size = new System.Drawing.Size(800, 100);
            this.ucf_KvaserCanModule1.TabIndex = 0;
            // 
            // Test_KvaserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1972, 1421);
            this.Controls.Add(this.ucf_KvaserCanModule1);
            this.Name = "Test_KvaserManagerForm";
            this.Text = "Test_KvaserManagerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private FormzNavUC.ucf_KvaserCanModule ucf_KvaserCanModule1;
    }
}