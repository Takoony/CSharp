using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
public struct FutureTick
{
    public string time;
    public string symbol;
    public double price;
    public double buy_price1;
    public double buy_vol1;
    public double sell_price1;
    public double  sell_vol1;
    public int vol;
    public int open_interest;

}
namespace Console20160325
{
    class Program
    {
        const string fileName = "AppSettings.dat";
        const string ff = "a1703_20160328.bin";
        static void Main()
        {
            WriteDefaultValues();
            DisplayValues();
            Console.ReadKey();
        }

        public static void WriteDefaultValues()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(@"2014-05-05 01:01:02.900");
                //writer.Write(@"symbols");
               // writer.Write(@"66");
               // writer.Write(@"888888");
            }
        }

        public static void DisplayValues()
        {
            string tempDirectory="";
            string symbols;
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(ff, FileMode.Open)))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin); //将文件指针设置到文件开始
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        tempDirectory = reader.ReadInt64().ToString();
                    }
                       
                    //symbols = reader.ReadString();
                }
                Console.WriteLine("sr time is: " + tempDirectory);
               // Console.WriteLine("sr symbols is: " + symbols);
            }
        }
    }
}
