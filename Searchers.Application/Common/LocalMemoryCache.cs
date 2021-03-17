using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Searchers.Application.Common
{
    public class LocalMemoryCache<T>
    {
        const long _MEMORY_SIZE_LIMIT = 1024;
        const long _MEMORY_TIME_EXPIRATION = 300;
        private readonly IMemoryCache _cache;

        public LocalMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<T> MyGetOrCreate(object key, Func<Task<T>> executeLogic)
        {
            T cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = await executeLogic();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                                        .SetSize(1)
                                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(_MEMORY_TIME_EXPIRATION));
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }
        public static string GenerateKey(IEnumerable<string> keywords)
        {
            return string.Join(",", keywords);
        }

        public async static Task<T> GetOrCreateAsync(IMemoryCache cache, object key, Func<Task<T>> executeLogic)
        {
            T cacheEntry;
            //var cacheEntryOptions = new MemoryCacheEntryOptions()
            //                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(_MEMORY_TIME_EXPIRATION));
            
            cacheEntry = await cache.GetOrCreateAsync(key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(_MEMORY_TIME_EXPIRATION);
                return executeLogic();
            });
            
            return cacheEntry;
        }

        
    }
}
