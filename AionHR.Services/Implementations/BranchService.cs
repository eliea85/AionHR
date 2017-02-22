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
    }
}
