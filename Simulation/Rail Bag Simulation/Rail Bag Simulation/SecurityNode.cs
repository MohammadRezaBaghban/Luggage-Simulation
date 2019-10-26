﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class SecurityNode : Node
    {
        public override string Nodeinfo()
        {
            return "Security: \n";
        }

        private void ScanBagSecurity(Bag b)
        {
            Thread.Sleep(DelayTime);

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
