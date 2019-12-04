using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    internal class CheckinNode : Node
    {
        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Check-in: "};
            sender.AddRange(base.NodeInfo());
            return sender;
        }
    }
}