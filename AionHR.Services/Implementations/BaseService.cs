using AionHR.Infrastructure.Domain;
using AionHR.Infrastructure.Session;
using AionHR.Infrastructure.WebService;
using AionHR.Services.Interfaces;
using AionHR.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Implementations
{
    /// <summary>
    /// Base service used to hold all common properties and common service methods
    /// </summary>
    public abstract class BaseService
    {
       
        public SessionHelper SessionHelper { get; set; }
        public BaseService(SessionHelper sessionHelper)
        {
            SessionHelper = sessionHelper;
           
        }
        
       
        protected TResponse CreateServiceResponse<TResponse>(BaseWebServiceResponse webResponse) where TResponse :ResponseBase,new()
        {
            TResponse response =new TResponse();
            response.Success = webResponse!=null && webResponse.statusId == "1";
            return response;
        }

        protected abstract  dynamic GetRepository();
      

        public RecordResponse<T> Get<T>(RecordRequest request) 
        {
            RecordResponse<T> response;
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);

            RecordWebServiceResponse<T> webResponse =GetRepository().GetRecord(headers, queryParams);
            response = CreateServiceResponse<RecordResponse<T>>(webResponse);
            if(!response.Success)
            {
                response.Message = webResponse.statusId;
            }
            response.result = webResponse.record;

            return response;

        }
        public ListResponse<T> GetAll<T>(ListRequest request)
        {


            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            var webResponse = GetRepository().GetAll(headers, request.Parameters);
            var response = CreateServiceResponse<ListResponse<T>>(webResponse);
            if (!response.Success)
            {
                
                
            }
            response.count = webResponse.count;
            response.Items = webResponse.GetAll();

            return response;
        }

        public PostResponse<T> AddOrUpdate<T>(PostRequest<T> request)

        {
            PostResponse<T> response;
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            PostWebServiceResponse webResponse = GetRepository().AddOrUpdate(request.entity, headers);
            response = CreateServiceResponse<PostResponse<T>>(webResponse);
            response.recordId = webResponse.recordId;
            return response;
        }

        public StatusResponse Delete<T>(RecordRequest request)
        {
            StatusResponse response = new StatusResponse();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);
            var webResponse = GetRepository().Delete(headers, queryParams);
            response = CreateServiceResponse<StatusResponse>(webResponse);

            return response;
        }

        public RecordResponse<TChild> ChildGetRecord<TChild>(RecordRequest request)
        {
            RecordResponse<TChild> response = new RecordResponse<TChild>();
            var headers =SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);
            
            var webResponse = GetRepository().ChildGetRecord<TChild>(headers, request.Parameters);
            response = CreateServiceResponse<RecordResponse<TChild>>(webResponse);
            response.result = webResponse.record;
            return response;
        }

        public ListResponse<TChild> ChildGetAll<TChild>(ListRequest request)
        {
            ListResponse<TChild> response = new ListResponse<TChild>();

            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            ListWebServiceResponse<TChild> webResponse = GetRepository().ChildGetAll<TChild>(headers, request.Parameters);
            response = CreateServiceResponse<ListResponse<TChild>>(webResponse);
            if (!response.Success)
            {
                response.Message = string.IsNullOrEmpty(webResponse.message) ? "" : webResponse.message;
            }
            response.count = webResponse.count;
            response.Items = webResponse.list.ToList();
            return response;

        }

        public PostResponse<TChild> ChildAddOrUpdate<TChild>(PostRequest<TChild> request)
        {
            PostResponse<TChild> response;
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            PostWebServiceResponse webResponse = GetRepository().ChildAddOrUpdate<TChild>(request.entity, headers);
            response = CreateServiceResponse<PostResponse<TChild>>(webResponse);
            response.recordId = webResponse.recordId;
            return response;
        }

        public StatusResponse ChildDelete<TChild>(RequestBase request)
        {
            StatusResponse response = new StatusResponse();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams = request.Parameters;
            var webResponse = GetRepository().ChildDelete<TChild>(headers, queryParams);
            response = CreateServiceResponse<StatusResponse>(webResponse);

            return response;
        }

    }
}
