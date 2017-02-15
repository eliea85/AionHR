using AionHR.Infrastructure.Configuration;
using AionHR.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Infrastructure.WebService;

namespace AionHR.Repository.WebService.Repositories
{
    /// <summary>
    /// Class that handle the communcation between the model and the webservice. it encapsultes all the user relative methods
    /// </summary>
    public class UserRepository : Repository<UserInfo, string>, IUserRepository
    {
        
       // the webservice name       
        private string serviceName = "SY.asmx/";
        public UserRepository()
        {            
            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName ;            
        }

      
    }
}
