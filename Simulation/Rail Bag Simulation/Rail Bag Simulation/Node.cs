using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    abstract class Node
    {
       
       
        public Node ParentNode { get;  set; }

        private List<Node> _listOfConnectedNodes = new List<Node>();

        public int DelayTime
        {
            get => _delayTime;
            set => _delayTime = value = 10;
        }

        public List<Node> ListOfConnectedNodes => _listOfConnectedNodes;

        private int _delayTime;


        public Node(Node s)
        {
         
            ParentNode = s;
        }

        public abstract string Nodeinfo();


    }
}

