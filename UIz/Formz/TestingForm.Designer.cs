namespace VC_CAN_Simulator.UIz.Formz
{
    partial class TestingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer0_TestForm = new System.Windows.Forms.Timer(this.components);
            this.button1_initcan = new System.Windows.Forms.Button();
            this.textBox_Display = new System.Windows.Forms.TextBox();
            this.button1_KillCan = new System.Windows.Forms.Button();
            this.lbl_bussStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_LoopRunning = new System.Windows.Forms.CheckBox();
            this.label1_errors = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 29);
            this.label1.TabIndex = 77;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 78;
            this.label2.Text = "label2";
            // 
            // timer0_TestForm
            // 
            this.timer0_TestForm.Interval = 500;
            // 
            // button1_initcan
            // 
            this.button1_initcan.Location = new System.Drawing.Point(36, 169);
            this.button1_initcan.Name = "button1_initcan";
            this.button1_initcan.Size = new System.Drawing.Size(122, 43);
            this.button1_initcan.TabIndex = 79;
            this.button1_initcan.Text = "initcan";
            this.button1_initcan.UseVisualStyleBackColor = true;
            // 
            // textBox_Display
            // 
            this.textBox_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Display.Location = new System.Drawing.Point(302, 114);
            this.textBox_Display.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_Display.Multiline = true;
            this.textBox_Display.Name = "textBox_Display";
            this.textBox_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Display.Size = new System.Drawing.Size(1205, 818);
            this.textBox_Display.TabIndex = 81;
            this.textBox_Display.Text = "e";
            // 
            // button1_KillCan
            // 
            this.button1_KillCan.Location = new System.Drawing.Point(36, 421);
            this.button1_KillCan.Name = "button1_KillCan";
            this.button1_KillCan.Size = new System.Drawing.Size(122, 43);
            this.button1_KillCan.TabIndex = 82;
            this.button1_KillCan.Text = "kill can";
            this.button1_KillCan.UseVisualStyleBackColor = true;
            // 
            // lbl_bussStatus
            // 
            this.lbl_bussStatus.AutoSize = true;
            this.lbl_bussStatus.BackColor = System.Drawing.Color.Red;
            this.lbl_bussStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bussStatus.Location = new System.Drawing.Point(30, 9);
            this.lbl_bussStatus.Name = "lbl_bussStatus";
            this.lbl_bussStatus.Size = new System.Drawing.Size(116, 31);
            this.lbl_bussStatus.TabIndex = 83;
            this.lbl_bussStatus.Text = "ONBUS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(729, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 29);
            this.label4.TabIndex = 84;
            this.label4.Text = "label4";
            // 
            // checkBox_LoopRunning
            // 
            this.checkBox_LoopRunning.AutoSize = true;
            this.checkBox_LoopRunning.Location = new System.Drawing.Point(36, 73);
            this.checkBox_LoopRunning.Name = "checkBox_LoopRunning";
            this.checkBox_LoopRunning.Size = new System.Drawing.Size(182, 33);
            this.checkBox_LoopRunning.TabIndex = 85;
            this.checkBox_LoopRunning.Text = "loopRunning";
            this.checkBox_LoopRunning.UseVisualStyleBackColor = true;
            // 
            // label1_errors
            // 
            this.label1_errors.AutoSize = true;
            this.label1_errors.Location = new System.Drawing.Point(865, 17);
            this.label1_errors.Name = "label1_errors";
            this.label1_errors.Size = new System.Drawing.Size(79, 29);
            this.label1_errors.TabIndex = 86;
            this.label1_errors.Text = "label3";
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2872, 1701);
            this.Controls.Add(this.label1_errors);
            this.Controls.Add(this.checkBox_LoopRunning);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_bussStatus);
            this.Controls.Add(this.button1_KillCan);
            this.Controls.Add(this.textBox_Display);
            this.Controls.Add(this.button1_initcan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(2900, 2000);
            this.MinimumSize = new System.Drawing.Size(2900, 1680);
            this.Name = "TestingForm";
            this.Text = "1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer0_TestForm;
        private System.Windows.Forms.Button button1_initcan;
        private System.Windows.Forms.TextBox textBox_Display;
        private System.Windows.Forms.Button button1_KillCan;
        private System.Windows.Forms.Label lbl_bussStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_LoopRunning;
        private System.Windows.Forms.Label label1_errors;
    }
}