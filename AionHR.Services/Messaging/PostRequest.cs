﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Messaging
{
    public class PostRequest<T> : RequestBase
    {
        public T entity
        {
            get; set;
        }
    }
}
