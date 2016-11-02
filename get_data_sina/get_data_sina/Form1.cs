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
using System.Threading;
namespace get_data_sina
{
    public partial class Form1 : Form
    {
        Thread[] get_data_thread = new Thread[1];
        List<bar> bars = new List<bar>();
        public Form1()
        {
            InitializeComponent();
        }
        //此委托允许异步的调用为Listbox添加Item  
        delegate void AddItemCallback(string text);
        //这种方法演示如何在线程安全的模式下调用Windows窗体上的控件。  
        private void add_item(string text)
        {
            //前线程不是创建控件的线程时为true
            //简单的说，如果有两个线程，Thread A和Thread B，并且有一个Control c，是在Thread A里面new的。
            //那么在Thread A里面运行的任何方法调用c.InvokeRequired都会返回false。
            //相反，如果在Thread B里面运行的任何方法调用c.InvokeRequired都会返回true。
            //是否是UI线程与结果无关。（通常Control所在的线程是UI线程，但是可以有例外）
            //也可以认为，在new Control()的时候，control用一个变量记录下了当前线程，在调用InvokeRequired时，返回当前线程是否不等于new的时候记录下来的那个线程。
            if (this.listBox1.InvokeRequired)//跨线程
            {
                AddItemCallback d = new AddItemCallback(add_item);
                this.Invoke(d, new object[] { text });
                //Invoke指定用主线程中的控件去调用这个委托,相当于主线程来执行这个函数 
            }
            else//没有跨线程
            {
                this.listBox1.Items.Add(text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string start_date =txt_start_date.Text.ToString().TrimStart().TrimEnd();
            string end_date = txt_end_date.Text.ToString().TrimStart().TrimEnd();
            string filapath = txt_filename.Text.ToString().TrimStart().TrimEnd()+".txt";
            get_hst_data_from_url(start_date,end_date, filapath);
            label4.Text = "获取历史数据成功";
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
                MessageBox.Show("sina出错"+url);
            }
            return str_result;
        }

        public List<string> get_trading_day(string start_day, string end_day)
        {
            List<string> trading_day_list = new List<string>();
            FileStream fs = new FileStream("trading_day.txt", FileMode.Open, FileAccess.Read);
            //使用StreamReader类来读取文件
            StreamReader m_stream_reader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));
            m_stream_reader.BaseStream.Seek(0, SeekOrigin.Begin);
            string line = m_stream_reader.ReadLine();
            while (line != null)
            {
               // line = line.Replace("-", "");
                if (UtilityFun.compare_strings(line, start_day) && UtilityFun.compare_strings(end_day, line))
                {
                    trading_day_list.Add(line);
                }
                line = m_stream_reader.ReadLine();
            }

            return trading_day_list;
        }

        public string get_last_trading_day()
        {
            FileStream fs = new FileStream("G:\\data\\trading_date.txt", FileMode.Open, FileAccess.Read);
            //使用StreamReader类来读取文件
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string last_day = null;
            string line = m_streamReader.ReadLine();
            while (line != null)
            {
                last_day = line;
                line = m_streamReader.ReadLine();
            }
            m_streamReader.Close();
            return last_day;
        }

        public void get_data_from_url(string start_date,string end_date)
        {
            List<string> datas = new List<string>();
            //要抓取的URL地址
            List<string> urls = new List<string>();
            string first_url = "http://vip.stock.finance.sina.com.cn/q/view/vFutures_History.php?page=";
            string second_url = "1";
            string third_url_one = "&breed=SR0&start=";
            //string cur_date = DateTime.Now.ToString("yyyy-MM-dd");
            //string last_get_trading_date = get_last_trading_day();
            //start_date = last_get_trading_date;
            //end_date = cur_date;
            string third_url = third_url_one + start_date + "&end=" + end_date + "&jys=czce&pz=SR&hy=SR0&type=inner&name=%A1%E4%A8%AE%26%23182%3B11109";
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

            FileStream data_output = new FileStream(@"G:\data\sr\daily\86400.txt", FileMode.OpenOrCreate, FileAccess.Write);
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

            FileStream trading_date_output = new FileStream(@"G:\data\trading_date.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter trading_date_stream_writer = new StreamWriter(trading_date_output);
            trading_date_stream_writer.Flush();  // 使用StreamWriter来往文件中写入内容
            trading_date_stream_writer.BaseStream.Seek(0, SeekOrigin.End);
            for (int jj = bars.Count - 1; jj >= 0; jj--)
            {
                trading_date_stream_writer.WriteLine(bars[jj].date);
            }
            trading_date_stream_writer.Close();
        }

        public void get_hst_data_from_url(string start_date, string end_date,string filepath)
        {
            List<string> datas = new List<string>();
            //要抓取的URL地址
            List<string> urls = new List<string>();
            string first_url = "http://vip.stock.finance.sina.com.cn/q/view/vFutures_History.php?page=";
            string second_url = "1";
            string third_url_one = "&breed=SR0&start=";
            //string cur_date = DateTime.Now.ToString("yyyy-MM-dd");
            //string last_get_trading_date = get_last_trading_day();
            //start_date = last_get_trading_date;
            //end_date = cur_date;
            string third_url = third_url_one + start_date + "&end=" + end_date + "&jys=czce&pz=SR&hy=SR0&type=inner&name=%A1%E4%A8%AE%26%23182%3B11109";
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

            FileStream data_output = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (get_data_thread[0] == null)
            {
                get_data_thread[0] = new Thread(new ThreadStart(get_last_data));
                get_data_thread[0].Name = "get_data";
                get_data_thread[0].Start();
            }
        }

        public void get_last_data()
        {
            while (true)
            {
                string start_date = "2006-01-12";
                string end_date = "2016-05-11";
                string cur_date = DateTime.Now.ToString("yyyy-MM-dd");
                string last_get_trading_date = get_last_trading_day();
                start_date = last_get_trading_date;
                end_date = cur_date;
                if (end_date.CompareTo(start_date) == 1&&DateTime.Now.Hour>19&&DateTime.Now.Hour<24)
                {
                   // rtb_display.Text += "补充历史数据进入," + end_date + ",当前时间" + DateTime.Now.ToString() + "  ";
                    bars.Clear();
                    get_data_from_url(start_date, end_date);
                    string text = "新数据进入，插入当前时间：" + DateTime.Now.ToString();
                    add_item(text);
                }
            }
        }
    }
}
