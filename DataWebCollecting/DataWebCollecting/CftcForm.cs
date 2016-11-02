using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cftc;
using System.IO;

namespace DataWebCollecting
{
    public partial class CftcForm : Form
    {
        public CftcForm()
        {
            InitializeComponent();
            cbx_symbol_list.Items.Add("CORN");
            cbx_symbol_list.Items.Add("WHEAT");
            cbx_symbol_list.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //获得品种名称
            string symbol = cbx_symbol_list.SelectedItem.ToString();


            /////////////////////////////////////////////////////
            //获得起始时间
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
            ///////////////////////////////////////////////////////
            //////////////进度条提示
            //rtx_notice_log.AppendText("正在获取"+ symbol.ToLower()+tmp_start_day + "-"+tmp_end_day +"之内的数据" );
            InterestData cftc_open_interest = new InterestData();
            cftc_open_interest.get_interest_data(symbol, tmp_start_day, tmp_end_day);
            string data = cftc_open_interest.ToString();

            string fold_path = "CFTC\\";
            string filepath = symbol.ToLower() + "_" + tmp_start_day + "_" + tmp_end_day + ".csv";

            if (!Directory.Exists(fold_path))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(fold_path); //新建文件夹   
            }

            string header = " Date,OpenInterest,ProducerLong,ProducerShort,SwapDealersLong,SwapDealersShort,SwapDealersSpreading,ManagedMoneyLong,ManagedMoneyShort,ManagedMoneySpreading,OtherLong,OtherShort,OtherSpreading\r\n";
            //FileStream fs = new FileStream(fold_path + filepath, FileMode.Append, FileAccess.Write);
            StreamWriter data_stream_writer = new StreamWriter(fold_path + filepath,false);

            data_stream_writer.Write(header+data);
            data_stream_writer.Close();
            rtx_notice_log.AppendText("结束获取" + symbol.ToLower() + tmp_start_day + "-" + tmp_end_day + "之内的数据");
        }
    }
}