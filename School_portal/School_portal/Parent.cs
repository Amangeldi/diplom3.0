﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Parent : Users
    {
        public int parent_id { get; set; }
        public int student_ticket_number { get; set; }
        public string tel { get; set; }
        public Parent(int user_id)
        {
            this.user_id = user_id;
        }
        public ConnOpen add_parent = new ConnOpen();
        public void add(int user_id)
        {
            //this.user_id = user_id;
            add_parent.connection.Open();
            string sql = string.Format("Insert Into parent" +
                       "(user_id, tel, student_ticket_number) Values(@user_id, @tel, @student_ticket_number)");
            using (SqlCommand cmd = new SqlCommand(sql, add_parent.connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@tel", "+3752512345678");
                cmd.Parameters.AddWithValue("@student_ticket_number", 1);
                cmd.ExecuteNonQuery();
            }
            add_parent.connection.Close();
        }
    }
}