using AionHR.Infrastructure.Domain;
using AionHR.Infrastructure.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Repository.WebService.Repositories
{
    /// <summary>
    /// Abstract class for all the repositories used
    /// </summary>
    /// <typeparam name="T">T is an IEntity</typeparam>
    /// <typeparam name="TEntityKey">the key of the entity</typeparam>
    public abstract class Repository<T, TEntityKey> where T : IEntity
    {
        public string ServiceURL;


        /// <summary>
        /// Generic method for getting a record T from the webservice
        /// </summary>
        /// <param name="methodName">the methos inside the webservice</param>
        /// <param name="Headers">the addional data headers</param>
        /// <param name="QueryStringParams"> the query strings param shipped with the request</param>
        /// <returns>a record of the requested data inside the RecordWebserviceResponse</returns>
        public RecordWebServiceResponse<T> GetRecord(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + methodName;
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;

            return request.GetAsync<RecordWebServiceResponse<T>>();

        }

        /// <summary>
        /// Generic method for getting a list of record T from the webservice
        /// </summary>
        /// <param name="methodName">the methos inside the webservice</param>
        /// <param name="Headers">the addional data headers</param>
        /// <param name="QueryStringParams"> the query strings param shipped with the request</param>
        /// <returns>a list of records of the requested data inside the ListWebServiceResponse</returns>
        public ListWebServiceResponse<T> GetAll(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + methodName;
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;


            return request.GetAsync<ListWebServiceResponse<T>>();

        }

        public PostWebServiceResponse AddOrUpdate(string methodName, T entity, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "POST";
            request.URL = ServiceURL + methodName;
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;
            return request.PostAsync<T>(entity);
            
                
        }

        public BlankWebServiceResponse Delete(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + methodName;
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;

            return request.GetAsync<BlankWebServiceResponse>();
        }

       public RecordWebServiceResponse<TChild> ChildGetRecord<TChild>(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + methodName;
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;

            return request.GetAsync<RecordWebServiceResponse<TChild>>();
        }

        public ListWebServiceResponse<TChild> ChildGetAll<TChild>(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "GET";
            request.URL = ServiceURL + methodName;
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;


            return request.GetAsync<ListWebServiceResponse<TChild>>();
        }

        public PostWebServiceResponse ChildAddOrUpdate<TChild>(string methodName, TChild entity, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null)
        {
            var request = new HTTPWebServiceRequest();
            request.MethodType = "POST";
            request.URL = ServiceURL + methodName;
            if (Headers != null)
                request.Headers = Headers;
            if (QueryStringParams != null)
                request.QueryStringParams = QueryStringParams;
            return request.PostAsync<TChild>(entity);
        }
    }
}
