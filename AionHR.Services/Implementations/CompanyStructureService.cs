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
            
            base.ChildGetLookup = new Dictionary<Type, string>();
            base.ChildGetLookup.Add(typeof(Branch), "getBR");
            base.ChildGetLookup.Add(typeof(Department), "getDE");

            base.ChildGetAllLookup = new Dictionary<Type, string>();
            base.ChildGetAllLookup.Add(typeof(Branch), "qryBR");
            base.ChildGetAllLookup.Add(typeof(Department), "qryDE");

            base.ChildAddOrUpdateLookup = new Dictionary<Type, string>();
            base.ChildAddOrUpdateLookup.Add(typeof(Branch), "setBR");
            base.ChildAddOrUpdateLookup.Add(typeof(Department), "setDE");

            base.GetAllMethodName = "";
            base.GetRecordMethodName = "";
            base.DeleteMethodName = "";
            base.AddOrUpdateMethodName = "";
        }

        
    }
}

