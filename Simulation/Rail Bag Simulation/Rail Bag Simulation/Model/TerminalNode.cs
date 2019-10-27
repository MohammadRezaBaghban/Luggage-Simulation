using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {
        public static int counter=0;
        public Terminal Terminal { get; private set; }
        public TerminalNode(Terminal terminal)
        {
            Terminal = terminal;
        }
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public override string Nodeinfo()
        {
            string sender =" Terminal: " +Terminal.TerminalId +"\n";
            ListOfConnectedNodes.ForEach(n => { sender += n.Nodeinfo() + n.Next.Nodeinfo(); });
            return sender ;
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
                    Thread.Sleep(DelayTime);
                    ((ConveyorNode)(next)).Conveyor.PushBagToConveyorBelt(g);
                }
                if (next.Next is GateNode) tmpConveyor = (ConveyorNode)next;
                next = ((next).Next);
            }

            var tbag = tmpConveyor.Conveyor.RemoveBagFromConveyorBelt();
            while (tbag == null && !tmpConveyor.Conveyor.IsEmpty())
            {
                tbag = tmpConveyor.Conveyor.RemoveBagFromConveyorBelt();
            }

            if (tbag != null)
            {
                Thread.Sleep(DelayTime);
                ((GateNode)(next)).AddBag(tbag); counter++;
            }
            
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
