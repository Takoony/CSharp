using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SR_EventListClient
{
    public partial class Form2 : Form
    {
        //创建数据库连接类的对象
        string connstr;
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter sda;
        public Form2()
        {
            InitializeComponent();
            connstr = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
            con = new SqlConnection(connstr);
            con.Open();
            ds = new DataSet();
            this.AcceptButton = button1;
        }

         public void Form2_KeyDown(object sender, KeyEventArgs e)

        {

            if (e.KeyCode == Keys.Enter)//判断回车键 
            {
                this.button1_Click(sender, e);//触发按钮事件 
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string start_yyyymmdd = dtp_start.Value.Year.ToString()+"-"+ dtp_start.Value.Month.ToString() + "-" + dtp_start.Value.Day.ToString();
            string over_yyyymmdd = dtp_over.Value.Year.ToString() + "-" + dtp_over.Value.Month.ToString() + "-" + dtp_over.Value.Day.ToString();
            string sql_where = "";
            if (start_yyyymmdd == over_yyyymmdd)
                sql_where = "1=0";
            else
            {

                // sql_where = @"EL_effect_start_date>='" + start_yyyymmdd + "' AND EL_effect_start_date<'" + over_yyyymmdd+"'";
                sql_where = @"  EL_effect_over_date<'" + start_yyyymmdd + "'or EL_effect_start_date>='"+ over_yyyymmdd + "'";
            }
            if (con.State == ConnectionState.Open)
            {
                string sql_cmd = @"use [import_event]   select [EL_ID], [EL_title],[EL_volatility],[EL_concesus],[EL_actual],[EL_previous],[EL_effect_start_date]," +
                  "[EL_effect_over_date] from [EventList] where [EL_ID] not in (select [EL_ID] from [EventList] where " + sql_where+ ") ";
                sda = new SqlDataAdapter(sql_cmd, con);

                ds.Clear();
                sda.Fill(ds, "EventList");
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dataGridView1.DataSource = ds.Tables["EventList"];

                //int coun = dataGridView1.RowCount;
                //for (int i = 0; i < coun - 1; i++)
                //{
                //    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                //    //dataGridView1.Rows[i].Cells["event_id"].Value = i + 1;
                //}
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[0].DataPropertyName = ds.Tables[0].Columns[0].ToString();
                dataGridView1.Columns[1].HeaderText = "标题";
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[1].DataPropertyName = ds.Tables[0].Columns[1].ToString();
                dataGridView1.Columns[2].HeaderText = "Vol";
                dataGridView1.Columns[2].Width = 30;
                dataGridView1.Columns[2].DataPropertyName = ds.Tables[0].Columns[2].ToString();
                dataGridView1.Columns[3].HeaderText = "预期值";
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[3].DataPropertyName = ds.Tables[0].Columns[3].ToString();
                dataGridView1.Columns[4].HeaderText = "实际值";
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[4].DataPropertyName = ds.Tables[0].Columns[4].ToString();
                dataGridView1.Columns[5].HeaderText = "前值";
                dataGridView1.Columns[5].Width = 50;
                dataGridView1.Columns[5].DataPropertyName = ds.Tables[0].Columns[5].ToString();
                dataGridView1.Columns[6].HeaderText = "开始时间";
                dataGridView1.Columns[6].Width = 150;
                dataGridView1.Columns[6].DataPropertyName = ds.Tables[0].Columns[6].ToString();
                dataGridView1.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                dataGridView1.Columns[7].HeaderText = "结束时间";
                dataGridView1.Columns[7].Width = 150;
                dataGridView1.Columns[7].DataPropertyName = ds.Tables[0].Columns[7].ToString();
                dataGridView1.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                // dataGridView1.Columns[7].HeaderText = "插入时间";
                // dataGridView1.Columns[7].Width = 110;
                // dataGridView1.Columns[7].DataPropertyName = ds.Tables[0].Columns[7].ToString();
            }
        }
    }
}
