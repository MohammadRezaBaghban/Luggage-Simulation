using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class WhiteBreadPackage : IPackage
    {
        private string status;
        private static int id;

        public void Pack()
        {
            status = " White bread packing";
            id++;
        }

        public void Seal()
        {
            status = " White bread sealed";

        }

        public string GetStatus()
        {
            return status;
        }
    }
}
