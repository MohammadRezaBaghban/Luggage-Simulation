using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {
        public Terminal Terminal { get; set; }

        public override string Nodeinfo()
        {
            throw new NotImplementedException();
        }
    }
}
