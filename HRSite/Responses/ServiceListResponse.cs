using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using HRSite.Classes;
using HRSite.Responses;

namespace HRSite
{
    public class ServiceListResponse<T>:AbstractServiceResponse
    {
        
        
       public T[] list;
        
        public int viewCount;

        public List<T> GetAll()
        {
            return list.ToList<T>();
            
        }
       
        
    }
    
}