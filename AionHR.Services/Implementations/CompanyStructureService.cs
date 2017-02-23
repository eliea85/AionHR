using AionHR.Infrastructure.Domain;
using AionHR.Infrastructure.Session;
using AionHR.Infrastructure.WebService;
using AionHR.Model.Company.Structure;
using AionHR.Services.Interfaces;
using AionHR.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Implementations
{
    public class CompanyStructureService:BaseService,ICompanyStructureService
    {

        public enum CompanyStructureErrors
        {
            Company_Department_50005,
        }
        public CompanyStructureService(ICompanyStructureRepository companyStructureRepository, SessionHelper sessionHelper) : base(sessionHelper, companyStructureRepository)
        {
            
           
        }

        
    }
}

