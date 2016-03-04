using System;

namespace Sediment.Cache
{
    public interface ICache
    {
        void Set(string key, object value, TimeSpan duration);

        void Remove(string key);

        object Get(string key);
    }
}
