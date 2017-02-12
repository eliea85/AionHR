using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.Models
{
    public abstract class SimpleModel
    {
        public string recordId { get; set; }

       

        public string name { get; set; }
    }
}