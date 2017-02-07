using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.Responses
{
    public class SingleItemServiceResponse<T>:AbstractServiceResponse
    {
        public T record { get; set; }

    }
}