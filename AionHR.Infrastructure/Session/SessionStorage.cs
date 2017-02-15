﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AionHR.Infrastructure.Session
{
    /// <summary>
    /// The http context session storage
    /// </summary>
   public  class SessionStorage:ISessionStorage
    {
        /// <summary>
        /// Save value to session
        /// </summary>
        /// <param name="key">key session</param>
        /// <param name="value">value to store</param>
        public void Save(string key, object value)
        {
            HttpContext.Current.Session[key] = value;            
        }

        /// <summary>
        /// Get value from session based on key
        /// </summary>
        /// <param name="key">key value to return</param>
        /// <returns></returns>
        public object Retrieve(string key)
        {
            return HttpContext.Current.Session[key];
        }
    }
}
