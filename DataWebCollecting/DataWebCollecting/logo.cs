using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWebCollecting
{
    public partial class logo : Form
    {
        public logo()
        {
            InitializeComponent();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
           if(tbx_user.Text=="nyang"&&tbx_psd.Text=="888888")
            {
                this.Hide();
                MessageBox.Show("Welcome to 金潮投资Web数据系统");
                main_form main_form1 = new main_form();
                main_form1.Show();
            }
           else
            {
                MessageBox.Show("用户名与密码不对");
            }
        }
    }
}
