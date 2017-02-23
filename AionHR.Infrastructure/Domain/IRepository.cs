﻿using AionHR.Infrastructure.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Infrastructure.Domain
{
    /// <summary>
    /// Inteface to be implemented by all entities that need to exchange data
    /// </summary>
    /// <typeparam name="T">TEntity</typeparam>
    public interface IRepository<T, TID> 
    {

    
        RecordWebServiceResponse<T> GetRecord( string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null);

       
        ListWebServiceResponse<T> GetAll( string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null);

        PostWebServiceResponse AddOrUpdate(string methodName, T entity, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null);

         BlankWebServiceResponse Delete(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null);

         RecordWebServiceResponse<TChild> ChildGetRecord<TChild>(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null);

         ListWebServiceResponse<TChild> ChildGetAll<TChild>(string methodName, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null);

        PostWebServiceResponse ChildAddOrUpdate<TChild>(string methodName, TChild entity, Dictionary<string, string> Headers = null, Dictionary<string, string> QueryStringParams = null);

    }
}
