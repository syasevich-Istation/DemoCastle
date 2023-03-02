using System;
using System.Collections.Generic;
using System.Text;

namespace TheWorks
{
    public class BreadSlice
    {
        public string BreadName { get; private set; }
        public int Thinkness { get; private set; }

        public BreadSlice(string baadName, int thickness)
        {
            BreadName = baadName;
            Thinkness = thickness;
        }

        public string Description => BreadName.Replace("_", " ");
    }
}
