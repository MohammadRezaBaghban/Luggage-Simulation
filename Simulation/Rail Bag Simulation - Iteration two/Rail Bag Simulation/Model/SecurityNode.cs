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
        private readonly Queue<Bag> _bagQueue;
        public Image image { get; private set; }
        public SecurityNode():base()
        {
            _bagQueue = new Queue<Bag>();
            image = new Image
            {
                Width = 80,
                Height = 80,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Source = new BitmapImage(new Uri("../Resources/securityCheckHouse.png", UriKind.Relative))
            };
        }

        public override void Push(Bag bag)
        {
            lock (_bagQueue)
            {
                _bagQueue.Enqueue(bag);
            }
        }

        public override Bag Remove()
        {
            return ScanBagSecurity();
        }

        public override string Nodeinfo()
        {
            string sender = "Security: \n";
            foreach (Bag g in _bagQueue)
            {
                sender += g.GetBagInfo() + "\n";
            }

            return sender;
        }

        private Bag ScanBagSecurity()
        {
            Bag b = null;
            try
            {
                lock (_bagQueue)
                {
                    b = _bagQueue.Dequeue();
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
