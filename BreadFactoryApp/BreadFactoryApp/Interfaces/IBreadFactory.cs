using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadFactoryApp.Interfaces
{
     interface IBreadFactory
    {
        ILabel CreateLabel();
        IFlour CreateBakingFlour();
        IPackage CreatePackage();
    }
}
