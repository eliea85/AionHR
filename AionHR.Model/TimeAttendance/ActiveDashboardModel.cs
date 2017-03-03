using System;

namespace AionHR.Model.Attendance
{
    public  class CheckMonitor : ModelBase
    {
        public int figureId { get; set; }
        public int count { get; set; }
        public double rate { get; set; }
    }
    public  class ActiveCheck : ModelBase
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string time { get; set; }
        public string positionName { get; set; }
        public string departmentName { get; set; }
        public string branchName { get; set; }
    }

    public  class ActiveLate : ActiveCheck
    {
    }

    public  class ActiveOut : ActiveCheck
    {
    }

    public  class MissedPunch : ModelBase
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public DateTime date { get; set; }
        public bool missedIn { get; set; }
        public bool missedOut { get; set; }
        public string time { get; set; }
    }

    public  class ActiveAbsence : ModelBase
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string positionName { get; set; }
        public string departmentName { get; set; }
        public string branchName { get; set; }
    }

    public  class ActiveLeave : ModelBase
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string ltName { get; set; }
        public string destination { get; set; }
    }
}