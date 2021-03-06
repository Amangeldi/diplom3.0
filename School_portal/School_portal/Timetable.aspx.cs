﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_portal
{
    public partial class Timetable : System.Web.UI.Page
    {

        int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sName = "", gText = "";
            ConnOpen tLoad = new ConnOpen();
            ConnOpen tLoadUse = new ConnOpen();
            if (Session["Value"] != null)
            {
                int r = Convert.ToInt32(Session["Value"]);
                Label1.Text = r.ToString();
                if(r!=1)
                {
                    Panel1.Enabled = false;
                }
                else
                {
                    tLoad.connection.Open();
                    SqlCommand command_subject = new SqlCommand("SELECT * FROM dbo.subject", tLoad.connection);
                    SqlDataReader reader_subject = command_subject.ExecuteReader();
                    //DropDownList1.Items.Clear();
                    //Обнуляем количество итемов
                    if (flag == 0)
                    {
                        while (reader_subject.Read())
                        {
                            sName = reader_subject["subject_name"].ToString();
                            DropDownList1.Items.Add(new ListItem(sName, reader_subject["subject_id"].ToString()));
                        }
                    }
                    tLoad.connection.Close();
                    //------------------------------------------------------
                    tLoad.connection.Open();
                    tLoadUse.connection.Open();
                    SqlCommand command_teach = new SqlCommand("SELECT * FROM dbo.teacher", tLoad.connection);
                    SqlDataReader reader_teach = command_teach.ExecuteReader();
                    //--
                    SqlCommand command_use;
                    SqlDataReader reader_use;
                    string F = "", I = "", O = "";
                    //DropDownList2.Items.Clear();
                    //Обнуляем количество итемов
                    if (flag == 0)
                    {
                        while (reader_teach.Read())
                        {
                            command_use = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + reader_teach["user_id"].ToString() + "'", tLoadUse.connection);
                            reader_use = command_use.ExecuteReader();
                            //С таблицы dbo.users достаем строки где user_id равно user_id из таблицы dbo.teacher
                            reader_use.Read();
                            //Читаем таблицу dbo.users
                            F = reader_use["familija"].ToString() + " ";
                            I = reader_use["imja"].ToString() + " ";
                            O = reader_use["otchestvo"].ToString() + " ";
                            DropDownList2.Items.Add(new ListItem(F + I + O, reader_teach["teacher_id"].ToString()));
                            //Добавляем в DropDownList3 ФИО из таблицы dbo.users
                            reader_use.Close();
                        }
                    }
                    tLoad.connection.Close();
                    tLoadUse.connection.Close();
                    //------------------------------------------------------
                    tLoad.connection.Open();
                    SqlCommand command_groupp = new SqlCommand("SELECT * FROM dbo.groupp", tLoad.connection);
                    SqlDataReader reader_groupp = command_groupp.ExecuteReader();
                    //DropDownList3.Items.Clear();
                    //Обнуляем количество итемов
                    if (flag == 0)
                    {
                        while (reader_groupp.Read())
                        {
                            gText = reader_groupp["groupp_kurs"].ToString() + " " + reader_groupp["groupp_name"].ToString();
                            DropDownList3.Items.Add(new ListItem(gText, reader_groupp["groupp_id"].ToString()));
                        }
                    }
                    tLoad.connection.Close();
                    //------------------------------------------------------
                    tLoad.connection.Open();
                    string result = "";
                    string today = DateTime.Now.ToShortDateString().ToString();
                    Timetable deyOfWeek = new Timetable();
                    DateTime monday = deyOfWeek.getMonday(DateTime.Now);
                    DateTime sunday = deyOfWeek.getSunday(DateTime.Now);
                    Label1.Text = sunday.ToString();
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.timetable WHERE time BETWEEN '"+monday.ToShortDateString()+"' AND '"+sunday.ToShortDateString()+"' ORDER BY time ASC", tLoad.connection);
                    SqlDataReader reader = command.ExecuteReader();
                    result += "<table> <tr><td>Дата и время</td><td>Предмет</td> <td>Преподаватель</td><td>Группа</td> </tr>";

                    while (reader.Read())
                    {
                        result += "<tr> <td>" + reader["time"].ToString() + "</td>";
                        result += "<td>" + reader["subject_id"].ToString() + "</td>";
                        result += "<td>" + reader["teacher_id"].ToString() + "</td>";
                        result += "<td>" + reader["groupp_id"].ToString() + "</td>";
                        result += "</tr>";
                    }
                    result += "</ table >";
                    Label1.Text = result;
                    reader.Close();
                    flag = 1;
                }

            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Timetable rasp = new Timetable();
            rasp.add(Convert.ToInt32(DropDownList1.SelectedValue), Calendar1.SelectedDate.ToShortDateString(), Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(DropDownList3.SelectedValue), DropDownList4.SelectedValue);
        }
    }
}