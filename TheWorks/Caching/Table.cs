namespace TheWorks.Caching
{
    public class Table : IStorage
    {
        private readonly ICache _cache;
        private readonly IStorage _pantry;

        public Table(ICache cache, IStorage pantry)
        {
            _cache = cache;
            _pantry = pantry;
        }


        public IJar GetAJur(string name)
        {
            if (!_cache.TryGet(name, out int count) || count == 0)
            {
                var jar = _pantry.GetAJur(name);
                _cache.Put(name);
                return jar;
            }
            return new Jar(name);
        }

        public BreadLoaf GetBread(string name)
        {
            if (!_cache.TryGet(name, out int count) || count == 0)
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
