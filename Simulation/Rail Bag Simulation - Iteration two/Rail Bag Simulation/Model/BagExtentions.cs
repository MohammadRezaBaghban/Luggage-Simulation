using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation.Model
{
    static class Extentions
    {
        public static bool IsNull<T>(this T source)
        {
            return source==null;
        }
    }
}
