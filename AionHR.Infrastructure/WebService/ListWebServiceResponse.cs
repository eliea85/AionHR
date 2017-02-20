﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Infrastructure.WebService
{
    /// <summary>
    /// The object returned by a webserice call
    /// </summary>
    /// <typeparam name="T">IEntity</typeparam>
    public class ListWebServiceResponse<T> : BaseWebServiceResponse
    {
        
        public T[] list;

        public int viewCount;

        public List<T> GetAll()
        {
            return list.ToList<T>();

        }


    }

}