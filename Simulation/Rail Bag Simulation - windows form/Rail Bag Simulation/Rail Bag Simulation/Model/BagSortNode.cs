using System;
using System.Collections.Generic;
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

            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.GetNext() != null && !(currentNode is TerminalNode node))
                    currentNode = currentNode.GetNext();

                var result = GetTerminalNumber(g);
                if ((currentNode as TerminalNode)?.Terminal.TerminalId != result) continue;
                tnode = p;
                break;
            }

            return tnode;
        }

        public override void AddNode(int parentid, Type parenttype, Node _nodetoadd)

        {
            if (GetType() == parenttype && _nodetoadd is ConveyorNode conveyorNode)
                ConnectNodeToSorter(conveyorNode);
            else
                foreach (Node connectednodes in ListOfConnectedNodes)
                    connectednodes.AddNode(parentid, parenttype, _nodetoadd);
        }

        public override void PrintNodes(ref List<Node> Nodes)
        {
            if (!Nodes.Contains(this))
                Nodes.Add(this);

            foreach (Node connectednodes in ListOfConnectedNodes) connectednodes.PrintNodes(ref Nodes);
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
            lock (ListOfConnectedNodes)
            {
                var next = DetermineNextNode();
                if (next.IsNull()) return;
                var bag = Remove();
                if (bag.IsNull()) return;

                if (next.IsFull) { return;}

                next.Push(bag);
                OnQueueChangedEventHandler?.Invoke(this, EventArgs.Empty);
            }
        }


        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Bag Sort:"};
            sender.AddRange(base.NodeInfo());
            return sender;
        }
    }
}