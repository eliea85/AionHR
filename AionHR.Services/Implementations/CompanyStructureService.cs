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
            _companyRepository = companyStructureRepository;

        }
        ICompanyStructureRepository _companyRepository;
        public RecordResponse<TChild> ChildGetRecord<TChild>(RecordRequest request)
        {
            RecordResponse<TChild> response = new RecordResponse<TChild>();
            var headers = base.SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);

            var webResponse = _companyRepository.ChildGetRecord<TChild>(headers, queryParams);
            base.CreateServiceResponse<RecordResponse<TChild>>(webResponse);
            response.result = webResponse.record;
            return response;
        }
        public ListResponse<TChild> ChildGetAll<TChild>(ListRequest request)
        {
            ListResponse<TChild> response = new ListResponse<TChild>();

            var headers = base.SessionHelper.GetAuthorizationHeadersForUser();
            ListWebServiceResponse<TChild> webResponse = _companyRepository.ChildGetAll<TChild>(headers, request.Parameters);
            response = base.CreateServiceResponse<ListResponse<TChild>>(webResponse);
            if (!response.Success)
            {
                response.Message = webResponse.message;
            }

            response.Items = webResponse.list.ToList();
            return response;

        }

        public PostResponse<TChild> ChildAddOrUpdate<TChild>(PostRequest<TChild> request)
        {
            PostResponse<TChild> response;
            var headers = base.SessionHelper.GetAuthorizationHeadersForUser();
            PostWebServiceResponse webResponse = _companyRepository.ChildAddOrUpdate<TChild>(request.entity, headers);
            response = base.CreateServiceResponse<PostResponse<TChild>>(webResponse);
            response.recordId = webResponse.recordId;
            return response;
        }

    }
}

