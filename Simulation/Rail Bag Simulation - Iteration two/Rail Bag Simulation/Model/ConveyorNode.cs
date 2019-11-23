using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    
    class ConveyorNode : Node
    {
        private static int _idToGive = 100;
        public int Id { get; }
        private readonly int _setsize;
        private readonly Queue<Bag> _bagQueue;

        public ConveyorNode(int setsize)
        {
            _setsize = setsize;
            Id = ++_idToGive;
            _bagQueue = new Queue<Bag>(_setsize);
            
        }

        public bool IsEmpty { get; private set; } = true;
        public bool IsFull { get; private set; } = false;
        public Queue<Bag> ListofBagsinqueue()
        {
            lock (_bagQueue)
            {
                return _bagQueue;
            }
        }
        public override void Push(Bag bagtoqueue)
        {
            if (bagtoqueue == null) return;
            lock (_bagQueue)
            {
                if (_bagQueue.Count >= _setsize) return;
                _bagQueue.Enqueue(bagtoqueue);
                IsEmpty = false;
                var count = _bagQueue.Count;
                if (count < _setsize-1) _bagQueue.Enqueue(null);
                if (count == _setsize)IsFull = true;

            }
        }

        public override Bag Remove()
        {
            lock (_bagQueue)
            {
                if (_bagQueue.Count < 1){ IsEmpty = true; return null; }

            }
            var bag = _bagQueue.Dequeue();
            IsFull = false;
            return bag;
        }


        public override string NodeInfo() // change the method to return a list of bags
        {
            var bagqueueinfo = "Conveyor " + Id.ToString() + ": \n";
            var listOfBags = ListofBagsinqueue();
            lock (listOfBags)
            {
                foreach (Bag g in listOfBags)
                {
                    if(g != null){bagqueueinfo += string.Format( g.GetBagInfo() + "\n ");}
                    else
                    {
                        bagqueueinfo += "\n ** \n";
                    }
                }}
            return bagqueueinfo;
        }

       
    }
}
