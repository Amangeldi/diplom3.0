using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Teacher : Users
    {
        public int teacher_id { get; set; }
        public string position { get; set; }
        public Teacher(int user_id)
        {
            this.user_id = user_id;
        }
        public ConnOpen add_teacher = new ConnOpen();
        public ConnOpen delete_teacher = new ConnOpen();
        public void add(int user_id)
        {
            //this.user_id = user_id;
            add_teacher.connection.Open();
            string sql = string.Format("Insert Into teacher" +
                       "(user_id, position) Values(@user_id, @position)");
            using (SqlCommand cmd = new SqlCommand(sql, add_teacher.connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@position", "Преподаватель математики");
                cmd.ExecuteNonQuery();
            }
            add_teacher.connection.Close();
        }
        public new void delete(int user_id)
        {
            delete_teacher.connection.Open();
            Groupp update_groupp_Tid = new Groupp();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.teacher WHERE user_id LIKE '%" + user_id + "'", delete_teacher.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            dr.Read();
            update_groupp_Tid.update_Tid(Convert.ToInt32(dr["teacher_id"]));
            delete_teacher.connection.Close();
            //==========
            delete_teacher.connection.Open();
            string sql = string.Format("Delete from teacher where user_id = '{0}'", user_id);
            using (SqlCommand cmd = new SqlCommand(sql, delete_teacher.connection))
            {
                cmd.ExecuteNonQuery();
            }
            delete_teacher.connection.Close();
        }
    }
}