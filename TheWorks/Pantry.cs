using System;
using System.Threading;

namespace TheWorks
{
    public class Pantry : IStorage
    {
        bool isOpened = false;

        public void Open()
        {
            isOpened= true;
        }
        
        public IJar GetAJur(string name)
        {
            if (! isOpened)
            {
                throw new InvalidOperationException("Pantry is closed");
            }

            // it takes time to get it from the pantry
            Thread.Sleep(1200);

            return new Jar(name);
        }

        public BreadLoaf GetBread(string name)
        {
            if (!isOpened)
            {
                throw new InvalidOperationException("Pantry is closed");
            }

            // it takes time to get it from the pantry
            Thread.Sleep(1200);

            return new BreadLoaf (name);
        }

        public void Close()
        {
            // close pantry door
            isOpened = false;
        }
    }
}
