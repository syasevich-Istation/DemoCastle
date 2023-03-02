using System;
using System.Collections.Generic;
using System.Text;

namespace TheWorks.Caching
{
    public interface ICache
    {
        bool TryGet(string key, out int count);
        void Put(string key);
        void Cleanup();
    }
}
