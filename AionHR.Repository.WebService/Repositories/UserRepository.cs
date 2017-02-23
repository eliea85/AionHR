using AionHR.Infrastructure.Configuration;
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
    public class UserRepository : Repository<UserInfo, string>, IUserRepository,ICommonRepository
    {
        
       // the webservice name       
        private string serviceName = "SY.asmx/";
        public UserRepository()
        {            
            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName ;            
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
