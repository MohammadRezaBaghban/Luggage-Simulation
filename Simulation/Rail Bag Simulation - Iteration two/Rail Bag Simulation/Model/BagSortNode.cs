using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    internal class BagSortNode : Node
    {
        public BagSortNode() 
        {
            _bagQueue = new Queue<Bag>();
        }

      
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        private readonly Queue<Bag> _bagQueue;

        public void AddTerminal(int nbrOfConveyorbeltsBeforeTerminal)
        {
            ConveyorNode conveyorbelt = new ConveyorNode(5);
            if (nbrOfConveyorbeltsBeforeTerminal == 1)
            {
                TerminalNode terminalNode =new TerminalNode(new Terminal());
                conveyorbelt.Next = terminalNode;
                ListOfConnectedNodes.Add(conveyorbelt);
                return;
            }


            ConveyorNode currentNodelocator = conveyorbelt;

            for (int i = 1; i < nbrOfConveyorbeltsBeforeTerminal; i++)
            {
                currentNodelocator.Next = new ConveyorNode(5);
                currentNodelocator = (ConveyorNode)currentNodelocator.Next;

            }
            currentNodelocator.Next = new TerminalNode(new Terminal());

        }

        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }

        public Node DetermineNextNode(out Bag g)
        {
            Node tnode = null;
            g = Remove();
            if (g.IsNull()) return null;
            lock (ListOfConnectedNodes)
            {
                foreach (var p in ListOfConnectedNodes)
                {
                    Node currentNode = p;

                    while (currentNode.Next != null && !(currentNode is TerminalNode node))
                        currentNode = currentNode.Next;

                    var str = g?.TerminalAndGate;
                    var words = str.Split('-');
                    var result = Convert.ToInt32(words[0].Substring(1));
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


        public override string NodeInfo()
        {
            return _bagQueue.Aggregate("Bag Sorter: \n", (current, g) => current + (g.GetBagInfo() + "\n"));
        }
    }
}