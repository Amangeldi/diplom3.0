using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public partial class Message
    {
        public ConnOpen add_message = new ConnOpen();
        public void add(int sender, int adressee, string text)
        {
            add_message.connection.Open();
            string sql = string.Format("Insert Into message" +
                       "(sender, adressee, text, status) Values(@sender, @adressee, @text, @status)");
            using (SqlCommand cmd = new SqlCommand(sql, add_message.connection))
            {
                cmd.Parameters.AddWithValue("@sender", sender);
                cmd.Parameters.AddWithValue("@adressee", adressee);
                cmd.Parameters.AddWithValue("@text", text);
                cmd.Parameters.AddWithValue("@status", "0");
                cmd.ExecuteNonQuery();
            }
            add_message.connection.Close();
        }
    }
}