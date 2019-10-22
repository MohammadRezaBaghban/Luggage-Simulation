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
        private int _setsize;
        private Queue<Bag> _bagQueue;

        public Conveyorbelt(int setsize)
        {
            _setsize = setsize;
            Id = ++_idToGive;
            _bagQueue = new Queue<Bag>(_setsize);
        }
        public Queue<Bag> ListofBagsinqueue()
        {
            return _bagQueue;
        }
        public bool Push(Bag bagtoqueue)
        {
            if (_bagQueue.Count < _setsize)
            { 
                _bagQueue.Enqueue(bagtoqueue);
                if(_bagQueue.Count<_setsize-1) _bagQueue.Enqueue(null); //To be made random at the next iteration
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
                return null;
            Bag bag =_bagQueue.Dequeue();
            IsFull = false;
            return bag;
        }
    

    public override string ToString() // change the method to return a list of bags
        {
            string bagqueueinfo ="";
            foreach( Bag g in ListofBagsinqueue())
            {
                
                bagqueueinfo += string.Format(g != null ? g.GetBagInfo() + "\n " : " ** \n ");
            }
            return bagqueueinfo;
        }

    }
}
