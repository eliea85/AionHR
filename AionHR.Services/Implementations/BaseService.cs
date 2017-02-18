using AionHR.Infrastructure.Session;
using AionHR.Services.Interfaces;
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
    }
}
