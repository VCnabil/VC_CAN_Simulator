namespace VC_CAN_Simulator.UIz.Formz
{
    partial class CanManipForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_StartStop = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.timer1_Loop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_StartStop
            // 
            this.btn_StartStop.Location = new System.Drawing.Point(24, 12);
            this.btn_StartStop.Name = "btn_StartStop";
            this.btn_StartStop.Size = new System.Drawing.Size(121, 50);
            this.btn_StartStop.TabIndex = 0;
            this.btn_StartStop.Text = "Start";
            this.btn_StartStop.UseVisualStyleBackColor = true;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(171, 23);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(132, 29);
            this.lbl_status.TabIndex = 1;
            this.lbl_status.Text = "is_stopped";
            // 
            // CanManipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2091, 1367);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_StartStop);
            this.Name = "CanManipForm";
            this.Text = "CanManipForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartStop;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Timer timer1_Loop;
    }
}