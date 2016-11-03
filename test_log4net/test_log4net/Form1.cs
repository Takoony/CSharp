using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.Reflection;

namespace test_log4net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error("error", new Exception("发生了一个异常"));
            log.Fatal("fatal", new Exception("发生了一个致命错误"));
            log.Info("info");
            log.Debug("debug");
            log.Warn("warn");
            Console.WriteLine("日志记录完毕。");
        }
    }
}
