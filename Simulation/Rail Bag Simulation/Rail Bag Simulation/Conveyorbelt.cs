using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{

    class Conveyorbelt
    {
        private static int _idToGive = 100;
        public bool IsFull { get; private set; }
        public int Id { get; private set; }
        private Queue<Bag> _bagQueue;

        public Conveyorbelt()
        {
            Id = ++_idToGive;
            _bagQueue = new Queue<Bag>(5);
        }
        public Queue<Bag> ListofBagsinqueue()
        {
            return _bagQueue;
        }
        public bool Push(Bag bagtoqueue)
        {
            if (_bagQueue.Count < 5)
            {
                _bagQueue.Enqueue(bagtoqueue);

            }
            else
            {
                IsFull = true;
                throw new Exception("Queue for the conveyor belt "+Id+" is full"); 
            }
            return true;
        
        }
        public Bag Remove()
        {
            Bag bag;
            if (_bagQueue.Count >= 1)
            {
                bag =_bagQueue.Dequeue();
                IsFull = false;
            }else
            {
                throw new Exception("Queue for the conveyor belt " + Id + " is empty");
            }
            return bag;
        }
        public override string ToString()
        {
            string bagqueueinfo ="";
            foreach( Bag g in _bagQueue)
            {
                bagqueueinfo += g.GetBagInfo() + "\n";
            }
            return bagqueueinfo;
        }

    }
}
