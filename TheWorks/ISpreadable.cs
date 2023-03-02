using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace TheWorks
{
    // describes a portion of spreadable stuff
    public interface ISpreadable
    {
        // smooth_peanatbutter, chunky_peantbutter, stroberry_jelly, salty_peanut_butter, etc
        public string Name { get; }
        // 1/2/3/ spoons
        public int Quantity { get; }

        public string Description => Name.Replace("_", " ");
    }
}
