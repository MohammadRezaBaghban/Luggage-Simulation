using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class ConveyorNode : Node
    {
       
        public Conveyorbelt Conveyor { get; private set; }

        public NextStop Nextstop => _nextstop;

        private NextStop _nextstop;
        public Node EndPoint;

        public ConveyorNode(Conveyorbelt conveyorbelt)
        {
            this.Conveyor = conveyorbelt;
        }
        

        public override string Nodeinfo()
        {
           return Conveyor.Id.ToString() 
               + ": "+ Conveyor.ToString();
        }
    }
}
