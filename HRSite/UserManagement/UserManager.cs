using HRSite.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HRSite
{
    public class UserManager
    {
        private static ITokenGenerator generator = new APIKeyBasedTokenGenerator();
        public static Dictionary<string, string> GetAuthorizationHeadersForCurrentUser()
        {
            if (!CheckUserLoggedIn())
                return GetAuthorizationHeadersForApp();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Basic " + HttpContext.Current.Session["key"]);
            headers.Add("AccountId", "" + HttpContext.Current.Session["AccountId"]);
            headers.Add("UserId", HttpContext.Current.Session["UserId"].ToString());
            return headers;
        }

        public static Dictionary<string, string> GetAuthorizationHeadersForApp()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Basic " + GetTokenForUser(HttpContext.Current.Session["AccountId"].ToString(),"0"));
            headers.Add("AccountId", HttpContext.Current.Session["AccountId"].ToString());
            headers.Add("UserId", "0");
            return headers;
        }

        public static bool CheckUserLoggedIn()
        {
            if (HttpContext.Current.Session["key"] == null || HttpContext.Current.Session["AccountId"] == null || HttpContext.Current.Session["UserId"] == null)
                return false;
            else return true;
        }

        public static string GetTokenForUser(string accountId,string userId)
        {
            APIKeyBasedTokenGenerator gen = new APIKeyBasedTokenGenerator();
            gen.AccountId = accountId;
            gen.UserId = userId;
            string hashedKey = gen.GetUserToken();
            return hashedKey;
        }

        public static void LoginUser(UserInfo response)
        {
            if (response.recordId == null)
                throw new UnauthorizedAccessException();

            string accountId = HttpContext.Current.Session["AccountId"].ToString();
            string hashedKey = GetTokenForUser(accountId, response.recordId);
            HttpContext.Current.Session.Add("UserId", response.recordId);
            HttpContext.Current.Session.Add("key", hashedKey);

        }

        public static UserInfo GetUserFromSession()
        {
            if (!CheckUserLoggedIn())
                throw new UnauthorizedAccessException();
            UserInfo info = new HRSite.UserInfo();
            info.accountId = HttpContext.Current.Session["AccountId"].ToString();
            info.recordId = HttpContext.Current.Session["UserId"].ToString();
            return info;
        }


    }
}