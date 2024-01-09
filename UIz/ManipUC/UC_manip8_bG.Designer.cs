namespace VC_CAN_Simulator.UIz.ManipUC
{
    partial class UC_manip8_bG
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
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.lbl_Bval = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.textBox_error = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.AutoSize = true;
            this.lbl_Desc.Location = new System.Drawing.Point(99, 188);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(135, 29);
            this.lbl_Desc.TabIndex = 12;
            this.lbl_Desc.Text = "Description";
            this.lbl_Desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Bval
            // 
            this.lbl_Bval.AutoSize = true;
            this.lbl_Bval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lbl_Bval.Location = new System.Drawing.Point(3, 188);
            this.lbl_Bval.Name = "lbl_Bval";
            this.lbl_Bval.Size = new System.Drawing.Size(65, 29);
            this.lbl_Bval.TabIndex = 11;
            this.lbl_Bval.Text = "2556";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(407, 168);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(90, 49);
            this.btn_reset.TabIndex = 10;
            this.btn_reset.Text = "reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // textBox_error
            // 
            this.textBox_error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_error.Location = new System.Drawing.Point(8, 3);
            this.textBox_error.Multiline = true;
            this.textBox_error.Name = "textBox_error";
            this.textBox_error.Size = new System.Drawing.Size(480, 163);
            this.textBox_error.TabIndex = 13;
            this.textBox_error.Text = "Description there was an error on one or more components. please check value at g" +
    "roup1 and bits entered ";
            // 
            // UC_manip8_bG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_error);
            this.Controls.Add(this.lbl_Desc);
            this.Controls.Add(this.lbl_Bval);
            this.Controls.Add(this.btn_reset);
            this.Name = "UC_manip8_bG";
            this.Size = new System.Drawing.Size(500, 220);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Desc;
        private System.Windows.Forms.Label lbl_Bval;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox textBox_error;
    }
}
