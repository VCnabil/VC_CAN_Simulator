namespace VC_CAN_Simulator.UIz.FormzNavUC
{
    partial class ucf_KvaserCanModule
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
            this.components = new System.ComponentModel.Container();
            this.lbl_bussStatus = new System.Windows.Forms.Label();
            this.checkBox_LoopRunning = new System.Windows.Forms.CheckBox();
            this.button1_KillCan = new System.Windows.Forms.Button();
            this.button1_initcan = new System.Windows.Forms.Button();
            this.label1_errors = new System.Windows.Forms.Label();
            this.timer0_TestForm = new System.Windows.Forms.Timer(this.components);
            this.textBox_Rate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_bussStatus
            // 
            this.lbl_bussStatus.AutoSize = true;
            this.lbl_bussStatus.BackColor = System.Drawing.Color.Red;
            this.lbl_bussStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bussStatus.Location = new System.Drawing.Point(3, 48);
            this.lbl_bussStatus.Name = "lbl_bussStatus";
            this.lbl_bussStatus.Size = new System.Drawing.Size(116, 31);
            this.lbl_bussStatus.TabIndex = 84;
            this.lbl_bussStatus.Text = "ONBUS";
            // 
            // checkBox_LoopRunning
            // 
            this.checkBox_LoopRunning.AutoSize = true;
            this.checkBox_LoopRunning.Location = new System.Drawing.Point(163, 48);
            this.checkBox_LoopRunning.Name = "checkBox_LoopRunning";
            this.checkBox_LoopRunning.Size = new System.Drawing.Size(94, 33);
            this.checkBox_LoopRunning.TabIndex = 86;
            this.checkBox_LoopRunning.Text = "Run:";
            this.checkBox_LoopRunning.UseVisualStyleBackColor = true;
            // 
            // button1_KillCan
            // 
            this.button1_KillCan.Location = new System.Drawing.Point(460, 48);
            this.button1_KillCan.Name = "button1_KillCan";
            this.button1_KillCan.Size = new System.Drawing.Size(122, 43);
            this.button1_KillCan.TabIndex = 87;
            this.button1_KillCan.Text = "kill can";
            this.button1_KillCan.UseVisualStyleBackColor = true;
            // 
            // button1_initcan
            // 
            this.button1_initcan.Location = new System.Drawing.Point(306, 48);
            this.button1_initcan.Name = "button1_initcan";
            this.button1_initcan.Size = new System.Drawing.Size(122, 43);
            this.button1_initcan.TabIndex = 88;
            this.button1_initcan.Text = "initcan";
            this.button1_initcan.UseVisualStyleBackColor = true;
            // 
            // label1_errors
            // 
            this.label1_errors.AutoSize = true;
            this.label1_errors.Location = new System.Drawing.Point(3, 6);
            this.label1_errors.Name = "label1_errors";
            this.label1_errors.Size = new System.Drawing.Size(89, 29);
            this.label1_errors.TabIndex = 89;
            this.label1_errors.Text = "errors :";
            // 
            // timer0_TestForm
            // 
            this.timer0_TestForm.Interval = 400;
            // 
            // textBox_Rate
            // 
            this.textBox_Rate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Rate.Location = new System.Drawing.Point(697, 59);
            this.textBox_Rate.MaxLength = 6;
            this.textBox_Rate.Name = "textBox_Rate";
            this.textBox_Rate.Size = new System.Drawing.Size(100, 28);
            this.textBox_Rate.TabIndex = 90;
            this.textBox_Rate.Text = "400";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 91;
            this.label4.Text = "cntframes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 92;
            this.label1.Text = "Rate ms";
            // 
            // ucf_KvaserCanModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Rate);
            this.Controls.Add(this.label1_errors);
            this.Controls.Add(this.button1_initcan);
            this.Controls.Add(this.button1_KillCan);
            this.Controls.Add(this.checkBox_LoopRunning);
            this.Controls.Add(this.lbl_bussStatus);
            this.Name = "ucf_KvaserCanModule";
            this.Size = new System.Drawing.Size(800, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_bussStatus;
        private System.Windows.Forms.CheckBox checkBox_LoopRunning;
        private System.Windows.Forms.Button button1_KillCan;
        private System.Windows.Forms.Button button1_initcan;
        private System.Windows.Forms.Label label1_errors;
        private System.Windows.Forms.Timer timer0_TestForm;
        private System.Windows.Forms.TextBox textBox_Rate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}
