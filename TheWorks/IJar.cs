using System;
using System.Collections.Generic;
using System.Text;

namespace TheWorks
{
    public interface IJar
    {
        string Name { get; }
        void Open();
        void Close();
        ISpreadable GetStuff(int quantity);
    }
}
