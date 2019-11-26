using System.Collections.Generic;
using System.Linq;

namespace Rail_Bag_Simulation
{
    class GateNode : Node 
    {
        public Gate Gate { get; }

        public GateNode(Gate g)
        {
            this.Gate = g;
        }

        public override List<string> NodeInfo()
        {
            Sender.Clear();

            Sender.Add($"Gate: {Gate.GateNr}");
            base.NodeInfo();
            return Sender;
        }

        public override void MoveBagToNextNode()
        {
        }
    }
}


