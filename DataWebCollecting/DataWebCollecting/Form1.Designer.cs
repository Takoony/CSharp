namespace DataWebCollecting
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_over = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_filepath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_source = new System.Windows.Forms.Label();
            this.cbx_source = new System.Windows.Forms.ComboBox();
            this.cbx_data = new System.Windows.Forms.ComboBox();
            this.lbl_data_item = new System.Windows.Forms.Label();
            this.lbl_symbol = new System.Windows.Forms.Label();
            this.tbx_symbol = new System.Windows.Forms.TextBox();
            this.lbl_zhuyishixiang = new System.Windows.Forms.Label();
            this.lbl_zysx2 = new System.Windows.Forms.Label();
            this.lbl_zysx3 = new System.Windows.Forms.Label();
            this.lbl_exchange = new System.Windows.Forms.Label();
            this.cbx_exchange = new System.Windows.Forms.ComboBox();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_symbol_name = new System.Windows.Forms.TextBox();
            this.lbl_zysx_path = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 65);
            this.button1.TabIndex = 9;
            this.button1.Text = "get";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(129, 238);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(200, 21);
            this.dtp_start.TabIndex = 6;
            // 
            // dtp_over
            // 
            this.dtp_over.Location = new System.Drawing.Point(128, 288);
            this.dtp_over.Name = "dtp_over";
            this.dtp_over.Size = new System.Drawing.Size(200, 21);
            this.dtp_over.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "开始";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束";
            // 
            // tbx_filepath
            // 
            this.tbx_filepath.Location = new System.Drawing.Point(128, 347);
            this.tbx_filepath.Name = "tbx_filepath";
            this.tbx_filepath.Size = new System.Drawing.Size(201, 21);
            this.tbx_filepath.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "保存路径";
            // 
            // lbl_source
            // 
            this.lbl_source.AutoSize = true;
            this.lbl_source.Location = new System.Drawing.Point(72, 43);
            this.lbl_source.Name = "lbl_source";
            this.lbl_source.Size = new System.Drawing.Size(53, 12);
            this.lbl_source.TabIndex = 7;
            this.lbl_source.Text = "数据来源";
            // 
            // cbx_source
            // 
            this.cbx_source.FormattingEnabled = true;
            this.cbx_source.Location = new System.Drawing.Point(136, 34);
            this.cbx_source.Name = "cbx_source";
            this.cbx_source.Size = new System.Drawing.Size(200, 20);
            this.cbx_source.TabIndex = 1;
            this.cbx_source.SelectedIndexChanged += new System.EventHandler(this.cbx_source_SelectedIndexChanged);
            // 
            // cbx_data
            // 
            this.cbx_data.FormattingEnabled = true;
            this.cbx_data.Location = new System.Drawing.Point(134, 77);
            this.cbx_data.Name = "cbx_data";
            this.cbx_data.Size = new System.Drawing.Size(200, 20);
            this.cbx_data.TabIndex = 2;
            // 
            // lbl_data_item
            // 
            this.lbl_data_item.AutoSize = true;
            this.lbl_data_item.Location = new System.Drawing.Point(86, 85);
            this.lbl_data_item.Name = "lbl_data_item";
            this.lbl_data_item.Size = new System.Drawing.Size(29, 12);
            this.lbl_data_item.TabIndex = 10;
            this.lbl_data_item.Text = "数据";
            // 
            // lbl_symbol
            // 
            this.lbl_symbol.AutoSize = true;
            this.lbl_symbol.Location = new System.Drawing.Point(57, 198);
            this.lbl_symbol.Name = "lbl_symbol";
            this.lbl_symbol.Size = new System.Drawing.Size(53, 12);
            this.lbl_symbol.TabIndex = 11;
            this.lbl_symbol.Text = "合约代码";
            // 
            // tbx_symbol
            // 
            this.tbx_symbol.Location = new System.Drawing.Point(131, 188);
            this.tbx_symbol.Name = "tbx_symbol";
            this.tbx_symbol.Size = new System.Drawing.Size(198, 21);
            this.tbx_symbol.TabIndex = 5;
            // 
            // lbl_zhuyishixiang
            // 
            this.lbl_zhuyishixiang.AutoSize = true;
            this.lbl_zhuyishixiang.Location = new System.Drawing.Point(843, 125);
            this.lbl_zhuyishixiang.Name = "lbl_zhuyishixiang";
            this.lbl_zhuyishixiang.Size = new System.Drawing.Size(41, 12);
            this.lbl_zhuyishixiang.TabIndex = 13;
            this.lbl_zhuyishixiang.Text = "label4";
            // 
            // lbl_zysx2
            // 
            this.lbl_zysx2.AutoSize = true;
            this.lbl_zysx2.Location = new System.Drawing.Point(841, 34);
            this.lbl_zysx2.Name = "lbl_zysx2";
            this.lbl_zysx2.Size = new System.Drawing.Size(167, 12);
            this.lbl_zysx2.TabIndex = 14;
            this.lbl_zysx2.Text = "SINA:连续合约：品种+0,例SR0";
            // 
            // lbl_zysx3
            // 
            this.lbl_zysx3.AutoSize = true;
            this.lbl_zysx3.Location = new System.Drawing.Point(843, 75);
            this.lbl_zysx3.Name = "lbl_zysx3";
            this.lbl_zysx3.Size = new System.Drawing.Size(173, 12);
            this.lbl_zysx3.TabIndex = 15;
            this.lbl_zysx3.Text = "SINA:非连续合约:品种+4个数字";
            // 
            // lbl_exchange
            // 
            this.lbl_exchange.AutoSize = true;
            this.lbl_exchange.Location = new System.Drawing.Point(62, 121);
            this.lbl_exchange.Name = "lbl_exchange";
            this.lbl_exchange.Size = new System.Drawing.Size(41, 12);
            this.lbl_exchange.TabIndex = 16;
            this.lbl_exchange.Text = "交易所";
            // 
            // cbx_exchange
            // 
            this.cbx_exchange.FormattingEnabled = true;
            this.cbx_exchange.Location = new System.Drawing.Point(134, 121);
            this.cbx_exchange.Name = "cbx_exchange";
            this.cbx_exchange.Size = new System.Drawing.Size(197, 20);
            this.cbx_exchange.TabIndex = 3;
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(72, 515);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(53, 12);
            this.lbl_progress.TabIndex = 18;
            this.lbl_progress.Text = "获取进度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "品种名称";
            // 
            // tbx_symbol_name
            // 
            this.tbx_symbol_name.Location = new System.Drawing.Point(136, 157);
            this.tbx_symbol_name.Name = "tbx_symbol_name";
            this.tbx_symbol_name.Size = new System.Drawing.Size(195, 21);
            this.tbx_symbol_name.TabIndex = 4;
            // 
            // lbl_zysx_path
            // 
            this.lbl_zysx_path.AutoSize = true;
            this.lbl_zysx_path.Location = new System.Drawing.Point(841, 160);
            this.lbl_zysx_path.Name = "lbl_zysx_path";
            this.lbl_zysx_path.Size = new System.Drawing.Size(101, 12);
            this.lbl_zysx_path.TabIndex = 20;
            this.lbl_zysx_path.Text = "SIAN路径保存需要";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 656);
            this.Controls.Add(this.lbl_zysx_path);
            this.Controls.Add(this.tbx_symbol_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.cbx_exchange);
            this.Controls.Add(this.lbl_exchange);
            this.Controls.Add(this.lbl_zysx3);
            this.Controls.Add(this.lbl_zysx2);
            this.Controls.Add(this.lbl_zhuyishixiang);
            this.Controls.Add(this.tbx_symbol);
            this.Controls.Add(this.lbl_symbol);
            this.Controls.Add(this.lbl_data_item);
            this.Controls.Add(this.cbx_data);
            this.Controls.Add(this.cbx_source);
            this.Controls.Add(this.lbl_source);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_filepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_over);
            this.Controls.Add(this.dtp_start);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "金潮投资";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_over;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_filepath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_source;
        private System.Windows.Forms.ComboBox cbx_source;
        private System.Windows.Forms.ComboBox cbx_data;
        private System.Windows.Forms.Label lbl_data_item;
        private System.Windows.Forms.Label lbl_symbol;
        private System.Windows.Forms.TextBox tbx_symbol;
        private System.Windows.Forms.Label lbl_zhuyishixiang;
        private System.Windows.Forms.Label lbl_zysx2;
        private System.Windows.Forms.Label lbl_zysx3;
        private System.Windows.Forms.Label lbl_exchange;
        private System.Windows.Forms.ComboBox cbx_exchange;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_symbol_name;
        private System.Windows.Forms.Label lbl_zysx_path;
    }
}

