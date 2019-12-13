using System;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class BrownBreadFlour : IFlour
    {
        private static int id;

        String _status = "";

        public BrownBreadFlour() 
        {
            id++;
        }


        public void Bake()
        {
            _status="Baking brown bread";
        }

        public void Prepare()
        {
            _status = "Preparing brown bread";
        }

        public void Mix()
        {
            _status = "Mixing brown bread";
        }

        public void Freeze()
        {
            _status = "Freezing brown bread";
        }

        public void UnFreeze()
        {
            _status = "Unfreezing brown bread";
        }

        public void Slice()
        {
            _status = "Slicing brown bread";
        }

        public string GetStatus()
        {
            return _status;
        }
    }
}
