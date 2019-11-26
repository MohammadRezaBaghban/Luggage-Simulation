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

        public override string NodeInfo()
        {
            return ListOfBagsInQueue.Aggregate($"Gate: {Gate.GateNr} \n", (current, g) => current + (g.GetBagInfo() + "\n"));
        }

        public override void MoveBagToNextNode()
        {
        }
    }
}


