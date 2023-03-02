
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TheWorks.Caching
{
    /// <summary>
    /// Supper dummy implementation of cache
    /// Since everything is synchronous we do not need
    /// to worry about concurrency
    /// and we do store real data, just an indication that the item in on the table.
    /// </summary>
    public class Cache : ICache
    {
        // just a collection on food items in the table
        public HashSet<string> _itemsOnTheTable = new HashSet<string>();

        public bool TryGet(string key, out string name)
        {
            if (_itemsOnTheTable.TryGetValue(key, out var actualName))
            {
                Console.WriteLine($"           Cache hit for {key}");
                name = actualName;
                return true;
            }
            Console.WriteLine($"           Cache miss for {key}");
            name = "";
            return false;
        }

        public void Put(string key)
        {
            if (_itemsOnTheTable.Add(key))
                Console.WriteLine($"           Added to cache {key}");
        }

        public void Cleanup()
        {
            _itemsOnTheTable.Clear();
        }
    }
}
