using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Student : Users
    {
        public int student_ticket_number { get; set; }
        public int groupp_id { get; set; }
        public Student(int user_id)
        {
            this.user_id = user_id;
        }
        public ConnOpen add_student = new ConnOpen();
        public ConnOpen delete_student = new ConnOpen();
        public void add (int user_id)
        {
            //this.user_id = user_id;
            add_student.connection.Open();
            string sql = string.Format("Insert Into student" +
                       "(user_id, groupp_id) Values(@user_id, @groupp_id)");
            using (SqlCommand cmd = new SqlCommand(sql, add_student.connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@groupp_id", 1);
                cmd.ExecuteNonQuery();
            }
            add_student.connection.Close();
        }
        public new void delete(int user_id)
        {
            delete_student.connection.Open();
            Parent parent = new Parent();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.student WHERE user_id LIKE '%" + user_id + "'", delete_student.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            dr.Read();
            parent.delete(Convert.ToInt32(dr["student_ticket_number"]));
            delete_student.connection.Close();
            //==========
            delete_student.connection.Open();
            string sql = string.Format("Delete from student where user_id = '{0}'", user_id);
            using (SqlCommand cmd = new SqlCommand(sql, delete_student.connection))
            {
                cmd.ExecuteNonQuery();
            }
            delete_student.connection.Close();
        }
    }
}