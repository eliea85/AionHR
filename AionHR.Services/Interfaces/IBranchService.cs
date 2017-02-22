using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AionHR.Infrastructure.Session;
using AionHR.Services.Messaging;
using AionHR.Model.Company.Structure;

namespace AionHR.Services.Interfaces
{
    public interface IBranchService : IBaseService
    {
        ListResponse<Branch> GetAll(ListRequest request);
    }
}
