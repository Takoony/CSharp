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
using Utility;

namespace DataWebCollecting
{
    public partial class SinaPrice : Form
    {
        List<string> exchange_list = new List<string>();
        List<string> cffex_list = new List<string>();
        List<string> czce_list = new List<string>();
        List<string> dce_list = new List<string>();
        List<string> shfe_list = new List<string>();
        public SinaPrice()
        {
            InitializeComponent();
            //交易所
            cbx_exchanges.Items.Add("CFFEX");
            cbx_exchanges.Items.Add("SHFE");
            cbx_exchanges.Items.Add("DCE");
            cbx_exchanges.Items.Add("CZCE");
            cbx_exchanges.Items.Add("ALL");
            cbx_exchanges.SelectedIndex = 3;
            lbl_zhuyishixiang.Text = "cffex没有连续合约，只有目前正在交易的合约,\r\n" +
                "其他三个交易所，连续合约加上正在交易的合约";
            exchange_list.Add("CFFEX");
            cffex_list.Add("IF");
            cffex_list.Add("IH");
            cffex_list.Add("IC");


            exchange_list.Add("SHFE");
            shfe_list.Add("CU");
            shfe_list.Add("AL");
            shfe_list.Add("ZN");
            shfe_list.Add("PB");
            shfe_list.Add("AU");
            shfe_list.Add("AG");
            shfe_list.Add("RB");
            shfe_list.Add("WR");
            shfe_list.Add("FU");
            shfe_list.Add("RU");

            exchange_list.Add("DCE");
            dce_list.Add("C");
            dce_list.Add("A");
            dce_list.Add("B");
            dce_list.Add("M");
            dce_list.Add("Y");
            dce_list.Add("P");
            dce_list.Add("L");
            dce_list.Add("V");
            dce_list.Add("J");
            dce_list.Add("JM");

            exchange_list.Add("CZCE");
            czce_list.Add("WH");
            //czce_list.Add("PM");//新浪没有数据
            czce_list.Add("CF");
            czce_list.Add("SR");
            czce_list.Add("TA");
            czce_list.Add("OI");
            czce_list.Add("RI");
            czce_list.Add("MA");
            czce_list.Add("FG");
            czce_list.Add("RS");
            czce_list.Add("RM");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbl_progress.Text = "";
            lbl_progress.Text = "数据正在获取中";
            string symbol = tbx_symbol.Text.ToString().Trim();
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
            string file_path = tbx_filepath.Text.ToString().Trim();

            SinaData sina_price = new SinaData();
            string exchange = cbx_exchanges.SelectedItem.ToString();
            if (exchange == "ALL")
            {
                tbx_symbol.Enabled = false;
                for(int i=0;i<exchange_list.Count;i++)
                {
                    if(exchange_list[i]=="CFFEX")
                    {
                        for(int i1=0;i1<cffex_list.Count;i1++)
                        {
                            symbol = cffex_list[i1]+"0";
                            file_path = symbol + "_" + start_date + "" + over_date + ".txt";
                           // bool flag = sina_price.get_hst_data_from_url(exchange, symbol, start_date, over_date, file_path);
                           // if (flag) rtb_notice_progress.AppendText(exchange + " " + symbol + "数据获取结束\r\n");
                        }
                        
                    }
                    else if(exchange_list[i]=="SHFE")
                    {
                        for (int i2 = 0; i2 < shfe_list.Count; i2++)
                        {
                            symbol = shfe_list[i2] + "0";
                            file_path = symbol + "_" + start_date.Replace("-","") + "_" + over_date.Replace("-", "") + ".txt";
                            bool flag = sina_price.get_hst_data_from_url(exchange, symbol, start_date, over_date, file_path);
                            if (flag) rtb_notice_progress.AppendText( exchange + " " + symbol + "数据获取结束\r\n");
                        }
                    }
                    else if (exchange_list[i] == "DCE")
                    {
                        for (int i3 = 0; i3 < dce_list.Count; i3++)
                        {
                            symbol = dce_list[i3] + "0";
                            file_path = symbol + "_" + start_date.Replace("-", "") + "_" + over_date.Replace("-", "") + ".txt";
                            bool flag = sina_price.get_hst_data_from_url(exchange, symbol, start_date, over_date, file_path);
                            if (flag) rtb_notice_progress.AppendText(exchange + " " + symbol + "数据获取结束\r\n");
                        }
                    }
                    else
                    {
                        for (int i4 = 0; i4 < czce_list.Count; i4++)
                        {
                            symbol = czce_list[i4] + "0";
                            file_path=symbol+"_"+ start_date.Replace("-", "") + "_" + over_date.Replace("-", "") + ".txt";
                            bool flag = sina_price.get_hst_data_from_url(exchange, symbol, start_date, over_date, file_path);
                            if (flag) rtb_notice_progress.AppendText(exchange + " " + symbol + "数据获取结束\r\n");
                        }
                    }
                }
            } 
            else
            {
                file_path = symbol + "_" + start_date.Replace("-", "") + "_" + over_date.Replace("-", "") + ".txt";
                bool flag = sina_price.get_hst_data_from_url(exchange, symbol, start_date, over_date, file_path);
                if (flag) rtb_notice_progress.AppendText(exchange + " " + symbol + "数据获取结束\r\n");
            }

            rtb_notice_progress.AppendText( "所需数据获取结束\r\n");
        }
    }
}
