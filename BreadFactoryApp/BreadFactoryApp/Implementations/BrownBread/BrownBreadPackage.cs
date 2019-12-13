using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class BrownBreadPackage :  IPackage
    {
        private string status;
        public void Pack()
        {
            throw new NotImplementedException();
        }

        public void Seal()
        {
            throw new NotImplementedException();
        }

        public string GetStatus()
        {
            return status;
        }
    }
}
