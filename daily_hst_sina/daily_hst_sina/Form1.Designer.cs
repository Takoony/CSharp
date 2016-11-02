namespace daily_hst_sina
{
    partial class hst_sina
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbb_exchanges = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtime_start = new System.Windows.Forms.DateTimePicker();
            this.dtime_over = new System.Windows.Forms.DateTimePicker();
            this.btn_search = new System.Windows.Forms.Button();
            this.tbx_symbols = new System.Windows.Forms.TextBox();
            this.lbl_exchanges = new System.Windows.Forms.Label();
            this.lbl_symbol = new System.Windows.Forms.Label();
            this.lbl_start = new System.Windows.Forms.Label();
            this.lbl_over = new System.Windows.Forms.Label();
            this.lbl_filepath = new System.Windows.Forms.Label();
            this.tbx_filepath = new System.Windows.Forms.TextBox();
            this.lbl_display = new System.Windows.Forms.Label();
            this.lbl_example1 = new System.Windows.Forms.Label();
            this.lbl_example2 = new System.Windows.Forms.Label();
            this.lbl_zhuyishixiang = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbb_exchanges
            // 
            this.cbb_exchanges.FormattingEnabled = true;
            this.cbb_exchanges.Location = new System.Drawing.Point(81, 10);
            this.cbb_exchanges.Name = "cbb_exchanges";
            this.cbb_exchanges.Size = new System.Drawing.Size(149, 20);
            this.cbb_exchanges.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 1;
            // 
            // dtime_start
            // 
            this.dtime_start.Location = new System.Drawing.Point(81, 141);
            this.dtime_start.Name = "dtime_start";
            this.dtime_start.Size = new System.Drawing.Size(149, 21);
            this.dtime_start.TabIndex = 4;
            // 
            // dtime_over
            // 
            this.dtime_over.Location = new System.Drawing.Point(81, 220);
            this.dtime_over.Name = "dtime_over";
            this.dtime_over.Size = new System.Drawing.Size(149, 21);
            this.dtime_over.TabIndex = 5;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(81, 347);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(149, 76);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // tbx_symbols
            // 
            this.tbx_symbols.Location = new System.Drawing.Point(81, 70);
            this.tbx_symbols.Name = "tbx_symbols";
            this.tbx_symbols.Size = new System.Drawing.Size(149, 21);
            this.tbx_symbols.TabIndex = 7;
            // 
            // lbl_exchanges
            // 
            this.lbl_exchanges.AutoSize = true;
            this.lbl_exchanges.Location = new System.Drawing.Point(24, 13);
            this.lbl_exchanges.Name = "lbl_exchanges";
            this.lbl_exchanges.Size = new System.Drawing.Size(53, 12);
            this.lbl_exchanges.TabIndex = 8;
            this.lbl_exchanges.Text = "exchange";
            // 
            // lbl_symbol
            // 
            this.lbl_symbol.AutoSize = true;
            this.lbl_symbol.Location = new System.Drawing.Point(24, 79);
            this.lbl_symbol.Name = "lbl_symbol";
            this.lbl_symbol.Size = new System.Drawing.Size(41, 12);
            this.lbl_symbol.TabIndex = 9;
            this.lbl_symbol.Text = "symbol";
            // 
            // lbl_start
            // 
            this.lbl_start.AutoSize = true;
            this.lbl_start.Location = new System.Drawing.Point(12, 147);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(65, 12);
            this.lbl_start.TabIndex = 10;
            this.lbl_start.Text = "start_date";
            // 
            // lbl_over
            // 
            this.lbl_over.AutoSize = true;
            this.lbl_over.Location = new System.Drawing.Point(12, 226);
            this.lbl_over.Name = "lbl_over";
            this.lbl_over.Size = new System.Drawing.Size(59, 12);
            this.lbl_over.TabIndex = 11;
            this.lbl_over.Text = "over_date";
            // 
            // lbl_filepath
            // 
            this.lbl_filepath.AllowDrop = true;
            this.lbl_filepath.AutoSize = true;
            this.lbl_filepath.Location = new System.Drawing.Point(16, 303);
            this.lbl_filepath.Name = "lbl_filepath";
            this.lbl_filepath.Size = new System.Drawing.Size(59, 12);
            this.lbl_filepath.TabIndex = 12;
            this.lbl_filepath.Text = "file_path";
            // 
            // tbx_filepath
            // 
            this.tbx_filepath.Location = new System.Drawing.Point(81, 294);
            this.tbx_filepath.Name = "tbx_filepath";
            this.tbx_filepath.Size = new System.Drawing.Size(149, 21);
            this.tbx_filepath.TabIndex = 13;
            // 
            // lbl_display
            // 
            this.lbl_display.AutoSize = true;
            this.lbl_display.Location = new System.Drawing.Point(81, 443);
            this.lbl_display.Name = "lbl_display";
            this.lbl_display.Size = new System.Drawing.Size(41, 12);
            this.lbl_display.TabIndex = 14;
            this.lbl_display.Text = "label2";
            // 
            // lbl_example1
            // 
            this.lbl_example1.AutoSize = true;
            this.lbl_example1.Location = new System.Drawing.Point(81, 106);
            this.lbl_example1.Name = "lbl_example1";
            this.lbl_example1.Size = new System.Drawing.Size(137, 12);
            this.lbl_example1.TabIndex = 15;
            this.lbl_example1.Text = "连续合约：品种+0,例SR0";
            // 
            // lbl_example2
            // 
            this.lbl_example2.AutoSize = true;
            this.lbl_example2.Location = new System.Drawing.Point(79, 126);
            this.lbl_example2.Name = "lbl_example2";
            this.lbl_example2.Size = new System.Drawing.Size(143, 12);
            this.lbl_example2.TabIndex = 16;
            this.lbl_example2.Text = "非连续合约:品种+4个数字";
            // 
            // lbl_zhuyishixiang
            // 
            this.lbl_zhuyishixiang.AutoSize = true;
            this.lbl_zhuyishixiang.Location = new System.Drawing.Point(83, 482);
            this.lbl_zhuyishixiang.Name = "lbl_zhuyishixiang";
            this.lbl_zhuyishixiang.Size = new System.Drawing.Size(41, 12);
            this.lbl_zhuyishixiang.TabIndex = 17;
            this.lbl_zhuyishixiang.Text = "label2";
            // 
            // hst_sina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(307, 532);
            this.Controls.Add(this.lbl_zhuyishixiang);
            this.Controls.Add(this.lbl_example2);
            this.Controls.Add(this.lbl_example1);
            this.Controls.Add(this.lbl_display);
            this.Controls.Add(this.tbx_filepath);
            this.Controls.Add(this.lbl_filepath);
            this.Controls.Add(this.lbl_over);
            this.Controls.Add(this.lbl_start);
            this.Controls.Add(this.lbl_symbol);
            this.Controls.Add(this.lbl_exchanges);
            this.Controls.Add(this.tbx_symbols);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dtime_over);
            this.Controls.Add(this.dtime_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_exchanges);
            this.Name = "hst_sina";
            this.Text = "hst_sina";
            this.Load += new System.EventHandler(this.hst_sina_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_exchanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtime_start;
        private System.Windows.Forms.DateTimePicker dtime_over;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox tbx_symbols;
        private System.Windows.Forms.Label lbl_exchanges;
        private System.Windows.Forms.Label lbl_symbol;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.Label lbl_over;
        private System.Windows.Forms.Label lbl_filepath;
        private System.Windows.Forms.TextBox tbx_filepath;
        private System.Windows.Forms.Label lbl_display;
        private System.Windows.Forms.Label lbl_example1;
        private System.Windows.Forms.Label lbl_example2;
        private System.Windows.Forms.Label lbl_zhuyishixiang;
    }
}

