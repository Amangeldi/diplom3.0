using System;
using System.Collections.Generic;
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
            ConnOpen tLoad = new ConnOpen();
            if (Session["Value"] != null)
            {
                int r = Convert.ToInt32(Session["Value"]);
                Label1.Text = r.ToString();
                if(r!=1)
                {
                    Panel1.Enabled = false;
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