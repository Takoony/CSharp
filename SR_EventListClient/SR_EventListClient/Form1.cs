using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SR_EventListClient
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        public Form1()
        {
            InitializeComponent();
           
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键 
            {
                form2.Form2_KeyDown(sender, e);//触发按钮事件 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //定义窗体大小
            Size s = new Size(1000, 550);
            TabPage tabPage2 = tabControl1.TabPages[0];
            //如果选项卡内的控件比较多，则可以添加一个Form控件，但是Form空间的TopLevel要设置为false
            
            form2.Name = "formpage";
            form2.TopLevel = false;
            //给Form去边框
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Size = s;
            //把page添加到tabPage中
            tabPage2.Controls.Add(form2);
            //在tabPage选项卡中显示出来
            form2.Show();

            TabPage tabPage3 = tabControl1.TabPages[1];
            //如果选项卡内的控件比较多，则可以添加一个Form控件，但是Form空间的TopLevel要设置为false
            
            form3.Name = "formpage";
            form3.TopLevel = false;
            //给Form去边框
            form3.FormBorderStyle = FormBorderStyle.None;
            form3.Size = s;
            //把page添加到tabPage中
            tabPage3.Controls.Add(form3);
            //在tabPage选项卡中显示出来
            form3.Show();
        }
    }
}




///问题1：无法通过enter键触发button1的click事件