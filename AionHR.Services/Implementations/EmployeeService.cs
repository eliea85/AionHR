using AionHR.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Model.Employees;
using AionHR.Services.Messaging;
using AionHR.Infrastructure.Session;
using AionHR.Model.Employees.Profile;
using AionHR.Infrastructure.Domain;

namespace AionHR.Services.Implementations
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        
        public EmployeeService(IEmployeeRepository employeeRepository, SessionHelper sessionHelper) : base(sessionHelper)
        {
            GetAllMethodName = "qryES";
            GetRecordMethodName = "getEM";
            AddOrUpdateMethodName = "setEM";
        }

        protected override dynamic GetRepoistory()
        {
            return _employeeRepository;
        }
    }
}
