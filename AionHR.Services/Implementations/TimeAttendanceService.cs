using AionHR.Infrastructure.Session;
using AionHR.Model.TimeAttendance;
using AionHR.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Implementations
{
    public class TimeAttendanceService : BaseService,ITimeAttendanceService
    {
        private ITimeAttendanceRepository _repository;
        public TimeAttendanceService(SessionHelper helper, ITimeAttendanceRepository repository):base(helper)
        {
            this._repository = repository;
        }

        protected override dynamic GetRepository()
        {
            return _repository;
        }
    }
}
