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
        public void Push()
        {

        }
        public Bag Remove()
        {
            return null;
        }

    }
}
