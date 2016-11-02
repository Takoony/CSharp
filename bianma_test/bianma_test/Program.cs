using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bianma_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Encoding en = System.Text.Encoding.Default;
            string en = "湖大期货";
            string str = System.Text.Encoding.Default.EncodingName;
            Console.WriteLine(en);
            Console.WriteLine(str);
            log_helper.WriteLog(typeof(Program), "测试log4net");
            Console.ReadLine();

        }
    }
}
