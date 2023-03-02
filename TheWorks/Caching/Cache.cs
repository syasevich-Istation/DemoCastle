
using System;
using System.Collections.Concurrent;


namespace TheWorks.Caching
{
    public class Cache : ICache
    {
        // cunt of any stuff from storage that we keep on the table
        public ConcurrentDictionary<string, int> _dataCache = new ConcurrentDictionary<string, int>();

        public bool TryGet(string key, out int count)
        {
            if (_dataCache.TryGetValue(key, out var countFromCache))
            {
                Console.WriteLine($"           Cache hit for {key}");
                count = countFromCache;
                return true;
            }
            Console.WriteLine($"           Cache miss for {key}");
            count = 0;
            return false;
        }

        public void Put(string key)
        {
            if (_dataCache.TryAdd(key, 1))
                Console.WriteLine($"           Added to cache {key}");
        }

        public void Cleanup()
        {
            _dataCache.Clear();
        }
    }
}
