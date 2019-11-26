using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class TerminalNode
    {
        public static int counter = 0;
        public static EventHandler SimulationFinishedEvent;

        public Image image { get; private set; }
        public Queue<Bag> BagQueue { get; }
        public Terminal Terminal { get; private set; }
        public TerminalNode(Terminal terminal, int top, int left) : base(top, left)
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
