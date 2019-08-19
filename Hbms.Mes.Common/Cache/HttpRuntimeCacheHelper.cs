using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hbms.Mes.Common
{
    public class HttpRuntimeCacheHelper : ICache
    {
        public bool Add(string Key, object Value)
        {
            HttpRuntime.Cache.Insert(Key, Value);
            return true;
        }

        public bool Add(string Key, object Value, DateTime expiresAt)
        {
            HttpRuntime.Cache.Insert(Key, Value, null, expiresAt, TimeSpan.Zero);
            return true;
        }

        public T Get<T>(string Key)
        {
            return (T)HttpRuntime.Cache.Get(Key);
        }

        public object Get(string Key)
        {
            return HttpRuntime.Cache.Get(Key);
        }

        public bool Remove(string Key)
        {
            HttpRuntime.Cache.Remove(Key);
            return true;
        }

        public void RemoveAll()
        {
            var dic = HttpRuntime.Cache.GetEnumerator();
            var key = dic.Key;
            var value = dic.Value;
            throw new NotImplementedException();
        }

        public bool Set(string Key, object Value)
        {
            HttpRuntime.Cache.Remove(Key);
            HttpRuntime.Cache.Insert(Key, Value);
            return true;
        }

        public bool Set(string Key, object Value, DateTime expiresAt)
        {
            HttpRuntime.Cache.Remove(Key);
            HttpRuntime.Cache.Insert(Key, Value, null, expiresAt, TimeSpan.Zero);
            return true;
        }
    }
}
