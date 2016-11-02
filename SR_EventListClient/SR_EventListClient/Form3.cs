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
    public partial class Form3 : Form
    {
        //创建数据库连接类的对象
        string connstr;
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter sda;
        public Form3()
        {
            InitializeComponent();
            connstr = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
            con = new SqlConnection(connstr);
            con.Open();
            ds = new DataSet();
            lv_long.GridLines = true;
            lv_long.FullRowSelect = true;
            lv_long.View = View.Details;
            lv_long.Scrollable = true;
            lv_long.MultiSelect = true;
            

            lv_short.GridLines = true;
            lv_short.FullRowSelect = true;
            lv_short.View = View.Details;
            lv_short.Scrollable = true;
            lv_short.MultiSelect = true;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //Graphics g = e.Graphics;
            //Image image = Image.FromFile(@"E:\photo\weapon\sword.png");
            //Rectangle rec = new Rectangle(new Point(500, 100), new Size(60, 90));
            //g.DrawImage(image, rec);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string start_yyyymmdd = dtp_start.Value.Year.ToString() + "-" + dtp_start.Value.Month.ToString() + "-" + dtp_start.Value.Day.ToString();
            string over_yyyymmdd = dtp_over.Value.Year.ToString() + "-" + dtp_over.Value.Month.ToString() + "-" + dtp_over.Value.Day.ToString();
            string sql_where = "";
            if (start_yyyymmdd == over_yyyymmdd)
                sql_where = "1=1";
            else
            {

                sql_where = @"LE_effect_date>='" + start_yyyymmdd + "' AND LE_effect_date<'" + over_yyyymmdd + "'";
            }
            if (con.State == ConnectionState.Open)
            {
                string sql_cmd_long = @"use [import_event]   select [LE_INDEX], [LE_title],[LE_volatility],[LE_reason],[LE_effect_date] from [LongEvent] where " + sql_where;
                sda = new SqlDataAdapter(sql_cmd_long, con);

                ds.Clear();
                sda.Fill(ds, "LongEvent");
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                lv_long.Clear();
                lv_long.Columns.Add("context", "内容");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tmp_str = dt.Rows[i][1].ToString();
                    ListViewItem lvi = new ListViewItem();        //首先创建一个ListView项item                    
                    lvi.Text = tmp_str;    //该项的文本
                    lv_long.Items.Add(lvi);
                    //lv_long.Columns["context"].Width = -1;//根据内容设置宽度
                    lv_long.Columns["context"].Width = 338;
                }


                if (start_yyyymmdd == over_yyyymmdd)
                    sql_where = "1=1";
                else
                {
                    sql_where =@"SE_effect_date>='" + start_yyyymmdd + "' AND SE_effect_date<'" + over_yyyymmdd + "'";
                    //sql_where =@ "' AND SE_effect_date<'" + over_yyyymmdd + "'";
                }
                string sql_cmd_short = @"use [import_event]   select [SE_INDEX], [SE_title],[SE_volatility],[SE_reason],[SE_effect_date] from [ShortEvent] where " + sql_where;
                sda = new SqlDataAdapter(sql_cmd_short, con);

                ///short
                //ds.Clear();
                sda.Fill(ds, "ShortEvent");
                DataTable dt2 = new DataTable();
                dt2 = ds.Tables[1];
                lv_short.Clear();
                lv_short.Columns.Add("context", "内容");
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    string tmp_str = dt2.Rows[i][1].ToString();
                    ListViewItem lvi = new ListViewItem();        //首先创建一个ListView项item                    
                    lvi.Text = tmp_str;    //该项的文本
                    lv_short.Items.Add(lvi);
                    
                   // lv_short.Columns[0].Width = -1;//根据内容设置宽度
                    lv_short.Columns[0].Width = 338;
                }

                //int coun = dataGridView1.RowCount;
                //for (int i = 0; i < coun - 1; i++)
                //{
                //    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                //    //dataGridView1.Rows[i].Cells["event_id"].Value = i + 1;
                //}
                //dataGridView1.Columns[0].HeaderText = "ID";
                //dataGridView1.Columns[0].Width = 30;
                //dataGridView1.Columns[0].DataPropertyName = ds.Tables[0].Columns[0].ToString();
                //dataGridView1.Columns[1].HeaderText = "标题";
                //dataGridView1.Columns[1].Width = 300;
                //dataGridView1.Columns[1].DataPropertyName = ds.Tables[0].Columns[1].ToString();
                //dataGridView1.Columns[2].HeaderText = "Vol";
                //dataGridView1.Columns[2].Width = 30;
                //dataGridView1.Columns[2].DataPropertyName = ds.Tables[0].Columns[2].ToString();
                //dataGridView1.Columns[3].HeaderText = "预期值";
                //dataGridView1.Columns[3].Width = 50;
                //dataGridView1.Columns[3].DataPropertyName = ds.Tables[0].Columns[3].ToString();
                //dataGridView1.Columns[4].HeaderText = "实际值";
                //dataGridView1.Columns[4].Width = 50;
                //dataGridView1.Columns[4].DataPropertyName = ds.Tables[0].Columns[4].ToString();
                //dataGridView1.Columns[5].HeaderText = "前值";
                //dataGridView1.Columns[5].Width = 50;
                //dataGridView1.Columns[5].DataPropertyName = ds.Tables[0].Columns[5].ToString();
                //dataGridView1.Columns[6].HeaderText = "开始时间";
                //dataGridView1.Columns[6].Width = 150;
                //dataGridView1.Columns[6].DataPropertyName = ds.Tables[0].Columns[6].ToString();
                //dataGridView1.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                //dataGridView1.Columns[7].HeaderText = "结束时间";
                //dataGridView1.Columns[7].Width = 150;
                //dataGridView1.Columns[7].DataPropertyName = ds.Tables[0].Columns[7].ToString();
                //dataGridView1.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }
        }
    }

}
