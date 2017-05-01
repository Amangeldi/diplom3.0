using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_portal
{
    public partial class login : System.Web.UI.Page
    {

        int role = 5;
        string url;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                role = 1;
                url = "Admin";
            }
            else if (RadioButton2.Checked == true)
            {
                role = 2;
                url = "Teacher";
            }
            else if (RadioButton3.Checked == true)
            {
                role = 3;
                url = "Student";
            }
            else if (RadioButton4.Checked == true)
            {
                role = 4;
                url = "Parent";
            }
            else
            {
                role = 5;
            }
            string login = TextBox1.Text;
            string password = TextBox2.Text;
            ConnOpen loginConnection = new ConnOpen();
            loginConnection.connection.Open();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE role LIKE '%" + role + "' and login LIKE '%" + login + "'and password LIKE '%" + password + "'", loginConnection.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();

            int id;
            dr.Read();
            if (dr.HasRows == true)
            {
                id = Convert.ToInt32(dr["user_id"]);
                //устанавливаем сессию  
                Session["Value"] = id;
                Server.Transfer(url + ".aspx", true);
            }
            else
            {
                Label3.Text = "Не войдете!";
            }
            loginConnection.connection.Close();
        }
    }
}