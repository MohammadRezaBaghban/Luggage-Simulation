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
        public bool isFull { get; private set; }
        public int ID { get; private set; }
        private Queue<Bag> _bagQueue;

        public Conveyorbelt()
        {
            ID = ++_idToGive;
            _bagQueue = new Queue<Bag>(5);
        }
        public Queue<Bag> ListofBagsinqueue()
        {
            return _bagQueue;
        }
        public bool Push(Bag _bagtoqueue)
        {
            if (_bagQueue.Count < 5)
            {
                _bagQueue.Enqueue(_bagtoqueue);

            }
            else
            {
                isFull = true;
                throw new Exception("Queue for the conveyor belt "+ID+" is full"); 
            }
            return true;
        
        }
        public Bag Remove()
        {
            Bag _bag;
            if (_bagQueue.Count >= 1)
            {
                _bag =_bagQueue.Dequeue();
                isFull = false;
            }else
            {
                throw new Exception("Queue for the conveyor belt " + ID + " is empty");
            }
            return _bag;
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
