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
    public interface IBaseService<T,TID>where T :IEntity
    {
        SessionHelper SessionHelper { get; set; }
        RecordResponse<T> Get(RecordRequest request);

         ListResponse<T> GetAll(ListRequest request);
       

        PostResponse<T> AddOrUpdate(PostRequest<T> request);
        StatusResponse Delete(RecordRequest request);


        //child methods
        RecordResponse<TChild> ChildGetRecord<TChild>(RecordRequest request);
         ListResponse<TChild> ChildGetAll<TChild>(ListRequest request);

        PostResponse<TChild> ChildAddOrUpdate<TChild>(PostRequest<TChild> request);

        
        
    }
}
