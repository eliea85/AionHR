using AionHR.Infrastructure.Configuration;
using AionHR.Model.Employees.Leaves;
using AionHR.Model.LeaveManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Repository.WebService.Repositories
{
    /// <summary>
    /// 
    /// </summary>
   public  class LeaveManagementRepository:Repository<VacationSchedule,string>, ILeaveManagementRepository
    {
        private string serviceName = "LM.asmx/";

        public LeaveManagementRepository()
        {
            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName;

            ChildGetLookup.Add(typeof(VacationSchedule), "getVS");
            ChildGetLookup.Add(typeof(VacationSchedulePeriod), "getVP");

            ChildGetAllLookup.Add(typeof(VacationSchedule), "qryVS");
            ChildGetAllLookup.Add(typeof(VacationSchedulePeriod), "qryVP");

            ChildAddOrUpdateLookup.Add(typeof(VacationSchedule), "setVS");
            ChildAddOrUpdateLookup.Add(typeof(VacationSchedulePeriod[]), "arrVP");

            ChildDeleteLookup.Add(typeof(VacationSchedulePeriod), "delVP");
        }
    }
}
