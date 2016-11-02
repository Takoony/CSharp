using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace CZCE
{
    public class OpenInterestID
    {
        public string id;//序列号
        public int buy;//持买仓量
        public int change_buy;
        public int sell;//持卖仓量
        public int change_sell;
        public int vol;//交易量
        public int change_vol;
        public string trading_day;//交易日
        public string member;//会员名称
        public string insert_datetime;//数据插入时间
    }

    public class OpenInterestRankColumn
    {
        public string rank;
        public string abbreviation_member_vol;
        public string vol;
        public string change_vol;
        public string abbreviation_member_buy;
        public string hold_buy_vol;
        public string change_hold_buy;
        public string abbreviation_member_sell;
        public string hold_sell_vol;
        public string change_hold_sell;
    }

    public class ListOpenInterest
    {
        public ListOpenInterest()
        {
            list_open_interest = new List<OpenInterestID>();
            list_open_rank = new List<OpenInterestRankColumn>();
            ids = new List<member_id>();
            m_ids = new ListMember();
        }
        public List<OpenInterestID> list_open_interest;
        public List<OpenInterestRankColumn> list_open_rank;
        public List<member_id> ids;
        ListMember m_ids;
        public void get_list_member()
        {
            StreamReader sr = new StreamReader("members_id.json", Encoding.UTF8);
            String line;
            string str = "";
            while ((line = sr.ReadLine()) != null)
            {
                str += line;
            }
            sr.Close();
            if (str == "")
                ids = new List<member_id>();
            else
                ids = JsonConvert.DeserializeObject<List<member_id>>(str);
            m_ids.members = ids;
        }

        public string get_file_name(string name)
        {
            string filename = "";
            int pos = exist_list_member(name);
            if (pos < 0)
            {
                add_new_member_list(name);
                filename = ids[ids.Count - 1].id + ".csv";
            }
            else
            {
                filename = ids[pos].id + ".csv";
            }
            return filename;
        }
        public int exist_list_member(string name)
        {
            int flag = -1;
            if (ids != null)
                for (int i = 0; i < ids.Count; i++)
                {
                    if (ids[i].name == name)
                    {
                        flag = i;
                    }
                }
            return flag;
        }
        public void add_new_member_list(string name)
        {
            member_id mi = new member_id();
            if (ids == null && ids.Count == 0)
            {
                ids = new List<member_id>();

            }
            else if (ids.Count == 0)
            {
                //第一个会员ID
                mi.id = 1001.ToString();
            }
            else
            {
                mi.id = (int.Parse(ids[ids.Count - 1].id) + 1).ToString();
            }

            mi.name = name;
            ids.Add(mi);
        }

        public void save_member_list()
        {
            string ss = JsonConvert.SerializeObject(ids);
            FileStream fs = new FileStream("members_id.json", FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(ss);
            sw.Close();
            fs.Close();
        }
        public int exist_id_list_open_interest(string str)
        {
            int position = -1;
            for (int i = 0; i < list_open_interest.Count; i++)
            {
                if (list_open_interest[i].member.ToString() == str)
                {
                    position = i;
                }
            }
            return position;
        }
        public void list_interest_from_rank()
        {
            for (int i = 0; i < list_open_rank.Count; i++)
            {
                OpenInterestID tmp_oid;
                //for (int j=0;j<3;j++)
                //{
                int vol_position = exist_id_list_open_interest(list_open_rank[i].abbreviation_member_vol.ToString());
                if (vol_position > -1)
                {
                    list_open_interest[vol_position].vol = int.Parse(list_open_rank[i].vol.ToString());
                    list_open_interest[vol_position].change_vol = int.Parse(list_open_rank[i].change_vol.ToString());
                }
                else
                {
                    tmp_oid = new OpenInterestID();
                    tmp_oid.id = "999";
                    tmp_oid.member = list_open_rank[i].abbreviation_member_vol;
                    tmp_oid.vol = int.Parse(list_open_rank[i].vol.ToString());
                    tmp_oid.change_vol = int.Parse(list_open_rank[i].change_vol.ToString());
                    list_open_interest.Add(tmp_oid);
                }
                int buy_position = exist_id_list_open_interest(list_open_rank[i].abbreviation_member_buy.ToString());
                if (buy_position > -1)
                {
                    list_open_interest[buy_position].buy = int.Parse(list_open_rank[i].hold_buy_vol.ToString());
                    list_open_interest[buy_position].change_buy = int.Parse(list_open_rank[i].change_hold_buy.ToString());
                }
                else
                {
                    tmp_oid = new OpenInterestID();
                    tmp_oid.id = "999";
                    tmp_oid.member = list_open_rank[i].abbreviation_member_buy;
                    tmp_oid.buy = int.Parse(list_open_rank[i].hold_buy_vol.ToString());
                    tmp_oid.change_buy = int.Parse(list_open_rank[i].change_hold_buy.ToString());
                    list_open_interest.Add(tmp_oid);
                }

                int sell_position = exist_id_list_open_interest(list_open_rank[i].abbreviation_member_sell.ToString());
                if (sell_position > -1)
                {
                    list_open_interest[sell_position].sell = int.Parse(list_open_rank[i].hold_sell_vol.ToString());
                    list_open_interest[sell_position].change_sell = int.Parse(list_open_rank[i].change_hold_sell.ToString());
                }
                else
                {
                    tmp_oid = new OpenInterestID();
                    tmp_oid.id = "999";
                    tmp_oid.member = list_open_rank[i].abbreviation_member_sell;
                    tmp_oid.sell = int.Parse(list_open_rank[i].hold_sell_vol.ToString());
                    tmp_oid.change_sell = int.Parse(list_open_rank[i].change_hold_sell.ToString());
                    list_open_interest.Add(tmp_oid);
                }
                // }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void save_list_open_rank(string instremnt,string trading_day)
        {
            string file_path = instremnt+"_Date\\" + trading_day + ".csv";
            string fold = file_path.Substring(0, file_path.LastIndexOf('\\'));
            // FileStream fs = new FileStream(file_path,FileMode.Create);
            if (!Directory.Exists(fold))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(fold); //新建文件夹   
            }
            FileStream fs = new FileStream(file_path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            string ctx = "";
            for (int i = 0; i < list_open_rank.Count; i++)
            {
                ctx += list_open_rank[i].rank + ",";
                ctx += list_open_rank[i].abbreviation_member_vol + ",";
                ctx += list_open_rank[i].vol + ",";
                ctx += list_open_rank[i].change_vol + ",";
                ctx += list_open_rank[i].abbreviation_member_buy + ",";
                ctx += list_open_rank[i].hold_buy_vol + ",";
                ctx += list_open_rank[i].change_hold_buy + ",";
                ctx += list_open_rank[i].abbreviation_member_sell + ",";
                ctx += list_open_rank[i].hold_sell_vol + ",";
                ctx += list_open_rank[i].change_hold_sell + "," + Utility.U_datetime.format_date(trading_day) + "\r\n";
            }
            sw.Write(ctx);
            sw.Close();
            fs.Close();
        }

        public void save_list_open_interest(string file_path, string trading_day)
        {
            get_list_member();
            string ctx;
            for (int i = 0; i < list_open_interest.Count; i++)
            {
                ctx = "";
                string filename = get_file_name(list_open_interest[i].member);
                //ctx += list_open_interest[i].id + " ";
                //ctx += list_open_interest[i].id + ",";
                ctx += list_open_interest[i].member + ",";
                ctx += list_open_interest[i].vol.ToString() + ",";
                ctx += list_open_interest[i].change_vol.ToString() + ",";
                ctx += list_open_interest[i].buy.ToString() + ",";
                ctx += list_open_interest[i].change_buy + ",";
                ctx += list_open_interest[i].sell + ",";
                ctx += list_open_interest[i].change_sell + ",";
                ctx += Utility.U_datetime.format_date(trading_day);
                ctx += "\r\n";
                // FileStream fs = new FileStream(file_path,FileMode.Create);
                if (!Directory.Exists(file_path))//若文件夹不存在则新建文件夹   
                {
                    Directory.CreateDirectory(file_path); //新建文件夹   
                }
                //FileStream fs = new FileStream(file_path+ filename, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file_path + filename, true, Encoding.UTF8);
                //Encoding encoder = Encoding.UTF8;
                //sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(ctx);
                sw.Flush();
                sw.Close();
                //fs.Close();
            }

        }
        public void set_list_open_rank(List<string> data)
        {
            list_open_rank.Clear();
            if (data[0] != "1") Console.WriteLine("ListOpenInterest中set_list_open_rank传递的data有误");
            for (int i = 0; i < data.Count; i = i + 10)
            {

                OpenInterestRankColumn tmp = new OpenInterestRankColumn();
                tmp.rank = data[i];
                tmp.abbreviation_member_vol = data[i + 1];
                tmp.vol = data[i + 2];
                tmp.change_vol = data[i + 3];
                tmp.abbreviation_member_buy = data[i + 4];
                tmp.hold_buy_vol = data[i + 5];
                tmp.change_hold_buy = data[i + 6];
                tmp.abbreviation_member_sell = data[i + 7];
                tmp.hold_sell_vol = data[i + 8];
                tmp.change_hold_sell = data[i + 9];
                list_open_rank.Add(tmp);
            }
        }
    }
}
