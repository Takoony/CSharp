using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility;
namespace Cftc
{
    class OpenInterestStruct
    {
        string total;
        string producer_long;
        string producer_short;
        string swap_dealer_long;
        string swap_dealer_short;
        string swap_dealer_spreading;
        string managed_money_long;
        string managed_money_short;
        string managed_money_spreading;
        string others_long;
        string others_short;
        string others_spreading;

        public string ToString()
        {
            return total + "," + producer_long + "," + producer_short + "," + swap_dealer_long + "," + swap_dealer_short + "," + swap_dealer_spreading
                + "," + managed_money_long + "," + managed_money_short + "," + managed_money_spreading + "," + others_long + "," + others_short + "," + others_spreading;
        }
        public void set_value(List<string> ss)
        {
            if (ss.Count == 12)
            {
                total = ss[0];
                producer_long = ss[1];
                producer_short = ss[2];
                swap_dealer_long = ss[3];
                swap_dealer_short = ss[4];
                swap_dealer_spreading = ss[5];
                managed_money_long = ss[6];
                managed_money_short = ss[7];
                managed_money_spreading = ss[8];
                others_long = ss[9];
                others_short = ss[10];
                others_spreading = ss[11];
            }
        }
    }
    class InterestData
    {
        string symbol;
        string start_date;
        string over_date;
        List<string> open_interest_data;
        List<string> report_date_list;
       public void get_interest_data(string tmp_symbol,string tmp_start_date,string tmp_over_date)
        {
            List<string> data_collection = new List<string>();
            symbol = tmp_symbol;
            start_date = tmp_start_date;
            over_date = tmp_over_date;
            report_date_list = get_cftc_report_date(start_date, over_date);
            List<string> url_list = get_url_list(report_date_list);
            string tmp_data;
            for(int i=0;i<url_list.Count;i++)
            {
                tmp_data=get_effective_digit_from_url(url_list[i]);
                data_collection.Add(tmp_data);
            }
            open_interest_data= data_collection;

        }

        public string ToString()
        {
            string data_to_print="";
            for(int i=0;i<open_interest_data.Count;i++)
            {
                data_to_print += report_date_list[i] + "," + open_interest_data[i] + "\r\n";
            }
            return data_to_print;
        }
        public static List<string> get_url_list(List<string> tmp_list)
        {
            List<string> url_list = new List<string>();
            ///20090901开始公布新版本数据,即更为详细的数据
            string tmp_date = "";
            string year = "";
            string ddmmyy = "";
            string cftc_url_first = @"http://www.cftc.gov/files/dea/cotarchives/";
            string cftc_url_third = "/futures/ag_sf";
            string cftc_url_fifth = ".htm";
            string cftc_url_second = "";
            string url_all = "";
            string cftc_url_fouth = "";
            for (int i = 0; i < tmp_list.Count; i++)
            {
                if (String.Compare(tmp_list[i], "20090901") < 0) continue;
                tmp_date = tmp_list[i];
                year = tmp_date.Substring(0, 4);
                ddmmyy = tmp_date.Substring(4, 4) + tmp_date.Substring(2, 2);
                cftc_url_second = year;
                cftc_url_fouth = ddmmyy;
                url_all = cftc_url_first + cftc_url_second + cftc_url_third + cftc_url_fouth + cftc_url_fifth;
                url_list.Add(url_all);
            }

            return url_list;
        }

        public static List<string> get_cftc_report_date()
        {
            List<string> report_date_list = new List<string>();
            string url = "http://www.cftc.gov/MarketReports/CommitmentsofTraders/HistoricalViewable/index.htm";
            string str_web_content =U_web.get_web_content(url);
            string regex_pattern = "(href=\"){1}(ssLINK/){0,1}(cot){1}[0-9]{6}";
            Regex reg_instrument = new Regex(@"" + regex_pattern);
            MatchCollection mc_instrument = reg_instrument.Matches(str_web_content);
            Match mm = mc_instrument[0];
            string result = "";
            for (int i = 0; i < mc_instrument.Count; i++)
            {
                result += mc_instrument[i].Value;
            }


            string str_pattern_digit = @"[0-9]{6}";
            Regex regex_pattern_digit = new Regex(str_pattern_digit);
            MatchCollection remove_non_digit = regex_pattern_digit.Matches(result);
            //Match mm_digit = remove_non_digit[0];
            string tmp_str;
            for (int j = 0; j < remove_non_digit.Count; j++)
            {
                tmp_str = remove_non_digit[j].Value;
                tmp_str = "20" + tmp_str.Substring(4) + tmp_str.Substring(0, 4);
                report_date_list.Add(tmp_str);
            }
            report_date_list.Sort();
            return report_date_list;
        }


        public static List<string> get_cftc_report_date(string tmp_start_date,string tmp_over_date)
        {
            List<string> report_date_list = new List<string>();
            string url = "http://www.cftc.gov/MarketReports/CommitmentsofTraders/HistoricalViewable/index.htm";
            string str_web_content = U_web.get_web_content(url);
            string regex_pattern = "(href=\"){1}(ssLINK/){0,1}(cot){1}[0-9]{6}";
            Regex reg_instrument = new Regex(@"" + regex_pattern);
            MatchCollection mc_instrument = reg_instrument.Matches(str_web_content);
            Match mm = mc_instrument[0];
            string result = "";
            for (int i = 0; i < mc_instrument.Count; i++)
            {
                result += mc_instrument[i].Value;
            }


            string str_pattern_digit = @"[0-9]{6}";
            Regex regex_pattern_digit = new Regex(str_pattern_digit);
            MatchCollection remove_non_digit = regex_pattern_digit.Matches(result);
            //Match mm_digit = remove_non_digit[0];
            string tmp_str;
            for (int j = 0; j < remove_non_digit.Count; j++)
            {
                tmp_str = remove_non_digit[j].Value;
                tmp_str = "20" + tmp_str.Substring(4) + tmp_str.Substring(0, 4);
                if((String.Compare(tmp_str,tmp_start_date)>=0)&&String.Compare(tmp_str,tmp_over_date)<=0)
                  report_date_list.Add(tmp_str);
            }
            report_date_list.Sort();
            return report_date_list;
        }


        public static string get_effective_digit_from_url(string url)
        {
            List<string> res = new List<string>();
            ///第一次匹配，找出与品种相关的栏目,用开始与结束匹配出中间内容
            string data_web = U_web.get_web_content(url);
            string start = "CORN -";
            string over = "Disaggregated";
            string cxt = U_regex.GetValue(data_web, start, over);

            //第二次匹配,找出主要数据区间
            string regex_second_ctx = U_regex.GetValue(cxt, "Open Interest is", ": Changes from");

            //第三次匹配，找出数字与逗号
            string regex_digit = "[1-9]+([,]*[0-9]+)*";

            Regex regex_first = new Regex(@"" + regex_digit);
            MatchCollection match_collection = regex_first.Matches(regex_second_ctx);
            string ctx_digit = "";

            for (int j = 0; j < match_collection.Count; j++)
            {
                ctx_digit = match_collection[j].Value;

                res.Add(ctx_digit.Replace(",", ""));
            }
            OpenInterestStruct ois = new OpenInterestStruct();
            ois.set_value(res);
            return ois.ToString();
        }
    }
}
