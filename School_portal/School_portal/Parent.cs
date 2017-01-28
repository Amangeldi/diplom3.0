using System;
using System.Collections.Generic;
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
    }
}