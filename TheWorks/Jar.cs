using System;
using System.Collections.Generic;
using System.Text;

namespace TheWorks
{
    public class Jar : IJar
    {
        public string Name { get; internal set; }

        private bool _openStatus = false;

        public Jar(string name)
        {
            Name= name;
        }

        public void Close()
        {
            _openStatus = false;
        }

        public ISpreadablePortion GetPortion(int quantity)
        {
            if (_openStatus == false)
                Open();
            // get yammy stuff out the jar
            return new SpeadablePortion(Name, quantity);
        }

        public void Open()
        {
            _openStatus = true;
        }
    }
}
