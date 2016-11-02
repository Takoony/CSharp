namespace DataWebCollecting
{
    partial class main_form
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
            this.lbl_source_list = new System.Windows.Forms.Label();
            this.btn_source_sina = new System.Windows.Forms.Button();
            this.btn_source_czce = new System.Windows.Forms.Button();
            this.btn_source_cftc = new System.Windows.Forms.Button();
            this.btn_source_dce = new System.Windows.Forms.Button();
            this.btn_source_shfe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_source_list
            // 
            this.lbl_source_list.AutoSize = true;
            this.lbl_source_list.Location = new System.Drawing.Point(304, 21);
            this.lbl_source_list.Name = "lbl_source_list";
            this.lbl_source_list.Size = new System.Drawing.Size(65, 12);
            this.lbl_source_list.TabIndex = 0;
            this.lbl_source_list.Text = "数据源选择";
            // 
            // btn_source_sina
            // 
            this.btn_source_sina.Location = new System.Drawing.Point(64, 69);
            this.btn_source_sina.Name = "btn_source_sina";
            this.btn_source_sina.Size = new System.Drawing.Size(107, 28);
            this.btn_source_sina.TabIndex = 1;
            this.btn_source_sina.Text = "新  浪";
            this.btn_source_sina.UseVisualStyleBackColor = true;
            this.btn_source_sina.Click += new System.EventHandler(this.btn_source_sina_Click);
            // 
            // btn_source_czce
            // 
            this.btn_source_czce.Location = new System.Drawing.Point(206, 69);
            this.btn_source_czce.Name = "btn_source_czce";
            this.btn_source_czce.Size = new System.Drawing.Size(111, 27);
            this.btn_source_czce.TabIndex = 2;
            this.btn_source_czce.Text = "CZCE";
            this.btn_source_czce.UseVisualStyleBackColor = true;
            this.btn_source_czce.Click += new System.EventHandler(this.btn_source_czce_Click);
            // 
            // btn_source_cftc
            // 
            this.btn_source_cftc.Location = new System.Drawing.Point(631, 70);
            this.btn_source_cftc.Name = "btn_source_cftc";
            this.btn_source_cftc.Size = new System.Drawing.Size(111, 27);
            this.btn_source_cftc.TabIndex = 3;
            this.btn_source_cftc.Text = "CFTC";
            this.btn_source_cftc.UseVisualStyleBackColor = true;
            this.btn_source_cftc.Click += new System.EventHandler(this.btn_source_cftc_Click);
            // 
            // btn_source_dce
            // 
            this.btn_source_dce.Location = new System.Drawing.Point(340, 70);
            this.btn_source_dce.Name = "btn_source_dce";
            this.btn_source_dce.Size = new System.Drawing.Size(111, 27);
            this.btn_source_dce.TabIndex = 4;
            this.btn_source_dce.Text = "DCE";
            this.btn_source_dce.UseVisualStyleBackColor = true;
            // 
            // btn_source_shfe
            // 
            this.btn_source_shfe.Location = new System.Drawing.Point(478, 70);
            this.btn_source_shfe.Name = "btn_source_shfe";
            this.btn_source_shfe.Size = new System.Drawing.Size(111, 27);
            this.btn_source_shfe.TabIndex = 5;
            this.btn_source_shfe.Text = "SHFE";
            this.btn_source_shfe.UseVisualStyleBackColor = true;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 623);
            this.Controls.Add(this.btn_source_shfe);
            this.Controls.Add(this.btn_source_dce);
            this.Controls.Add(this.btn_source_cftc);
            this.Controls.Add(this.btn_source_czce);
            this.Controls.Add(this.btn_source_sina);
            this.Controls.Add(this.lbl_source_list);
            this.Name = "main_form";
            this.Text = "main_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_source_list;
        private System.Windows.Forms.Button btn_source_sina;
        private System.Windows.Forms.Button btn_source_czce;
        private System.Windows.Forms.Button btn_source_cftc;
        private System.Windows.Forms.Button btn_source_dce;
        private System.Windows.Forms.Button btn_source_shfe;
    }
}