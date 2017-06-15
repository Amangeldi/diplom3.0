using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_portal
{
    public partial class Student1 : System.Web.UI.Page
    {

        string FIO = null;
        int uId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnOpen studLoad = new ConnOpen();
            ConnOpen studLoadTe = new ConnOpen();
            ConnOpen studLoadSid = new ConnOpen();
            ConnOpen studLoadTuid = new ConnOpen();
            ConnOpen studLoadUse = new ConnOpen();
            if(Session["Value"] != null)
            {
                studLoad.connection.Open();
                int id = Convert.ToInt32(Session["Value"]);
                uId = Convert.ToInt32(Session["Value"]);
                Label1.Text = id.ToString();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + id + "'", studLoad.connection);
                SqlDataReader dr = sqlCom.ExecuteReader();
                dr.Read();
                FIO = dr["familija"].ToString() + " " + dr["imja"].ToString() + " " + dr["otchestvo"].ToString();
                Label1.Text = "Здравствуйте " + FIO;
                studLoad.connection.Close();
                //----------
                studLoad.connection.Open();
                studLoadUse.connection.Open();
                studLoadTe.connection.Open();
                string result = "";
                SqlCommand command_use = new SqlCommand("SELECT * FROM dbo.student WHERE user_id LIKE '%"+ id.ToString()+"'" , studLoadUse.connection);
                string studId = "";
                SqlDataReader reader_use = command_use.ExecuteReader();
                string grade = "";
                string groupp_id = "";
                while(reader_use.Read())
                {
                    studId = reader_use["student_ticket_number"].ToString();
                    groupp_id = reader_use["groupp_id"].ToString();
                }
                studLoadUse.connection.Close();
                //-
                studLoadUse.connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.journal WHERE student_ticket_number LIKE '%"+studId+"'", studLoad.connection);
                SqlDataReader reader = command.ExecuteReader();
                result += "<table> <tr><td>Предмет</td><td>Преподаватель</td> <td>Оценка</td><td>Время выставления оценки</td><td>Время проведение работ</td><td>Комментарий к оценке</td> </tr>";
                SqlCommand command_te;
                int teacher, teacherUid;
                string tTeacher = "";
                while (reader.Read())
                {
                    if(reader["grade"].ToString() =="0")
                    {
                        grade = "Отсутствовал";
                    }
                    else
                    {
                        grade = reader["grade"].ToString();
                    }

                    teacher = Convert.ToInt32(reader["teacher_user_id"]);
                    command_te = new SqlCommand("SELECT * FROM dbo.teacher WHERE teacher_id LIKE '%" + teacher + "'", studLoadTe.connection);
                    SqlDataReader reader_command_te = command_te.ExecuteReader();
                    SqlCommand command_teach_ft;
                    while (reader_command_te.Read())
                    {
                        teacherUid = Convert.ToInt32(reader_command_te["user_id"]);
                        command_teach_ft = new SqlCommand("SELECT * FROM users WHERE user_id LIKE '%" + teacherUid.ToString() + "'", studLoadUse.connection);
                        SqlDataReader reader_teach_ft = command_teach_ft.ExecuteReader();
                        while (reader_teach_ft.Read())
                        {
                            tTeacher = reader_teach_ft["familija"].ToString() + " " + reader_teach_ft["imja"].ToString() + " " + reader_teach_ft["otchestvo"].ToString();
                        }
                        reader_teach_ft.Close();
                    }
                    result += "<tr> <td>" + reader["subject_id"].ToString() + "</td>";
                    result += " <td>" + tTeacher + "</td>";
                    result += " <td>" + grade + "</td>";
                    result += " <td>" + reader["date_a"].ToString() + "</td>";
                    result += " <td>" + reader["date_b"].ToString() + "</td>";
                    result += " <td>" + reader["note"].ToString() + "</td>";
                    result += "</tr>";
                    reader_command_te.Close();
                }
                result += "</ table >";
                Label2.Text = "Оценки ученика:" + result;
                reader.Close();
                studLoad.connection.Close();
                studLoadUse.connection.Close();
                studLoadTe.connection.Close();
                //----------
                studLoad.connection.Open();
                studLoadSid.connection.Open();
                studLoadTuid.connection.Open();
                string result_hw = "";
                string today = DateTime.Now.ToShortDateString();
                SqlCommand hw_command = new SqlCommand("SELECT * FROM dbo.homework WHERE groupp_id LIKE '%" + groupp_id + "' AND time > '"+today+ "'  ORDER BY time ASC", studLoad.connection);
                SqlDataReader hw_reader = hw_command.ExecuteReader();
                SqlCommand command_sid;
                SqlCommand command_tuid;
                result_hw += "<table> <tr><td>Предмет</td><td>Преподаватель</td> <td>Домашнее задание</td><td>Время занятия</td></tr>";
                string sid, tuid;
                while(hw_reader.Read())
                {
                    sid = hw_reader["subject_id"].ToString();
                    tuid = hw_reader["teacher_user_id"].ToString();
                    command_sid = new SqlCommand("SELECT * FROM dbo.subject WHERE subject_id LIKE '%" +sid+"'", studLoadSid.connection);
                    command_tuid = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + tuid + "'", studLoadTuid.connection);
                    SqlDataReader reader_command_sid = command_sid.ExecuteReader();
                    while(reader_command_sid.Read())
                    {
                        sid = reader_command_sid["subject_name"].ToString();
                    }
                    SqlDataReader reader_command_tuid = command_tuid.ExecuteReader();
                    while (reader_command_tuid.Read())
                    {
                        tuid = reader_command_tuid["familija"].ToString() + " "+ reader_command_tuid["imja"].ToString() + " "+ reader_command_tuid["otchestvo"].ToString();
                    }
                    result_hw += " <td>" + sid + "</td>";
                    result_hw += " <td>" + tuid + "</td>";
                    result_hw += " <td>" + hw_reader["homework_text"].ToString() + "</td>";
                    result_hw += " <td>" + hw_reader["time"].ToString() + "</td>";
                    result_hw += "</tr>";
                }
                result_hw += "</ table >";
                Label3.Text = "Домашнее задание, для вашей группы: " +result_hw;
                studLoad.connection.Close();
                studLoadSid.connection.Close();
                studLoadTuid.connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Value"] = uId;
            Server.Transfer("Message.aspx", true);
        }
    }
}