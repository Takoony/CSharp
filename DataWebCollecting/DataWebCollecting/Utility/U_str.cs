using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Utility
{
    //U_代表辅助静态类
   /// <summary>
   /// 此类专门针对字符串
   /// </summary>
    public static class U_str
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

       
    }
}
