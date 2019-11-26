using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    static class BagExtensions
    {
        public static bool IsNotNull<T>(this T source)
        {
            return source != null;
        }
    }
}
