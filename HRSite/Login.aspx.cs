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
            
        }
        
        protected void login_Click(object sender, EventArgs e)
        {


            //ServiceRequest<UserInfo> request = new HRSite.ServiceRequest<UserInfo>("http://webservices.aionhr.net/SY.asmx/signIn");

            //request.QueryStringParams.Add("_accountName", accountName.Text);
            //request.QueryStringParams.Add("_email", email.Text);
            //request.QueryStringParams.Add("_password", password.Text);
            //UserInfo response = request.GetAsync();
            UserInfo response = SY.Signin2(accountName.Text, email.Text, password.Text); 
            if (response.recordId == null)
            {
                X.Msg.Alert("Error", "Login failed", new JFunction { }).Show();
                return;
            }
           
            UserManager.LoginUser(response);
            Response.Redirect("~/Home.aspx");
        }

      

   
    }
}