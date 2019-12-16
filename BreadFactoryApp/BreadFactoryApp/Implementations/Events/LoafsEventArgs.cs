using System;
using System.Collections.Generic;
using BreadFactoryApp.Implementations;

namespace BreadFactoryApp
{
    internal class LoafsEventArgs : EventArgs
    {
        private BreadLoaf _loaf;

        public LoafsEventArgs(BreadLoaf loaf)
        {
            _loaf = loaf;
        }

        public BreadLoaf Loaf => _loaf;
    }
}