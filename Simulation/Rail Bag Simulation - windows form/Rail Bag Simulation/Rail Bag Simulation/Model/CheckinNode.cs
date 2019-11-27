using System.Collections.Generic;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    class CheckinNode : Node
    {
        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Check-in: "};
            sender.AddRange(base.NodeInfo());
            return sender;
        }
    }
}
