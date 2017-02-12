using HRSite.Models;
using HRSite.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.ServiceWrapper
{
    public class TA
    {
        internal static string serviceUrl;
        private static string qryCA = "qryCA";
        public static List<WorkingCalendar> GetCalendars()
        {
            AuthenticatedServiceRequest<ServiceListResponse<WorkingCalendar>> req = new Requests.AuthenticatedServiceRequest<ServiceListResponse<WorkingCalendar>>(serviceUrl+qryCA);
            req.QueryStringParams.Add("_filter", "");
            ServiceListResponse<WorkingCalendar> s = req.GetAsync();
            return s.GetAll();
        }

       


    }
}