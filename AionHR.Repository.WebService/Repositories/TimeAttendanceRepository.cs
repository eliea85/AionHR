using AionHR.Infrastructure.Configuration;
using AionHR.Infrastructure.Domain;
using AionHR.Model.Attendance;
using AionHR.Model.TimeAttendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Repository.WebService.Repositories
{
    public class TimeAttendanceRepository:Repository<IEntity,string>, ITimeAttendanceRepository
    {
        private string serviceName = "TA.asmx/";

        public TimeAttendanceRepository()
        {
            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName;

            ChildGetLookup.Add(typeof(DayType), "getDT");
            ChildGetLookup.Add(typeof(AttendanceSchedule), "getSC");
            ChildGetLookup.Add(typeof(AttendanceScheduleDay), "getSD");
            ChildGetLookup.Add(typeof(WorkingCalendar), "getCA");
            ChildGetLookup.Add(typeof(CalendarYear), "getCY");
            ChildGetLookup.Add(typeof(CalendarDay), "getCD");

            ChildGetAllLookup.Add(typeof(DayType), "qryDT");
            ChildGetAllLookup.Add(typeof(AttendanceSchedule), "qrySC");
            ChildGetAllLookup.Add(typeof(AttendanceScheduleDay), "qrySD");
            ChildGetAllLookup.Add(typeof(AttendanceBreak), "qrySB");
            ChildGetAllLookup.Add(typeof(WorkingCalendar), "qryCA");
            ChildGetAllLookup.Add(typeof(CalendarYear), "qryCY");
            ChildGetAllLookup.Add(typeof(CalendarDay), "qryCD");

            ChildAddOrUpdateLookup.Add(typeof(DayType), "setDT");
            ChildAddOrUpdateLookup.Add(typeof(AttendanceSchedule), "setSC");
            ChildAddOrUpdateLookup.Add(typeof(AttendanceScheduleDay), "setSD");
            ChildAddOrUpdateLookup.Add(typeof(AttendanceBreak[]), "arrSB");
            ChildAddOrUpdateLookup.Add(typeof(WorkingCalendar), "setCA");
            ChildAddOrUpdateLookup.Add(typeof(CalendarYear), "setCY");
            ChildAddOrUpdateLookup.Add(typeof(CalendarDay), "setCD");

            ChildDeleteLookup.Add(typeof(AttendanceBreak), "detSB");



        }
    }
}
