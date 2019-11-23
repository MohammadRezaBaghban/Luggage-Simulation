using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {
        public static int counter=0;
        public static EventHandler SimulationFinishedEvent;

        public Queue<Bag> BagQueue { get; }
        public Terminal Terminal { get; private set; }
        public TerminalNode(Terminal terminal)
        {
            BagQueue = new Queue<Bag>();

            Terminal = terminal;
        }
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public override string Nodeinfo()
        {
            return BagQueue.Aggregate("Terminal: \n" + Terminal.TerminalId + "\n", (current, g) => current + (g.GetBagInfo() + "\n"));
        }
        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }


        public override void Push(Bag bag)
        {
            lock (BagQueue)
            {
                BagQueue.Enqueue(bag);
            }
        }

        public override Bag Remove()
        {
            lock (BagQueue)
            {
                if (BagQueue.Count < 1)
                    return null;
                var bag = BagQueue.Dequeue();
                return bag;
            }
        }

        public Bag Peek()
        {
            lock (BagQueue)
            {
                if (BagQueue.Count < 1)
                    return null;
                var bag = BagQueue.Peek();
                return bag;
            }
        }

        public ConveyorNode DetermineNextConveyorNode(out Bag g)
        {
            ConveyorNode tnode = null;
            g = Remove();
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
                if (counter + Storage.GetNumberOfBagsInStorage() >= ViewModel.ViewModel.numberOfBags)
                {
                    SimulationFinishedEvent?.Invoke(this, EventArgs.Empty);
                }
                break;
            }

            return tnode;
        }
    }
}
