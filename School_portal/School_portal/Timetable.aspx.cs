using System;
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
            ConnOpen tLoadTe = new ConnOpen();
            ConnOpen tLoadGr = new ConnOpen();
            ConnOpen tLoadSu = new ConnOpen();
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
                    tLoadGr.connection.Open();
                    tLoadSu.connection.Open();
                    tLoadTe.connection.Open();
                    tLoadUse.connection.Open();
                    string result = "";
                    string today = DateTime.Now.ToShortDateString().ToString();
                    Timetable deyOfWeek = new Timetable();
                    DateTime monday = deyOfWeek.getMonday(DateTime.Now);
                    DateTime sunday = deyOfWeek.getSunday(DateTime.Now);
                    Label1.Text = sunday.ToString();
                    int subject, teacher, teacherUid, groupp;
                    string tSubject = "", tTeacher = "", tGroupp = "";
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.timetable WHERE time BETWEEN '"+monday.ToShortDateString()+"' AND '"+sunday.ToShortDateString()+"' ORDER BY time ASC", tLoad.connection);
                    SqlCommand command_gr;
                    SqlCommand command_su;
                    SqlCommand command_te;
                    SqlCommand command_teach_ft;
                    SqlDataReader reader = command.ExecuteReader();
                    result += "<table> <tr><td>Дата и время</td><td>Предмет</td> <td>Преподаватель</td><td>Группа</td> </tr>";
                    while (reader.Read())
                    {
                        subject = Convert.ToInt32(reader["subject_id"]);
                        teacher = Convert.ToInt32(reader["teacher_id"]);
                        groupp = Convert.ToInt32(reader["groupp_id"]);
                        command_gr = new SqlCommand("SELECT * FROM dbo.groupp WHERE groupp_id LIKE '%" + groupp.ToString() + "'",tLoadGr.connection);
                        SqlDataReader reader_command_gr = command_gr.ExecuteReader();
                        while(reader_command_gr.Read())
                        {
                            tGroupp = reader_command_gr["groupp_kurs"].ToString()+" "+reader_command_gr["groupp_name"].ToString();
                        }
                        command_su = new SqlCommand("SELECT * FROM dbo.subject WHERE subject_id LIKE '%"+subject+"'", tLoadSu.connection);
                        SqlDataReader reader_command_su = command_su.ExecuteReader();
                        while(reader_command_su.Read())
                        {
                            tSubject = reader_command_su["subject_name"].ToString();
                        }
                        command_te = new SqlCommand("SELECT * FROM dbo.teacher WHERE teacher_id LIKE '%" + teacher + "'", tLoadTe.connection);
                        SqlDataReader reader_command_te = command_te.ExecuteReader();
                        while(reader_command_te.Read())
                        {
                            teacherUid = Convert.ToInt32(reader_command_te["user_id"]);
                            command_teach_ft = new SqlCommand("SELECT * FROM users WHERE user_id LIKE '%" + teacherUid.ToString() + "'", tLoadUse.connection);
                            SqlDataReader reader_teach_ft = command_teach_ft.ExecuteReader();
                            while (reader_teach_ft.Read())
                            {
                                tTeacher = reader_teach_ft["familija"].ToString() + " " + reader_teach_ft["imja"].ToString() + " " + reader_teach_ft["otchestvo"].ToString();
                            }
                            reader_teach_ft.Close();
                        }
                        
                        result += "<tr> <td>" + reader["time"].ToString() + "</td>";
                        result += "<td>" + tSubject + "</td>";
                        result += "<td>" + tTeacher + "</td>";
                        result += "<td>" + tGroupp + "</td>";
                        result += "</tr>";
                        reader_command_gr.Close();
                        reader_command_su.Close();
                        reader_command_te.Close();
                    }
                    result += "</ table >";
                    Label1.Text = result;
                    reader.Close();
                    flag = 1;
                    tLoad.connection.Close();
                    tLoadGr.connection.Close();
                    tLoadSu.connection.Close();
                    tLoadTe.connection.Close();
                    tLoadUse.connection.Close();
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