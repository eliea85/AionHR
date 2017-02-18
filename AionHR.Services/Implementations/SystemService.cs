using AionHR.Infrastructure.Session;
using AionHR.Infrastructure.WebService;
using AionHR.Model.System;
using AionHR.Services.Interfaces;
using AionHR.Services.Messaging.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Implementations
{
    /// <summary>
    /// Class responsible for all operation of the system.
    /// </summary>
    public class SystemService :BaseService, ISystemService
    {
        
        private readonly IUserRepository _userRepository;
       // public readonly SessionHelper _sessionHelper;

        public SystemService(IUserRepository userRepository, SessionHelper sessionHelper) : base(sessionHelper)
        {
            _userRepository = userRepository;
           // _sessionHelper = sessionHelper;
        }

        /// <summary>
        /// The concrete method that authenticate a user request 
        /// </summary>
        /// <param name="request">holding the username, account an the password</param>
        /// <returns>Object AuthenticateResponse</returns>
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            //Building the WebService request
            //First Step Request by Account >> Defining Header
            AuthenticateResponse response = new AuthenticateResponse();

            SessionHelper.Set("AccountId", "0"); //To be checked as it is a strange behavior ( simulated from old code)
            Dictionary<string, string> headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("_accountName", request.Account);

            RecordWebServiceResponse<UserInfo> record = _userRepository.GetRecord("getAC", headers, parameters);
            if (record == null)
            {
                response.Success = false;
                response.Message = "RequestError"; //This message have to be read from resource, it indicate that there was a problem in the connection.
                return response;
            }
            if (record.record == null)
            {
                response.Success = false;
                response.Message = "InvalidAccount";
                return response;
            }


            //Valid account >> fill session and prepare for the new request
            SessionHelper.Set("AccountId", record.record.accountId);
             headers = SessionHelper.GetAuthorizationHeadersForUser();
            parameters.Clear();
            parameters.Add("_email", request.UserName);
            parameters.Add("_password", request.Password);
            record = _userRepository.GetRecord("signIn", headers, parameters);
            if (record == null)
            {
                response.Success = false;
                response.Message = "RequestError"; //This message have to be read from resource, it indicate that there was a problem in the connection.
                return response;
            }
            if (record.record == null)
            {
                response.Success = false;
                response.Message = "InvalidCredentials"; 
                return response;
            }
            //authentication Valid, set the session then return the response back


            SessionHelper.Set("UserId", record.record.recordId);
            SessionHelper.Set("key", SessionHelper.GetToken(SessionHelper.Get("AccountId").ToString(), record.record.recordId));

            response.Success = true;
            return response;

        }
    }
}
