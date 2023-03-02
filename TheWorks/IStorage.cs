using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TheWorks
{
    public interface IStorage
    {
        void Open();
        IJar GetAJur(string name);
        BreadLoaf GetBread(string name);
        void Close();
    }
}
