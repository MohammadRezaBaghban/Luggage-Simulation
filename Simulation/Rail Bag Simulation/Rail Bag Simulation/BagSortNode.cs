using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
            Node next = (ConveyorNode) determineNextNode(g);
            ConveyorNode tmpConveyor = null;
            while (!(next is TerminalNode))
            {
                if (((ConveyorNode)(next)).Conveyor.IsFull == false)
                {
                    ((ConveyorNode)(next)).Conveyor.PushBagToConveyorBelt(((ConveyorNode)(next)).Conveyor.RemoveBagFromConveyorBelt());
                }

                if (next.Next is TerminalNode) tmpConveyor = (ConveyorNode) next;
                next = ((next).Next) ;
            }

            var tbag = tmpConveyor.Conveyor.RemoveBagFromConveyorBelt();

            while (tbag == null && !tmpConveyor.Conveyor.IsEmpty())
            {
                tbag = tmpConveyor.Conveyor.RemoveBagFromConveyorBelt();
            }
            if (tbag != null) ((TerminalNode)(next)).PassBag(tbag);

            Thread.Sleep(DelayTime);
        }

        private Node determineNextNode(Bag g)
        {
            Node tnode = null;
            if (g == null) return null;

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
            var sender =  $"Bag sorter : \n" ;

            ListOfConnectedNodes.ForEach(n => { sender += n.Nodeinfo().ToString() +" "+ n.Next.Nodeinfo(); });

            return sender;
        }
    }
}