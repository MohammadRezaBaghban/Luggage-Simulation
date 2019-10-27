using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class CheckinNode : Node
    {
        public Queue<Bag> _bagsQueue;

        public CheckinNode()
        {
            _bagsQueue = new Queue<Bag>();
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
