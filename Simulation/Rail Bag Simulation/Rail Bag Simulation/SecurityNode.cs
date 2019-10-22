using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class SecurityNode : Node
    {
        public override string Nodeinfo()
        {
            return " ";
        }

        private void ScanBagSecurity(Bag b)
        {
            if (b.GetSecurityStatus() == null)
            {
                if (Next is ConveyorNode node)
                {
                    node.Conveyor.Push(b);
                }
                return;
            }
            
            Airport.Storage.StoreSuspiciousBag(b);
        }
    }
}
