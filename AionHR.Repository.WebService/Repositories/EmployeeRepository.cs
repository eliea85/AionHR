using AionHR.Model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Infrastructure.Domain;
using AionHR.Infrastructure.Configuration;
using AionHR.Model.Employees.Profile;
using AionHR.Infrastructure.WebService;

namespace AionHR.Repository.WebService.Repositories
{
    /// Class that handle the communcation between the model and the webservice. it encapsultes all the employee relative methods
    public class EmployeeRepository : Repository<Employee, string>, IEmployeeRepository
    {

        /// <summary>
        /// the service name
        /// </summary>
        private string serviceName = "EP.asmx/";
        private string addOrRemoveEmployeeWithImageMethodName = "setEM";
        public EmployeeRepository()
        {

            base.ServiceURL = ApplicationSettingsFactory.GetApplicationSettings().BaseURL + serviceName;
            GetAllMethodName = "qryES";
            AddOrUpdateMethodName = "setEM";
            GetRecordMethodName = "getEM1";

            ChildGetAllLookup.Add(typeof(Sponsor), "qrySP");
            ChildGetAllLookup.Add(typeof(AllowanceType), "qryAT");
            ChildGetAllLookup.Add(typeof(CertificateLevel), "qryCL");

            ChildGetLookup.Add(typeof(Sponsor), "getSP");
            ChildGetLookup.Add(typeof(AllowanceType), "getAT");
            ChildGetLookup.Add(typeof(CertificateLevel), "getCL");

            ChildAddOrUpdateLookup.Add(typeof(Sponsor), "setSP");
            ChildAddOrUpdateLookup.Add(typeof(AllowanceType), "setAT");
            ChildAddOrUpdateLookup.Add(typeof(CertificateLevel), "setCL");

            ChildDeleteLookup.Add(typeof(Sponsor), "delSP");
            ChildDeleteLookup.Add(typeof(AllowanceType), "delAT");
            ChildDeleteLookup.Add(typeof(CertificateLevel), "delCL");
        }

        public PostWebServiceResponse AddOrUpdateEmployeeWithImage(Employee emp, string imgName, byte[] imgDate,Dictionary<string,string> headers = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "POST";
            request.URL = ServiceURL + addOrRemoveEmployeeWithImageMethodName;
            if (headers != null)
                request.Headers = headers;

            return request.PostAsyncWithBinary<Employee>(emp, imgName, imgDate);
        }
    }
}
