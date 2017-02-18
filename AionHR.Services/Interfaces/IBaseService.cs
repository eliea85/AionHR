using AionHR.Infrastructure.Session;
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
    }
}
