using System;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class BrownBreadFlour : IFlour
    {
        String _status = "";

        public void Bake()
        {
            throw new NotImplementedException();
        }

        public void Prepare()
        {
            throw new NotImplementedException();
        }

        public void Mix()
        {
            throw new NotImplementedException();
        }

        public void Freeze()
        {
            throw new NotImplementedException();
        }

        public void UnFreeze()
        {
            throw new NotImplementedException();
        }

        public void Slice()
        {
            throw new NotImplementedException();
        }

        public string GetStatus()
        {
            return _status;
        }
    }
}
