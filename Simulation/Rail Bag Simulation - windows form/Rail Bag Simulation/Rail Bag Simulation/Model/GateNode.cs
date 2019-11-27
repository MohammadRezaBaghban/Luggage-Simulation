using System.Collections.Generic;
using System.Linq;

namespace Rail_Bag_Simulation
{
    class GateNode : Node 
    {
        public Gate Gate { get; }

        public GateNode(Gate g)
        {
            Gate = g;
        }

        public override List<string> NodeInfo()
        {
            var sender = new List<string>
            {
                $"Gate: {Gate.GateNr}"
            };
            sender.AddRange(base.NodeInfo());
            return sender;
        }

        public override void MoveBagToNextNode()
        {
        }
    }
}


