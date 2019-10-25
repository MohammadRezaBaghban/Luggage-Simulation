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
              //if(_bagQueue.Count<4) _bagQueue.Enqueue(null); //To be made random at the next iteration
            }
            else
            {
                IsFull = true;
                return false;
            }
            return true;
        
        }

        public Bag Remove()
        {
            
            if (_bagQueue.Count < 1)
            {
                throw new Exception("Queue for the conveyor belt " + Id + " is empty");
            }
            IsFull = false; 
            Bag bag =_bagQueue.Dequeue();
            return bag;
        }
    

    public override string ToString() // change the method to return a list of bags
        {
            string bagqueueinfo ="";
            foreach( Bag g in ListofBagsinqueue())
            {
                
                bagqueueinfo += string.Format(g != null ? g.GetBagInfo() + "\n" : "Empty");
            }
            return bagqueueinfo;
        }

    }
}
