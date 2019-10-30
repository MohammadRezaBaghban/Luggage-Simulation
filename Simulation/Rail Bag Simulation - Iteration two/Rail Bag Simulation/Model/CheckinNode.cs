using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Rail_Bag_Simulation
{
    class CheckinNode : Node
    {
        public Queue<Bag> _bagsQueue;
        public Image image { get; private set; }
        public static string control;
        public CheckinNode(int top,int left):base(top, left)
        {
            _bagsQueue = new Queue<Bag>();
            image = new Image
            {
                Width = 150,
                Height = 150,
           
                Source = new BitmapImage(new Uri("../../Resources/check-in.png", UriKind.Relative))
            };

        }

        public override string Nodeinfo()
        {
            string sender = "Check in: \n";
            foreach (Bag g in _bagsQueue)
            {
                sender +=  g.GetBagInfo() + "\n";
            }

            return sender;
        }

        public bool Push(List<Bag> bagsList)
        { 
            bagsList.ForEach(p =>
            {
                
                control += p.GetBagInfo() + "\n";
                _bagsQueue.Enqueue(p);
            });

            return true;

        }

        public Bag Remove()
        {
            if (_bagsQueue.Count < 1)
                return null;
            var bag = _bagsQueue.Dequeue();
            return bag;
        }
    }
}
