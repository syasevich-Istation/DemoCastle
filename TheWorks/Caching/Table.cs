namespace TheWorks.Caching
{
    /// <summary>
    /// Table is a proxy for pantry
    /// it conforms to the same IStorage interface
    /// and proxies request to pantry only when it is incapable to resolve them itself
    /// </summary>
    public class Table : IStorage
    {
        private readonly ICache _cache;
        private readonly IStorage _pantry;

        public Table(ICache cache, IStorage pantry)
        {
            _cache = cache;
            _pantry = pantry;
        }

        public void Open()
        {
            _pantry.Open();
        }

        public IJar GetAJur(string name)
        {
            // we do not care what it returns, we just need to know if the jar is on the table
            if (!_cache.TryGet(name, out _))
            {
                var jar = _pantry.GetAJur(name);
                _cache.Put(name);
                return jar;
            }
            return new Jar(name);
        }

        public BreadLoaf GetBread(string name)
        {
            // we do not care what it returns, we just need to know if the bread loaf is on the table
            if (!_cache.TryGet(name, out string _))
            {
                // not in cache (not on the table) - get from pantry
                var loaf = _pantry.GetBread(name);

                // leave it on the table
                _cache.Put(name);
                return loaf;
            }
            return new BreadLoaf(name);
        }

        public void Close()
        {
            // return everything to pantry and close the door
            _cache.Cleanup();
            _pantry.Close();
        }
    }
}
