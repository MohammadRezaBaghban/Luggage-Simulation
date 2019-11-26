using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    abstract class Node
    {
        public Node Next { get; set; } // the next node it refers to; null if there does not exist a next node
        public Node Previous { get; set; }

        public int Top { get; private set; }
        public int Left { get; private set; }
        public static List<string> log = new List<string>();

        public Node(int top, int left)
        {
            Top = top;
            Left = left;
            Next = null;
            Previous = null;
        }

        public abstract string Nodeinfo();
    }
}
