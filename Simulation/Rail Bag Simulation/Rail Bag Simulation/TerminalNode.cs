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
            Node next = (ConveyorNode)determineNextNode(g);
            ConveyorNode tmpConveyor = null;
            while (!(next is GateNode))
            {
                if (((ConveyorNode)(next)).Conveyor.IsFull == false)
                {
                    ((ConveyorNode)(next)).Conveyor.PushBagToConveyorBelt(((ConveyorNode)(next)).Conveyor.RemoveBagFromConveyorBelt());
                }

                if (next.Next is GateNode) tmpConveyor = (ConveyorNode)next;
                next = ((next).Next);
            }

            var tbag = tmpConveyor.Conveyor.RemoveBagFromConveyorBelt();

            while (tbag == null && !tmpConveyor.Conveyor.IsEmpty())
            {
                tbag = tmpConveyor.Conveyor.RemoveBagFromConveyorBelt();
            }
            if (tbag != null) ((GateNode)(next)).AddBag(tbag);
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
