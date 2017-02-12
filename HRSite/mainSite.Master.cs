using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSite
{
    public partial class mainSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserManager.CheckUserLoggedIn())
                logoutButton.Visible = false;

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            UserManager.Logout();
            Response.Redirect("~/Login.aspx");
        }
    }
}