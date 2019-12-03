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

                    while (currentNode.GetNext() != null && !(currentNode is TerminalNode node))
                        currentNode = currentNode.GetNext();

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
        public override void AddNode(int parentid,Type parenttype, Node _nodetoadd)
        
        {
            if (this.GetType() == parenttype && _nodetoadd is ConveyorNode conveyorNode)
            {
                this.ConnectNodeToSorter(conveyorNode);
            }
            else
            {
                foreach(Node connectednodes in ListOfConnectedNodes)
                {
                    connectednodes.AddNode(parentid, parenttype, _nodetoadd);
                }
            }

        }
        public override void PrintNodes(ref List<Node> Nodes)
        {
            if (!Nodes.Contains(this))
                Nodes.Add(this);

           foreach(Node connectednodes in ListOfConnectedNodes)
            {
                connectednodes.PrintNodes(ref Nodes);
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