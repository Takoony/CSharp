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

namespace Sina
{
    class SinaData
    {
        //string exchange = null;
        //string symbol = null;
        // string start_date;
        // string over_date;
        // string file_path;
        string fold_path = "SINA\\";
        List<SinaBar> bars = new List<SinaBar>();

        public bool get_hst_data_from_url(string exchange, string symbol, string start_date, string end_date, string filepath)
        {
            bars.Clear();
            List<string> datas = new List<string>();
            //要抓取的URL地址
            List<string> urls = new List<string>();
            string first_url = "http://vip.stock.finance.sina.com.cn/q/view/vFutures_History.php?page=";
            string second_url = "1";
            string pz = U_str.remove_digit_string(symbol);//静态函数使用方法一同于c++
            string third_url_one = "&breed=" + symbol + "&start=";
            //string cur_date = DateTime.Now.ToString("yyyy-MM-dd");
            //string last_get_trading_date = get_last_trading_day();
            //start_date = last_get_trading_date;
            //end_date = cur_date;
            string third_url = third_url_one + start_date + "&end=" + end_date + "&jys=" + exchange + "&pz=" + pz + "&hy=" + symbol + "&type=inner&name=%A1%E4%A8%AE%26%23182%3B11109";
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
                SinaBar b;
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
                        b = new SinaBar();
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

            if (!Directory.Exists(fold_path))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(fold_path); //新建文件夹   
            }
            FileStream data_output;
            if (File.Exists(filepath))
            {
                data_output = new FileStream(fold_path+filepath, FileMode.Append, FileAccess.Write);
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
                data_output = new FileStream(fold_path+filepath, FileMode.OpenOrCreate, FileAccess.Write);
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

            return true;
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
                MessageBox.Show("出错" + url);
            }
            return str_result;
        }
    }
}
