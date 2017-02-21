using AionHR.Infrastructure.Domain;
using AionHR.Infrastructure.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Model.System
{
    /// <summary>
    /// Interface for user repository
    /// </summary>
    public interface IUserRepository:IRepository<UserInfo,string>
    {

        
    }
}
