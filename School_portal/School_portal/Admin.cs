using System;
using System.Collections.Generic;
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
    }
}