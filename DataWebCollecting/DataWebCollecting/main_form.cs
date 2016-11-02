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
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
        }

        private void btn_source_sina_Click(object sender, EventArgs e)
        {
            //this.Hide();
            SinaPrice sina_form = new SinaPrice();
            sina_form.Show();
        }

        private void btn_source_czce_Click(object sender, EventArgs e)
        {
            CzceForm czce_form = new CzceForm();
            czce_form.Show();
        }

        private void btn_source_cftc_Click(object sender, EventArgs e)
        {
            CftcForm cftc_form = new CftcForm();
            cftc_form.Show();
        }
    }
}
