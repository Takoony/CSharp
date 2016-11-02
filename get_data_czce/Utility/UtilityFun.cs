using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Utility
{
    public static class UtilityFun
    {
        public static  Boolean compare_strings(string one,string two)//one>=two true or false
        {
            int res = string.Compare(one, two);
            if (res >= 0) return true;
            else return false;
        }

        public static Boolean str_contains_num(string str)
        {
            for(int i=0;i<str.Length;i++)
            {
                if (char.IsDigit(str[i])) return true;
            }

            return false;
        }

        public static string remove_digit_string(string s)
        {
            string str = null;
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i])) str += s[i];
            }
            return str;
        }

        public static string remove_html_tag(string content,string replace_str)
        {
            string stroutput = content;
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");
            stroutput = regex.Replace(stroutput, replace_str);
            return stroutput;
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string format_date(string date)
        {
            date = date.Insert(4, "-");
            date = date.Insert(7,"-");
            date = date.TrimEnd();
            return date;
        }
    }
}
