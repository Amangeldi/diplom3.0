using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Admin : Users
    {
        public int admin_id { get; set; }
        public Admin(int user_id)
        {
            this.user_id = user_id;
        }
        public ConnOpen add_admin = new ConnOpen();
        public ConnOpen delete_admin = new ConnOpen();
        public void add(int user_id)
        {
            //this.user_id = user_id;
            add_admin.connection.Open();
            string sql = string.Format("Insert Into admin" +
                       "(user_id) Values(@user_id)");
            using (SqlCommand cmd = new SqlCommand(sql, add_admin.connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.ExecuteNonQuery();
            }
            add_admin.connection.Close();
        }
        public new void delete(int user_id)
        {
            delete_admin.connection.Open();
            string sql = string.Format("Delete from admin where user_id = '{0}'", user_id);
            using (SqlCommand cmd = new SqlCommand(sql, delete_admin.connection))
            {
                cmd.ExecuteNonQuery();
            }
            delete_admin.connection.Close();
        }

    }
}