﻿using AionHR.Model.Company.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Infrastructure.WebService;
using AionHR.Infrastructure.Configuration;
using AionHR.Infrastructure.Domain;

namespace AionHR.Repository.WebService.Repositories
{
    public class CompanyStructureRepository : Repository<IEntity,string>, ICompanyStructureRepository
    {
        private string serviceName = "CS.asmx/";
        public CompanyStructureRepository()
        {

            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName;
            
            base.ChildGetLookup.Add(typeof(Branch), "getBR");
            base.ChildGetLookup.Add(typeof(Department), "getDE");
            base.ChildGetLookup.Add(typeof(Position), "getPO");

            
            base.ChildGetAllLookup.Add(typeof(Branch), "qryBR");
            base.ChildGetAllLookup.Add(typeof(Department), "qryDE");
            base.ChildGetAllLookup.Add(typeof(Position), "qryPO");

            
            base.ChildAddOrUpdateLookup.Add(typeof(Branch), "setBR");
            base.ChildAddOrUpdateLookup.Add(typeof(Department), "setDE");
            base.ChildAddOrUpdateLookup.Add(typeof(Position), "setPO");

            ChildDeleteLookup.Add(typeof(Branch), "delBR");
            ChildDeleteLookup.Add(typeof(Department), "delDE");
            ChildDeleteLookup.Add(typeof(Position), "delPO");

            base.GetAllMethodName = "";
            base.GetRecordMethodName = "";
            base.DeleteMethodName = "";
            base.AddOrUpdateMethodName = "";
        }
    }
}
