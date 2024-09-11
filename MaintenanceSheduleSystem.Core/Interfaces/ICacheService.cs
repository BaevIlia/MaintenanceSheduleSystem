using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetFromCache<T>(string key) where T : class;
        Task<bool> WriteToCache(object data, string key);
    }
}
