﻿using AionHR.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Model.Attendance
{
    class DayType:ModelBase
    {
        public string name { get; set; }
        public string color { get; set; }
        public bool isWorkingDay { get; set; }
    }
}
