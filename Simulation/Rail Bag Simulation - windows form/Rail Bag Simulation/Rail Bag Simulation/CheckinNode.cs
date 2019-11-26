using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    class CheckinNode : Node
    {
        public override string NodeInfo()
        {
            string sender = "Check in: \n"+ base.NodeInfo();
            return sender;
        }

        internal bool IsEmpty()
        {
            lock (ListOfBagsInQueue)
            {
                return QueueCount < 1;
            }
        }

        public override void MoveBagToNextNode()
        {
            if (((ConveyorNode)Next).IsFull) return;
            var bag = Remove();
            if (bag.IsNull()) { return; }
            Next.Push(bag);
        }
    }
}
