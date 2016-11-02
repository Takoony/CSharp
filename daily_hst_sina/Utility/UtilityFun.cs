using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

       public static string remove_digit_string(string s)
        {
            string str=null;
            for(int i=0;i<s.Length;i++)
            {
                if (!char.IsDigit(s[i])) str += s[i];
            }
            return str;
        }
    }
}
