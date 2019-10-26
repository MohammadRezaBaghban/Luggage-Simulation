using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class BagSortNode : Node
    {
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public BagSortNode()
        {
            DelayTime = 10;
        }

        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }

        public void PassBag(Bag g)
        {
            while(!((ConveyorNode)determineNextNode(g)).Conveyor.Push(g)) { }
            Thread.Sleep(DelayTime);
        }

        private Node determineNextNode(Bag g)
        {
            Node tnode = null;
            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.Next != null && !(currentNode is TerminalNode node))
                {
                    currentNode = currentNode.Next;
                }

            
                string str = g.TerminalAndGate;
                string[] words = str.Split('-');
                var result = words[0];
                if ((currentNode as TerminalNode)?.Terminal.TerminalId.ToString() != result) continue;
                tnode = p;
                break;
            }

            return tnode;
        }


        public override string Nodeinfo()
        {
            return "Bag sorter: \n";
        }
    }
}