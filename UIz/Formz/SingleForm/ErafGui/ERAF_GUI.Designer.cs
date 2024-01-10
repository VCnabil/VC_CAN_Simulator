namespace VC_CAN_Simulator.UIz.Formz.SingleForm.ErafGui
{
    partial class ERAF_GUI
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
            this.textBox_LogDisplay = new System.Windows.Forms.TextBox();
            this.cb_sendFF54 = new System.Windows.Forms.CheckBox();
            this.checkBox_stopRX = new System.Windows.Forms.CheckBox();
            this.checkBox_formatDecimal = new System.Windows.Forms.CheckBox();
            this.btn_clearDisplay = new System.Windows.Forms.Button();
            this.checkBox_stopTXCAN = new System.Windows.Forms.CheckBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.cb_Send_ff34 = new System.Windows.Forms.CheckBox();
            this.cb_Send_ff51 = new System.Windows.Forms.CheckBox();
            this.cb_Send_ff50 = new System.Windows.Forms.CheckBox();
            this.uC_PGN_FF34_Clu = new VC_CAN_Simulator.UIz.Formz.SingleForm.ErafGui.UC_ERAF_PGN_FF34_ClutchCom();
            this.uC_PGN_FF51_Lev = new VC_CAN_Simulator.UIz.Formz.SingleForm.ErafGui.UC_ERAF_PGN_FF51_LeverPos();
            this.uC_PGN_FF50_hlm = new VC_CAN_Simulator.UIz.Formz.SingleForm.ErafGui.UC_ERAF_PGN_FF50_Helm_TakeCtrl();
            this.timer_runCanSend = new System.Windows.Forms.Timer(this.components);
            this.timer_runCanReceive = new System.Windows.Forms.Timer(this.components);
            this.timer_Loop = new System.Windows.Forms.Timer(this.components);
            this.checkBox_DisplayReceivedCAN = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_LogDisplay
            // 
            this.textBox_LogDisplay.Location = new System.Drawing.Point(21, 320);
            this.textBox_LogDisplay.Multiline = true;
            this.textBox_LogDisplay.Name = "textBox_LogDisplay";
            this.textBox_LogDisplay.ReadOnly = true;
            this.textBox_LogDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_LogDisplay.Size = new System.Drawing.Size(759, 630);
            this.textBox_LogDisplay.TabIndex = 6;
            this.textBox_LogDisplay.Text = "logger";
            // 
            // cb_sendFF54
            // 
            this.cb_sendFF54.AutoSize = true;
            this.cb_sendFF54.Location = new System.Drawing.Point(220, 151);
            this.cb_sendFF54.Name = "cb_sendFF54";
            this.cb_sendFF54.Size = new System.Drawing.Size(144, 33);
            this.cb_sendFF54.TabIndex = 22;
            this.cb_sendFF54.Text = "dend ff54";
            this.cb_sendFF54.UseVisualStyleBackColor = true;
            // 
            // checkBox_stopRX
            // 
            this.checkBox_stopRX.AutoSize = true;
            this.checkBox_stopRX.Location = new System.Drawing.Point(416, 33);
            this.checkBox_stopRX.Name = "checkBox_stopRX";
            this.checkBox_stopRX.Size = new System.Drawing.Size(191, 33);
            this.checkBox_stopRX.TabIndex = 21;
            this.checkBox_stopRX.Text = "Stop RX CAN";
            this.checkBox_stopRX.UseVisualStyleBackColor = true;
            // 
            // checkBox_formatDecimal
            // 
            this.checkBox_formatDecimal.AutoSize = true;
            this.checkBox_formatDecimal.Location = new System.Drawing.Point(220, 111);
            this.checkBox_formatDecimal.Name = "checkBox_formatDecimal";
            this.checkBox_formatDecimal.Size = new System.Drawing.Size(87, 33);
            this.checkBox_formatDecimal.TabIndex = 20;
            this.checkBox_formatDecimal.Text = "Hex";
            this.checkBox_formatDecimal.UseVisualStyleBackColor = true;
            // 
            // btn_clearDisplay
            // 
            this.btn_clearDisplay.Location = new System.Drawing.Point(589, 122);
            this.btn_clearDisplay.Name = "btn_clearDisplay";
            this.btn_clearDisplay.Size = new System.Drawing.Size(165, 55);
            this.btn_clearDisplay.TabIndex = 19;
            this.btn_clearDisplay.Text = "Clear Log";
            this.btn_clearDisplay.UseVisualStyleBackColor = true;
            // 
            // checkBox_stopTXCAN
            // 
            this.checkBox_stopTXCAN.AutoSize = true;
            this.checkBox_stopTXCAN.Location = new System.Drawing.Point(220, 34);
            this.checkBox_stopTXCAN.Name = "checkBox_stopTXCAN";
            this.checkBox_stopTXCAN.Size = new System.Drawing.Size(190, 33);
            this.checkBox_stopTXCAN.TabIndex = 18;
            this.checkBox_stopTXCAN.Text = "Stop TX CAN";
            this.checkBox_stopTXCAN.UseVisualStyleBackColor = true;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(11, 111);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(165, 55);
            this.btn_Stop.TabIndex = 17;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(11, 34);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(165, 55);
            this.btn_Start.TabIndex = 16;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // cb_Send_ff34
            // 
            this.cb_Send_ff34.AutoSize = true;
            this.cb_Send_ff34.Location = new System.Drawing.Point(832, 596);
            this.cb_Send_ff34.Name = "cb_Send_ff34";
            this.cb_Send_ff34.Size = new System.Drawing.Size(101, 33);
            this.cb_Send_ff34.TabIndex = 25;
            this.cb_Send_ff34.Text = "FF34";
            this.cb_Send_ff34.UseVisualStyleBackColor = true;
            // 
            // cb_Send_ff51
            // 
            this.cb_Send_ff51.AutoSize = true;
            this.cb_Send_ff51.Location = new System.Drawing.Point(1124, 83);
            this.cb_Send_ff51.Name = "cb_Send_ff51";
            this.cb_Send_ff51.Size = new System.Drawing.Size(101, 33);
            this.cb_Send_ff51.TabIndex = 24;
            this.cb_Send_ff51.Text = "FF51";
            this.cb_Send_ff51.UseVisualStyleBackColor = true;
            // 
            // cb_Send_ff50
            // 
            this.cb_Send_ff50.AutoSize = true;
            this.cb_Send_ff50.Location = new System.Drawing.Point(800, 83);
            this.cb_Send_ff50.Name = "cb_Send_ff50";
            this.cb_Send_ff50.Size = new System.Drawing.Size(101, 33);
            this.cb_Send_ff50.TabIndex = 23;
            this.cb_Send_ff50.Text = "FF50";
            this.cb_Send_ff50.UseVisualStyleBackColor = true;
            // 
            // uC_PGN_FF34_Clu
            // 
            this.uC_PGN_FF34_Clu.Location = new System.Drawing.Point(789, 650);
            this.uC_PGN_FF34_Clu.Name = "uC_PGN_FF34_Clu";
            this.uC_PGN_FF34_Clu.Size = new System.Drawing.Size(700, 300);
            this.uC_PGN_FF34_Clu.TabIndex = 28;
            // 
            // uC_PGN_FF51_Lev
            // 
            this.uC_PGN_FF51_Lev.Location = new System.Drawing.Point(1076, 151);
            this.uC_PGN_FF51_Lev.Name = "uC_PGN_FF51_Lev";
            this.uC_PGN_FF51_Lev.Size = new System.Drawing.Size(400, 400);
            this.uC_PGN_FF51_Lev.TabIndex = 27;
            // 
            // uC_PGN_FF50_hlm
            // 
            this.uC_PGN_FF50_hlm.Location = new System.Drawing.Point(800, 122);
            this.uC_PGN_FF50_hlm.Name = "uC_PGN_FF50_hlm";
            this.uC_PGN_FF50_hlm.Size = new System.Drawing.Size(200, 400);
            this.uC_PGN_FF50_hlm.TabIndex = 26;
            // 
            // timer_Loop
            // 
            this.timer_Loop.Interval = 200;
            // 
            // checkBox_DisplayReceivedCAN
            // 
            this.checkBox_DisplayReceivedCAN.AutoSize = true;
            this.checkBox_DisplayReceivedCAN.Location = new System.Drawing.Point(220, 72);
            this.checkBox_DisplayReceivedCAN.Name = "checkBox_DisplayReceivedCAN";
            this.checkBox_DisplayReceivedCAN.Size = new System.Drawing.Size(297, 33);
            this.checkBox_DisplayReceivedCAN.TabIndex = 29;
            this.checkBox_DisplayReceivedCAN.Text = "Display CAN Messages";
            this.checkBox_DisplayReceivedCAN.UseVisualStyleBackColor = true;
            // 
            // ERAF_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 1037);
            this.Controls.Add(this.checkBox_DisplayReceivedCAN);
            this.Controls.Add(this.uC_PGN_FF34_Clu);
            this.Controls.Add(this.uC_PGN_FF51_Lev);
            this.Controls.Add(this.uC_PGN_FF50_hlm);
            this.Controls.Add(this.cb_Send_ff34);
            this.Controls.Add(this.cb_Send_ff51);
            this.Controls.Add(this.cb_Send_ff50);
            this.Controls.Add(this.cb_sendFF54);
            this.Controls.Add(this.checkBox_stopRX);
            this.Controls.Add(this.checkBox_formatDecimal);
            this.Controls.Add(this.btn_clearDisplay);
            this.Controls.Add(this.checkBox_stopTXCAN);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.textBox_LogDisplay);
            this.Name = "ERAF_GUI";
            this.Text = "ERAF_GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_LogDisplay;
        private System.Windows.Forms.CheckBox cb_sendFF54;
        private System.Windows.Forms.CheckBox checkBox_stopRX;
        private System.Windows.Forms.CheckBox checkBox_formatDecimal;
        private System.Windows.Forms.Button btn_clearDisplay;
        private System.Windows.Forms.CheckBox checkBox_stopTXCAN;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.CheckBox cb_Send_ff34;
        private System.Windows.Forms.CheckBox cb_Send_ff51;
        private System.Windows.Forms.CheckBox cb_Send_ff50;
        private UC_ERAF_PGN_FF50_Helm_TakeCtrl uC_PGN_FF50_hlm;
        private UC_ERAF_PGN_FF51_LeverPos uC_PGN_FF51_Lev;
        private UC_ERAF_PGN_FF34_ClutchCom uC_PGN_FF34_Clu;
        private System.Windows.Forms.Timer timer_runCanSend;
        private System.Windows.Forms.Timer timer_runCanReceive;
        private System.Windows.Forms.Timer timer_Loop;
        private System.Windows.Forms.CheckBox checkBox_DisplayReceivedCAN;
    }
}