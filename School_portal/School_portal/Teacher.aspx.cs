using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_portal
{
    public partial class Teacher1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnOpen teachLoad = new ConnOpen();
            if(Session["Value"] != null)
            {
                teachLoad.connection.Open();

                teachLoad.connection.Close();
            }
        }
    }
}