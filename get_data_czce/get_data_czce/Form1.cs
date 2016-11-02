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
using Newtonsoft.Json;
//instrument 定义成品种代码
//symbol定义成代码
namespace get_data_czce
{
    public partial class Form1 : Form
    {
        List<OpenInterestID> open_insterest_data = new List<OpenInterestID>();
        ListOpenInterest loi = new ListOpenInterest();
        public Form1()
        {
            InitializeComponent();
            //string jsonText = @"{""input"" : ""value"", ""output"" : ""result""}";
            //JsonReader reader = new JsonTextReader(new StringReader(jsonText));
            label5.Text = "";
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label5.Text = "搜索数据开始";
            List<string> datas = new List<string>();
            List<string> trading_day_list;
            //要抓取的URL地址
            List<string> urls = new List<string>();
            string Url = "";
            string str_web_content;
            string first_url = "http://www.czce.com.cn/portal/DFSStaticFiles/Future/";
            string second_url = null;
            string third_url = "/FutureDataHolding.htm";

            //获取表格值
            ////////////////////////////////////////////////////
            string ipt_start_day =txt_startdate.Text.ToString().TrimEnd().TrimStart();
            string ipt_end_day = txt_overdate.Text.ToString().TrimEnd().TrimStart();
            string ipt_instrument = txt_instrument.Text.ToString().TrimEnd().TrimStart();
            string ipt_symbol_name = tbx_symbol_name.Text.ToString().Trim();
            //////////////////////////////////////////////////

            ///
            string start_day = ipt_start_day;
            string end_day = ipt_end_day;
            string instrment = ipt_instrument;
            string symbol_name = ipt_symbol_name;

            string regex_instrument_first = "品种：";
            regex_instrument_first+= symbol_name + instrment;
            string regex_symbol_first = "合约："+ instrment;
            string regex_instrument_end = "合计";
            string regex_symbol_end = "合计";
            string exchange = "CZCE";
            string main_symbol = instrment + "0";
            trading_day_list = get_tradingday_list_from_sina(exchange, main_symbol, start_day, end_day);
            string line_value = "";
            //得到指定Url的源码
            //FileStream output = new FileStream(symbol+"_openinterest.txt",FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter m_streamWriter1 = new StreamWriter(output, System.Text.Encoding.Default);
            //m_streamWriter1.Flush();  // 使用StreamWriter来往文件中写入内容
            //m_streamWriter1.BaseStream.Seek(0, SeekOrigin.Begin);
            // trading_day_list.Add("20160517");
            for (int ij = trading_day_list.Count-1; ij > -1; ij--)
            {
                datas.Clear();
                string web_content_remove_tag= null;
                string instrument_regex_content = null;
                string symbol_regex_content = null;
                string year = trading_day_list[ij].Substring(0, 4);
                Url = first_url + year+"/"+ trading_day_list[ij] + third_url;
                //Console.WriteLine(trading_day_list[ij]);
                str_web_content = get_web_content(Url);
                if (str_web_content == "") continue;
                //期货品种
                string pattern_instrument = regex_instrument_first + "[\\s\\S]*"+"("+ regex_instrument_end + ")";
                Regex reg_instrument = new Regex(@""+ pattern_instrument + "{1}");//{1}的作用只匹配第一个结尾匹配符
                MatchCollection mc_instrument = reg_instrument.Matches(str_web_content);
                Match mm = mc_instrument[0];
                instrument_regex_content = mm.Value;
                instrument_regex_content = instrument_regex_content.Substring(0, instrument_regex_content.IndexOf(regex_instrument_end));
                //datas.Clear();
                string str_value;
                Regex reg_remove_html_tag = new Regex(@">.*<");
                MatchCollection mc = reg_remove_html_tag.Matches(instrument_regex_content);
                
                foreach (Match m in mc)
                {
                    str_value = m.Value.TrimStart('>').TrimEnd('<');
                    if(str_value.Contains(','))
                       str_value = str_value.Replace(",","");
                    line_value += "__"+str_value;
                    datas.Add(str_value);
                    //string str = System.Text.Encoding.Default.EncodingName;
                }
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                datas.RemoveAt(0);
                loi.set_list_open_rank(datas);
                
                loi.save_list_open_rank(instrment, trading_day_list[ij]);
                loi.list_interest_from_rank();
                //string filepath2 = DateTime.Now.ToString("yyyyMMddhhmmss")+".txt";
                
                loi.save_list_open_interest(instrment+"_Members\\", trading_day_list[ij]);
            }
            //FileStream fs = new FileStream("trading_date.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter m_streamWriter = new StreamWriter(fs);
            //m_streamWriter.Flush();  // 使用StreamWriter来往文件中写入内容
            //m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);

            //m_streamWriter.Close();
            loi.save_member_list();
            //button1.Text = "get";
            label5.Text += "搜索数据结束\r\n";
        }

        //根据Url地址得到网页的html源码
        private string get_web_content(string Url)
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //声明一个HttpWebRequest请求
                request.Timeout = 30000;
                //设置连接超时时间
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("GB2312");
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                strResult = streamReader.ReadToEnd();
            }
            catch
            {
                //MessageBox.Show("CZCE出错");
                
            }
            return strResult;
        }

        //public List<string> get_trading_day(string start_day,string end_day)
        //{
        //    List<string> trading_day_list=new List<string>();
        //    FileStream fs = new FileStream(@"G:\data\trading_date.txt", FileMode.Open, FileAccess.Read);
        //    //使用StreamReader类来读取文件
        //    StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));
        //    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        //    string line = m_streamReader.ReadLine();
        //    while(line != null)
        //    {
        //        line = line.Replace("-", "");
        //        if (UtilityFun.compare_strings(line, start_day)&&UtilityFun.compare_strings(end_day,line))
        //        {
        //            trading_day_list.Add(line);
        //        }
        //        line = m_streamReader.ReadLine();
        //    }

        //    return trading_day_list;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="symbol">只能填写主力合约名，比如SR0</param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        public List<string> get_tradingday_list_from_sina(string exchange, string symbol, string start_date, string end_date)
        {
            List<string> datas = new List<string>();
            List<string> trading_day_list = new List<string>();
            //要抓取的URL地址
            List<string> urls = new List<string>();
            string first_url = "http://vip.stock.finance.sina.com.cn/q/view/vFutures_History.php?page=";
            string second_url = "1";
            string pz = UtilityFun.remove_digit_string(symbol);//静态函数使用方法一同于c++
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
                Regex reg3 = new Regex(@">[0-9][0-9,.,-]*[0-9]*<");
                MatchCollection mc = reg3.Matches(str_web_content);
                foreach (Match m in mc)
                {
                    str_value = m.Value.TrimStart('>').TrimEnd('<');
                    datas.Add(str_value);
                }
                char[] chr_date = null;
                for (int i = 0; i < datas.Count; i++)
                {

                    int j = (i + 1) % 6;
                    if (j == 1)
                    {
                        chr_date = datas[i].ToCharArray();
                        string str_date = new string(chr_date);
                        str_date = str_date.Replace("-","");
                        trading_day_list.Add(str_date);
                    }
                }       
            }
            return trading_day_list;
        }

    }
}
