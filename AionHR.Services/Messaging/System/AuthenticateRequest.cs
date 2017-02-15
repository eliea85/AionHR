using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Messaging.System
{
    /// <summary>
    /// Class holding the parameter to authenticate the user
    /// </summary>
    public class AuthenticateRequest
    {
        /// <summary>
        /// Company account
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// User name 
        /// </summary>
        public string UserName{ get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
