﻿using AionHR.Model.MasterModule;
using AionHR.Services.Messaging;
using AionHR.Services.Messaging.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Interfaces
{
    public interface IMasterService:IBaseService<Account,string>
    {
        Response<Account> GetAccount(AuthenticateRequest request);

        Response<Account> RequestAccountRecovery(AuthenticateRequest request);
            

    }
}
