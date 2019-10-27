using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public abstract class Node
    {
       
        public Node Next { get;  set; } // the next node it refers to; null if there does not exist a next node
        public Node Previous { get;  set; }

        public static List<string> log=new List<string>();

        public int DelayTime
        {
            get => _delayTime;
            set => _delayTime = value = 150;
        }

        

        private int _delayTime;


        public Node()
        {
         
            Next = null;
            Previous = null;
        }

        public abstract string Nodeinfo();


    }
}

