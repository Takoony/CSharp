using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utility
{
    class U_datetime
    {
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string format_date(string date)
        {
            date = date.Insert(4, "-");
            date = date.Insert(7, "-");
            date = date.TrimEnd();
            return date;
        }

        /// <summary>
        /// 获取某个合约的某段时间的交易日
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="symbol"></param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <returns></returns>
        public static  List<string> get_tradingday_list_from_sina(string exchange, string symbol, string start_date, string end_date)
        {
            List<string> datas = new List<string>();
            List<string> trading_day_list = new List<string>();
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
            string str_web_content = U_web.get_web_content(url);
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
                str_web_content = U_web.get_web_content(url);
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
                        str_date = str_date.Replace("-", "");
                        trading_day_list.Add(str_date);
                    }
                }
            }
            return trading_day_list;
        }
    }
}
