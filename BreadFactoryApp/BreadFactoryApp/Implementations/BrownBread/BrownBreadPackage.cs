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
        private static int id;
        public void Pack()
        {
            status = "Brown bread packed";
            id++;
        }

        public void Seal()
        {
            status = "Brown bread sealed";
        }

        public string GetStatus()
        {
            return status;
        }
    }
}
