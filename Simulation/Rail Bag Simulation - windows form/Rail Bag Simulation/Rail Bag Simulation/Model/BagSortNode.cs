using System;
using System.Collections.Generic;
using System.Linq;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    internal class BagSortNode : Node
    {
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }

        public ConveyorNode DetermineNextNode()
        {
            ConveyorNode tnode = null;
            var g = Peek();
            if (g.IsNull()) return null;
            lock (ListOfConnectedNodes)
            {
                foreach (var p in ListOfConnectedNodes)
                {
                    Node currentNode = p;

                    while (currentNode.Next != null && !(currentNode is TerminalNode node))
                        currentNode = currentNode.Next;

                    var result = GetTerminalNumber(g);
                    if ((currentNode as TerminalNode)?.Terminal.TerminalId != result) 
                    { 
                        continue;
                    }
                    tnode = p;
                    break;
                }
                return tnode;
            }
        }

        private static int GetTerminalNumber(Bag g)
        {
            var str = g?.TerminalAndGate;
            var words = str?.Split('-');
            var result = Convert.ToInt32(words?[0].Substring(1));
            return result;
        }

        public override void MoveBagToNextNode()
        {
            var next = DetermineNextNode();
            if (next.IsNull()) return;
            var bag = Remove();
            if (bag.IsNull()) return;

            while(next.IsFull) { }

            next.Push(bag);
        }


        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Bag Sort:"};
            sender.AddRange(base.NodeInfo());
            return sender;
        }
    }
}