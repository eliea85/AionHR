using AionHR.Infrastructure.Session;
using AionHR.Model.LeaveManagement;
using AionHR.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Implementations
{
    public class LeaveManagementService : BaseService, ILeaveManagementService

    {
        private ILeaveManagementRepository _repository;
        public LeaveManagementService(SessionHelper helper, ILeaveManagementRepository repository):base(helper)
        {
            this._repository = repository;
        }

        protected override dynamic GetRepository()
        {
            return _repository;
        }
    }
}
