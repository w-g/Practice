using Sediment.Cache;
using System;
using System.Runtime.Caching;

namespace Sediment.Infrastructure
{
    public class MemoryCacheWrapper : ICache
    {
        private MemoryCache _cache;

        public MemoryCacheWrapper(MemoryCache cache)
        {
            _cache = cache;
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set(string key, object value, TimeSpan duration)
        {
            var item = new CacheItem(key, value);
            var policy = new CacheItemPolicy()
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.Add(duration))
            };

            _cache.Set(item, policy);
        }
    }
}
