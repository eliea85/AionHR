using Ext.Net;
using HRSite.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace HRSite
{
    public class ServiceRequest<T>
    {
        private string url;

        private CustomResolver resolver;

        private Dictionary<string, string> additionalHeaders;
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public Dictionary<string, string> QueryStringParams
        {
            get
            {
                return queryStringParams;
            }

            set
            {
                queryStringParams = value;
            }
        }

        public ServiceRequest(string url)
        {
            this.url = url;
            queryStringParams = new Dictionary<string, string>();
            additionalHeaders = new Dictionary<string, string>();
        }

        public ServiceRequest(string url, CustomResolver resolver) : this(url)
        {
            this.resolver = resolver;
        }

        private Dictionary<string, string> queryStringParams;

        public string requestUrl
        {
            get
            {
                string res = url + "?";
                foreach (var item in queryStringParams)
                {
                    res = res + item.Key + "=" + item.Value + "&";
                }
                res = res.Remove(res.Length - 1);
                return res;
            }
        }

        public CustomResolver Resolver
        {
            get
            {
                return resolver;
            }

            set
            {
                resolver = value;
            }
        }

        protected virtual void BuildAuthorizationHeaders(WebRequest req)
        {
           
        }

        public void AddAdditionalHeader(string key, string value)
        {
            additionalHeaders.Add(key, value);
        }

        protected void BuildAdditionalHeaders(WebRequest req)
        {
            foreach (var item in additionalHeaders)
            {
                req.Headers.Add(item.Key, item.Value);
            }
        }
        public T GetAsync()
        {
            WebRequest req = HttpWebRequest.Create(requestUrl);
            //WebProxy p = new WebProxy("proxy.tishreen.net",8080);
            //p.Credentials = new NetworkCredential("user16@26", "R3DU");
            //req.Credentials = p.Credentials;
            //req.Proxy = p;
            req.Method = "GET";
            BuildAuthorizationHeaders(req);
            if (additionalHeaders.Count > 0)
                BuildAdditionalHeaders(req);
            var r = req.GetResponse();
            Stream s = r.GetResponseStream();
            StreamReader reader = new StreamReader(s, true);
            string x = reader.ReadToEnd();

            var settings = JSON.GlobalSettings;
            if (resolver != null)
            {
                settings = new JsonSerializerSettings();

                settings.ContractResolver = resolver;

            }
            settings.NullValueHandling = NullValueHandling.Ignore;
            T response = JSON.Deserialize<T>(x, settings);

            return response;

        }


    }
}