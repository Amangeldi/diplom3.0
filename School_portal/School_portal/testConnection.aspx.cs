using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace School_portal
{
    public partial class testConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["school_portal"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();
                Label1.Text = "<b>Версия сервера: </b>" + connection.ServerVersion;
                Label1.Text += "<br /><b>Состояние соединения: </b> " + connection.State.ToString();
            }
            Label1.Text += "<br /><b>Состояние соединения после using: </b> " + connection.State.ToString();

        }
    }
}