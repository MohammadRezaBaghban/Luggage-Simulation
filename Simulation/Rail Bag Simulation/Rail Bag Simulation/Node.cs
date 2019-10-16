using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
<<<<<<< HEAD
      class Node
        {
            private object obj; //the item it refers to
            private Node next;    // the next node it refers to; null if there does not exist a next node

            public Node(object obj)
            {
                this.obj = obj;
                this.next = null;
            }

            public object getItem() { return this.obj; }

            public Node getNextNode() { return this.next; }
            public void setNext(Node n) { this.next = n; }

        }
=======
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
>>>>>>> 54d705e62b12b4cfad5e13a7a44bbf015c889ba4
    }

