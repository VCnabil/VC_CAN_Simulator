namespace VC_CAN_Simulator.UIz.Formz
{
    partial class CreateOrModifyProject
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.tb_filename = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(50, 0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 50);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(700, 0);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(100, 50);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.Text = "load";
            this.btn_Load.UseVisualStyleBackColor = true;
            // 
            // tb_filename
            // 
            this.tb_filename.Location = new System.Drawing.Point(360, 8);
            this.tb_filename.Name = "tb_filename";
            this.tb_filename.Size = new System.Drawing.Size(323, 35);
            this.tb_filename.TabIndex = 2;
            // 
            // CreateOrModifyProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2872, 1721);
            this.Controls.Add(this.tb_filename);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Save);
            this.MaximumSize = new System.Drawing.Size(2900, 2000);
            this.MinimumSize = new System.Drawing.Size(2900, 1680);
            this.Name = "CreateOrModifyProject";
            this.Text = "CreateOrModifyProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.TextBox tb_filename;
    }
}