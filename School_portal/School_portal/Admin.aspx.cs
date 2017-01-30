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
    public partial class Admin1 : System.Web.UI.Page
    {
        string role;
        string role_text;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["school_portal"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int id = Convert.ToInt32(Session["Value"]);
            Label1.Text = id.ToString();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + id + "'", connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            string FIO;
            dr.Read();
            FIO = dr["familija"].ToString() + " " + dr["imja"].ToString() + " " + dr["otchestvo"].ToString();
            Label1.Text = "Здравствуйте " + FIO;
            connection.Close();

            //------------------------------------------------------

            connection.Open();
            string result = "";
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.users", connection);
            SqlDataReader reader = command.ExecuteReader();
            result += "<table> <tr><td>id пользователя</td><td>роль</td> <td>фамилия</td><td>имя</td><td>отчество</td><td>адрес</td><td>login</td><td>Дата рождения</td> </tr>";
            while (reader.Read())
            {
                role = reader["role"].ToString();
                if (role == "1")
                {
                    role_text = "<b>Администратор</b>";
                }
                else if (role == "2")
                {
                    role_text = "<b>Преподаватель</b>";
                }
                else if (role == "3")
                {
                    role_text = "<b>Ученик</b>";
                }
                else if (role == "4")
                {
                    role_text = "<b>Родитель</b>";
                }
                result += "<tr> <td>" + reader["user_id"].ToString() + "</td>";
                result += " <td>" + role_text + "</td>";
                result += " <td>" + reader["familija"].ToString() + "</td>";
                result += " <td>" + reader["imja"].ToString() + "</td>";
                result += " <td>" + reader["otchestvo"].ToString() + "</td>";
                result += " <td>" + reader["adress"].ToString() + "</td>";
                result += " <td>" + reader["login"].ToString() + "</td>";
                result += " <td>" + reader["DOB"].ToString() + "</td>";
                result += "</tr>";
            }
            result += "</ table >";
            Label2.Text += result;
            reader.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}