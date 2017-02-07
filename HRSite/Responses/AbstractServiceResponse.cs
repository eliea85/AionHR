using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.Responses
{
    public class AbstractServiceResponse
    {
        public string statusId { get; set; }

        public string message { get; set; }
    }
}