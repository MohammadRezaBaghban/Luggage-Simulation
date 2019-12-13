using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadFactoryApp.Interfaces
{
    interface IPackage
    {
        void Pack();
        void Seal();

        String GetStatus();
        int getID();
    }
}
