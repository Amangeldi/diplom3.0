using System;
using System.Collections.Generic;
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
    }
}