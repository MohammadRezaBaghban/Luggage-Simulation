using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Gate
    {
       public string GateNr { get; private set; }
       public Gate(string gateNr)
        {
            this.GateNr = gateNr;
        }
    }
}
