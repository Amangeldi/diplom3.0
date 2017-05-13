using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Journal
    {
        //public int journal_id { get; set; }
        //public int groupp_id { get; set; }
        //public int student_ticket_number { get; set; }
        //public int teacher_id { get; set; }
        //public int grade { get; set; }
        //public DateTime date_a { get; set; }
        //public DateTime date_b { get; set; }
        //public string note { get; set; }
        ConnOpen add_journal = new ConnOpen();
        public void add (int groupp_id, int student_ticket_number, int teacher_user_id, int grade, string date_b, string note, int subject_id)
        {
            string date_a = DateTime.Now.ToString();
            add_journal.connection.Open();
            string sql = string.Format("Insert Into journal" +
                       "(groupp_id, student_ticket_number, teacher_user_id, grade, date_a, date_b, note, subject_id) Values(@groupp_id, @student_ticket_number, @teacher_user_id, @grade, @date_a, @date_b, @note, @subject_id)");
            using (SqlCommand cmd = new SqlCommand(sql, add_journal.connection))
            {
                cmd.Parameters.AddWithValue("@groupp_id", groupp_id);
                cmd.Parameters.AddWithValue("@student_ticket_number", student_ticket_number);
                cmd.Parameters.AddWithValue("@teacher_user_id", teacher_user_id);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@date_a", date_a);
                cmd.Parameters.AddWithValue("@date_b", date_b);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.ExecuteNonQuery();
            }
            add_journal.connection.Close();
        }

    }
}