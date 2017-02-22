﻿using AionHR.Infrastructure.Domain;
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
    public abstract class BaseService<T,TID> where T :IEntity
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
        public BaseService(SessionHelper sessionHelper,IRepository<T,TID> repository)
        {
            SessionHelper = sessionHelper;
            _repository = repository;
        }
        
        public IRepository<T,TID> _repository;
        protected TResponse CreateServiceResponse<TResponse>(BaseWebServiceResponse webResponse) where TResponse :ResponseBase,new()
        {
            TResponse response =new TResponse();
            response.Success = webResponse!=null && webResponse.statusId == "1";
            return response;
        }

        

        public RecordResponse<T> Get(RecordRequest request)
        {
            RecordResponse<T> response = new RecordResponse<T>();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);

            var webResponse = _repository.GetRecord(GetRecordMethodName, headers, queryParams);
            CreateServiceResponse<RecordResponse<T>>(webResponse);
            response.result = webResponse.record;
            return response;

        }
        public ListResponse<T> GetAll(ListRequest request)
        {
            ListResponse<T> response = new ListResponse<T>();

            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            ListWebServiceResponse<T> webResponse = _repository.GetAll(GetAllMethodName, headers, request.Parameters);
            response = CreateServiceResponse<ListResponse<T>>(webResponse);
            if (!response.Success)
            {
                response.Message = webResponse.message;
            }

            response.Items = webResponse.list.ToList();
            return response;
        }

        public PostResponse<T> AddOrUpdate(PostRequest<T> request)
        {
            PostResponse<T> response;
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            PostWebServiceResponse webResponse = _repository.AddOrUpdate(AddOrUpdateMethodName, request.entity, headers);
            response = CreateServiceResponse<PostResponse<T>>(webResponse);
            response.recordId = webResponse.recordId;
            return response;
        }

        public StatusResponse Delete(RecordRequest request)
        {
            StatusResponse response = new StatusResponse();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);
            var webResponse = _repository.Delete(DeleteMethodName, headers, queryParams);
            response = CreateServiceResponse<StatusResponse>(webResponse);

            return response;
        }

        public RecordResponse<TChild> ChildGetRecord<TChild>(RecordRequest request)
        {
            RecordResponse<TChild> response = new RecordResponse<TChild>();
            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("_recordId", request.RecordID);
            
            var webResponse = _repository.ChildGetRecord<TChild>(ChildGetLookup[typeof(TChild)], headers, queryParams);
            CreateServiceResponse<RecordResponse<TChild>>(webResponse);
            response.result = webResponse.record;
            return response;
        }
        public ListResponse<TChild> ChildGetAll<TChild>(ListRequest request)
        {
            ListResponse<TChild> response = new ListResponse<TChild>();

            var headers = SessionHelper.GetAuthorizationHeadersForUser();
            ListWebServiceResponse<TChild> webResponse = _repository.ChildGetAll<TChild>(ChildGetAllLookup[typeof(TChild)].ToString(), headers, request.Parameters);
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
            PostWebServiceResponse webResponse = _repository.ChildAddOrUpdate<TChild>(ChildAddOrUpdateLookup[typeof(TChild)], request.entity, headers);
            response = CreateServiceResponse<PostResponse<TChild>>(webResponse);
            response.recordId = webResponse.recordId;
            return response;
        }
    }
}
