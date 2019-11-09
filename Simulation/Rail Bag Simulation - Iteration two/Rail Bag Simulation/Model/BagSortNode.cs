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
        public BagSortNode(int top, int left) : base(top, left)
        {
            _bagQueue = new Queue<Bag>();
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

        private Queue<Bag> _bagQueue;


        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }
        

        public bool Push(Bag bag)
        {
            lock (_bagQueue)
            {
                _bagQueue.Enqueue(bag);
                return true;
            }
        }

        public Bag Remove()
        {
            lock (_bagQueue)
            {
                if (_bagQueue.Count < 1)
                    return null;
                var bag = _bagQueue.Dequeue();
                return bag;
            }
        }

        public Node determineNextNode(out Bag g)
        {
            Node tnode = null;
            g = this.Remove();
            if (g != null)
                lock (ListOfConnectedNodes)
                {
                    foreach (var p in ListOfConnectedNodes)
                    {
                        Node currentNode = p;

                        while (currentNode.Next != null && !(currentNode is TerminalNode node))
                            currentNode = currentNode.Next;

                        var str = g?.TerminalAndGate;
                        var words = str.Split('-');
                        var result = words[0];
                        if ((currentNode as TerminalNode)?.Terminal.TerminalId != result) continue;
                        tnode = p;
                        break;
                    }

                    return tnode;
                }

            return null;
        }


        public override string Nodeinfo()
        {
            return _bagQueue.Aggregate("Bag Sorter: \n", (current, g) => current + (g.GetBagInfo() + "\n"));
        }
    }
}