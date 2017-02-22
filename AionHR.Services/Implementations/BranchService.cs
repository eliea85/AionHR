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
    public class BranchService:BaseService,IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository, SessionHelper sessionHelper) : base(sessionHelper)
        {
            _branchRepository = branchRepository;
        }
        public RecordResponse<Branch> Get(RecordRequest request)
        {
            RecordResponse<Branch> response = new RecordResponse<Branch>();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);
            var webResponse = _branchRepository.GetRecord("getBR", headers, queryParams);
            CreateServiceResponse<RecordResponse<Branch>>(webResponse);
            response.result = webResponse.record;
            return response;
            
        }
        public ListResponse<Branch> GetAll(ListRequest request)
        {
            ListResponse<Branch> response = new ListResponse<Branch>();

            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            ListWebServiceResponse<Branch> webResponse = _branchRepository.GetAll("qryBR", headers, request.Parameters);
            response = CreateServiceResponse<ListResponse<Branch>>(webResponse);
            if(!response.Success)
            {
                response.Message = webResponse.message;
            }

            response.Items = webResponse.list.ToList();
            return response;
        }

        public PostResponse Add(Branch branch)
        {
            PostResponse response = new PostResponse();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            PostWebServiceResponse webResponse = _branchRepository.Post("setBR", branch, headers);
            return response;
        }
       
    }
}

