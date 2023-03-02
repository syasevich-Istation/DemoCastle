using System;
using System.Collections.Generic;
using System.Text;

namespace TheWorks
{
    public class BreadLoaf
    {
        public string Name { get; private set; }

        public BreadLoaf(string name)
        {
            Name = name;
        }

        public BreadSlice GetBreadSlice(int thickness)
        {
            return new BreadSlice(Name, thickness);
        }
    }
}
