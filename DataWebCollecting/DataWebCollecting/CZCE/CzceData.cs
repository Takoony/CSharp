using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility;
namespace CZCE
{
    class CzceData
    {
        List<OpenInterestID> open_insterest_data = new List<OpenInterestID>();
        ListOpenInterest loi = new ListOpenInterest();
        List<string> datas = new List<string>();
        List<string> trading_day_list;
        //要抓取的URL地址
        List<string> urls = new List<string>();
        string Url = "";
        string str_web_content;
        string first_url = "http://www.czce.com.cn/portal/DFSStaticFiles/Future/";
        string second_url = null;
        string third_url = "/FutureDataHolding.htm";
        /// <summary>
        /// 下面四个变量为外部参数
        /// </summary>
        string start_day = "";
        string end_day = "";
        string instrment = "";
        string symbol_name = "";

        public bool get_interest_data(string start_d,string end_d,string inst,string sym_name)
        {
            start_day = start_d;
            end_day = end_d;
            instrment = inst;
            symbol_name = sym_name;
            bool flag = false;
            string regex_instrument_first = "品种：";
            regex_instrument_first += symbol_name + instrment;
            string regex_symbol_first = "合约：" + instrment;
            string regex_instrument_end = "合计";
            string regex_symbol_end = "合计";
            string exchange = "CZCE";
            string main_symbol = instrment + "0";
            trading_day_list = U_datetime.get_tradingday_list_from_sina(exchange, main_symbol, start_day, end_day);
            string line_value = "";

            for (int ij = trading_day_list.Count - 1; ij > -1; ij--)
            {
                datas.Clear();
                string web_content_remove_tag = null;
                string instrument_regex_content = null;
                string symbol_regex_content = null;
                string year = trading_day_list[ij].Substring(0, 4);
                Url = first_url + year + "/" + trading_day_list[ij] + third_url;
                //Console.WriteLine(trading_day_list[ij]);
                str_web_content = U_web.get_web_content(Url);
                if (str_web_content == "") continue;
                //期货品种
                string pattern_instrument = regex_instrument_first + "[\\s\\S]*" + "(" + regex_instrument_end + ")";
                Regex reg_instrument = new Regex(@"" + pattern_instrument + "{1}");//{1}的作用只匹配第一个结尾匹配符
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
                    if (str_value.Contains(','))
                        str_value = str_value.Replace(",", "");
                    line_value += "__" + str_value;
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

                loi.save_list_open_interest(instrment + "_Members\\", trading_day_list[ij]);
               
            }
            //FileStream fs = new FileStream("trading_date.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter m_streamWriter = new StreamWriter(fs);
            //m_streamWriter.Flush();  // 使用StreamWriter来往文件中写入内容
            //m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);

            //m_streamWriter.Close();
            loi.save_member_list();
            flag = true;
            return true;
        }
       


    }
}
