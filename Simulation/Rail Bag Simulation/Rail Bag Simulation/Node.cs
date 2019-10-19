using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Node
    {
       
        public Node Next { get;  set; } // the next node it refers to; null if there does not exist a next node
        public Node Previous { get;  set; }
        
        public Node()
        {
         
            this.Next = null;
            this.Previous = null;
        }
        public virtual string Nodeinfo()
        {
            return "";
        }

    }
}

