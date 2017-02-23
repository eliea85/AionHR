using AionHR.Infrastructure.Domain;
using AionHR.Infrastructure.Session;
using AionHR.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Interfaces
{
    public interface IBaseService<IRepositoryBaseType>where IRepositoryBaseType:IRepository<IEntity,string>
    {
        SessionHelper SessionHelper { get; set; }
        RecordResponse<T> Get<T>(RecordRequest request)where T :IEntity;

        ListResponse<IEntity> GetAll<T>(ListRequest request);


        PostResponse<T> AddOrUpdate<T>(PostRequest<T> request) where T : IEntity;
        StatusResponse Delete<T>(RecordRequest request) where T : IEntity;


  

        
        
    }
}
