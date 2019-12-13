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
      
        public IPackage Package => package;

        public IFlour Flour => flour;

        public ILabel Label => label;

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
    }
}
