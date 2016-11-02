namespace DataWebCollecting
{
    partial class SinaPrice
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_symbol = new System.Windows.Forms.TextBox();
            this.tbx_filepath = new System.Windows.Forms.TextBox();
            this.cbx_exchanges = new System.Windows.Forms.ComboBox();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_over = new System.Windows.Forms.DateTimePicker();
            this.btn_search_data = new System.Windows.Forms.Button();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.lbl_zhuyishixiang = new System.Windows.Forms.Label();
            this.rtb_notice_progress = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "交易所";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "合约代码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "开始时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "结束时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "文件路径";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "格式：连续合约SR0，其他合约SR1701";
            // 
            // tbx_symbol
            // 
            this.tbx_symbol.Location = new System.Drawing.Point(179, 109);
            this.tbx_symbol.Name = "tbx_symbol";
            this.tbx_symbol.Size = new System.Drawing.Size(149, 21);
            this.tbx_symbol.TabIndex = 7;
            // 
            // tbx_filepath
            // 
            this.tbx_filepath.Location = new System.Drawing.Point(179, 294);
            this.tbx_filepath.Name = "tbx_filepath";
            this.tbx_filepath.Size = new System.Drawing.Size(139, 21);
            this.tbx_filepath.TabIndex = 8;
            // 
            // cbx_exchanges
            // 
            this.cbx_exchanges.FormattingEnabled = true;
            this.cbx_exchanges.Location = new System.Drawing.Point(179, 53);
            this.cbx_exchanges.Name = "cbx_exchanges";
            this.cbx_exchanges.Size = new System.Drawing.Size(149, 20);
            this.cbx_exchanges.TabIndex = 9;
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(179, 169);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(139, 21);
            this.dtp_start.TabIndex = 10;
            // 
            // dtp_over
            // 
            this.dtp_over.Location = new System.Drawing.Point(179, 237);
            this.dtp_over.Name = "dtp_over";
            this.dtp_over.Size = new System.Drawing.Size(139, 21);
            this.dtp_over.TabIndex = 11;
            // 
            // btn_search_data
            // 
            this.btn_search_data.Location = new System.Drawing.Point(79, 369);
            this.btn_search_data.Name = "btn_search_data";
            this.btn_search_data.Size = new System.Drawing.Size(239, 69);
            this.btn_search_data.TabIndex = 12;
            this.btn_search_data.Text = "招财进宝";
            this.btn_search_data.UseVisualStyleBackColor = true;
            this.btn_search_data.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(85, 511);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(41, 12);
            this.lbl_progress.TabIndex = 13;
            this.lbl_progress.Text = "......";
            // 
            // lbl_zhuyishixiang
            // 
            this.lbl_zhuyishixiang.AutoSize = true;
            this.lbl_zhuyishixiang.Location = new System.Drawing.Point(77, 499);
            this.lbl_zhuyishixiang.Name = "lbl_zhuyishixiang";
            this.lbl_zhuyishixiang.Size = new System.Drawing.Size(41, 12);
            this.lbl_zhuyishixiang.TabIndex = 14;
            this.lbl_zhuyishixiang.Text = "label7";
            // 
            // rtb_notice_progress
            // 
            this.rtb_notice_progress.Location = new System.Drawing.Point(393, 153);
            this.rtb_notice_progress.Name = "rtb_notice_progress";
            this.rtb_notice_progress.Size = new System.Drawing.Size(178, 171);
            this.rtb_notice_progress.TabIndex = 15;
            this.rtb_notice_progress.Text = "";
            // 
            // SinaPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 610);
            this.Controls.Add(this.rtb_notice_progress);
            this.Controls.Add(this.lbl_zhuyishixiang);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.btn_search_data);
            this.Controls.Add(this.dtp_over);
            this.Controls.Add(this.dtp_start);
            this.Controls.Add(this.cbx_exchanges);
            this.Controls.Add(this.tbx_filepath);
            this.Controls.Add(this.tbx_symbol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SinaPrice";
            this.Text = "SinaPrice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_symbol;
        private System.Windows.Forms.TextBox tbx_filepath;
        private System.Windows.Forms.ComboBox cbx_exchanges;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_over;
        private System.Windows.Forms.Button btn_search_data;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.Label lbl_zhuyishixiang;
        private System.Windows.Forms.RichTextBox rtb_notice_progress;
    }
}