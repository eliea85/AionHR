using AionHR.Infrastructure.Session;
using AionHR.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Interfaces
{
    public interface IBaseService
    {
        SessionHelper SessionHelper { get; set; }

        ListResponse<T> GetAll<T>(ListRequest request);
        RecordResponse<T> Get<T>(RecordRequest request);

        PostResponse Add<T>(T branch);
    }
}
