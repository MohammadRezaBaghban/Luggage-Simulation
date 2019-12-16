using System;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp
{
    internal class FlourEventArgs:EventArgs
    {
        private IFlour flour;

        public FlourEventArgs(IFlour flour)
        {
            this.flour = flour;
        }

        public IFlour Flour => flour;
    }
}