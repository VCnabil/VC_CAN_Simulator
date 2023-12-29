namespace VC_CAN_Simulator.UIz.UControlz.Builders
{
    partial class CTRL_Builder_UC
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
            this.cb_CtrlType = new System.Windows.Forms.ComboBox();
            this.tb_min = new System.Windows.Forms.TextBox();
            this.tb_max = new System.Windows.Forms.TextBox();
            this.tb_DefDec = new System.Windows.Forms.TextBox();
            this.tb_indexLO = new System.Windows.Forms.TextBox();
            this.tb_indexHI = new System.Windows.Forms.TextBox();
            this.tb_group1 = new System.Windows.Forms.TextBox();
            this.tb_group2 = new System.Windows.Forms.TextBox();
            this.tb_remote1 = new System.Windows.Forms.TextBox();
            this.tb_remote2 = new System.Windows.Forms.TextBox();
            this.tb_remote3 = new System.Windows.Forms.TextBox();
            this.tb_remote4 = new System.Windows.Forms.TextBox();
            this.btn_rem = new System.Windows.Forms.Button();
            this.label_conflicts = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bitNamesList_uc1 = new VC_CAN_Simulator.UIz.UControlz.BitNamesList_uc();
            this.SuspendLayout();
            // 
            // cb_CtrlType
            // 
            this.cb_CtrlType.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cb_CtrlType.FormattingEnabled = true;
            this.cb_CtrlType.Location = new System.Drawing.Point(0, 3);
            this.cb_CtrlType.Margin = new System.Windows.Forms.Padding(0);
            this.cb_CtrlType.MaximumSize = new System.Drawing.Size(100, 0);
            this.cb_CtrlType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cb_CtrlType.Name = "cb_CtrlType";
            this.cb_CtrlType.Size = new System.Drawing.Size(100, 35);
            this.cb_CtrlType.TabIndex = 0;
            this.cb_CtrlType.Text = "8_bits";
            // 
            // tb_min
            // 
            this.tb_min.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_min.Location = new System.Drawing.Point(3, 40);
            this.tb_min.Margin = new System.Windows.Forms.Padding(0);
            this.tb_min.MaxLength = 4;
            this.tb_min.Name = "tb_min";
            this.tb_min.Size = new System.Drawing.Size(41, 36);
            this.tb_min.TabIndex = 3;
            this.tb_min.Text = "0";
            this.tb_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_max
            // 
            this.tb_max.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_max.Location = new System.Drawing.Point(44, 40);
            this.tb_max.Margin = new System.Windows.Forms.Padding(0);
            this.tb_max.MaxLength = 4;
            this.tb_max.Name = "tb_max";
            this.tb_max.Size = new System.Drawing.Size(50, 36);
            this.tb_max.TabIndex = 4;
            this.tb_max.Text = "255";
            this.tb_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_DefDec
            // 
            this.tb_DefDec.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_DefDec.Location = new System.Drawing.Point(24, 84);
            this.tb_DefDec.Margin = new System.Windows.Forms.Padding(0);
            this.tb_DefDec.MaxLength = 4;
            this.tb_DefDec.Name = "tb_DefDec";
            this.tb_DefDec.Size = new System.Drawing.Size(50, 36);
            this.tb_DefDec.TabIndex = 5;
            this.tb_DefDec.Text = "100";
            this.tb_DefDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_indexLO
            // 
            this.tb_indexLO.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_indexLO.Location = new System.Drawing.Point(3, 122);
            this.tb_indexLO.Margin = new System.Windows.Forms.Padding(0);
            this.tb_indexLO.MaxLength = 4;
            this.tb_indexLO.Name = "tb_indexLO";
            this.tb_indexLO.Size = new System.Drawing.Size(41, 36);
            this.tb_indexLO.TabIndex = 7;
            this.tb_indexLO.Text = "7";
            this.tb_indexLO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_indexHI
            // 
            this.tb_indexHI.Font = new System.Drawing.Font("Miriam CLM", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_indexHI.Location = new System.Drawing.Point(53, 122);
            this.tb_indexHI.Margin = new System.Windows.Forms.Padding(0);
            this.tb_indexHI.MaxLength = 4;
            this.tb_indexHI.Name = "tb_indexHI";
            this.tb_indexHI.Size = new System.Drawing.Size(41, 36);
            this.tb_indexHI.TabIndex = 8;
            this.tb_indexHI.Text = "7";
            this.tb_indexHI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_group1
            // 
            this.tb_group1.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_group1.Location = new System.Drawing.Point(0, 335);
            this.tb_group1.Name = "tb_group1";
            this.tb_group1.Size = new System.Drawing.Size(91, 32);
            this.tb_group1.TabIndex = 10;
            this.tb_group1.Text = "0,2,4,6";
            this.tb_group1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_group2
            // 
            this.tb_group2.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_group2.Location = new System.Drawing.Point(3, 373);
            this.tb_group2.Name = "tb_group2";
            this.tb_group2.Size = new System.Drawing.Size(91, 32);
            this.tb_group2.TabIndex = 11;
            this.tb_group2.Text = "1,3,5,7";
            this.tb_group2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_remote1
            // 
            this.tb_remote1.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_remote1.Location = new System.Drawing.Point(100, 431);
            this.tb_remote1.Name = "tb_remote1";
            this.tb_remote1.Size = new System.Drawing.Size(91, 32);
            this.tb_remote1.TabIndex = 12;
            this.tb_remote1.Text = "1,3,5,7";
            this.tb_remote1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_remote2
            // 
            this.tb_remote2.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_remote2.Location = new System.Drawing.Point(100, 469);
            this.tb_remote2.Name = "tb_remote2";
            this.tb_remote2.Size = new System.Drawing.Size(91, 32);
            this.tb_remote2.TabIndex = 13;
            this.tb_remote2.Text = "1,3,5,7";
            this.tb_remote2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_remote3
            // 
            this.tb_remote3.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_remote3.Location = new System.Drawing.Point(197, 431);
            this.tb_remote3.Name = "tb_remote3";
            this.tb_remote3.Size = new System.Drawing.Size(91, 32);
            this.tb_remote3.TabIndex = 14;
            this.tb_remote3.Text = "1,3,5,7";
            this.tb_remote3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_remote4
            // 
            this.tb_remote4.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_remote4.Location = new System.Drawing.Point(197, 469);
            this.tb_remote4.Name = "tb_remote4";
            this.tb_remote4.Size = new System.Drawing.Size(91, 32);
            this.tb_remote4.TabIndex = 15;
            this.tb_remote4.Text = "1,3,5,7";
            this.tb_remote4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_rem
            // 
            this.btn_rem.Font = new System.Drawing.Font("Miriam CLM", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_rem.Location = new System.Drawing.Point(407, 431);
            this.btn_rem.Name = "btn_rem";
            this.btn_rem.Size = new System.Drawing.Size(90, 66);
            this.btn_rem.TabIndex = 16;
            this.btn_rem.Text = "rem";
            this.btn_rem.UseVisualStyleBackColor = true;
            // 
            // label_conflicts
            // 
            this.label_conflicts.AutoSize = true;
            this.label_conflicts.Font = new System.Drawing.Font("Miriam CLM", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_conflicts.ForeColor = System.Drawing.Color.Red;
            this.label_conflicts.Location = new System.Drawing.Point(3, 405);
            this.label_conflicts.Name = "label_conflicts";
            this.label_conflicts.Size = new System.Drawing.Size(79, 23);
            this.label_conflicts.TabIndex = 17;
            this.label_conflicts.Text = "conflicts:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Miriam CLM", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(4, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 66);
            this.button1.TabIndex = 18;
            this.button1.Text = "validate groups ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bitNamesList_uc1
            // 
            this.bitNamesList_uc1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bitNamesList_uc1.Location = new System.Drawing.Point(100, 3);
            this.bitNamesList_uc1.Name = "bitNamesList_uc1";
            this.bitNamesList_uc1.Size = new System.Drawing.Size(400, 422);
            this.bitNamesList_uc1.TabIndex = 19;
            // 
            // CTRL_Builder_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bitNamesList_uc1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_conflicts);
            this.Controls.Add(this.btn_rem);
            this.Controls.Add(this.tb_remote4);
            this.Controls.Add(this.tb_remote3);
            this.Controls.Add(this.tb_remote2);
            this.Controls.Add(this.tb_remote1);
            this.Controls.Add(this.tb_group2);
            this.Controls.Add(this.tb_group1);
            this.Controls.Add(this.tb_indexHI);
            this.Controls.Add(this.tb_indexLO);
            this.Controls.Add(this.tb_DefDec);
            this.Controls.Add(this.tb_max);
            this.Controls.Add(this.tb_min);
            this.Controls.Add(this.cb_CtrlType);
            this.Name = "CTRL_Builder_UC";
            this.Size = new System.Drawing.Size(500, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_CtrlType;
        private System.Windows.Forms.TextBox tb_min;
        private System.Windows.Forms.TextBox tb_max;
        private System.Windows.Forms.TextBox tb_DefDec;
        private System.Windows.Forms.TextBox tb_indexLO;
        private System.Windows.Forms.TextBox tb_indexHI;
        private System.Windows.Forms.TextBox tb_group1;
        private System.Windows.Forms.TextBox tb_group2;
        private System.Windows.Forms.TextBox tb_remote1;
        private System.Windows.Forms.TextBox tb_remote2;
        private System.Windows.Forms.TextBox tb_remote3;
        private System.Windows.Forms.TextBox tb_remote4;
        private System.Windows.Forms.Button btn_rem;
        private System.Windows.Forms.Label label_conflicts;
        private System.Windows.Forms.Button button1;
        private BitNamesList_uc bitNamesList_uc1;
    }
}
