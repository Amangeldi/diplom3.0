using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace School_portal
{
    public class ConnOpen
    {
        static string connectionString = WebConfigurationManager.ConnectionStrings["school_portal"].ConnectionString;
        public SqlConnection connection = new SqlConnection(connectionString);
    }
}