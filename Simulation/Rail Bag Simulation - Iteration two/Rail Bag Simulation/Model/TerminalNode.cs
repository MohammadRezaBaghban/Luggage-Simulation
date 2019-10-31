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

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {
        public static int counter=0;
        public Image image { get; private set; }
        public Terminal Terminal { get; private set; }
        public TerminalNode(Terminal terminal,int top, int left) : base(top, left)
        {
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
            string sender =" Terminal: " +Terminal.TerminalId +"\n";
           
            return sender ;
        }
        public void ConnectNodeToSorter(ConveyorNode n)
        {
            ListOfConnectedNodes.Add(n);
        }
        public void PassBag(Bag g)
        {
            Node next = (ConveyorNode)determineNextNode(g);
            ConveyorNode tmpConveyor = null;
            while (!(next is GateNode))
            {
                if (((ConveyorNode)(next)).IsFull() == false)
                {
                    Thread.Sleep(DelayTime);
                    ((ConveyorNode)(next)).PushBagToConveyorBelt(g);
                }
                if (next.Next is GateNode) tmpConveyor = (ConveyorNode)next;
                next = ((next).Next);
            }

            var tbag = tmpConveyor.RemoveBagFromConveyorBelt();
            while (tbag == null && !tmpConveyor.IsEmpty())
            {
                tbag = tmpConveyor.RemoveBagFromConveyorBelt();
            }

            if (tbag != null)
            {
                Thread.Sleep(DelayTime);
                ((GateNode)(next)).AddBag(tbag); counter++;
            }
            
        }

        public Node determineNextNode(Bag g)
        {
            Node tnode = null;
            foreach (var p in ListOfConnectedNodes)
            {
                Node currentNode = p;

                while (currentNode.Next != null && !(currentNode is GateNode node))
                {
                    currentNode = currentNode.Next;
                }

                string str = g.TerminalAndGate;
                string[] words = str.Split('-');
                var result = words[1];
                if ((currentNode as GateNode)?.Gate.GateNr.ToString() != result) continue;
                tnode = p;
                break;
            }

            return tnode;
        }
    }
}
