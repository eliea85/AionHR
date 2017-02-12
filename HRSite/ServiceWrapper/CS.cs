using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSite.Classes;
using HRSite.Requests;
using HRSite.Responses;
using HRSite.Models;

namespace HRSite.ServiceLayer
{
    public class CS
    {
        public static string serviceUrl;
        private const string qryDE = "qryDE";
        private const string qryBR = "qryBR";
        private const string qryPO = "qryPO";
        public static List<Department> GetDepartments()
        {
            
            AuthenticatedServiceRequest<ServiceListResponse<Department>> req = new Requests.AuthenticatedServiceRequest<ServiceListResponse<Department>>(serviceUrl + qryDE);
            req.QueryStringParams.Add("_filter", "");
            ServiceListResponse<Department> s = req.GetAsync();
            return s.GetAll();
        }
        public static List<Branch> GetBranches()
        {
            
            AuthenticatedServiceRequest<ServiceListResponse<Branch>> req = new Requests.AuthenticatedServiceRequest<ServiceListResponse<Branch>>(serviceUrl + qryBR);
            req.QueryStringParams.Add("_filter", "");
            ServiceListResponse<Branch> s = req.GetAsync();
            return s.GetAll();
        }
        public static List<Position> GetPositions()
        {

            AuthenticatedServiceRequest<ServiceListResponse<Position>> req = new Requests.AuthenticatedServiceRequest<ServiceListResponse<Position>>(serviceUrl + qryPO);
            req.QueryStringParams.Add("_filter", "");
            ServiceListResponse<Position> s = req.GetAsync();
            return s.GetAll();
        }
    }
}