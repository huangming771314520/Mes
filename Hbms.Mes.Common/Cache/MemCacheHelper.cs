using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hbms.Mes.Common
{
    public class MemCacheHelper : ICache
    {
        private static MemcachedClient MemClient;
        private static readonly object obj_lock = new object();
        public MemCacheHelper()
        {
            if (MemClient == null)
            {
                lock (obj_lock)
                {
                    if (MemClient == null)
                    {
                        MemClient = new MemcachedClient();
                    }
                }
            }
        }

        public bool Add(string Key, object Value)
        {
            return MemClient.Store(StoreMode.Add, Key, Value);
        }

        public bool Add(string Key, object Value, DateTime expiresAt)
        {
            return MemClient.Store(StoreMode.Add, Key, Value, expiresAt);
        }

        public bool Set(string Key, object Value)
        {
            return MemClient.Store(StoreMode.Set, Key, Value);
        }

        public bool Set(string Key, object Value, DateTime expiresAt)
        {
            return MemClient.Store(StoreMode.Set, Key, Value, expiresAt);
        }

        public T Get<T>(string Key)
        {
            return MemClient.Get<T>(Key);
        }

        public object Get(string Key)
        {
            return MemClient.Get(Key);
        }

        public bool Remove(string Key)
        {
            return MemClient.Remove(Key);
        }

        public void RemoveAll()
        {
            MemClient.FlushAll();
        }

    }
}
