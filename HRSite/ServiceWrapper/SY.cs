using HRSite.Models;
using HRSite.Requests;
using HRSite.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.ServiceWrapper
{
    public class SY
    {
        internal static string serviceUrl;

        private static string signIn = "signIn";
        private static string getAC = "getAC";
        private static string qryNA = "qryNA";

        public static UserInfo Signin(string accountName, string email, string password)
        {
            try
            {
                AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>> request = new AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>>(serviceUrl+getAC);

                request.QueryStringParams.Add("_accountName", accountName);

                HttpContext.Current.Session["AccountId"] = "0";
                var r1 = request.GetAsync();
                if (r1.statusId != "1")
                    return null;
                UserInfo firstResponse = r1.record;
                AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>> secondRequest = new AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>>(serviceUrl + signIn);
                secondRequest.QueryStringParams.Add("_email", email);
                secondRequest.QueryStringParams.Add("_password", password);
                HttpContext.Current.Session["AccountId"] = firstResponse.accountId;
                var r2 = secondRequest.GetAsync();
                if (r2.statusId != "1")
                    return null;
                UserInfo response = r2.record;
                return response;
            }
            catch
            {
                return null;
            }
        }

        public static List<Nationality> GetNationalities()
        {
            AuthenticatedServiceRequest<ServiceListResponse<Nationality>> req = new Requests.AuthenticatedServiceRequest<HRSite.ServiceListResponse<Models.Nationality>>(serviceUrl+qryNA);
            req.QueryStringParams.Add("_filter", "");
            var s= req.GetAsync() ;
            if (s.statusId != "1")
                return null;
            return s.GetAll();
        }
    }
}