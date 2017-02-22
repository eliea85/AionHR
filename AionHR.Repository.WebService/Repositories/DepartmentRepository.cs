using AionHR.Model.Company.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Infrastructure.WebService;
using AionHR.Infrastructure.Configuration;
namespace AionHR.Repository.WebService.Repositories
{
    public class DepartmentRepository: Repository<Department,string>,IDepartmentRepository
    {
        private string serviceName = "CS.asmx/";
        public DepartmentRepository()
        {

            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName;

        }
    }
}
