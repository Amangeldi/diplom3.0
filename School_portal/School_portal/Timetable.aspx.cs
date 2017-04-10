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
        protected void Page_Load(object sender, EventArgs e)
        {
            string sName = "";
            ConnOpen tLoad = new ConnOpen();
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
                    while(reader_subject.Read())
                    {
                        sName = reader_subject["subject_name"].ToString();
                        DropDownList1.Items.Add(new ListItem(sName, reader_subject["subject_id"].ToString()));
                    }
                    tLoad.connection.Close();
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}