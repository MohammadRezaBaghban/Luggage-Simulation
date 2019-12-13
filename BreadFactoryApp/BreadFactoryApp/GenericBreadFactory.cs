using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Implementations;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp
{
    class GenericBreadFactory
    {
        private IBreadFactory factory;
        private bool ManufacturingComplete;
        private readonly int CountOfNeededLoaf;
        private readonly int CountOfLoafsDone;

        private List<BreadLoaf> Loafs;


        public GenericBreadFactory(IBreadFactory factory, int countOfNeededLoaf)
        {
            this.factory = factory;
            CountOfNeededLoaf = countOfNeededLoaf;
           
        }

        public void StartManufacturing()
        {

        }
    }
}
