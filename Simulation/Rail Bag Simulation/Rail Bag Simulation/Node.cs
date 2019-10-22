using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    abstract class Node
    {
       
        public Node Next { get;  set; } // the next node it refers to; null if there does not exist a next node
        public Node Previous { get;  set; }

        private List<Node> _listOfConnectedNodes = new List<Node>();

        public int DelayTime
        {
            get => _delayTime;
            set => _delayTime = value = 10;
        }

        public List<Node> ListOfConnectedNodes => _listOfConnectedNodes;

        private int _delayTime;


        public Node()
        {
         
            Next = null;
            Previous = null;
        }

        public abstract string Nodeinfo();


    }
}

