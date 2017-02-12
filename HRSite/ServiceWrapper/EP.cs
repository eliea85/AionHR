using HRSite.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSite.Classes;
using HRSite.Responses;

namespace HRSite.ServiceLayer
{
    public class EP
    {
        public static string serviceUrl;

        private static string qryES = "qryES";
        private static string getEM = "getEM";
        public static List<Employee> GetEmployees(int count, int startAt, out int total)
        {
            AuthenticatedServiceRequest<ServiceListResponse<Employee>> req = new Requests.AuthenticatedServiceRequest<ServiceListResponse<Employee>>(serviceUrl+qryES);
            req.QueryStringParams.Add("_filter", "");
            req.QueryStringParams.Add("_size", count.ToString());
            req.QueryStringParams.Add("_startAt", startAt.ToString());
            ServiceListResponse<Employee> s = req.GetAsync();
            total = s.viewCount;
            return s.GetAll();
        }

        public static Employee GetEmployee(string empId)
        {
            AuthenticatedServiceRequest<SingleItemServiceResponse<Employee>> req = new AuthenticatedServiceRequest<SingleItemServiceResponse<Employee>>(serviceUrl+getEM);
            req.QueryStringParams.Add("_recordId", empId);
            var s = req.GetAsync();
            return s.record;
        }
    }
}