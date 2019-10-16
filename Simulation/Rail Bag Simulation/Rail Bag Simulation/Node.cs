using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
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
    }

