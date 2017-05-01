using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public partial class Timetable
    {
        public string data { get; set; }
        public int subject_id { get; set; }
        public int teacher_id { get; set; }
        public int groupp_id { get; set; }
        public ConnOpen add_timetable = new ConnOpen();
        public void add(int subject_id, string data, int teacher_id, int groupp_id, string time)
        {
            //this.data = data;
            //this.subject_id = subject_id;
            //this.teacher_id = teacher_id;
            //this.groupp_id = groupp_id;
            data = data + " " + time;
            add_timetable.connection.Open();
            string sql = string.Format("Insert Into timetable" +
                       "(time, subject_id, teacher_id, groupp_id) Values(@time, @subject_id, @teacher_id, @groupp_id)");
            using (SqlCommand cmd = new SqlCommand(sql, add_timetable.connection))
            {
                cmd.Parameters.AddWithValue("@time", data);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.Parameters.AddWithValue("@groupp_id", groupp_id);
                cmd.ExecuteNonQuery();
            }
            add_timetable.connection.Close();
        }
            //-------
        public DateTime getMonday(DateTime date)
        {
            while (date.DayOfWeek != System.DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }
            return date;
        }
        public DateTime getSunday(DateTime date)
        {
            while (date.DayOfWeek != System.DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            return date;
        }
    }
}