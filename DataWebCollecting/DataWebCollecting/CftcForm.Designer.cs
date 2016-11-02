namespace DataWebCollecting
{
    partial class CftcForm
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
            this.lbl_symbol_list = new System.Windows.Forms.Label();
            this.lbl_start_date = new System.Windows.Forms.Label();
            this.cbx_symbol_list = new System.Windows.Forms.ComboBox();
            this.lbl_over_date = new System.Windows.Forms.Label();
            this.dtp_start_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_over_date = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.rtx_notice_log = new System.Windows.Forms.RichTextBox();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_symbol_list
            // 
            this.lbl_symbol_list.AutoSize = true;
            this.lbl_symbol_list.Location = new System.Drawing.Point(69, 67);
            this.lbl_symbol_list.Name = "lbl_symbol_list";
            this.lbl_symbol_list.Size = new System.Drawing.Size(29, 12);
            this.lbl_symbol_list.TabIndex = 0;
            this.lbl_symbol_list.Text = "品种";
            // 
            // lbl_start_date
            // 
            this.lbl_start_date.AutoSize = true;
            this.lbl_start_date.Location = new System.Drawing.Point(71, 146);
            this.lbl_start_date.Name = "lbl_start_date";
            this.lbl_start_date.Size = new System.Drawing.Size(53, 12);
            this.lbl_start_date.TabIndex = 1;
            this.lbl_start_date.Text = "开始时间";
            // 
            // cbx_symbol_list
            // 
            this.cbx_symbol_list.FormattingEnabled = true;
            this.cbx_symbol_list.Location = new System.Drawing.Point(167, 67);
            this.cbx_symbol_list.Name = "cbx_symbol_list";
            this.cbx_symbol_list.Size = new System.Drawing.Size(143, 20);
            this.cbx_symbol_list.TabIndex = 2;
            // 
            // lbl_over_date
            // 
            this.lbl_over_date.AutoSize = true;
            this.lbl_over_date.Location = new System.Drawing.Point(73, 235);
            this.lbl_over_date.Name = "lbl_over_date";
            this.lbl_over_date.Size = new System.Drawing.Size(53, 12);
            this.lbl_over_date.TabIndex = 3;
            this.lbl_over_date.Text = "结束时间";
            // 
            // dtp_start_date
            // 
            this.dtp_start_date.Location = new System.Drawing.Point(167, 146);
            this.dtp_start_date.Name = "dtp_start_date";
            this.dtp_start_date.Size = new System.Drawing.Size(143, 21);
            this.dtp_start_date.TabIndex = 4;
            // 
            // dtp_over_date
            // 
            this.dtp_over_date.Location = new System.Drawing.Point(167, 225);
            this.dtp_over_date.Name = "dtp_over_date";
            this.dtp_over_date.Size = new System.Drawing.Size(143, 21);
            this.dtp_over_date.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(71, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(285, 150);
            this.button1.TabIndex = 6;
            this.button1.Text = "一 本 万 利";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtx_notice_log
            // 
            this.rtx_notice_log.Location = new System.Drawing.Point(447, 83);
            this.rtx_notice_log.Name = "rtx_notice_log";
            this.rtx_notice_log.Size = new System.Drawing.Size(173, 163);
            this.rtx_notice_log.TabIndex = 7;
            this.rtx_notice_log.Text = "";
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(447, 66);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(29, 12);
            this.lbl_progress.TabIndex = 8;
            this.lbl_progress.Text = "进度";
            // 
            // CftcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 490);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.rtx_notice_log);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtp_over_date);
            this.Controls.Add(this.dtp_start_date);
            this.Controls.Add(this.lbl_over_date);
            this.Controls.Add(this.cbx_symbol_list);
            this.Controls.Add(this.lbl_start_date);
            this.Controls.Add(this.lbl_symbol_list);
            this.Name = "CftcForm";
            this.Text = "CftcForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_symbol_list;
        private System.Windows.Forms.Label lbl_start_date;
        private System.Windows.Forms.ComboBox cbx_symbol_list;
        private System.Windows.Forms.Label lbl_over_date;
        private System.Windows.Forms.DateTimePicker dtp_start_date;
        private System.Windows.Forms.DateTimePicker dtp_over_date;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtx_notice_log;
        private System.Windows.Forms.Label lbl_progress;
    }
}