using System;
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
        public SecurityNode(int top,int left):base(top,left)
        {
            image = new Image
            {
                Width = 80,
                Height = 80,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Source = new BitmapImage(new Uri("../Resources/securityCheckHouse.png", UriKind.Relative))
            };
        }
        public override string Nodeinfo()
        {
            return "Security:" + Airport.Storage.ToString();
        }

        public void ScanBagSecurity(Bag b)
        {
            Thread.Sleep(DelayTime);

            if (b?.GetSecurityStatus() == null)
            {
                if (Next is ConveyorNode node)
                {       
                    node.PushBagToConveyorBelt(b);
                }
                return;
            }
            
            Airport.Storage.StoreSuspiciousBag(b);
        }
    }
}
