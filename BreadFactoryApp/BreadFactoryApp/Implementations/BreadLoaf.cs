using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class BreadLoaf
    {
        private ILabel label;
        private IPackage package;
        private IFlour flour;
        private int _id;
        private static int IdToGive;

        public BreadLoaf()
        {
            _id = ++IdToGive;

        }

        public void setLabel(ILabel label)
        {
            this.label = label;
        }
        public void setPackage(IPackage package)
        {
            this.package = package;
        }
        public void setFlour(IFlour flour)
        {
            this.flour = flour;
        }

        public int getID()
        { 
            return _id;
        }

        public override string ToString()
        {
            return $"Loaf id " + _id + " Expiry Date: " + label.PrintExpiryDate();
        }
    }
}
