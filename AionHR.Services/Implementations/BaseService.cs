using AionHR.Infrastructure.Session;
using AionHR.Infrastructure.WebService;
using AionHR.Services.Interfaces;
using AionHR.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Implementations
{
    /// <summary>
    /// Base service used to hold all common properties and common service methods
    /// </summary>
    public abstract class BaseService 
    {
        public SessionHelper SessionHelper { get; set; }
        public BaseService(SessionHelper sessionHelper)
        {
            SessionHelper = sessionHelper;
        }

        protected T CreateServiceResponse<T>(BaseWebServiceResponse webResponse) where T :ResponseBase,new()
        {
            T response =new T();
            response.Success = webResponse!=null && webResponse.statusId == "1";
            return response;
        }
    }
}
