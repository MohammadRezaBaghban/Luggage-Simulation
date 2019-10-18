using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Node
    {
        public object obj { get; private set; } //the item it refers to
        public Node next { get; set; } // the next node it refers to; null if there does not exist a next node
        public NextStop stopcheck;
        public Node(object obj)
        {
            if (obj is Conveyorbelt)
            {
                this.obj = (Conveyorbelt)obj;
            }
            else
            {
                this.obj = obj;
            }
            this.next = null;
        }
        
        public override string ToString()
        {
            if (obj is Conveyorbelt)
            {
                string bagsinqueue = null;

                foreach (Bag g in ((Conveyorbelt)obj).ListofBagsinqueue())
                {
                    bagsinqueue += g.GetBagInfo()+"\n";
                }
                return bagsinqueue;
            }
           
            return "this is a checkpoint ";

        }
    }
}

