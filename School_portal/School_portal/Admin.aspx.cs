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
        string FIO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            ConnOpen admLoad = new ConnOpen();
            ConnOpen admLoadUse = new ConnOpen();
            if (FIO == null || Session["Value"] == null)
            {
                //connection.Open();
                admLoad.connection.Open();
                int id = Convert.ToInt32(Session["Value"]);
                Label1.Text = id.ToString();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + id + "'", admLoad.connection);
                SqlDataReader dr = sqlCom.ExecuteReader();
                dr.Read();
                FIO = dr["familija"].ToString() + " " + dr["imja"].ToString() + " " + dr["otchestvo"].ToString();
                Label1.Text = "Здравствуйте " + FIO;
                admLoad.connection.Close();
                //----------
                //Тут нужно все расписать подробно, я сейчас уже не понимаю что происходит, а завтра точно не вспомню
                admLoad.connection.Open();
                admLoadUse.connection.Open();
                //Добавил 2 коннекта, просто я раньше запретил несколько команд в одном коннекте
                SqlCommand command_teach = new SqlCommand("SELECT * FROM dbo.teacher", admLoad.connection);
                SqlDataReader reader_teach = command_teach.ExecuteReader();
                //Создал команду для таблицы dbo.teacher
                SqlCommand command_use;
                SqlDataReader reader_use;
                //Создал команду для таблицы dbo.users
                string F = "", I = "", O = "";
                while (reader_teach.Read())//По циклу читаем таблицу dbo.teacher до конца таблицы
                {
                    command_use = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + reader_teach["user_id"].ToString() + "'", admLoadUse.connection);
                    reader_use = command_use.ExecuteReader();
                    //С таблицы dbo.users достаем строки где user_id равно user_id из таблицы dbo.teacher
                    reader_use.Read();
                    //Читаем таблицу dbo.users
                    F = reader_use["familija"].ToString()+" ";
                    I = reader_use["imja"].ToString() + " ";
                    O = reader_use["otchestvo"].ToString() + " ";
                    DropDownList3.Items.Add(new ListItem(F+I+O, reader_teach["teacher_id"].ToString()));
                    //Добавляем в DropDownList3 ФИО из таблицы dbo.users
                    reader_use.Close();
                    //Обязательно закрываем reader_use, ну его нахрен
                }
                admLoad.connection.Close();
                admLoadUse.connection.Close();
                //Закрываем коннекты и стараемся сюда не возвращаться
                FIO = "1";
            }
            //------------------------------------------------------

            admLoad.connection.Open();
            string result = "";
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.users", admLoad.connection);
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
            Label2.Text = "Список пользователей:" + result;
            reader.Close();
            admLoad.connection.Close();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            bool test = user.test_login(TextBox5.Text);
            if(test == false)
            {
                Label15.Text = "Введите другой логин";
            }
            else
            {
                Label15.Text = "OK";
                user.add(Convert.ToInt32(DropDownList1.SelectedValue), TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Groupp groupp = new Groupp();
            bool test = groupp.test_groupp_name(TextBox8.Text, Convert.ToInt32(DropDownList2.SelectedValue));
            if (test == false)
            {
                Label15.Text = "Введите другое имя класса";
            }
            else
            {
                Label15.Text = "OK";
                groupp.add(TextBox8.Text,Convert.ToInt32(DropDownList3.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue));
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            bool test = user.test_id(TextBox9.Text);
            if (test == true)
            {
                Label15.Text = "Пользователь с таким id не существует или был удален";
            }
            else
            {
                user.delete(Convert.ToInt32(TextBox9.Text));
                Label15.Text = "OK";
            }
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {
            
            //Button3.ForeColor = System.Drawing.Color.FromName("red");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["Value"] = 1;
            Server.Transfer("Timetable.aspx", true);
        }
    }
}