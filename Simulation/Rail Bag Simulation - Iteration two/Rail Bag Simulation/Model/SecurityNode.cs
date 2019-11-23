using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Rail_Bag_Simulation
{
    class SecurityNode : Node
    {
        public Image image { get; private set; }
       

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
                lock (BagsQueue)
                {
                    b = BagsQueue.Dequeue();
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
