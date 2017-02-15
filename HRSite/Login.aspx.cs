using Ext.Net;
using HRSite.Responses;
using HRSite.ServiceWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserManager.CheckUserLoggedIn())
                Response.Redirect("~/Home.aspx");
        }
        
        protected void login_Click(object sender, EventArgs e)
        {
            UserInfo response = SY.Signin(accountName.Text, email.Text, password.Text); 
            if (response==null|| response.recordId == null)
            {
                X.Msg.Alert("Authentication Error", "Please check your information and try again", new JFunction { }).Show();
                Session.Clear();
                return;
            }
           
            UserManager.LoginUser(response);
            Response.Redirect("~/Home.aspx");

        }
        
   
    }
}