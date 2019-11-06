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
        public Image image { get; private set; }
        public Queue<Bag> BagQueue { get; }
        public Terminal Terminal { get; private set; }
        public TerminalNode(Terminal terminal,int top, int left) : base(top, left)
        {
            BagQueue = new Queue<Bag>();

            Terminal = terminal;
            image = new Image
            {
                Width = 80,
                Height = 80,
            
                Source = new BitmapImage(new Uri("../../Resources/terminal.jpg", UriKind.Relative))
            };
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


        public bool Push(Bag bag)
        {
            lock (BagQueue)
            {
                BagQueue.Enqueue(bag);
                return true;
            }
        }

        public Bag Remove()
        {
            lock (BagQueue)
            {
                if (BagQueue.Count < 1)
                    return null;
                var bag = BagQueue.Dequeue();
                return bag;
            }
        }

        public Node DetermineNextNode(out Bag g)
        {
            Node tnode = null;
            g = this.Remove();
            if (!g.IsNotNull()) return null;
            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.Next != null && !(currentNode is GateNode node))
                {
                    currentNode = currentNode.Next;
                }

                string str = g?.TerminalAndGate;
                string[] words = str.Split('-');
                var result = words[1];
                if ((currentNode as GateNode)?.Gate.GateNr.ToString() != result) continue;
                tnode = p;
                counter++;
                break;
            }

            return tnode;
        }
    }
}
