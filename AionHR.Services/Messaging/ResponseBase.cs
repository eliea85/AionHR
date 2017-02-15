﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Messaging
{
    /// <summary>
    /// The base response result returned by a service
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// indicate if request succeeded
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// message returned with the request. In case of failure it returns the error message.
        /// </summary>
        public string Message { get; set; }
    }
}
