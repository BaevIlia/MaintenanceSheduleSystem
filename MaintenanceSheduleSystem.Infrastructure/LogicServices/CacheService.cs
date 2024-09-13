using MaintenanceSheduleSystem.Core.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Infrastructure.LogicServices
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetFromCache<T>(string key) where T : class
        {
            try
            {
                var resutlString = await _cache.GetAsync(key);

                object? data = null;
                if (resutlString != null)
                {
                    data = JsonSerializer.Deserialize<T>(resutlString);
                    if (data is null)
                    {
                        throw new Exception("Ошибка десериализации из кэша");
                    }
                    return data as T;
                }
                return data as T;
            }
            catch (Exception ex) 
            {
                throw new SystemException(ex.Message);
            }
        }
        public async Task<bool> WriteToCache(object data, string key)
        {
            var resultString = JsonSerializer.Serialize(data);

            await _cache.SetStringAsync(key, resultString, new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(2)
            });
            return true;
        }
    }
}
