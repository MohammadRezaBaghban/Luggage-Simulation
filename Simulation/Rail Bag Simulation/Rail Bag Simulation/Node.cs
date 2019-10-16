using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
     class Node
    {
        private Object machine; //the item it refers to
        private Node next;    // the next node it refers to; null if there does not exist a next node

        public Node(Object machine)
        {
            this.machine = machine;
            this.next = null;
        }

        
        public Object getMachine()
        {
            return this.machine;
        }
        public Node GetNext() { return this.next; }
        public void SetNext(Node n) { this.next = n; }  
    }
}
