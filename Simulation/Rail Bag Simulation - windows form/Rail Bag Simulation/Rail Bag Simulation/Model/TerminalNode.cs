using System;
using System.Collections.Generic;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    internal class TerminalNode : Node
    {
        public TerminalNode(Terminal terminal)
        {
            Terminal = terminal;
            Id = terminal.TerminalId;
        }


        public Terminal Terminal { get; }

        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Terminal: \n" + Terminal.TerminalId};
            sender.AddRange(base.NodeInfo());

            return sender;
        }

        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }

        public override void AddNode(int parentid, Type parenttype, Node _nodetoadd)

        {
            if (Id == parentid && GetType() == parenttype && _nodetoadd is ConveyorNode conveyorNode)
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

        public ConveyorNode DetermineNextConveyorNode()
        {
            ConveyorNode tnode = null;
            var g = Peek();
            if (g.IsNull()) return null;
            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.GetNext() != null && !(currentNode is GateNode node))
                    currentNode = currentNode.GetNext();

                if (GetGateNumber(g, out var result)) return null;
                if ((currentNode as GateNode)?.Gate.GateNr != result) continue;
                tnode = p;
                break;
            }

            return tnode;
        }

        private static bool GetGateNumber(Bag g, out string result)
        {
            var str = g?.TerminalAndGate;
            result = null;
            if (str.IsNull()) return true;
            var words = str?.Split('-');

            result = words[1];
            return false;
        }

        public override void MoveBagToNextNode()
        {
            lock (BagsQueue)
            {
                var next = DetermineNextConveyorNode();
                while (next.IsNull()) return;

                var bag = Remove();
                if (bag.IsNull()) return;

                while (next.IsFull)
                {
                }

                next.Push(bag);
                OnQueueChangedEventHandler?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}