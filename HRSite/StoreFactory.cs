using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite
{
    public class StoreFactory
    {
        public static Model GetEmployeeModel()
        {
            Model m = new Model()
            {
                Fields =
                {
                    new ModelField("recordId", ModelFieldType.String),
                    new ModelField("reference", ModelFieldType.String),
                    new ModelField("fullName", ModelFieldType.String),
                    new ModelField("firstName", ModelFieldType.String),
                    new ModelField("middleName", ModelFieldType.String),
                    new ModelField("lastName", ModelFieldType.String),
                    new ModelField("departmentName", ModelFieldType.String),
                    new ModelField("departmentId", ModelFieldType.String),
                    new ModelField("NationalityId", ModelFieldType.String),
                    new ModelField("mainDept", ModelFieldType.String),
                    new ModelField("positionName", ModelFieldType.String),
                    new ModelField("positionId", ModelFieldType.String),
                    new ModelField("branchName", ModelFieldType.String),
                    new ModelField("lengthOfService", ModelFieldType.Int),
                    new ModelField("isInactive", ModelFieldType.Boolean),
                    new ModelField("gender", ModelFieldType.String),
                     new ModelField("mobile", ModelFieldType.String),
                    new ModelField("birthDate", ModelFieldType.Date),
                    new ModelField("hireDate", ModelFieldType.Date),
                    new ModelField("contractEndingDate", ModelFieldType.Date),
                    new ModelField("isInactive", ModelFieldType.Boolean),
                    new ModelField("emailAccount", ModelFieldType.String),
                    new ModelField("religion", ModelFieldType.String),
                     new ModelField("sponsorId", ModelFieldType.String),
                    new ModelField("sponsorName", ModelFieldType.String),
                    new ModelField("wcName", ModelFieldType.String),
                    new ModelField("religion", ModelFieldType.String),
                     new ModelField("vsId", ModelFieldType.String),
                      new ModelField("caId", ModelFieldType.String)

                }
            };
            return m;
        }
        public static Model GetNameValueModel()
        {
            Model m = new Model()
            {
                Fields =
                {
                    new ModelField("recordId", ModelFieldType.String),
                    
                    new ModelField("name", ModelFieldType.String)

                }
            };
            return m;
        }
    }
}