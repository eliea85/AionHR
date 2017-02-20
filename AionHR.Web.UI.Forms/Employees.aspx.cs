using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext;
using Ext.Net;
using System.IO;
using System.Net;
using AionHR.Model.Employees;
using AionHR.Services.Messaging;
using AionHR.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using AionHR.Model.Employees.Profile;

namespace AionHR.Web.UI.Forms
{
    public class Employees : System.Web.UI.Page
    {
        IEmployeeService _employeeService = ServiceLocator.Current.GetInstance<IEmployeeService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
           
        }
        
        [DirectMethod]
        public object BindData(string action, Dictionary<string, object> extraParams)
        {
            
                
            StoreRequestParameters prms = new StoreRequestParameters(extraParams);

            int total;
            ListRequest req = new ListRequest();
            req.Size = prms.Limit.ToString();
            req.StartAt = prms.Start.ToString();
            req.QueryStringParams.Add("_departmentId", "0");
            req.QueryStringParams.Add("_branchId", "0");
            req.QueryStringParams.Add("_includeInactive", "true");
            req.QueryStringParams.Add("_sortBy", "fullName");
            req.Filter = "";
            Response<List<Employee>> response = _employeeService.GetAll(req);
            var data = response.result;
            total = response.rowCount;
            return new { data, total };
        }
    }
}