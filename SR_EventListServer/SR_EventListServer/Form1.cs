using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace SR_EventListServer
{
    public partial class Form1 : Form
    {
        public int[] s = { 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }
        //在选项卡中生成窗体  
        public void GenerateForm(string form, object sender)
        {  
            // 反射生成窗体  
            Form fm = (Form)Assembly.GetExecutingAssembly().CreateInstance(form);  
            //设置窗体没有边框 加入到选项卡中  
            fm.FormBorderStyle = FormBorderStyle.None;  
            fm.TopLevel = false;  
            fm.Parent = ((TabControl)sender).SelectedTab;  
            fm.ControlBox = false;  
            fm.Dock = DockStyle.Fill;
            fm.BackColor = Color.Red;
            fm.Show();  
            s[((TabControl)sender).SelectedIndex] = 1;  
         }

        private void Form1_Load(object sender, EventArgs e)
        {
            //定义窗体大小
            Size s = new Size(1000,550);
            TabPage tabPage2 =tabControl1.TabPages[0];
            //如果选项卡内的控件比较多，则可以添加一个Form控件，但是Form空间的TopLevel要设置为false
            Form2 form2 = new Form2();
            form2.Name = "formpage";
            form2.TopLevel = false;
            //给Form去边框
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Size=s;
            //把page添加到tabPage中
            tabPage2.Controls.Add(form2);
            //在tabPage选项卡中显示出来
            form2.Show();

            TabPage tabPage3 = tabControl1.TabPages[1];
            //如果选项卡内的控件比较多，则可以添加一个Form控件，但是Form空间的TopLevel要设置为false
            Form3 form3= new Form3();
            form3.Name = "formpage";
            form3.TopLevel = false;
            //给Form去边框
            form3.FormBorderStyle = FormBorderStyle.None;
            form3.Size = s;
            //把page添加到tabPage中
            tabPage3.Controls.Add(form3);
            //在tabPage选项卡中显示出来
            form3.Show();

            TabPage tabPage4 = tabControl1.TabPages[2];
            //如果选项卡内的控件比较多，则可以添加一个Form控件，但是Form空间的TopLevel要设置为false
            Form4 form4 = new Form4();
            form4.Name = "formpage";
            form4.TopLevel = false;
            //给Form去边框
            form4.FormBorderStyle = FormBorderStyle.None;
            form4.Size = s;
            //把page添加到tabPage中
            tabPage4.Controls.Add(form4);
            //在tabPage选项卡中显示出来
            form4.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
       {  
           if(s[tabControl1.SelectedIndex]==0)    //只生成一次  
           {  
                btnX_Click(sender, e);  
           }  
        }  
  
        /// <summary>  
        /// 通用按钮点击选项卡 在选项卡上显示对应的窗体  
        /// </summary>  
        private void btnX_Click(object sender, EventArgs e)
        {  
            string formClass = ((TabControl)sender).SelectedTab.Tag.ToString();  
            //string form = tabControl1.SelectedTab.Tag.ToString();  
           GenerateForm(formClass, sender);  
 
        }   

    }
}
