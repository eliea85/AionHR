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
            EmployeeListRequest req = new EmployeeListRequest();
            req.Size = prms.Limit.ToString();
            req.StartAt = prms.Start.ToString();
            
            req.DepartmentId = "0";
            req.BranchId = "0";
            req.IncludeIsInactive = true;
            req.SortBy = "firstName";

            req.StartAt = "1";
            req.Size = "20";
          
            req.Filter = "";
            ListResponse<Employee> response = null;// _employeeService.GetAll<Employee>(req);
            var data = response.Items;
            total = response.Count;
            return new { data, total };
        }
    }
}