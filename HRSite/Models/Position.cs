using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.Models
{
    public class Position:SimpleModel
    {
        public string reference { get; set; }
        public string description { get; set; }

        public string referPositionId { get; set; }

        public string referPositionName { get; set; }

    }
}