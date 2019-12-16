using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Implementations;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp
{
    class WhiteBreadFactory : IBreadFactory
    {

        public ILabel CreateLabel()
        {
            return new WhiteBreadLabel();
        }

        public IFlour CreateBakingFlour()
        {
            return new WhiteBreadFlour();
        }

        public IPackage CreatePackage()
        {
            return new WhiteBreadPackage();
        }
    }
}
