using HRSite.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace HRSite.Requests
{
    public class AuthenticatedServiceRequest<T> : ServiceRequest<T>
    {
        public AuthenticatedServiceRequest(string url) : base(url)
        {

        }

        public AuthenticatedServiceRequest(string url, CustomResolver res) : base(url, res)
        {

        }

        protected override void BuildAuthorizationHeaders(WebRequest req)
        {
            Dictionary<string, string> headers = UserManager.GetAuthorizationHeadersForCurrentUser();
            foreach (var item in headers)
            {
                    req.Headers.Add(item.Key, item.Value);
            }
        }
    }
}