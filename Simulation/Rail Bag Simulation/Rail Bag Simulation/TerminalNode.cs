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
        public Terminal Terminal { get; set; }
        private List<ConveyorNode> _listOfConnectedNodes = new List<ConveyorNode>();
        public List<ConveyorNode> ListOfConnectedNodes => _listOfConnectedNodes;

        public override string Nodeinfo()
        {
            throw new NotImplementedException(); 
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

                var st = g.TerminalAndGate;
                var pFrom = st.IndexOf("G") + "G".Length;
                var result = st.Substring(pFrom);
                if ((currentNode as GateNode)?.Gate.GateNr.ToString() != result) continue;
                tnode = p;
                break;
            }

            return tnode;
        }
    }
}
