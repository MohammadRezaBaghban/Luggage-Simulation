using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class WhiteBreadFlour : IFlour
    {
        private string status = "";
        public void Bake()
        {
            status="Baking white bread";
        }

        public void Prepare()
        {
            status = "Preparing white bread";

        }

        public void Mix()
        {
            status = "Mixing white bread";

        }

        public void Freeze()
        {
            status = "Freezing white bread";

        }

        public void UnFreeze()
        {
            status = "Unfreezing white bread";

        }

        public void Slice()
        {
            status = "Slicing white bread";

        }

        public string GetStatus()
        {
            return status;
        }
    }
}
