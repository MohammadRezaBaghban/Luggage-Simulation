using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Rail_Bag_Simulation
{
    class BagSortNode : Node
    {
        public Image image { get; private set; }
        public List<ConveyorNode> ListOfConnectedNodes { get; } = new List<ConveyorNode>();

        public BagSortNode(int top, int left) : base(top, left)
        {
            DelayTime = 10;
           TransformedBitmap tr = new TransformedBitmap();
           RotateTransform right = new RotateTransform(90);
           BitmapImage bmp = new BitmapImage();
         

            image = new Image
            {
                Width = 72,
                Height = 72,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                
                
            };
            bmp  = new BitmapImage(new Uri($"../../Resources/sorter.png", UriKind.Relative));
            tr.BeginInit();

            tr.Source = bmp;

            RotateTransform transform = new RotateTransform(90);

            tr.Transform = transform;

            tr.EndInit();

            image.Source = tr;
        }

        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }

        public void PassBag(Bag g)
        {
            Node next = (ConveyorNode) determineNextNode(g);
            ConveyorNode tmpConveyor = null;
            while (!(next is TerminalNode))
            {
                if (((ConveyorNode)(next)).IsFull == false)
                {
                    ((ConveyorNode)(next)).PushBagToConveyorBelt(g);
                }

                if (next.Next is TerminalNode) tmpConveyor = (ConveyorNode) next;
                next = ((next).Next) ;
            }

            var tbag = tmpConveyor.RemoveBagFromConveyorBelt();

            while (tbag == null && !tmpConveyor.IsEmpty())
            {
                tbag = tmpConveyor.RemoveBagFromConveyorBelt();
            }
            if (tbag != null) ((TerminalNode)(next)).PassBag(tbag);

            Thread.Sleep(DelayTime);
        }

        private Node determineNextNode(Bag g)
        {
            Node tnode = null;
            if (g == null) return null;

            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.Next != null && !(currentNode is TerminalNode node))
                {
                    currentNode = currentNode.Next;
                }

                string str = g.TerminalAndGate;
                string[] words = str.Split('-');
                var result = words[0];
                if ((currentNode as TerminalNode)?.Terminal.TerminalId.ToString() != result) continue;
                tnode = p;
                break;
            }

            return tnode;
        }


        public override string Nodeinfo()
        {
            var sender =  $"Bag sorter : \n" ;

            

            return sender;
        }
    }
}