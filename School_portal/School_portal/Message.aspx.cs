using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_portal
{
    public partial class Message : System.Web.UI.Page
    {
        string sender = "";
        int uId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            uId = Convert.ToInt32(Session["Value"]);
            ConnOpen messageLoad = new ConnOpen();
            if (Session["Value"] != null)
            {
                messageLoad.connection.Open();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM dbo.users WHERE user_id LIKE '%" + uId + "'", messageLoad.connection);
                SqlDataReader dr = sqlCom.ExecuteReader();
                dr.Read();
                sender = dr["familija"].ToString() + " " + dr["imja"].ToString() + " " + dr["otchestvo"].ToString();
                Label1.Text = "Здравствуйте " + sender;
                messageLoad.connection.Close();
                //----------
                messageLoad.connection.Open();
                SqlCommand command_nm = new SqlCommand("SELECT * FROM dbo.message WHERE adressee LIKE '%"+uId+"' AND status LIKE '0'", messageLoad.connection);
                SqlDataReader reader_nm = command_nm.ExecuteReader();
                string result_nm = "";
                result_nm += "<table> <tr><td>Отправитель</td><td>текст</td></tr>";
                while(reader_nm.Read())
                {
                    result_nm += "<tr> <td>" + reader_nm["sender"].ToString() + "</td>";
                    result_nm += "<td>" + reader_nm["text"].ToString() + "</td>";
                    result_nm += "</tr>";
                }
                result_nm += "</ table >";
                Label4.Text = result_nm;
                reader_nm.Close();
                messageLoad.connection.Close();
                //----------
                messageLoad.connection.Open();
                SqlCommand command_old = new SqlCommand("SELECT * FROM dbo.message WHERE adressee LIKE '%" + uId + "' AND status LIKE '1'", messageLoad.connection);
                SqlDataReader reader_old = command_old.ExecuteReader();
                string result_old = "";
                result_old += "<table> <tr><td>Отправитель</td><td>текст</td></tr>";
                while (reader_old.Read())
                {
                    result_old += "<tr> <td>" + reader_old["sender"].ToString() + "</td>";
                    result_old += "<td>" + reader_old["text"].ToString() + "</td>";
                    result_old += "</tr>";
                }
                result_old += "</ table >";
                Label5.Text = result_old;
                reader_old.Close();
                messageLoad.connection.Close();
                //----------
                messageLoad.connection.Open();
                SqlCommand command_o = new SqlCommand("SELECT * FROM dbo.message WHERE sender LIKE '%" + uId + "'", messageLoad.connection);
                SqlDataReader reader_o = command_o.ExecuteReader();
                string result_o = "";
                result_o += "<table> <tr><td>Отправитель</td><td>текст</td><td>Получатель</td></tr>";
                while (reader_o.Read())
                {
                    result_o += "<tr> <td>" + reader_o["sender"].ToString() + "</td>";
                    result_o += "<td>" + reader_o["text"].ToString() + "</td>";
                    result_o += "<td>" + reader_o["adressee"].ToString() + "</td>";
                    result_o += "</tr>";
                }
                result_o += "</ table >";
                Label3.Text = result_o;
                reader_o.Close();
                messageLoad.connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            ConnOpen message = new ConnOpen();
            message.connection.Open();
            SqlCommand command_adressee;
            SqlDataReader reader_adressee;
            if (DropDownList1.SelectedValue == "0")
            {
                command_adressee = new SqlCommand("SELECT * FROM dbo.users WHERE user_id != '" + uId.ToString() + "'", message.connection);
            }
            else
            {
                command_adressee = new SqlCommand("SELECT * FROM dbo.users WHERE user_id != '" + uId.ToString() + "' AND role LIKE '"+DropDownList1.SelectedValue+"'", message.connection);
            }
            reader_adressee = command_adressee.ExecuteReader();
            string adresse = "";
            while(reader_adressee.Read())
            {
                adresse = reader_adressee["familija"].ToString() + " " + reader_adressee["imja"].ToString() + " " + reader_adressee["otchestvo"].ToString();
                DropDownList2.Items.Add(new ListItem(adresse, reader_adressee["user_id"].ToString()));
            }
            message.connection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string text = TextBox1.Text.Replace("\n", "<br />");
            //Label3.Text +="<br />"+ text.Replace("\n","<br />");
            Message sb = new Message();
            sb.add(uId, Convert.ToInt32(DropDownList2.SelectedValue), text);
        }
    }
}