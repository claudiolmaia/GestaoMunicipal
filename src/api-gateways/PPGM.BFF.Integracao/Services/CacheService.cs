using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Services
{
    public interface ICacheService
    {
        Task<string> GetCache(string cacheName);
        void CreateCache(string cacheName, string data, int minutos);

        void RemoveCache(string cacheName);
    }
    
    
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetCache(string cacheName)
        {
            return await _cache.GetStringAsync(cacheName);            
        }

        public async void CreateCache(string cacheName, string data, int minutos)
        {
            DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
            opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(minutos));
            await _cache.SetStringAsync(cacheName, data, opcoesCache);
        }

        public async void RemoveCache(string cacheName)
        {
            await _cache.RemoveAsync(cacheName);
        }
    }
}
