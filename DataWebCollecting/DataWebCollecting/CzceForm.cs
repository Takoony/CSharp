using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWebCollecting
{
    public partial class CzceForm : Form
    {
        public int[] s = { 0, 0 };
        public CzceForm()
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

        private void CzceForm_Load(object sender, EventArgs e)
        {
            try
            {
                //定义窗体大小
                Size s = new Size(670, 440);
                TabPage tab_page_first_form = tab_control_page_czce.TabPages[0];
                //如果选项卡内的控件比较多，则可以添加一个Form控件，但是Form空间的TopLevel要设置为false
                CzceInterest interest_form = new CzceInterest();
                interest_form.Name = "CzceOpenInterest";
                interest_form.TopLevel = false;
                //给Form去边框
                interest_form.FormBorderStyle = FormBorderStyle.None;
                interest_form.Size = s;
                //把page添加到tabPage中
                tab_page_first_form.Controls.Add(interest_form);
                //在tabPage选项卡中显示出来
                interest_form.Show();

                TabPage tab_page_second = tab_control_page_czce.TabPages[1];
                //如果选项卡内的控件比较多，则可以添加一个Form控件，但是Form空间的TopLevel要设置为false
                CzceWarehouseReceipt tap_page_second_form = new CzceWarehouseReceipt();
                tap_page_second_form.Name = "CzceWarehouseReceipt";
                tap_page_second_form.TopLevel = false;
                //给Form去边框
                tap_page_second_form.FormBorderStyle = FormBorderStyle.None;
                tap_page_second_form.Size = s;
                //把page添加到tabPage中
                tab_page_second.Controls.Add(tap_page_second_form);
                //在tabPage选项卡中显示出来
                tap_page_second_form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tab_control_page_czce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (s[tab_control_page_czce.SelectedIndex] == 0)    //只生成一次  
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
