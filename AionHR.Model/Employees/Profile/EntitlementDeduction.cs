﻿using AionHR.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Model.Employees.Profile
{
    public class EntitlementDeduction:ModelBase
    {
        public string name { get; set; }
        public short type { get; set; }
    }
}
