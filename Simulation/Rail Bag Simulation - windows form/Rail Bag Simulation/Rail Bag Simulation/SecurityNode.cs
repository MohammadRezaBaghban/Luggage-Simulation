using System;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    class SecurityNode : Node
    {
        public override Bag Remove()
        {
            return ScanBagSecurity();
        }

        public override string NodeInfo()
        { 
            string sender = "Security: \n" + base.NodeInfo();
            return sender;
        }

        private Bag ScanBagSecurity()
        {
            Bag b = null;
            try
            {
                lock (ListOfBagsInQueue)
                {
                    b = ListOfBagsInQueue.Dequeue();
                }
            }
            catch (Exception)
            {
                // ignored
            }

            if (b?.GetSecurityStatus() == null)
            {
                return b;
            }

            
            Airport.Storage.StoreSuspiciousBag(b);
            return null;
        }

        public override void MoveBagToNextNode()
        {
            if (((ConveyorNode) Next).IsFull) return;
            var bag = Remove();
            if (bag.IsNull()) { return;}
            Next.Push(bag);
        }
    }
}
