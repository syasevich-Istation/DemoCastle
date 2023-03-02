using System;
using System.Collections.Generic;
using System.Text;

namespace TheWorks
{
    public class SpeadablePortion : ISpreadable
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public SpeadablePortion(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
