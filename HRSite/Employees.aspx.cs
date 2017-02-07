using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext;
using Ext.Net;
using System.IO;
using System.Net;
using HRSite.Requests;
using HRSite.ServiceLayer;
using HRSite.Classes;
namespace HRSite
{
    public class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserManager.CheckUserLoggedIn())
                Response.Redirect("~/Login.aspx");
        }
        
        [DirectMethod]
        public object BindData(string action, Dictionary<string, object> extraParams)
        {
            
                
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);

            int total;
            
            List<Employee> data = EP.GetEmployees(prms.Limit, prms.Start, out total);

            return new { data, total };
        }
    }
}