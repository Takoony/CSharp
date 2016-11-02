namespace DataWebCollecting
{
    partial class CzceForm
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
            this.tab_control_page_czce = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tab_page_warehouse_receipt = new System.Windows.Forms.TabPage();
            this.tab_control_page_czce.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_control_page_czce
            // 
            this.tab_control_page_czce.Controls.Add(this.tabPage1);
            this.tab_control_page_czce.Controls.Add(this.tab_page_warehouse_receipt);
            this.tab_control_page_czce.Location = new System.Drawing.Point(45, 42);
            this.tab_control_page_czce.Name = "tab_control_page_czce";
            this.tab_control_page_czce.SelectedIndex = 0;
            this.tab_control_page_czce.Size = new System.Drawing.Size(684, 469);
            this.tab_control_page_czce.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "持仓";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tab_page_warehouse_receipt
            // 
            this.tab_page_warehouse_receipt.Location = new System.Drawing.Point(4, 22);
            this.tab_page_warehouse_receipt.Name = "tab_page_warehouse_receipt";
            this.tab_page_warehouse_receipt.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_warehouse_receipt.Size = new System.Drawing.Size(676, 443);
            this.tab_page_warehouse_receipt.TabIndex = 1;
            this.tab_page_warehouse_receipt.Text = "仓单";
            this.tab_page_warehouse_receipt.UseVisualStyleBackColor = true;
            // 
            // CzceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 571);
            this.Controls.Add(this.tab_control_page_czce);
            this.Name = "CzceForm";
            this.Text = "CzceForm";
            this.Load += new System.EventHandler(this.CzceForm_Load);
            this.tab_control_page_czce.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_control_page_czce;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tab_page_warehouse_receipt;
    }
}