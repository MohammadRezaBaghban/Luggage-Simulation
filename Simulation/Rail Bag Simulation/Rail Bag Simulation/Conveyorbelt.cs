using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{

    class Conveyorbelt
    {
        private int _id;
        private Queue<Bag> _bagQueue;

        public Conveyorbelt()
        {
            _bagQueue = new Queue<Bag>(5);
        }
        public bool Push(Bag _bagtoqueue)
        {
            if (_bagQueue.Count <= 5)
            {
                _bagQueue.Enqueue(_bagtoqueue);
            }
            else
            {
                return false;
                throw new Exception("Queue for the conveyor belt "+_id+" is full");
            }
            return true;
        
        }
        public Bag Remove()
        {
            Bag _bag;
            if (_bagQueue.Count >= 1)
            {
                _bag =(Bag)_bagQueue.Dequeue();
            }else
            {
                throw new Exception("Queue for the conveyor belt " + _id + " is empty");
            }
            return _bag;
        }

    }
}
