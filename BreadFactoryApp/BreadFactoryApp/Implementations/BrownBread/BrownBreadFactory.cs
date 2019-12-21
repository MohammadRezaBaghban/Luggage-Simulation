using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Implementations;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp
{
    public class BrownBreadFactory : IBreadFactory
    {
        public ILabel CreateLabel()
        {
            return new BrownBreadLabel();
        }

        public IFlour CreateBakingFlour()
        {
            return new BrownBreadFlour();
        }

        public IPackage CreatePackage()
        {
            return new BrownBreadPackage();
        }
    }
}
