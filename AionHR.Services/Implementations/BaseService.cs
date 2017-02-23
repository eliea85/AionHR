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
        protected string GetRecordMethodName;
        protected string GetAllMethodName;
        protected string AddOrUpdateMethodName;
        protected string DeleteMethodName;
        protected Dictionary<Type, string> ChildGetLookup;
        protected Dictionary<Type, string> ChildGetAllLookup;
        protected Dictionary<Type, string> ChildAddOrUpdateLookup;
        protected Dictionary<Type, string> ChildDeleteLookup;
        public SessionHelper SessionHelper { get; set; }
        public BaseService(SessionHelper sessionHelper,ICommonRepository repository)
        {
            SessionHelper = sessionHelper;
            _repository = (IRepository < IEntity, string> )repository;
        }

        public IRepository<IEntity, string> _repository;
        protected TResponse CreateServiceResponse<TResponse>(BaseWebServiceResponse webResponse) where TResponse :ResponseBase,new()
        {
            TResponse response =new TResponse();
            response.Success = webResponse!=null && webResponse.statusId == "1";
            return response;
        }

        

        public RecordResponse<T> Get<T>(RecordRequest request) where T :IEntity
        {
            RecordResponse<T> response = new RecordResponse<T>();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);

            var webResponse = _repository.GetRecord(headers, queryParams);
            CreateServiceResponse<RecordResponse<T>>(webResponse);
            response.result =(T) webResponse.record;
            return response;

        }
        public ListResponse<IEntity> GetAll<T>(ListRequest request)
        {
            

            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            var webResponse = _repository.GetAll( headers, request.Parameters);
            var response = CreateServiceResponse<ListResponse<IEntity>>(webResponse);
            if (!response.Success)
            {
                response.Message = webResponse.message;
            }

            response.Items = webResponse.GetAll();

            return response;
        }

        public PostResponse<T> AddOrUpdate<T>(PostRequest<T> request) where T:IEntity
            
        {
            PostResponse<T> response;
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            PostWebServiceResponse webResponse = _repository.AddOrUpdate( request.entity, headers);
            response = CreateServiceResponse<PostResponse<T>>(webResponse);
            response.recordId = webResponse.recordId;
            return response;
        }

        public StatusResponse Delete<T>(RecordRequest request) where T : IEntity
        {
            StatusResponse response = new StatusResponse();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);
            var webResponse = _repository.Delete(headers, queryParams);
            response = CreateServiceResponse<StatusResponse>(webResponse);

            return response;
        }

        public RecordResponse<TChild> ChildGetRecord<TChild>(RecordRequest request)
        {
            RecordResponse<TChild> response = new RecordResponse<TChild>();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);
            
            var webResponse = _repository.ChildGetRecord<TChild>(headers, queryParams);
            CreateServiceResponse<RecordResponse<TChild>>(webResponse);
            response.result = webResponse.record;
            return response;
        }
        public ListResponse<TChild> ChildGetAll<TChild>(ListRequest request)
        {
            ListResponse<TChild> response = new ListResponse<TChild>();

            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            ListWebServiceResponse<TChild> webResponse = _repository.ChildGetAll<TChild>( headers, request.Parameters);
            response = CreateServiceResponse<ListResponse<TChild>>(webResponse);
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
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            PostWebServiceResponse webResponse = _repository.ChildAddOrUpdate<TChild>(request.entity, headers);
            response = CreateServiceResponse<PostResponse<TChild>>(webResponse);
            response.recordId = webResponse.recordId;
            return response;
        }
    }
}
