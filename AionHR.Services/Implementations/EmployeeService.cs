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

namespace AionHR.Services.Implementations
{
    public class EmployeeService : BaseService<Employee,string>, IEmployeeService
    {
        
        
        public EmployeeService(IEmployeeRepository employeeRepository, SessionHelper sessionHelper) : base(sessionHelper, employeeRepository)
        {
            GetAllMethodName = "qryES";
            GetRecordMethodName = "getEM";
            AddOrUpdateMethodName = "setEM";
        }
        
    }
}
