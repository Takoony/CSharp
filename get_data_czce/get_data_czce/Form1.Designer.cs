namespace get_data_czce
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
            this.txt_instrument = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_startdate = new System.Windows.Forms.TextBox();
            this.txt_overdate = new System.Windows.Forms.TextBox();
            this.lbl_timeformat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_symbol_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "get_data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_instrument
            // 
            this.txt_instrument.Location = new System.Drawing.Point(70, 47);
            this.txt_instrument.Name = "txt_instrument";
            this.txt_instrument.Size = new System.Drawing.Size(100, 21);
            this.txt_instrument.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "instrument";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "start_date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "over_date";
            // 
            // txt_startdate
            // 
            this.txt_startdate.Location = new System.Drawing.Point(70, 85);
            this.txt_startdate.Name = "txt_startdate";
            this.txt_startdate.Size = new System.Drawing.Size(100, 21);
            this.txt_startdate.TabIndex = 5;
            // 
            // txt_overdate
            // 
            this.txt_overdate.Location = new System.Drawing.Point(70, 136);
            this.txt_overdate.Name = "txt_overdate";
            this.txt_overdate.Size = new System.Drawing.Size(100, 21);
            this.txt_overdate.TabIndex = 6;
            // 
            // lbl_timeformat
            // 
            this.lbl_timeformat.AutoSize = true;
            this.lbl_timeformat.Location = new System.Drawing.Point(176, 94);
            this.lbl_timeformat.Name = "lbl_timeformat";
            this.lbl_timeformat.Size = new System.Drawing.Size(107, 12);
            this.lbl_timeformat.TabIndex = 7;
            this.lbl_timeformat.Text = "时间格式:20160506";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "品牌代码，例如白糖就写SR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "品种名称";
            // 
            // tbx_symbol_name
            // 
            this.tbx_symbol_name.Location = new System.Drawing.Point(70, 10);
            this.tbx_symbol_name.Name = "tbx_symbol_name";
            this.tbx_symbol_name.Size = new System.Drawing.Size(100, 21);
            this.tbx_symbol_name.TabIndex = 11;
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 357);
            this.Controls.Add(this.tbx_symbol_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_timeformat);
            this.Controls.Add(this.txt_overdate);
            this.Controls.Add(this.txt_startdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_instrument);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_instrument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_startdate;
        private System.Windows.Forms.TextBox txt_overdate;
        private System.Windows.Forms.Label lbl_timeformat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_symbol_name;
    }
}

