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
        public int group_id { get; set; }
        public Student(int user_id)
        {
            this.user_id = user_id;
        }
        public ConnOpen add_student = new ConnOpen();
        public void add (int user_id)
        {
            //this.user_id = user_id;
            add_student.connection.Open();
            string sql = string.Format("Insert Into student" +
                       "(user_id, group_id) Values(@user_id, @group_id)");
            using (SqlCommand cmd = new SqlCommand(sql, add_student.connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@group_id", 1);
                cmd.ExecuteNonQuery();
            }
            add_student.connection.Close();
        }
    }
}