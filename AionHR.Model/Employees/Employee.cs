
using AionHR.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AionHR.Model.Employees
{
    /// <summary>
    /// Employee Entity
    /// </summary>
    public class Employee : IEntity
    {
        
        public string recordId { get; set; }
        
        public string reference { get; set; }
        public string fullName { get; set; }
        public string departmentName { get; set; }

        public string mainDept { get; set; }

        public string positionName { get; set; }

        public string branchName { get; set; }

        public int lengthOfService { get; set; }

        public bool isInactive { get; set; }

        public string firstName { get; set; }

        public string middleName { get; set; }

        public string lastName { get; set; }

        public string age { get; set; }


    }
}