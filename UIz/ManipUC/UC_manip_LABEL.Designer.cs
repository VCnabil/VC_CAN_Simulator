namespace VC_CAN_Simulator.UIz.ManipUC
{
    partial class UC_manip_LABEL
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
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.lbl_Bval = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.tlp_hori = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_def = new System.Windows.Forms.Label();
            this.tb_RawVAL = new System.Windows.Forms.TextBox();
            this.lbl_byteLOVal = new System.Windows.Forms.Label();
            this.lbl_byteHIVal = new System.Windows.Forms.Label();
            this.lbl_decVal = new System.Windows.Forms.Label();
            this.lbl_min = new System.Windows.Forms.Label();
            this.lbl_max = new System.Windows.Forms.Label();
            this.tlp_hori.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.AutoSize = true;
            this.lbl_Desc.Location = new System.Drawing.Point(99, 13);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(135, 29);
            this.lbl_Desc.TabIndex = 12;
            this.lbl_Desc.Text = "Description";
            this.lbl_Desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Bval
            // 
            this.lbl_Bval.AutoSize = true;
            this.lbl_Bval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lbl_Bval.Location = new System.Drawing.Point(3, 55);
            this.lbl_Bval.Name = "lbl_Bval";
            this.lbl_Bval.Size = new System.Drawing.Size(65, 29);
            this.lbl_Bval.TabIndex = 11;
            this.lbl_Bval.Text = "2556";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(3, 3);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(90, 49);
            this.btn_reset.TabIndex = 10;
            this.btn_reset.Text = "reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // tlp_hori
            // 
            this.tlp_hori.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_hori.ColumnCount = 4;
            this.tlp_hori.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_hori.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_hori.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_hori.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_hori.Controls.Add(this.lbl_def, 2, 0);
            this.tlp_hori.Controls.Add(this.tb_RawVAL, 1, 1);
            this.tlp_hori.Controls.Add(this.lbl_byteLOVal, 1, 2);
            this.tlp_hori.Controls.Add(this.lbl_byteHIVal, 3, 2);
            this.tlp_hori.Controls.Add(this.lbl_decVal, 1, 0);
            this.tlp_hori.Controls.Add(this.lbl_min, 0, 0);
            this.tlp_hori.Controls.Add(this.lbl_max, 3, 0);
            this.tlp_hori.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlp_hori.Location = new System.Drawing.Point(95, 75);
            this.tlp_hori.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_hori.Name = "tlp_hori";
            this.tlp_hori.RowCount = 3;
            this.tlp_hori.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_hori.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tlp_hori.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlp_hori.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_hori.Size = new System.Drawing.Size(400, 140);
            this.tlp_hori.TabIndex = 14;
            // 
            // lbl_def
            // 
            this.lbl_def.AutoSize = true;
            this.lbl_def.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_def.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbl_def.Location = new System.Drawing.Point(202, 1);
            this.lbl_def.Name = "lbl_def";
            this.lbl_def.Size = new System.Drawing.Size(92, 33);
            this.lbl_def.TabIndex = 18;
            this.lbl_def.Text = "0";
            this.lbl_def.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_RawVAL
            // 
            this.tlp_hori.SetColumnSpan(this.tb_RawVAL, 2);
            this.tb_RawVAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_RawVAL.Location = new System.Drawing.Point(103, 38);
            this.tb_RawVAL.MaxLength = 6;
            this.tb_RawVAL.Name = "tb_RawVAL";
            this.tb_RawVAL.Size = new System.Drawing.Size(191, 35);
            this.tb_RawVAL.TabIndex = 17;
            // 
            // lbl_byteLOVal
            // 
            this.lbl_byteLOVal.AutoSize = true;
            this.lbl_byteLOVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbl_byteLOVal.Location = new System.Drawing.Point(103, 115);
            this.lbl_byteLOVal.Name = "lbl_byteLOVal";
            this.lbl_byteLOVal.Size = new System.Drawing.Size(30, 22);
            this.lbl_byteLOVal.TabIndex = 14;
            this.lbl_byteLOVal.Text = "00";
            // 
            // lbl_byteHIVal
            // 
            this.lbl_byteHIVal.AutoSize = true;
            this.lbl_byteHIVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbl_byteHIVal.Location = new System.Drawing.Point(301, 115);
            this.lbl_byteHIVal.Name = "lbl_byteHIVal";
            this.lbl_byteHIVal.Size = new System.Drawing.Size(32, 22);
            this.lbl_byteHIVal.TabIndex = 15;
            this.lbl_byteHIVal.Text = "FF";
            // 
            // lbl_decVal
            // 
            this.lbl_decVal.AutoSize = true;
            this.lbl_decVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_decVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            this.lbl_decVal.Location = new System.Drawing.Point(103, 1);
            this.lbl_decVal.Name = "lbl_decVal";
            this.lbl_decVal.Size = new System.Drawing.Size(92, 33);
            this.lbl_decVal.TabIndex = 14;
            this.lbl_decVal.Text = "2556";
            this.lbl_decVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_min
            // 
            this.lbl_min.AutoSize = true;
            this.lbl_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbl_min.Location = new System.Drawing.Point(4, 1);
            this.lbl_min.Name = "lbl_min";
            this.lbl_min.Size = new System.Drawing.Size(92, 33);
            this.lbl_min.TabIndex = 11;
            this.lbl_min.Text = "0";
            this.lbl_min.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_max
            // 
            this.lbl_max.AutoSize = true;
            this.lbl_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbl_max.Location = new System.Drawing.Point(301, 1);
            this.lbl_max.Name = "lbl_max";
            this.lbl_max.Size = new System.Drawing.Size(95, 33);
            this.lbl_max.TabIndex = 12;
            this.lbl_max.Text = "1000";
            this.lbl_max.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UC_manip_LABEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_hori);
            this.Controls.Add(this.lbl_Desc);
            this.Controls.Add(this.lbl_Bval);
            this.Controls.Add(this.btn_reset);
            this.Name = "UC_manip_LABEL";
            this.Size = new System.Drawing.Size(500, 220);
            this.tlp_hori.ResumeLayout(false);
            this.tlp_hori.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Desc;
        private System.Windows.Forms.Label lbl_Bval;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TableLayoutPanel tlp_hori;
        private System.Windows.Forms.Label lbl_byteLOVal;
        private System.Windows.Forms.Label lbl_byteHIVal;
        private System.Windows.Forms.Label lbl_decVal;
        private System.Windows.Forms.Label lbl_min;
        private System.Windows.Forms.Label lbl_max;
        private System.Windows.Forms.TextBox tb_RawVAL;
        private System.Windows.Forms.Label lbl_def;
    }
}
