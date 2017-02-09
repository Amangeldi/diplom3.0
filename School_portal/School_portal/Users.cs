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
        public ConnOpen for_id = new ConnOpen();
        public ConnOpen delete_user = new ConnOpen();
        public ConnOpen for_role = new ConnOpen();
        public bool test_login(string _login)
        {
            login = _login;
            bool tlog;
            test_user.connection.Open();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE login LIKE '%" + login + "'", test_user.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            if (dr.HasRows == true)
            {
                tlog = false;
            }
            else
            {
                tlog = true;
            }
            test_user.connection.Close();
            return tlog;
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
            using (SqlCommand cmd = new SqlCommand(sql, add_user.connection))
            {
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@familija", familija);
                cmd.Parameters.AddWithValue("@imja", imja);
                cmd.Parameters.AddWithValue("@otchestvo", otchestvo);
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.ExecuteNonQuery();
            }
            add_user.connection.Close();

            for_id.connection.Open();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE login LIKE '%" + login + "'", for_id.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            dr.Read();
            if (role == 1)
            {
                Admin nAdmin = new Admin(Convert.ToInt32(dr["user_id"]));
                nAdmin.add(Convert.ToInt32(dr["user_id"]));
            }
            else if(role == 2)
            {
                Teacher nTeacher = new Teacher(Convert.ToInt32(dr["user_id"]));
                nTeacher.add(Convert.ToInt32(dr["user_id"]));
            }
            else if(role == 3)
            {
                Student nStudent = new Student(Convert.ToInt32(dr["user_id"]));
                nStudent.add(Convert.ToInt32(dr["user_id"]));
            }
            else if(role == 4)
            {
                Parent nParent = new Parent(Convert.ToInt32(dr["user_id"]));
                nParent.add(Convert.ToInt32(dr["user_id"]));
            }

            for_id.connection.Close();
        }

        public void delete(int _user_id)
        {
            this.user_id = _user_id;
            for_role.connection.Open();
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + user_id + "'", for_role.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            dr.Read();
            role =Convert.ToInt32(dr["role"]);
            if (role == 1)
            {
                Admin nAdmin = new Admin(Convert.ToInt32(dr["user_id"]));
                nAdmin.delete(user_id);
            }
            else if (role == 2)
            {
                Teacher nTeacher = new Teacher(Convert.ToInt32(dr["user_id"]));
                nTeacher.delete(user_id);
            }
            else if (role == 3)
            {
                Student nStudent = new Student(Convert.ToInt32(dr["user_id"]));
                nStudent.delete(user_id);
            }
            else if (role == 4)
            {
                Parent nParent = new Parent(Convert.ToInt32(dr["user_id"]));
                nParent.delete_Uid(user_id);
            }
            for_role.connection.Close();
            //----------
            delete_user.connection.Open();
            string sql = string.Format("Delete from users where user_id = '{0}'", user_id);
            using (SqlCommand cmd = new SqlCommand(sql, delete_user.connection))
            {
                cmd.ExecuteNonQuery();
            }
            delete_user.connection.Close();
        }
        public bool test_id (string _user_id)
        {
            test_user.connection.Open();
            bool test;
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + _user_id + "'", test_user.connection);
            SqlDataReader dr = sqlCom.ExecuteReader();
            if (dr.HasRows == true)
            {
                test = false;
            }
            else
            {
                test = true;
            }
            test_user.connection.Close();
            return test;
        }
    }
}