using System;
using System.Collections.Generic;
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
        public BagSortNode(int top, int left) : base(top, left)
        {
            BagQueue = new Queue<Bag>();
            DelayTime = 10;
            var tr = new TransformedBitmap();


            image = new Image
            {
                Width = 72,
                Height = 72,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            var bmp = new BitmapImage(new Uri("../../Resources/sorter.png", UriKind.Relative));
            tr.BeginInit();

            tr.Source = bmp;

            var transform = new RotateTransform(90);

            tr.Transform = transform;

            tr.EndInit();

            image.Source = tr;
        }

        public Image image { get; }
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public Queue<Bag> BagQueue { get; }

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

        public Node determineNextNode(out Bag g)
        {
            Node tnode = null;
            g = this.Remove();
            if (!g.IsNotNull()) return null;
            lock (ListOfConnectedNodes)
            {
                foreach (var p in ListOfConnectedNodes)
                {
                    Node currentNode = p;

                    while (currentNode.Next != null && !(currentNode is TerminalNode node))
                        currentNode = currentNode.Next;

                    var str = g.TerminalAndGate;
                    var words = str.Split('-');
                    var result = words[0];
                    if ((currentNode as TerminalNode)?.Terminal.TerminalId != result) continue;
                    tnode = p;
                    break;
                }

                return tnode;
            }
        }


        public override string Nodeinfo()
        {
            var sender = "Bag Sorter: \n";
            foreach (var g in BagQueue) sender += g.GetBagInfo() + "\n";

            return sender;
        }
    }
}