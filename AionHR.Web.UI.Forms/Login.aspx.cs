using AionHR.Model.MasterModule;
using AionHR.Services.Implementations;
using AionHR.Services.Interfaces;
using AionHR.Services.Messaging;
using AionHR.Services.Messaging.System;
using AionHR.Web.UI.Forms.Utilities;
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
        IMasterService _masterService = ServiceLocator.Current.GetInstance<IMasterService>();

        protected override void InitializeCulture()
        {

            base.InitializeCulture();
            //User came to english login so set the language to english           
            _systemService.SessionHelper.SetLanguage("en");
            LocalisationManager.Instance.SetEnglishLocalisation();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["timeout"] != null && Request.QueryString["timeout"].ToString() == "yes")
            {
                lblError.Text = Resources.Common.SessionDisconnected;
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            AuthenticateRequest request = new AuthenticateRequest();
            request.Account = tbAccountName.Text;
            request.UserName = tbUsername.Text;
            request.Password = tbPassword.Text;
            AuthenticateResponse response = _systemService.Authenticate(request);
            if (response.Success)
            {
                //Redirecting..
                Response.Redirect("Default.aspx", true);
            }
            else
            {
                lblError.Text = (String)GetLocalResourceObject(response.Message);
                
            }
        }

        [DirectMethod]
        public object DirectCheckField(string value)
        {
            //return true;
            AuthenticateRequest request = new AuthenticateRequest();
            request.Account = value;

           Response<Account> response= _masterService.GetAccount(request);

            if(response.Success)
            {
                
                tbAccountName.IndicatorIcon = Icon.Accept;
                ResourceManager1.RegisterIcon(Icon.Accept);
                
            }
            else
            {
                tbAccountName.IndicatorIcon = Icon.Error;
                ResourceManager1.RegisterIcon(Icon.Error);

            }
            tbAccountName.ShowIndicator();
            return response.Success;
        }
        protected void CheckField(object sender, RemoteValidationEventArgs e)
        {
            TextField field = (TextField)sender;
            AuthenticateRequest request = new AuthenticateRequest();
            request.Account = field.Text;

            Response<Account> response = _masterService.GetAccount(request);

            if (response.Success)
            {

                tbAccountName.IndicatorIcon = Icon.Accept;
                ResourceManager1.RegisterIcon(Icon.Accept);
                e.Success = true;
            }
            else
            {
                tbAccountName.IndicatorIcon = Icon.Error;
                ResourceManager1.RegisterIcon(Icon.Error);
                e.Success = false;
                e.ErrorMessage = "Invalid Account";//should access local resources, just didn't figure how yet , only Resources.Common is accessible

            }
            tbAccountName.ShowIndicator();
            

            System.Threading.Thread.Sleep(500);
        }





    }
}