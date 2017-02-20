using AionHR.Infrastructure.Configuration;
using AionHR.Model.MasterModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Repository.WebService.Repositories
{
    /// <summary>
    /// Class that handle the communcation between the model and the webservice. it encapsultes all the account related methods
    /// </summary>
   public class AccountRepository :Repository<Account,string>, IAccountRepository
    {
        // the webservice name       
        private string serviceName = "MA.asmx/";
        public AccountRepository()
        {
            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName;
        }
    }
}
