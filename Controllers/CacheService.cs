using System;
using Microsoft.Extensions.Caching.Memory;

namespace vopen_api.Controllers
{
    public class CacheService
    {
        private IMemoryCache memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public T GetValue<T>(string cacheKey)
        {
            T value;
            this.memoryCache.TryGetValue<T>(cacheKey, out value);

            return value;
        }

        public void SetValue<T>(string cacheKey, T value, int expirationInMinutes = 60)
        {

            TimeSpan expiration = TimeSpan.FromMinutes(expirationInMinutes);

            // Keep in cache for this time, reset time if accessed.
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(expiration);

            // Save data in cache.
            this.memoryCache.Set<T>(cacheKey, value, cacheEntryOptions);
        }
    }
}
