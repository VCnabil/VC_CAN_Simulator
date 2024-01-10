namespace VC_CAN_Simulator.UIz.ManipUC.BuildersManips
{
    partial class UC_PGN_Controller
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cb_allowSend = new System.Windows.Forms.CheckBox();
            this.uC_DataDisplayCTRL1 = new VC_CAN_Simulator.UIz.ManipUC.UC_DataDisplayCTRL();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 140);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(550, 1120);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // cb_allowSend
            // 
            this.cb_allowSend.AutoSize = true;
            this.cb_allowSend.Location = new System.Drawing.Point(506, 3);
            this.cb_allowSend.Name = "cb_allowSend";
            this.cb_allowSend.Size = new System.Drawing.Size(28, 27);
            this.cb_allowSend.TabIndex = 2;
            this.cb_allowSend.UseVisualStyleBackColor = true;
            // 
            // uC_DataDisplayCTRL1
            // 
            this.uC_DataDisplayCTRL1.Location = new System.Drawing.Point(0, 0);
            this.uC_DataDisplayCTRL1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_DataDisplayCTRL1.Name = "uC_DataDisplayCTRL1";
            this.uC_DataDisplayCTRL1.Size = new System.Drawing.Size(500, 140);
            this.uC_DataDisplayCTRL1.TabIndex = 1;
            // 
            // UC_PGN_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_allowSend);
            this.Controls.Add(this.uC_DataDisplayCTRL1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UC_PGN_Controller";
            this.Size = new System.Drawing.Size(550, 1260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UC_DataDisplayCTRL uC_DataDisplayCTRL1;
        private System.Windows.Forms.CheckBox cb_allowSend;
    }
}
