using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZCE
{
    public class member_id
    {

        public string id;
        public string name;
    }
    public class ListMember
    {
        private List<member_id> m_members;
        public List<member_id> members
        {
            get { return m_members; }
            set { m_members = value; }
        }

        public void add_member_by_name(string name)
        {
            member_id mi = new member_id();
            mi.id = (int.Parse(m_members[amount - 1].id) + 1).ToString();
            mi.name = name;
            m_members.Add(mi);
        }
        public int amount
        {
            get { return m_members.Count; }
        }
        public bool exist_members_name(string member_name)
        {
            bool flag = false;
            for (int i = 0; i < m_members.Count; i++)
            {
                if (m_members[i].name == member_name)
                    flag = true;
            }
            return flag;
        }
    }
}
