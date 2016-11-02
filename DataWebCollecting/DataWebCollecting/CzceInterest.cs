using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sina;
using CZCE;
using Utility;
namespace DataWebCollecting
{
    public partial class CzceInterest : Form
    {
        public CzceInterest()
        {
            InitializeComponent();
            lbl_progress.Text = "进度信息";
            cbx_data_class.Items.Add("持仓");
            cbx_data_class.Items.Add("仓单");
            cbx_data_class.SelectedIndex = 0;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
           
            //获取持仓数据
            if (cbx_data_class.SelectedIndex==0)
            {
                lbl_progress.Text = "";
                lbl_progress.Text = "持仓数据正在获取中";
                CZCE.CzceData czce_insterest = new CZCE.CzceData();
                //获取表格值
                //////////////////////////////////////////////////
                string year = dtp_start_date.Value.Year.ToString();
                string month = "0" + dtp_start_date.Value.Month.ToString();
                month = month.Substring(month.Length - 2, 2);
                string day = "0" + dtp_start_date.Value.Day.ToString();
                day = day.Substring(day.Length - 2, 2);
                string start_date = year + "-" + month + "-" + day;
                year = dtp_over_date.Value.Year.ToString();
                month = "0" + dtp_over_date.Value.Month.ToString();
                month = month.Substring(month.Length - 2, 2);
                day = "0" + dtp_over_date.Value.Day.ToString();
                day = day.Substring(day.Length - 2, 2);
                string over_date = year + "-" + month + "-" + day;
                string tmp_start_day = start_date.Replace("-", "");
                string tmp_end_day = over_date.Replace("-", "");
                string tmp_symbol = tbx_symbol.Text.ToString().TrimEnd().TrimStart();
                string tmp_symbol_name = tbx_symbol_name.Text.ToString().Trim();
                //////////////////////////////////////////////////
                if (czce_insterest.get_interest_data(tmp_start_day, tmp_end_day, tmp_symbol, tmp_symbol_name))
                {
                    lbl_progress.Text = "CZCE " + tmp_symbol_name + "数据获取结束";
                }
            }
        }
    }
}
