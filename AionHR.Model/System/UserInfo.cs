using AionHR.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AionHR.Model.System
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class UserInfo : IEntity
    {
        public string accountId
        {
            get; set;
        }

        public string recordId { get; set; }

        public string employeeId { get; set; }
        public string languageId { get; set; }
        public string userName { get; set; }
        public string enableHijriCalendar { get; set; }

        public bool isAdministrator { get; set; }
        public string companyName { get; set; }
    }
}