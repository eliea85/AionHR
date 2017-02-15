using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSite.Models;
namespace HRSite.Classes
{
    public enum EmpGender
        {
        Female=0,Male=1
    };
    public class Employee:SimpleModel
    {
        
        
        
        public string reference { get; set; }
        public string fullName { get; set; }
        public string departmentName { get; set; }

        public string departmentId { get; set; }

        public string NationalityId { get; set; }
        public string mainDept { get; set; }

        public string positionName { get; set; }
            
        public string branchName { get; set; }

        public int lengthOfService { get; set; }

        public bool isInactive { get; set; }

        public string firstName { get; set; }

        public string middleName { get; set; }

        public string mobile { get; set; }

        public string lastName { get; set; }

        public string age { get; set; }
        public string sponsorId { get; set; }

        public string sponsorName { get; set; }
        public string wcName { get; set; }
        public DateTime hireDate { get; set; }

        public DateTime contractEndingDate { get; set; }


        public DateTime birthDate { get; set; }

        public EmpGender gender { get; set; }

        public string emailAccount { get; set; }

        public string totalInService { get
            {
                
                TimeSpan  s= DateTime.Now.Subtract(hireDate);
                var x = s.TotalDays;
                int years = (int)s.TotalDays / 365;
                x = x % 365;
                int months = (int)x / 30;
                x = x % 30;
                int days = (int)x;
                return String.Format("{0}سنين {1} أشهر {2} أيام", years,months,days);
            } }

        public string picturePath { get; set; }

        public string religion { get; set; }
        public string vsId { get; set; }

        public string caId { get; set; }

        public string positionId { get; set; }
    }
}