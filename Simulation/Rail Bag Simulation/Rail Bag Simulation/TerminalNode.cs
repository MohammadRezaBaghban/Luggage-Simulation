using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {

        public Terminal Terminal { get; private set; }
        public TerminalNode(Terminal terminal)
        {
            Terminal = terminal;
        }
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public override string Nodeinfo()
        {
            return "Terminal: "+Terminal.TerminalId +"\n";
        }
        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }
        public void PassBag(Bag g)
        {
            while (!((ConveyorNode)determineNextNode(g)).Conveyor.Push(g)) { }
            Thread.Sleep(DelayTime);
        }

        private Node determineNextNode(Bag g)
        {
            Node tnode = null;
            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.Next != null && !(currentNode is GateNode node))
                {
                    currentNode = currentNode.Next;
                }

                string str = g.TerminalAndGate;
                string[] words = str.Split('-');
                var result = words[1];
                if ((currentNode as GateNode)?.Gate.GateNr.ToString() != result) continue;
                tnode = p;
                break;
            }

            return tnode;
        }
    }
}
