using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sediment.Infrastructure;
using System.Runtime.Caching;
using System.Threading;
using Sediment.Cache;

namespace Infrastructure.Test
{
    [TestClass]
    public class MemoryCacheTest
    {
        private ICache _cache = new MemoryCacheWrapper(MemoryCache.Default);

        [TestMethod]
        public void CacheSomething()
        {
            var something = "I'm a teacher.";

            _cache.Set("something", something, TimeSpan.FromDays(10));
            Assert.AreEqual(something, _cache.Get("something"));

            _cache.Remove("something");
            Assert.AreEqual(null, _cache.Get("something"));

            _cache.Set("something", something, TimeSpan.FromSeconds(10));

            Thread.Sleep(TimeSpan.FromSeconds(2));
            Assert.AreEqual(something, _cache.Get("something"));

            Thread.Sleep(TimeSpan.FromSeconds(8));
            Assert.AreEqual(null, _cache.Get("something"));
        }
    }
}
