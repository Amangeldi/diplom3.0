using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Homework
    {
        public ConnOpen add_homework = new ConnOpen();
        public void add (int groupp_id, int subject_id, int teacher_user_id, string homework_text, string time)
        {
            add_homework.connection.Open();
            string sql = string.Format("Insert Into homework" +
                       "(groupp_id, subject_id, teacher_user_id, homework_text, time) Values(@groupp_id, @subject_id, @teacher_user_id, @homework_text, @time)");
            using (SqlCommand cmd = new SqlCommand(sql, add_homework.connection))
            {
                cmd.Parameters.AddWithValue("@groupp_id", groupp_id);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@teacher_user_id", teacher_user_id);
                cmd.Parameters.AddWithValue("@homework_text", homework_text);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.ExecuteNonQuery();
            }
            add_homework.connection.Close();
        }
    }
}