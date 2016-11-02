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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                string sql_cmd = @"use [import_event]   select [LE_INDEX], [LE_title],[LE_volatility],[LE_reason],[LE_effect_date] from [LongEvent]";
                sda = new SqlDataAdapter(sql_cmd, con);
                sda.Fill(ds, "LongEvent");
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                this.dataGridView1.ColumnHeadersVisible = true;
                //this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = ds.Tables["LongEvent"];
                this.dataGridView1.Columns[0].HeaderText = "ID";
                this.dataGridView1.Columns[0].Width = 50;
                this.dataGridView1.Columns[0].DataPropertyName = ds.Tables[0].Columns[0].ToString();
                this.dataGridView1.Columns[1].HeaderText = "标题";
                this.dataGridView1.Columns[1].Width = 270;
                this.dataGridView1.Columns[1].DataPropertyName = ds.Tables[0].Columns[1].ToString();
                this.dataGridView1.Columns[2].HeaderText = "Vol";
                this.dataGridView1.Columns[2].Width = 50;
                this.dataGridView1.Columns[2].DataPropertyName = ds.Tables[0].Columns[2].ToString();
                this.dataGridView1.Columns[3].HeaderText = "理由";
                this.dataGridView1.Columns[3].Width = 270;
                this.dataGridView1.Columns[3].DataPropertyName = ds.Tables[0].Columns[3].ToString();
                this.dataGridView1.Columns[4].HeaderText = "日期";
                this.dataGridView1.Columns[4].Width = 120;
                this.dataGridView1.Columns[4].DataPropertyName = ds.Tables[0].Columns[4].ToString();

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
                    sda.Update(ds.Tables["LongEvent"]);
                    ds.Tables["LongEvent"].AcceptChanges();
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
            DataTable dt = ds.Tables["LongEvent"];
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
            sda.Update(ds.Tables["LongEvent"]);
        }
    }
}
