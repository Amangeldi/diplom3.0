using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_portal
{
    public partial class Parent1 : System.Web.UI.Page
    {
        string FIO = null, sUser_id = null, STN = null, sFIO = null;

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Value"] = uId;
            Server.Transfer("Message.aspx", true);
        }

        int uId;
        protected void Button1_Click(object sender, EventArgs e)
        {
            ConnOpen journal = new ConnOpen();
            journal.connection.Open();
            string command_journal = "UPDATE dbo.journal SET status = '1' WHERE student_ticket_number = '"+STN+"'";
            using (SqlCommand cmd = new SqlCommand(command_journal,journal.connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ConnOpen parentLoad = new ConnOpen();
            ConnOpen journalLoad = new ConnOpen();
            if (Session["Value"] != null)
            {
                parentLoad.connection.Open();
                int id = Convert.ToInt32(Session["Value"]);
                uId = Convert.ToInt32(Session["Value"]);
                Label1.Text = id.ToString();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + id + "'", parentLoad.connection);
                SqlDataReader dr = sqlCom.ExecuteReader();
                dr.Read();
                FIO = dr["familija"].ToString() + " " + dr["imja"].ToString() + " " + dr["otchestvo"].ToString();
                Label1.Text = "Здравствуйте " + FIO + " Вы родитель ученика ";
                parentLoad.connection.Close();
                parentLoad.connection.Open();
                SqlCommand sqlComId = new SqlCommand("SELECT * FROM dbo.parent WHERE user_id LIKE '%" + id + "'", parentLoad.connection);
                SqlDataReader drId = sqlComId.ExecuteReader();
                drId.Read();
                STN = drId["student_ticket_number"].ToString();
                parentLoad.connection.Close();
                parentLoad.connection.Open();
                SqlCommand sqlComSTN = new SqlCommand("SELECT * FROM dbo.student WHERE student_ticket_number LIKE '%" + STN + "'", parentLoad.connection);
                SqlDataReader drSTN = sqlComSTN.ExecuteReader();
                drSTN.Read();
                sUser_id = drSTN["user_id"].ToString();
                parentLoad.connection.Close();
                parentLoad.connection.Open();
                SqlCommand sqlComAll = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + sUser_id + "'", parentLoad.connection);
                SqlDataReader drAll = sqlComAll.ExecuteReader();
                drAll.Read();
                sFIO = drAll["familija"].ToString() + " " + drAll["imja"].ToString() + " " + drAll["otchestvo"].ToString();
                Label1.Text += sFIO;
                parentLoad.connection.Close();
                //-----------------
                journalLoad.connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.journal WHERE student_ticket_number LIKE '%" + STN + "' AND (status LIKE '0' OR status LIKE 'NULL')", journalLoad.connection);
                SqlDataReader reader = command.ExecuteReader();
                string result = "", grade="";
                result += "<table> <tr><td>id</td><td>Предмет</td><td>Преподаватель</td> <td>Оценка</td><td>Время выставления оценки</td><td>Время проведение работ</td><td>Комментарий к оценке</td> </tr>";
                while (reader.Read())
                {
                    if (reader["grade"].ToString() == "0")
                    {
                        grade = "Отсутствовал";
                    }
                    else
                    {
                        grade = reader["grade"].ToString();
                    }
                    result += "<tr> <td>" + reader["journal_id"].ToString() + "</td>";
                    result += "<td>" + reader["subject_id"].ToString() + "</td>";
                    result += " <td>" + reader["teacher_user_id"].ToString() + "</td>";
                    result += " <td>" + grade + "</td>";
                    result += " <td>" + reader["date_a"].ToString() + "</td>";
                    result += " <td>" + reader["date_b"].ToString() + "</td>";
                    result += " <td>" + reader["note"].ToString() + "</td>";
                    result += "</tr>";
                }
                result += "</ table >";
                Label2.Text = "Оценки ученика "+sFIO+":" + result;
                reader.Close();
                journalLoad.connection.Close();
            }
        }
    }
}