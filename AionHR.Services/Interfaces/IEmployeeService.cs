using AionHR.Model.Employees;
using AionHR.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Interfaces
{
    public interface IEmployeeService:IBaseService
    {
        Response<List<Employee>> GetAll(ListRequest request);
    }
}
