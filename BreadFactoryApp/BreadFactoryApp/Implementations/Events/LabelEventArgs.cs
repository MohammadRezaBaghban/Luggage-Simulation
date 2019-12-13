using System;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp
{
    internal class LabelEventArgs : EventArgs
    {
        private ILabel label;

        public LabelEventArgs(ILabel Label)
        {
            this.label = Label;
        }

        public ILabel Label => label;
    }
}