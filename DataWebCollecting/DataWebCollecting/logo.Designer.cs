namespace DataWebCollecting
{
    partial class logo
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
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_psd = new System.Windows.Forms.Label();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.tbx_psd = new System.Windows.Forms.TextBox();
            this.btn_log = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(82, 93);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(29, 12);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "user";
            // 
            // lbl_psd
            // 
            this.lbl_psd.AutoSize = true;
            this.lbl_psd.Location = new System.Drawing.Point(84, 138);
            this.lbl_psd.Name = "lbl_psd";
            this.lbl_psd.Size = new System.Drawing.Size(23, 12);
            this.lbl_psd.TabIndex = 1;
            this.lbl_psd.Text = "psd";
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(149, 93);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(100, 21);
            this.tbx_user.TabIndex = 2;
            // 
            // tbx_psd
            // 
            this.tbx_psd.Location = new System.Drawing.Point(149, 135);
            this.tbx_psd.Name = "tbx_psd";
            this.tbx_psd.PasswordChar = '*';
            this.tbx_psd.Size = new System.Drawing.Size(100, 21);
            this.tbx_psd.TabIndex = 3;
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(84, 197);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(75, 23);
            this.btn_log.TabIndex = 4;
            this.btn_log.Text = "登陆";
            this.btn_log.UseVisualStyleBackColor = true;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // logo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 339);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.tbx_psd);
            this.Controls.Add(this.tbx_user);
            this.Controls.Add(this.lbl_psd);
            this.Controls.Add(this.lbl_user);
            this.Name = "logo";
            this.Text = "金潮投资";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_psd;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.TextBox tbx_psd;
        private System.Windows.Forms.Button btn_log;
    }
}