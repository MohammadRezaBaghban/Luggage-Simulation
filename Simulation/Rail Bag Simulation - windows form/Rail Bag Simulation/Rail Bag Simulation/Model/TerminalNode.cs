using System;
using System.Collections.Generic;
using System.Threading;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    internal class TerminalNode : Node
    {
        

        public Terminal Terminal { get; }

        public TerminalNode(Terminal terminal)
        {
            Terminal = terminal;
        }

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

        public ConveyorNode DetermineNextConveyorNode()
        {
            ConveyorNode tnode = null;
            var g = Peek();
            if (g.IsNull()) return null;
            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.GetNext() != null && !(currentNode is GateNode node)) currentNode = currentNode.GetNext();

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
            var next = DetermineNextConveyorNode();
            while (next.IsNull()) return;

            var bag = Remove();
            if (bag.IsNull()) return;

            while (next.IsFull)
            {
            }

            next.Push(bag);
        }

        
    }
}