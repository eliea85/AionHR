using AionHR.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Model.Employees;
using AionHR.Services.Messaging;
using AionHR.Infrastructure.Session;

namespace AionHR.Services.Implementations
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, SessionHelper sessionHelper) : base(sessionHelper)
        {
            _employeeRepository = employeeRepository;
        }
        public Response<List<Employee>> GetAll(ListRequest request)
        {
            Response<List<Employee>> response = new Response<List<Employee>>();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            var webResponse = _employeeRepository.GetAll("qryES", headers, request.Parameters);
            if (webResponse.statusId != "1")
            {
                response.result = null;
                response.Success = false;
                
            }
            else
            {
                response.result = webResponse.list.ToList<Employee>();
                response.rowCount = webResponse.viewCount;
                response.Success = true;
            }
            return response;

        }
    }
}
