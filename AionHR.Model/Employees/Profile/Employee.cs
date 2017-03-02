﻿using AionHR.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Model.Employees.Profile
{
    public class Employee:ModelBase,IEntity
    {
        public string reference { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string familyName { get; set; }
        public short gender { get; set; }
        public short? religion { get; set; }
        public DateTime? birthDate { get; set; }
        public string placeOfBirth { get; set; }
        public int? nationalityId { get; set; }
        public string countryName { get; set; }
        public string mobile { get; set; }
        public string homeMail { get; set; }

        public string workMail { get; set; }
        public int? positionId { get; set; }
        public string positionName { get; set; }
        public int? departmentId { get; set; }
        public string departmentName { get; set; }
        public string mainDept { get; set; }
        public int? branchId { get; set; }
        public string branchName { get; set; }
        
        public DateTime? hireDate { get; set; }
        public int? lastDayWork { get; set; }
        public DateTime? contractEndingDate { get; set; }
        public string lengthOfService { get; set; }
        public int? sponsorId { get; set; }
        public string sponsorName { get; set; }
        public int? vsId { get; set; }
        public string vsName { get; set; }
        public int? caId { get; set; }
        public string caName { get; set; }
        public bool isInactive { get; set; }

        public string pictureUrl { get; set; }
    }
}
