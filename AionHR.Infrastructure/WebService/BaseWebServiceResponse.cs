using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Infrastructure.WebService
{
    /// <summary>
    /// The base web service response returned when calling a web service methos
    /// </summary>
    public abstract class BaseWebServiceResponse
    {
        /// <summary>
        /// the stutus of the response
        /// </summary>
        public string statusId { get; set; }

        /// <summary>
        /// the message returned
        /// </summary>
        public string message { get; set; }
    }
}
