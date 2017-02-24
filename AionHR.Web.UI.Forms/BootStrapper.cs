﻿using AionHR.Infrastructure.Configuration;
using AionHR.Infrastructure.Logging;
using AionHR.Infrastructure.Session;
using AionHR.Infrastructure.Tokens;
using AionHR.Model.Company.Structure;
using AionHR.Model.Employees;
using AionHR.Model.MasterModule;
using AionHR.Model.System;
using AionHR.Repository.WebService.Repositories;
using AionHR.Services.Implementations;
using AionHR.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace AionHR.Web.UI.Forms
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            // Initialize the registry
            var container = new Container(c => { c.AddRegistry<ModelRegistry>(); });
            var smServiceLocator = new StructureMapServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => smServiceLocator);
        }

        public class ModelRegistry : Registry
        {
            public ModelRegistry()
            {
                //Infrastructure

                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
                For<ISessionStorage>().Use<SessionStorage>();
                For<ITokenGenerator>().Use<APIKeyBasedTokenGenerator>();

                // Application Settings                 
                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();

                // Logger
                For<ILogger>().Use<Log4NetAdapter>();

                //Repositories
                For<IEmployeeRepository>().Use<EmployeeRepository>();
                For<ISystemRepository>().Use<SystemRepository>();
                For<IAccountRepository>().Use<AccountRepository>();
                For<ICompanyStructureRepository>().Use<CompanyStructureRepository>();

                //Services
                For<ISystemService>().Use<SystemService>();
                For<IEmployeeService>().Use<EmployeeService>();
                For<IMasterService>().Use<MasterService>();
                For<ICompanyStructureService>().Use<CompanyStructureService>();
            }
        }
    }
}