namespace VC_CAN_Simulator.UIz.Formz
{
    partial class CustomCanGUI
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
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_modify = new System.Windows.Forms.Button();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_MKV = new System.Windows.Forms.Button();
            this.btn_ERAF = new System.Windows.Forms.Button();
            this.btn_WSKI = new System.Windows.Forms.Button();
            this.btn_KA27 = new System.Windows.Forms.Button();
            this.btn_NOMAD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(6, 12);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(146, 52);
            this.btn_load.TabIndex = 19;
            this.btn_load.Text = "load file";
            this.btn_load.UseVisualStyleBackColor = true;
            // 
            // btn_modify
            // 
            this.btn_modify.Location = new System.Drawing.Point(469, 12);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(226, 52);
            this.btn_modify.TabIndex = 20;
            this.btn_modify.Text = "create / modify";
            this.btn_modify.UseVisualStyleBackColor = true;
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Location = new System.Drawing.Point(158, 21);
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.Size = new System.Drawing.Size(297, 35);
            this.textBox_fileName.TabIndex = 21;
            this.textBox_fileName.Text = "testpfile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 23;
            this.label2.Text = "label2";
            // 
            // btn_MKV
            // 
            this.btn_MKV.Location = new System.Drawing.Point(6, 249);
            this.btn_MKV.Name = "btn_MKV";
            this.btn_MKV.Size = new System.Drawing.Size(146, 52);
            this.btn_MKV.TabIndex = 24;
            this.btn_MKV.Text = "run MKV";
            this.btn_MKV.UseVisualStyleBackColor = true;
            // 
            // btn_ERAF
            // 
            this.btn_ERAF.Location = new System.Drawing.Point(6, 317);
            this.btn_ERAF.Name = "btn_ERAF";
            this.btn_ERAF.Size = new System.Drawing.Size(150, 52);
            this.btn_ERAF.TabIndex = 25;
            this.btn_ERAF.Text = "run ERAF";
            this.btn_ERAF.UseVisualStyleBackColor = true;
            // 
            // btn_WSKI
            // 
            this.btn_WSKI.Location = new System.Drawing.Point(2, 386);
            this.btn_WSKI.Name = "btn_WSKI";
            this.btn_WSKI.Size = new System.Drawing.Size(150, 52);
            this.btn_WSKI.TabIndex = 26;
            this.btn_WSKI.Text = "run WSKI";
            this.btn_WSKI.UseVisualStyleBackColor = true;
            // 
            // btn_KA27
            // 
            this.btn_KA27.Location = new System.Drawing.Point(6, 191);
            this.btn_KA27.Name = "btn_KA27";
            this.btn_KA27.Size = new System.Drawing.Size(150, 52);
            this.btn_KA27.TabIndex = 27;
            this.btn_KA27.Text = "run KA27";
            this.btn_KA27.UseVisualStyleBackColor = true;
            // 
            // btn_NOMAD
            // 
            this.btn_NOMAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NOMAD.Location = new System.Drawing.Point(2, 463);
            this.btn_NOMAD.Name = "btn_NOMAD";
            this.btn_NOMAD.Size = new System.Drawing.Size(150, 52);
            this.btn_NOMAD.TabIndex = 28;
            this.btn_NOMAD.Text = "run NOMAD";
            this.btn_NOMAD.UseVisualStyleBackColor = true;
            // 
            // CustomCanGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this.btn_NOMAD);
            this.Controls.Add(this.btn_KA27);
            this.Controls.Add(this.btn_WSKI);
            this.Controls.Add(this.btn_ERAF);
            this.Controls.Add(this.btn_MKV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_fileName);
            this.Controls.Add(this.btn_modify);
            this.Controls.Add(this.btn_load);
            this.Name = "CustomCanGUI";
            this.Text = "CustomCanGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_MKV;
        private System.Windows.Forms.Button btn_ERAF;
        private System.Windows.Forms.Button btn_WSKI;
        private System.Windows.Forms.Button btn_KA27;
        private System.Windows.Forms.Button btn_NOMAD;
    }
}