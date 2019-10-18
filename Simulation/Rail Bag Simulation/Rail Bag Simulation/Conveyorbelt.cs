using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{

    class Conveyorbelt
    {
        public int ID { get; private set; }
        private Queue<Bag> _bagQueue;

        public Conveyorbelt()
        {
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
                return false;
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
            }else
            {
                throw new Exception("Queue for the conveyor belt " + ID + " is empty");
            }
            return _bag;
        }

    }
}
