namespace VC_CAN_Simulator.VC_PGNS_DIR.VC_UI
{
    partial class VC_PGNjsonGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VC_PGNjsonGUI));
            this.btn_Gzero_toJson = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_makeText_fromJson = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_ShowFiltered = new System.Windows.Forms.Button();
            this.cb_showdate = new System.Windows.Forms.CheckBox();
            this.cb_ShowHeavy = new System.Windows.Forms.CheckBox();
            this.cb_showByteDetail = new System.Windows.Forms.CheckBox();
            this.cb_Filter_PGN = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_Gzero_toJson
            // 
            this.btn_Gzero_toJson.Location = new System.Drawing.Point(12, 68);
            this.btn_Gzero_toJson.Name = "btn_Gzero_toJson";
            this.btn_Gzero_toJson.Size = new System.Drawing.Size(218, 109);
            this.btn_Gzero_toJson.TabIndex = 0;
            this.btn_Gzero_toJson.Text = "unpack groundZero";
            this.btn_Gzero_toJson.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(236, 68);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(689, 1541);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "blocks Read";
            // 
            // btn_makeText_fromJson
            // 
            this.btn_makeText_fromJson.Location = new System.Drawing.Point(1321, 87);
            this.btn_makeText_fromJson.Name = "btn_makeText_fromJson";
            this.btn_makeText_fromJson.Size = new System.Drawing.Size(172, 71);
            this.btn_makeText_fromJson.TabIndex = 4;
            this.btn_makeText_fromJson.Text = "Build TExt from JSON";
            this.btn_makeText_fromJson.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(1538, 54);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(1055, 1541);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // btn_ShowFiltered
            // 
            this.btn_ShowFiltered.Location = new System.Drawing.Point(1321, 218);
            this.btn_ShowFiltered.Name = "btn_ShowFiltered";
            this.btn_ShowFiltered.Size = new System.Drawing.Size(162, 109);
            this.btn_ShowFiltered.TabIndex = 6;
            this.btn_ShowFiltered.Text = "filtered load";
            this.btn_ShowFiltered.UseVisualStyleBackColor = true;
            // 
            // cb_showdate
            // 
            this.cb_showdate.AutoSize = true;
            this.cb_showdate.Location = new System.Drawing.Point(1017, 435);
            this.cb_showdate.Name = "cb_showdate";
            this.cb_showdate.Size = new System.Drawing.Size(155, 33);
            this.cb_showdate.TabIndex = 7;
            this.cb_showdate.Text = "show date";
            this.cb_showdate.UseVisualStyleBackColor = true;
            // 
            // cb_ShowHeavy
            // 
            this.cb_ShowHeavy.AutoSize = true;
            this.cb_ShowHeavy.Location = new System.Drawing.Point(1017, 498);
            this.cb_ShowHeavy.Name = "cb_ShowHeavy";
            this.cb_ShowHeavy.Size = new System.Drawing.Size(149, 33);
            this.cb_ShowHeavy.TabIndex = 8;
            this.cb_ShowHeavy.Text = "full format";
            this.cb_ShowHeavy.UseVisualStyleBackColor = true;
            // 
            // cb_showByteDetail
            // 
            this.cb_showByteDetail.AutoSize = true;
            this.cb_showByteDetail.Location = new System.Drawing.Point(1017, 568);
            this.cb_showByteDetail.Name = "cb_showByteDetail";
            this.cb_showByteDetail.Size = new System.Drawing.Size(174, 33);
            this.cb_showByteDetail.TabIndex = 9;
            this.cb_showByteDetail.Text = "Show Detail";
            this.cb_showByteDetail.UseVisualStyleBackColor = true;
            // 
            // cb_Filter_PGN
            // 
            this.cb_Filter_PGN.AutoSize = true;
            this.cb_Filter_PGN.Location = new System.Drawing.Point(1017, 681);
            this.cb_Filter_PGN.Name = "cb_Filter_PGN";
            this.cb_Filter_PGN.Size = new System.Drawing.Size(152, 33);
            this.cb_Filter_PGN.TabIndex = 10;
            this.cb_Filter_PGN.Text = "FilterPGN";
            this.cb_Filter_PGN.UseVisualStyleBackColor = true;
            // 
            // VC_PGNjsonGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2672, 1637);
            this.Controls.Add(this.cb_Filter_PGN);
            this.Controls.Add(this.cb_showByteDetail);
            this.Controls.Add(this.cb_ShowHeavy);
            this.Controls.Add(this.cb_showdate);
            this.Controls.Add(this.btn_ShowFiltered);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_makeText_fromJson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Gzero_toJson);
            this.Name = "VC_PGNjsonGUI";
            this.Text = "VC_PGNjsonGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Gzero_toJson;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_makeText_fromJson;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_ShowFiltered;
        private System.Windows.Forms.CheckBox cb_showdate;
        private System.Windows.Forms.CheckBox cb_ShowHeavy;
        private System.Windows.Forms.CheckBox cb_showByteDetail;
        private System.Windows.Forms.CheckBox cb_Filter_PGN;
    }
}