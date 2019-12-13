using System;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp
{
    internal class PackagesEventArgs : EventArgs
    {
        private IPackage package;

        public PackagesEventArgs(IPackage package)
        {
            this.package = package;
        }

        public IPackage Package => package;
    }
}