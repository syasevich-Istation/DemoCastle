using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TheWorks
{
    public class Pantry : IStorage
    {
        public IJar GetAJur(string name)
        {
            // it takes time to get it from the pantry
            Thread.Sleep(1200);

            return new Jar(name);
        }

        public BreadLoaf GetBread(string name)
        {
            // it takes time to get it from the pantry
            Thread.Sleep(1200);

            return new BreadLoaf (name);
        }

        public void Close()
        {
            // close pantry door
        }
    }
}
