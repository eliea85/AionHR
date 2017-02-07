using Ext.Net;
using HRSite.Classes;
using HRSite.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSite
{
    public partial class Depts : System.Web.UI.Page
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

            int total = 5;

            List<Department> data = CS.GetDepartments();

            return new { data};
        }
    }
}