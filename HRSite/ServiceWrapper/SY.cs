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
        public static UserInfo Signin(string accountName,string email,string password)
        {
            ServiceRequest<UserInfo> request = new HRSite.ServiceRequest<UserInfo>("http://webservices.aionhr.net/SY.asmx/signIn");

            request.QueryStringParams.Add("_accountName", accountName);
            request.QueryStringParams.Add("_email", email);
            request.QueryStringParams.Add("_password", password);
            UserInfo response = request.GetAsync();
            return response;
        }
        public static UserInfo Signin2(string accountName, string email, string password)
        {
            AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>> request = new AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>>("http://webservices.aionhr.net/SY.asmx/getAC");
            
            request.QueryStringParams.Add("_accountName", accountName);

            HttpContext.Current.Session["AccountId"] = "0";

            UserInfo firstResponse = request.GetAsync().record;
            AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>> secondRequest = new AuthenticatedServiceRequest<SingleItemServiceResponse<UserInfo>>("http://webservices.aionhr.net/SY.asmx/signIn");
            secondRequest.QueryStringParams.Add("_email", email);
            secondRequest.QueryStringParams.Add("_password", password);
            HttpContext.Current.Session["AccountId"] = firstResponse.accountId;
            
            UserInfo response = secondRequest.GetAsync().record;
            return response;
        }
    }
}