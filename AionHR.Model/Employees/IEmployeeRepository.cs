﻿using AionHR.Infrastructure.Domain;
using AionHR.Model.Employees.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Model.Employees
{
    /// <summary>
    /// Interface for the EmployeeRepository
    /// </summary>
   public interface IEmployeeRepository:IRepository<Employee,string>,ICommonRepository
    {
        
    }
}
