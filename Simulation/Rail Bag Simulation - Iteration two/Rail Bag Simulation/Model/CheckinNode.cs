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
        public static string control;
        public CheckinNode():base()
        {
            BagsQueue = new Queue<Bag>();
        }

        public override string Nodeinfo()
        {
            string sender = "Check in: \n";
            lock (BagsQueue)
            {
                foreach (Bag g in BagsQueue)
                {
                    sender += g.GetBagInfo() + "\n";
                }
            }

            return sender;
        }

        public int QueueCount => BagsQueue.Count;
        internal bool IsEmpty()
        {
            lock (BagsQueue)
            {
                return QueueCount < 1;
            }
        }
        public Queue<Bag> BagsQueue { get; }

        public void Push(List<Bag> bagsList)
        { 
            bagsList.ForEach(p =>
            {
                control += p.GetBagInfo() + "\n";
                lock (BagsQueue)
                {
                    BagsQueue.Enqueue(p);
                }
            });
        }

        public override void Push(Bag b)
        {
         
        }

        public override Bag Remove()
        {
            lock (BagsQueue)
            {
                if (BagsQueue.Count < 1)
                    return null;
                var bag = BagsQueue.Dequeue();
                return bag;
            }
        }
    }
}
