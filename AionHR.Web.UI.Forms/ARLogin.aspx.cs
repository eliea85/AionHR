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
    public partial class ARLogin : Page
    {



        ISystemService _systemService = ServiceLocator.Current.GetInstance<ISystemService>();
        IMasterService _masterService = ServiceLocator.Current.GetInstance<IMasterService>();
        private TextField sender;

        protected override void InitializeCulture()
        {

            base.InitializeCulture();
            //User came to arabic login so set the language to arabic           
            _systemService.SessionHelper.SetLanguage("ar");
            LocalisationManager.Instance.SetArabicLocalisation();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["timeout"] != null && Request.QueryString["timeout"].ToString() == "yes")
            {
                //lblError.Text = Resources.Common.SessionDisconnected;
            }
            if (!IsPostBack && Request.QueryString["account"] != null)
            {
                tbAccountName.Text = Request.QueryString["account"];
                DirectCheckField(tbAccountName.Text);
            }
           
            SetExtLanguage();
            if (!X.IsAjaxRequest)
            {
                ResourceManager1.RegisterIcon(Icon.Tick);
                ResourceManager1.RegisterIcon(Icon.Error);
            }

        }

        private void SetExtLanguage()
        {
            
                this.ResourceManager1.RTL = true;
                this.Viewport1.RTL = true;

           
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
                if (response.User.languageId == "3")
                    _systemService.SessionHelper.SetLanguage("ar");
                else
                    _systemService.SessionHelper.SetLanguage("en");

                Response.Redirect("Default.aspx", true);

            }
            else
            {
                lblError.Text = (String)GetLocalResourceObject(response.Message);
                
            }
        }

        protected void CheckField(object sender, RemoteValidationEventArgs e)
        {
            TextField field = (TextField)sender;
            AuthenticateRequest request = new AuthenticateRequest();
            request.Account = field.Text;

            Response<Account> response = _masterService.GetAccount(request);

            if (response.Success)
            {

                e.Success = true;
                field.IndicatorTip = (String)GetLocalResourceObject("AccountValid");
            }
            else
            {


                e.Success = false;
                e.ErrorMessage = (String)GetLocalResourceObject(response.Message); 

            }

            System.Threading.Thread.Sleep(500);

        }
        public object DirectCheckField(string value)
        {
            //return true;
            AuthenticateRequest request = new AuthenticateRequest();
            request.Account = value;

            Response<Account> response = _masterService.GetAccount(request);

            if (response.Success)
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
        protected void forgotpw_Event(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgotPassword.aspx");

        }
    }
}