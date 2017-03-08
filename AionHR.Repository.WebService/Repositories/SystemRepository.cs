﻿using AionHR.Infrastructure.Configuration;
using AionHR.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Infrastructure.WebService;
using AionHR.Infrastructure.Domain;

namespace AionHR.Repository.WebService.Repositories
{
    /// <summary>
    /// Class that handle the communcation between the model and the webservice. it encapsultes all the user relative methods
    /// </summary>
    public class SystemRepository : Repository<UserInfo, string>, ISystemRepository,ICommonRepository
    {
        
       // the webservice name       
        private string serviceName = "SY.asmx/";
        public SystemRepository()
        {            
            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName ;

            ChildAddOrUpdateLookup.Add(typeof(Nationality), "setNA");
            ChildGetAllLookup.Add(typeof(Nationality), "qryNA");
            ChildGetLookup.Add(typeof(Nationality), "getNA");
            ChildAddOrUpdateLookup.Add(typeof(Currency), "setCU");
            ChildGetAllLookup.Add(typeof(Currency), "qryCU");
            ChildGetLookup.Add(typeof(Currency), "getCU");
            ChildAddOrUpdateLookup.Add(typeof(UserInfo), "setUS");
            ChildGetAllLookup.Add(typeof(UserInfo), "qryUS");
            ChildGetLookup.Add(typeof(UserInfo), "getUS");

            ChildDeleteLookup.Add(typeof(Nationality) ,"delNA");
            ChildDeleteLookup.Add(typeof(UserInfo), "delUS");
        }

        public RecordWebServiceResponse<UserInfo> Authenticate(Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + "signIn";
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;

            return request.GetAsync<RecordWebServiceResponse<UserInfo>>();

        }

        public RecordWebServiceResponse<UserInfo> RequestPasswordRecovery(Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + "reqPW";
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;

            return request.GetAsync<RecordWebServiceResponse<UserInfo>>();

        }

        public RecordWebServiceResponse<UserInfo> ResetPassword(Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + "resetPW";
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;

            return request.GetAsync<RecordWebServiceResponse<UserInfo>>();

        }




    }
}
