using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Users
    {
        public int user_id { get; set; }
        public int role { get; set; }
        public string familija { get; set; }
        public string imja { get; set; }
        public string otchestvo { get; set; }
        public string adress { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string DOB { get; set; }

        public ConnOpen Add_user = new ConnOpen();
        Admin1 admin = new Admin1();
        public void add ()
        {
            Add_user.connection.Open();
        }
    }
}