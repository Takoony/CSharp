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
namespace SR_EventListServer
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
            //if (con.State == ConnectionState.Open)
            //{
            //    //MessageBox.Show("连接成功");
            //}
            //else
            //{
            //    con.Close();
            //}
        }

     
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                string sql_cmd = @"use [import_event]   select [EL_ID], [EL_title],[EL_volatility],[EL_previous],[EL_concesus],[EL_actual],[EL_effect_start_date]," +
                  "[EL_effect_over_date] from [EventList]";
                sda = new SqlDataAdapter(sql_cmd, con);

                
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
                dataGridView1.Columns[3].HeaderText = "前值";
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[3].DataPropertyName = ds.Tables[0].Columns[3].ToString();
                dataGridView1.Columns[4].HeaderText = "预期值";
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[4].DataPropertyName = ds.Tables[0].Columns[4].ToString();
                dataGridView1.Columns[5].HeaderText = "实际值";
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (ds.HasChanges())
            {
                try
                {
                    SqlCommandBuilder SCB = new SqlCommandBuilder(sda);
                    sda.UpdateCommand = SCB.GetUpdateCommand();
                    sda.InsertCommand = SCB.GetInsertCommand();
                    sda.Update(ds.Tables["EventList"]);
                    ds.Tables["EventList"].AcceptChanges();
                    MessageBox.Show("更新成功！", "操作结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "更新失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = ds.Tables["EventList"];
            if (dataGridView1.Rows.Count <= 0 ||
                dataGridView1.SelectedRows.Count <= 0) return;

            //定义一个数组保存所选中的行 
            int[] sel_rows = new int[dataGridView1.SelectedRows.Count];
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                sel_rows[i] = dataGridView1.SelectedRows[i].Index;
            }

            //根据数组选择所得到的行号删除数据表 
            for (int i = 0; i < sel_rows.Length; i++)
            {
                dt.Rows[sel_rows[i]].Delete();
            }
            SqlCommandBuilder SCB = new SqlCommandBuilder(sda);
            sda.UpdateCommand = SCB.GetUpdateCommand();
            sda.InsertCommand = SCB.GetInsertCommand();
            sda.DeleteCommand = SCB.GetDeleteCommand();
            sda.Update(ds.Tables["EventList"]);//用这句来更新数据数据，真正地删除掉(如果不删除数据里的资料就不用这条语句) 
    }
}
}
