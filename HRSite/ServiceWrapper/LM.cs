using HRSite.Models;
using HRSite.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.ServiceWrapper
{
    public class LM
    {
        internal static string serviceUrl;

        private static string qryVS = "qryVS";
        public static List<VacationSchedule> GetVacations()
        {
            
            AuthenticatedServiceRequest<ServiceListResponse<VacationSchedule>> req = new Requests.AuthenticatedServiceRequest<ServiceListResponse<VacationSchedule>>(serviceUrl+qryVS);
            req.QueryStringParams.Add("_filter", "");
            ServiceListResponse<VacationSchedule> s = req.GetAsync();
            return s.GetAll();
        }
    }
}