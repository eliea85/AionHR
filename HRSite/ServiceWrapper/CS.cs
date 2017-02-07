using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSite.Classes;
using HRSite.Requests;
using HRSite.Responses;

namespace HRSite.ServiceLayer
{
    public class CS
    {
        public static List<Department> GetDepartments()
        {
            AuthenticatedServiceRequest<ServiceListResponse<Department>> req = new Requests.AuthenticatedServiceRequest<ServiceListResponse<Department>>("http://webservices.aionhr.net/CS.asmx/qryDE");
            req.QueryStringParams.Add("_filter", "");
            ServiceListResponse<Department> s = req.GetAsync();
            return s.GetAll();
        }
    }
}