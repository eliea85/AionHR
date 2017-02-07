using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.Classes
{
    public class Department
    {
        
        public string recordId { get; set; }
        
        public string reference { get; set; }
        
        public string name { get; set; }
        
        public string parentName { get; set; }
        
        public string parentId { get; set; }
        
        public string supervisorId { get; set; }
        
        public string supervisorName { get; set; }
        

        public string segmentCode { get; set; }
      

        public bool isSegmentedHead { get; set; }



    }
}