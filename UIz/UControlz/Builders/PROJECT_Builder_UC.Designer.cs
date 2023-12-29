namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    partial class PROJECT_Builder_UC
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
            this.btn_AddPGN = new System.Windows.Forms.Button();
            this.fl_verticalpannel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btn_AddPGN
            // 
            this.btn_AddPGN.Font = new System.Drawing.Font("Miriam CLM", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_AddPGN.Location = new System.Drawing.Point(3, 3);
            this.btn_AddPGN.Name = "btn_AddPGN";
            this.btn_AddPGN.Size = new System.Drawing.Size(120, 66);
            this.btn_AddPGN.TabIndex = 18;
            this.btn_AddPGN.Text = "Add a new PGN";
            this.btn_AddPGN.UseVisualStyleBackColor = true;
            // 
            // fl_verticalpannel
            // 
            this.fl_verticalpannel.AutoScroll = true;
            this.fl_verticalpannel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.fl_verticalpannel.Dock = System.Windows.Forms.DockStyle.Right;
            this.fl_verticalpannel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fl_verticalpannel.Location = new System.Drawing.Point(140, 0);
            this.fl_verticalpannel.Name = "fl_verticalpannel";
            this.fl_verticalpannel.Size = new System.Drawing.Size(2660, 1680);
            this.fl_verticalpannel.TabIndex = 19;
            this.fl_verticalpannel.WrapContents = false;
            // 
            // PROJECT_Builder_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.Controls.Add(this.fl_verticalpannel);
            this.Controls.Add(this.btn_AddPGN);
            this.Name = "PROJECT_Builder_UC";
            this.Size = new System.Drawing.Size(2800, 1680);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_AddPGN;
        private System.Windows.Forms.FlowLayoutPanel fl_verticalpannel;
    }
}
