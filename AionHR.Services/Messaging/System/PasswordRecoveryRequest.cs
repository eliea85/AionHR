﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Messaging.System
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

       
        
        public string Guid { get; set; }

        public string NewPassword { get; set; }
    }
}
