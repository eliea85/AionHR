using AionHR.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Infrastructure.Session;
using AionHR.Model.MasterModule;
using AionHR.Services.Messaging;
using AionHR.Services.Messaging.System;
using AionHR.Infrastructure.WebService;

namespace AionHR.Services.Implementations
{
    public class MasterService : BaseService,IMasterService
    {
        private IAccountRepository _accountRepository;
        public MasterService(IAccountRepository accountRepository, SessionHelper helper):base(helper)
        {
            _accountRepository = accountRepository;
        }



        public Response<Account> GetAccount(AuthenticateRequest request)
        {
            Response<Account> response = new Response<Account>();
            SessionHelper.Set("AccountId", "0"); //To be checked as it is a strange behavior ( simulated from old code)
            Dictionary<string, string> headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("_accountName", request.Account);

            RecordWebServiceResponse<Account> accountRecord = _accountRepository.GetRecord("getAC", headers, parameters);
            if (accountRecord == null)
            {
                response.Success = false;
                response.Message = "RequestError"; //This message have to be read from resource, it indicate that there was a problem in the connection.
                return response;
            }
            if (accountRecord.record == null)
            {
                response.Success = false;
                response.Message = "InvalidAccount";
                return response;
            }
            response.result = accountRecord.record;
            response.Success = true;
            return response;
        }
    }
}
