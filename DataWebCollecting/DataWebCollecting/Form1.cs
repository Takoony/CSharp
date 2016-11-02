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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbx_exchange.Hide();
            //tbx_symbol_name.Hide();
            cbx_source.Items.Add("CZCE");
            cbx_source.Items.Add("SHFE");
            cbx_source.Items.Add("DCE");
            cbx_source.Items.Add("CFFEX");
            cbx_source.Items.Add("CFTC");
            cbx_source.Items.Add("SINA");
            cbx_source.SelectedIndex =0;
            lbl_zhuyishixiang.Text= "cffex没有连续合约，只有目前正在交易的合约,\r\n" +
                "其他三个交易所，连续合约加上正在交易的合约";
        }

        private void cbx_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_exchange.Hide();
            tbx_symbol_name.Hide();
            cbx_data.Items.Clear();
            if(cbx_source.SelectedIndex==0)
            {
                cbx_data.Items.Add("持仓");
                cbx_data.Items.Add("仓单");
                tbx_symbol_name.Show();
            }
            else if(cbx_source.SelectedIndex==1)
            {
                cbx_data.Items.Add("持仓");
                cbx_data.Items.Add("仓单");
            }
            else if (cbx_source.SelectedIndex == 2)
            {
                cbx_data.Items.Add("持仓");
                cbx_data.Items.Add("仓单");
            }
            else if (cbx_source.SelectedIndex == 3)
            {
                cbx_data.Items.Add("持仓");
                cbx_data.Items.Add("仓单");
            }
            else if (cbx_source.SelectedIndex == 4)
            {
                cbx_data.Items.Add("持仓");
            }
            else 
            {
                cbx_data.Items.Add("价格");
                cbx_exchange.Items.Add("CZCE");
                cbx_exchange.Items.Add("DCE");
                cbx_exchange.Items.Add("SHFE");
                cbx_exchange.Items.Add("CFFEX");
                cbx_exchange.SelectedIndex = 0;
                cbx_exchange.Show();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbl_progress.Text = "";
            lbl_progress.Text = "数据正在获取中";
            string symbol = tbx_symbol.Text.ToString().Trim();
            string file_path = tbx_filepath.Text.ToString().Trim();
            //数据源索引,CZCE,CFTC
            int data_source_index = cbx_source.SelectedIndex;
            string data_source_chr = cbx_source.SelectedItem.ToString();

            //数据类型索引，比如仓单，数据
            int data_index = cbx_data.SelectedIndex;
            string data_chr = cbx_data.SelectedItem.ToString();
            string year = dtp_start.Value.Year.ToString();
            string month = "0" + dtp_start.Value.Month.ToString();
            month = month.Substring(month.Length - 2, 2);
            string day = "0" + dtp_start.Value.Day.ToString();
            day = day.Substring(day.Length - 2, 2);
            string start_date = year + "-" + month + "-" + day;
            year = dtp_over.Value.Year.ToString();
            month = "0" + dtp_over.Value.Month.ToString();
            month = month.Substring(month.Length - 2, 2);
            day = "0" + dtp_over.Value.Day.ToString();
            day = day.Substring(day.Length - 2, 2);
            string over_date = year + "-" + month + "-" + day;
            ///新浪价格数据
            if (data_source_index == 5&& data_index == 0)
            {
                SinaData sina_price = new SinaData();
                string exchange = cbx_exchange.SelectedItem.ToString();
                bool flag=sina_price.get_hst_data_from_url(exchange, symbol, start_date,over_date, file_path);
                if (flag) lbl_progress.Text = exchange+" "+symbol+"数据获取结束";
            }
            ///CZCE持仓数据
            else if(data_source_index==0&& data_index==0)
            {
                CZCE.CzceData czce_insterest = new CZCE.CzceData();
                //获取表格值
                //////////////////////////////////////////////////
                string tmp_start_day = start_date.Replace("-","");
                string tmp_end_day = over_date.Replace("-", "");
                string tmp_symbol = tbx_symbol.Text.ToString().TrimEnd().TrimStart();
                string tmp_symbol_name = tbx_symbol_name.Text.ToString().Trim();
                //////////////////////////////////////////////////
                if(czce_insterest.get_interest_data(tmp_start_day,tmp_end_day, tmp_symbol, tmp_symbol_name))
                {
                    lbl_progress.Text = "CZCE " + tmp_symbol_name + "数据获取结束";
                }
            }
        }
    }
}
