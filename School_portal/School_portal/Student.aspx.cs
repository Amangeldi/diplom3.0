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
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnOpen studLoad = new ConnOpen();
            ConnOpen studLoadUse = new ConnOpen();
            if(Session["Value"] != null)
            {
                studLoad.connection.Open();
                int id = Convert.ToInt32(Session["Value"]);
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
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.journal WHERE student_ticket_number LIKE '%"+studId+"'", studLoad.connection);
                SqlDataReader reader = command.ExecuteReader();
                result += "<table> <tr><td>Предмет</td><td>Преподаватель</td> <td>Оценка</td><td>Время выставления оценки</td><td>Время проведение работ</td><td>Комментарий к оценке</td> </tr>";
                while(reader.Read())
                {
                    if(reader["grade"].ToString() =="0")
                    {
                        grade = "Отсутствовал";
                    }
                    else
                    {
                        grade = reader["grade"].ToString();
                    }
                    result += "<tr> <td>" + reader["subject_id"].ToString() + "</td>";
                    result += " <td>" + reader["teacher_user_id"].ToString() + "</td>";
                    result += " <td>" + grade + "</td>";
                    result += " <td>" + reader["date_a"].ToString() + "</td>";
                    result += " <td>" + reader["date_b"].ToString() + "</td>";
                    result += " <td>" + reader["note"].ToString() + "</td>";
                    result += "</tr>";
                }
                result += "</ table >";
                Label2.Text = "Оценки ученика:" + result;
                reader.Close();
                studLoad.connection.Close();
                //----------
                studLoad.connection.Open();
                string result_hw = "";
                string today = DateTime.Now.ToShortDateString();
                SqlCommand hw_command = new SqlCommand("SELECT * FROM dbo.homework WHERE groupp_id LIKE '%" + groupp_id + "' AND time > '"+today+ "'  ORDER BY time ASC", studLoad.connection);
                SqlDataReader hw_reader = hw_command.ExecuteReader();
                result_hw += "<table> <tr><td>Предмет</td><td>Преподаватель</td> <td>Домашнее задание</td><td>Время занятия</td></tr>";
                while(hw_reader.Read())
                {
                    result_hw += " <td>" + hw_reader["subject_id"].ToString() + "</td>";
                    result_hw += " <td>" + hw_reader["teacher_user_id"].ToString() + "</td>";
                    result_hw += " <td>" + hw_reader["homework_text"].ToString() + "</td>";
                    result_hw += " <td>" + hw_reader["time"].ToString() + "</td>";
                    result_hw += "</tr>";
                }
                result_hw += "</ table >";
                Label3.Text = "Домашнее задание, для вашей группы: " +result_hw;
                studLoad.connection.Close();
            }
        }
    }
}