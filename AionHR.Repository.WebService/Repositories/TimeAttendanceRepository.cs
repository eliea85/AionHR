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
           

            ChildGetAllLookup.Add(typeof(DayType), "qryDT");
           

            ChildAddOrUpdateLookup.Add(typeof(DayType), "setDT");
            

            
        }
    }
}
