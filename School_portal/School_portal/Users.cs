using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public ConnOpen add_user = new ConnOpen();
        public ConnOpen test_user = new ConnOpen();
        public bool test_login(string _login)
        {
            login = _login;
            test_user.connection.Open();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE login LIKE '%" + login + "'", test_user.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            if(dr.HasRows == true)
            {
                return false;
            }
            else
            {
                return true;
            }
            test_user.connection.Close();
        }

        public void add (int _role, string _familija, string _imja, string _otchestvo, string _adress, string _login, string _password, string _DOB)
        {
            this.role = _role;
            this.familija = _familija;
            this.imja = _imja;
            this.otchestvo = _otchestvo;
            this.adress = _adress;
            this.login = _login;
            this.password = _password;
            this.DOB = _DOB;
            add_user.connection.Open();
            string sql = string.Format("Insert Into users" +
                       "(role, familija, imja, otchestvo, adress, login, password, DOB) Values(@role, @familija, @imja, @otchestvo, @adress, @login, @password, @DOB)");
            using (SqlCommand cmd_10 = new SqlCommand(sql, add_user.connection))
            {
                cmd_10.Parameters.AddWithValue("@role", role);
                cmd_10.Parameters.AddWithValue("@familija", familija);
                cmd_10.Parameters.AddWithValue("@imja", imja);
                cmd_10.Parameters.AddWithValue("@otchestvo", otchestvo);
                cmd_10.Parameters.AddWithValue("@adress", adress);
                cmd_10.Parameters.AddWithValue("@login", login);
                cmd_10.Parameters.AddWithValue("@password", password);
                cmd_10.Parameters.AddWithValue("@DOB", DOB);
                cmd_10.ExecuteNonQuery();
            }
            add_user.connection.Close();
        }
    }
}