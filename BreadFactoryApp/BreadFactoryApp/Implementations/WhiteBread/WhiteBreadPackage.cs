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
        private int id;
        private static int IdToGive;

        public void Pack()
        {
            status = "White bread packing";
            id = ++IdToGive;
        }

        public void Seal()
        {
            status = "White bread sealed";

        }

        public string GetStatus()
        {
            return status;
        }

        public  int getID()
        {
            return id;
        }
    }
}
