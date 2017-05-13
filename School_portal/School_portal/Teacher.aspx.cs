using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_portal
{
    public partial class Teacher1 : System.Web.UI.Page
    {
        int uid;
        int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            uid = Convert.ToInt32(Session["Value"]);
            string sName = "", gText = "";
            ConnOpen teachLoad = new ConnOpen();
            ConnOpen teachLoadUse = new ConnOpen();
            if(Session["Value"] != null)
            {
                teachLoad.connection.Open();
                SqlCommand command_groupp = new SqlCommand("SELECT * FROM dbo.groupp", teachLoad.connection);
                SqlDataReader reader_groupp = command_groupp.ExecuteReader();
                //DropDownList1.Items.Clear();
                //Обнуляем количество итемов
                if (flag == 0)
                {
                    while (reader_groupp.Read())
                    {
                        gText = reader_groupp["groupp_kurs"].ToString() + " " + reader_groupp["groupp_name"].ToString();
                        DropDownList1.Items.Add(new ListItem(gText, reader_groupp["groupp_id"].ToString()));
                        Label6.Text += reader_groupp["groupp_id"].ToString();
                    }
                }
                teachLoad.connection.Close();
                //------------------------------------------------------
                teachLoad.connection.Open();
                teachLoadUse.connection.Open();
                SqlCommand command_student = new SqlCommand("SELECT * FROM dbo.student", teachLoad.connection);
                SqlDataReader reader_student = command_student.ExecuteReader();
                SqlCommand command_use;
                SqlDataReader reader_use;
                //Создал команду для таблицы dbo.users
                string F = "", I = "", O = "";
                //DropDownList2.Items.Clear();
                //Обнуляем количество итемов
                if (flag == 0)
                {
                    while (reader_student.Read())
                    {
                        command_use = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + reader_student["user_id"].ToString() + "'", teachLoadUse.connection);
                        reader_use = command_use.ExecuteReader();
                        //С таблицы dbo.users достаем строки где user_id равно user_id из таблицы dbo.teacher
                        reader_use.Read();
                        //Читаем таблицу dbo.users
                        F = reader_use["familija"].ToString() + " ";
                        I = reader_use["imja"].ToString() + " ";
                        O = reader_use["otchestvo"].ToString() + " ";
                        DropDownList2.Items.Add(new ListItem(F + I + O, reader_student["student_ticket_number"].ToString()));
                        //Добавляем в DropDownList3 ФИО из таблицы dbo.users
                        reader_use.Close();
                        //Обязательно закрываем reader_use
                    }
                }
                teachLoad.connection.Close();
                teachLoadUse.connection.Close();
                //------------------------------------------------------
                teachLoad.connection.Open();
                SqlCommand command_subject = new SqlCommand("SELECT * FROM dbo.subject", teachLoad.connection);
                SqlDataReader reader_subject = command_subject.ExecuteReader();
                //DropDownList4.Items.Clear();
                //Обнуляем количество итемов
                if (flag == 0)
                {
                    while (reader_subject.Read())
                    {
                        sName = reader_subject["subject_name"].ToString();
                        DropDownList4.Items.Add(new ListItem(sName, reader_subject["subject_id"].ToString()));
                    }
                }
                teachLoad.connection.Close();
                flag = 1;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Journal grade = new Journal();
            grade.add(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue), uid, Convert.ToInt32(DropDownList3.SelectedValue), TextBox1.Text, TextBox2.Text, Convert.ToInt32(DropDownList4.SelectedValue));
            // d/m/y ttt: 01 / 01 / 2017 23:59:59
            Label6.Text = DropDownList1.SelectedValue;
        }
    }
}