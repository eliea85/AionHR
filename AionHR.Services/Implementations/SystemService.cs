using AionHR.Infrastructure.Domain;
using AionHR.Infrastructure.Session;
using AionHR.Infrastructure.WebService;
using AionHR.Model.MasterModule;
using AionHR.Model.System;
using AionHR.Services.Interfaces;
using AionHR.Services.Messaging;
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
    public class SystemService : BaseService, ISystemService
    {

      

        // public readonly SessionHelper _sessionHelper;

        public SystemService(IUserRepository userRepository, SessionHelper sessionHelper) : base(sessionHelper)
        {
            this.childRepo = userRepository;
            // _sessionHelper = sessionHelper;
        }
        private IUserRepository childRepo;

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


            Dictionary<string, string> headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> parameters = new Dictionary<string, string>();





            parameters.Add("_email", request.UserName);
            parameters.Add("_password", request.Password);
            RecordWebServiceResponse<UserInfo> userRecord = childRepo.Authenticate(headers, parameters);
            if (userRecord == null)
            {
                response.Success = false;
                response.Message = "RequestError"; //This message have to be read from resource, it indicate that there was a problem in the connection.
                return response;
            }
            if (userRecord.record == null)
            {
                response.Success = false;
                response.Message = "InvalidCredentials";
                return response;
            }
            //authentication Valid, set the session then return the response back


            SessionHelper.Set("UserId", userRecord.record.recordId);
            SessionHelper.Set("key", SessionHelper.GetToken(SessionHelper.Get("AccountId").ToString(), userRecord.record.recordId));

            response.Success = true;
            return response;

        }

        public PasswordRecoveryResponse RequestPasswordRecovery(AuthenticateRequest request)
        {
            PasswordRecoveryResponse response = new PasswordRecoveryResponse();



            Dictionary<string, string> headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("_email", request.UserName);
            RecordWebServiceResponse<UserInfo> userRecord =childRepo.RequestPasswordRecovery( headers, parameters);

            response = CreateServiceResponse<PasswordRecoveryResponse>(userRecord);
           // if (response.Success)
                return response;
           
        }

        public PasswordRecoveryResponse ResetPassword(ResetPasswordRequest request)
        {
            PasswordRecoveryResponse response;
            Dictionary<string, string> headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("_email", request.Email);
            parameters.Add("_guid", request.Guid);
            parameters.Add("_newPassword", request.NewPassword);
            RecordWebServiceResponse<UserInfo> webResponse = childRepo.ResetPassword( headers, parameters);


            response = CreateServiceResponse<PasswordRecoveryResponse>(webResponse);

            return response;
        }

        protected override dynamic GetRepository()
        {
            return childRepo;
        }
    }
}
