using System.Collections.Generic;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    class CheckinNode : Node
    {
        public override List<string> NodeInfo()
        {
            Sender.Clear();
            Sender.Add("Check-in: ");
            base.NodeInfo();
            return Sender;
        }
    }
}
