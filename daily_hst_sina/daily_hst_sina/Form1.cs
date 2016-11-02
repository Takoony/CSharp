using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Utility;
namespace daily_hst_sina
{



    public partial class hst_sina : Form
    {
        string exchange = null;
        string symbol = null;
        string start_date;
        string over_date;
        string file_path;
        List<bar> bars = new List<bar>();
        public hst_sina()
        {
            InitializeComponent();
            ///注意事项
            lbl_zhuyishixiang.Text = "cffex没有连续合约，只有目前正在交易的合约,\r\n"+
                "其他三个交易所，连续合约加上正在交易的合约";
            //交易所
            cbb_exchanges.Items.Add("CFFEX");
            cbb_exchanges.Items.Add("SHFE");
            cbb_exchanges.Items.Add("DCE");
            cbb_exchanges.Items.Add("CZCE");
            cbb_exchanges.SelectedIndex = 3;
        }

        private void hst_sina_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            bars.Clear();
            lbl_display.Text = "正在获取历史数据";
            exchange = cbb_exchanges.SelectedItem.ToString();
            //合约品种
            symbol = tbx_symbols.Text.ToString().TrimStart().TrimEnd();
            //时间区间
            string year = dtime_start.Value.Year.ToString();
            string month = dtime_start.Value.Month.ToString();
            string day = dtime_start.Value.Day.ToString();
            start_date = year + "-" + month + "-" + day;
            year = dtime_over.Value.Year.ToString();
            month = "0"+dtime_over.Value.Month.ToString();
            month = month.Substring(month.Length -2 , 2);
            day = "0" + dtime_over.Value.Day.ToString();
            day = day.Substring(day.Length - 2, 2);
            over_date = year+ "-"+ month +"-"+ day;
            file_path = tbx_filepath.Text.ToString().TrimEnd().TrimStart();
            get_hst_data_from_url(exchange, symbol,start_date, over_date, file_path);
            lbl_display.Text = "获取历史数据成功";
        }


        public void get_hst_data_from_url(string exchange,string symbol,string start_date, string end_date, string filepath)
        {
            List<string> datas = new List<string>();
            //要抓取的URL地址
            List<string> urls = new List<string>();
            string first_url = "http://vip.stock.finance.sina.com.cn/q/view/vFutures_History.php?page=";
            string second_url = "1";
            string pz = UtilityFun.remove_digit_string(symbol);//静态函数使用方法一同于c++
            string third_url_one = "&breed="+symbol+"&start=";
            //string cur_date = DateTime.Now.ToString("yyyy-MM-dd");
            //string last_get_trading_date = get_last_trading_day();
            //start_date = last_get_trading_date;
            //end_date = cur_date;
            string third_url = third_url_one + start_date + "&end=" + end_date + "&jys="+exchange+"&pz="+ pz+ "&hy="+symbol+"&type=inner&name=%A1%E4%A8%AE%26%23182%3B11109";
            string url = first_url + second_url + third_url;
            //string Url = "http://vip.stock.finance.sina.com.cn/q/view/vFutures_History.php?page=1&breed=SR0&start=2006-01-12&end=2016-05-10&jys=czce&pz=SR&hy=SR0&type=inner&name=%A1%E4%A8%AE%26%23182%3B11109";
            string str_web_content = get_web_content(url);
            Regex reg = new Regex(@"共\s*(\d+)\s*页");
            Match match = reg.Match(str_web_content);
            string str_pages = match.Groups[1].Value.ToString();
            int page_count;
            if (str_pages == "") page_count = 1;
            else page_count = Int32.Parse(str_pages);
            //得到指定Url的源码
            for (int ij = 1; ij <= page_count; ij++)
            {
                url = first_url + ij.ToString() + third_url;
                str_web_content = get_web_content(url);
                datas.Clear();
                string str_value;
                bar b;
                Regex reg3 = new Regex(@">[0-9][0-9,.,-]*[0-9]*<");
                MatchCollection mc = reg3.Matches(str_web_content);
                foreach (Match m in mc)
                {
                    str_value = m.Value.TrimStart('>').TrimEnd('<');
                    datas.Add(str_value);
                }
                char[] chr_date = null;
                float f_close = 0.0f;
                float f_open = 0.0f;
                float f_high = 0.0f;
                float f_low = 0.0f;
                int f_vol = 0;
                for (int i = 0; i < datas.Count; i++)
                {

                    int j = (i + 1) % 6;
                    if (j == 1)
                    {
                        chr_date = datas[i].ToCharArray();
                    }
                    else if (j == 2)
                    {
                        f_close = float.Parse(datas[i]);
                    }
                    else if (j == 3)
                    {
                        f_open = float.Parse(datas[i]);
                    }
                    else if (j == 4)
                    {
                        f_high = float.Parse(datas[i]);
                    }
                    else if (j == 5)
                    {
                        f_low = float.Parse(datas[i]);
                    }
                    else
                    {
                        f_vol = int.Parse(datas[i]);
                        b = new bar();
                        b.date = chr_date;
                        b.close = f_close;
                        b.open = f_open;
                        b.high = f_high;
                        b.low = f_low;
                        b.volume = f_vol;
                        if (string.Concat(b.date) != start_date)
                            bars.Add(b);
                    }


                }
            }
            FileStream data_output;
            if (File.Exists(filepath))
            {
                data_output = new FileStream(filepath, FileMode.Append, FileAccess.Write);
                StreamWriter data_stream_writer = new StreamWriter(data_output);
                data_stream_writer.Flush();  // 使用StreamWriter来往文件中写入内容
                data_stream_writer.BaseStream.Seek(0, SeekOrigin.End);
                for (int jj = bars.Count - 1; jj >= 0; jj--)
                {
                    data_stream_writer.Write(bars[jj].date);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].open);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].high);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].low);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].close);
                    data_stream_writer.Write(" ");
                    data_stream_writer.WriteLine(bars[jj].volume);
                }
                data_stream_writer.Close();
            }
            else
            {
                data_output = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter data_stream_writer = new StreamWriter(data_output);
                data_stream_writer.Flush();  // 使用StreamWriter来往文件中写入内容
                data_stream_writer.BaseStream.Seek(0, SeekOrigin.End);
                data_stream_writer.Write("date");
                data_stream_writer.Write(" ");
                data_stream_writer.Write("open");
                data_stream_writer.Write(" ");
                data_stream_writer.Write("high");
                data_stream_writer.Write(" ");
                data_stream_writer.Write("low");
                data_stream_writer.Write(" ");
                data_stream_writer.Write("close");
                data_stream_writer.Write(" ");
                data_stream_writer.WriteLine("volume");
                for (int jj = bars.Count - 1; jj >= 0; jj--)
                {
                    data_stream_writer.Write(bars[jj].date);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].open);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].high);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].low);
                    data_stream_writer.Write(" ");
                    data_stream_writer.Write(bars[jj].close);
                    data_stream_writer.Write(" ");
                    data_stream_writer.WriteLine(bars[jj].volume);
                }
                data_stream_writer.Close();
            }
            
            
        }

        //根据Url地址得到网页的html源码
        private string get_web_content(string url)
        {
            string str_result = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //声明一个HttpWebRequest请求
                request.Timeout = 30000;
                //设置连接超时时间
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream_receive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("GB2312");
                StreamReader stream_reader = new StreamReader(stream_receive, encoding);
                str_result = stream_reader.ReadToEnd();
            }
            catch
            {
                MessageBox.Show("sina出错" + url);
            }
            return str_result;
        }
    }
}
