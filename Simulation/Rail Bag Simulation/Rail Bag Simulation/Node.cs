using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Node
    {
       
        public Node next { get;  set; } // the next node it refers to; null if there does not exist a next node
        public Node previous { get;  set; }
        
        public Node()
        {
         
            this.next = null;
            this.previous = null;
        }
        public virtual string Nodeinfo()
        {
            return "";
        }

    }
}

