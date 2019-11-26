using System;
using System.Collections.Generic;
using System.Linq;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {
        public static int counter=0;
        public static int totalNumberOfBags=0;
        public static EventHandler SimulationFinishedEvent;

        public Terminal Terminal { get; private set; }
        public TerminalNode(Terminal terminal)
        {
            totalNumberOfBags = Airport.TotalNumberOfBags;
            Terminal = terminal;
        }
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public override string NodeInfo()
        {
            return ListOfBagsInQueue.Aggregate("Terminal: \n" + Terminal.TerminalId + "\n", (current, g) => current + (g.GetBagInfo() + "\n"));
        }
        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }

        public ConveyorNode DetermineNextConveyorNode()
        {
            ConveyorNode tnode = null;
            Bag g = Peek();
            if (g.IsNull()) return null;
            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.Next != null && !(currentNode is GateNode node))
                {
                    currentNode = currentNode.Next;
                }

                string str = g?.TerminalAndGate;
                if (str.IsNull()) return null;
                string[] words = str?.Split('-');
                
                var result =words[1];
                if ((currentNode as GateNode)?.Gate.GateNr != result) continue;
                tnode = p;
                counter++;
                if (counter + Storage.GetNumberOfBagsInStorage() >= totalNumberOfBags)
                {
                    SimulationFinishedEvent?.Invoke(this, EventArgs.Empty);
                }
                break;
            }

            return tnode;
        }

        public override void MoveBagToNextNode()
        {
            var next = DetermineNextConveyorNode();
            if (next.IsNull()) return; 
            if (!next.IsFull)
            {
                var bag = Remove();
                if (bag.IsNull()) return;
                next.Push(bag);
            }
        }
    }
}
