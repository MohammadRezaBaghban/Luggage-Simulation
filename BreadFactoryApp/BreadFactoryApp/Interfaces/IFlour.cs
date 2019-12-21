using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadFactoryApp.Interfaces
{
   public interface IFlour
    {
        void Bake();
        void Prepare();
        void Mix();
        void Freeze();
        void UnFreeze();
        void Slice();

        String GetStatus();

        int getID();
    }
}
