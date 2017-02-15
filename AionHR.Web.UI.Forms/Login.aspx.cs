using AionHR.Services.Implementations;
using AionHR.Services.Interfaces;
using AionHR.Services.Messaging.System;
using Ext.Net;
using Microsoft.Practices.ServiceLocation;
using StructureMap.Attributes;
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

namespace AionHR.Web.UI.Forms
{
    public partial class Login : Page
    {

       ISystemService _systemService = ServiceLocator.Current.GetInstance<ISystemService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void login_Click(object sender, EventArgs e)
        {
            AuthenticateRequest request = new AuthenticateRequest();
            request.Account = accountName.Text;
            request.UserName = email.Text;
            request.Password = password.Text;
            AuthenticateResponse response = _systemService.Authenticate(request);
            if (response.Success)
            {
                X.Msg.Alert("Success", "Testing").Show();
            }
            else
            {
                X.Msg.Alert("Error", response.Message).Show();
                return;
            }          
        }

      

   
    }
}