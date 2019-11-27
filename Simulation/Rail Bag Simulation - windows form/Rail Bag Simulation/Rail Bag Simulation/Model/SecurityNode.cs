using System;
using System.Collections.Generic;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    internal class SecurityNode : Node
    {
        public override Bag Remove()
        {
            return ScanBagSecurity();
        }

        public override List<String> NodeInfo()
        {
            var sender = new List<string> {"Security:"};
            sender.AddRange(base.NodeInfo());
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

    }
}
