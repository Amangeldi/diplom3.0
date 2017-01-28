using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Teacher : Users
    {
        public int teacher_id { get; set; }
        public string position { get; set; }
        public Teacher(int user_id)
        {
            this.user_id = user_id;
        }
    }
}