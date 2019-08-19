using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hbms.Mes.Common
{
    public interface ICache
    {
        bool Add(string Key, object Value);
        bool Add(string Key, object Value, DateTime expiresAt);
        bool Set(string Key, object Value);
        bool Set(string Key, object Value, DateTime expiresAt);
        T Get<T>(string Key);
        object Get(string Key);
        bool Remove(string Key);
        void RemoveAll();
    }
}