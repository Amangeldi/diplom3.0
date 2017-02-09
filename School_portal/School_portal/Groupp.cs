using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Groupp
    {
        public int groupp_id { get; set; }
        public string groupp_name { get; set; }
        public int teacher_id { get; set; }
        public int groupp_kurs { get; set; }
        public ConnOpen add_groupp = new ConnOpen();
        public ConnOpen test_groupp = new ConnOpen();
        public ConnOpen delete_groupp = new ConnOpen();
        public ConnOpen update_groupp = new ConnOpen();
        public bool test_groupp_name( string _groupp_name, int _groupp_kurs)
        {
            groupp_name = _groupp_name;
            groupp_kurs = _groupp_kurs;
            bool tgn;
            test_groupp.connection.Open();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.groupp WHERE group_name LIKE '%" + groupp_name +"' AND group_kurs LIKE '%"+ groupp_kurs.ToString()+ "'", test_groupp.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            if (dr.HasRows == true)
            {
                tgn = false;
            }
            else
            {
                tgn = true;
            }
            test_groupp.connection.Close();
            return tgn;
        }
        public void add (string _groupp_name, int _teacher_id, int _groupp_kurs)
        {
            groupp_name = _groupp_name;
            teacher_id = _teacher_id;
            groupp_kurs = _groupp_kurs;
            add_groupp.connection.Open();
            string sql = string.Format("Insert Into groupp" +
                       "(group_name, teacher_id, group_kurs) Values(@group_name, @teacher_id, @group_kurs)");
            using (SqlCommand cmd = new SqlCommand(sql, add_groupp.connection))
            {
                cmd.Parameters.AddWithValue("@group_name", groupp_name);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.Parameters.AddWithValue("@group_kurs", groupp_kurs);
                cmd.ExecuteNonQuery();
            }
            add_groupp.connection.Close();

        }
        public void delete(int groupp_id)
        {
            delete_groupp.connection.Open();
            string sql = string.Format("Delete from groupp where groupp_id = '{0}'", groupp_id);
            using (SqlCommand cmd = new SqlCommand(sql, delete_groupp.connection))
            {
                cmd.ExecuteNonQuery();
            }
            delete_groupp.connection.Close();
        }
        public void update_Tid(int teacher_id)
        {
            update_groupp.connection.Open();
            string sql = string.Format("Update groupp Set teacher_id = NULL Where teacher_id = "+ teacher_id.ToString()+";");
            using (SqlCommand cmd = new SqlCommand(sql, update_groupp.connection))
            {
                cmd.ExecuteNonQuery();
            }
            update_groupp.connection.Close();
        }
    }
}