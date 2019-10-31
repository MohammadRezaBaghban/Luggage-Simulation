using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Rail_Bag_Simulation
{
    public class LinkedList
    {
        public Node First { get; private set; }
        public static bool IsSimulationFinished = false;

        private Node current;
        private readonly List<Thread> ThreadList = new List<Thread>();
        private readonly Dictionary<Node, Node> distinatioNodes = new Dictionary<Node, Node>();

        public void MoveBags(int totalnr)
        {
            var t1 = new Thread(() =>
            {
                while (TerminalNode.counter + Storage.GetNumberOfBagsInStorage() == totalnr)
                {
                    IsSimulationFinished = true;
                }
            });
            t1.Start();
            CreateThreads();
            
            foreach (var t in ThreadList) { t.Start(); }

            /*if (First != null)
            {
                var t2 = new Thread(() =>
                {
                    while (current.Next == null || current is GateNode) return;
                });

                var check = true;
                switch (current.Next)
                {
                    case ConveyorNode NextNode when current is CheckinNode checkidNode:
                        {
                            if (checkidNode.QueueCount > 0 && NextNode.IsFull == false)
                            {
                                NextNode.PushBagToConveyorBelt(checkidNode.Remove());
                                Node.log.Add("Added bag to " + NextNode.Id);
                            }
                            break;
                        }

                    case SecurityNode nextNode when current is ConveyorNode conveyorNode:
                        {
                            if ((nextNode.Next as ConveyorNode).IsFull || !(conveyorNode.IsEmpty()))
                            {
                                var bagToChecked = conveyorNode.RemoveBagFromConveyorBelt();
                                if (bagToChecked != null)
                                {
                                    var bagChecked = nextNode.ScanBagSecurity(bagToChecked);
                                    if (bagChecked != null)
                                    {
                                        ((ConveyorNode)(nextNode.Next)).PushBagToConveyorBelt(bagChecked);
                                    }
                                    else
                                    {
                                        check = false;

                                        current = First;
                                    }
                                }
                            }

                            break;
                        }

                    case BagSortNode node when current is ConveyorNode conveyorNode:
                        {
                            if (!conveyorNode.IsEmpty() && !IsSimulationFinished)
                            {
                                var con = (ConveyorNode)(node.determineNextNode(conveyorNode.ListofBagsinqueue().Peek()));
                                con.PushBagToConveyorBelt(conveyorNode.RemoveBagFromConveyorBelt());

                                current = con;
                                check = false;

                                //var tbag = conveyorNode.RemoveBagFromConveyorBelt();
                                //if (tbag != null)
                                //{
                                //    check = true;
                                //    node.PassBag(tbag);
                                //}
                            }
                            break;
                        }
                    case TerminalNode terminalNode when current is ConveyorNode conveyorNode:
                        {
                            if (!conveyorNode.IsEmpty() && !IsSimulationFinished)
                            {
                                var con =
                                    (ConveyorNode)(terminalNode.determineNextNode(conveyorNode.ListofBagsinqueue()
                                        .Peek()));
                                con.PushBagToConveyorBelt(conveyorNode.RemoveBagFromConveyorBelt());

                                current = con;
                                check = false;

                                //var tbag = conveyorNode.RemoveBagFromConveyorBelt();


                                //if (tbag != null)
                                //{
                                //    check = true;
                                //    node.PassBag(tbag);
                                //}
                            }


                            break;
                        }

                    case GateNode gateNode when current is ConveyorNode conveyorNode:
                        {
                            if (!conveyorNode.IsEmpty() && !IsSimulationFinished)
                            {

                                gateNode.AddBag(conveyorNode.RemoveBagFromConveyorBelt());


                                //var tbag = conveyorNode.RemoveBagFromConveyorBelt();
                                //if (tbag != null)
                                //{
                                //    check = true;
                                //    node.PassBag(tbag);
                                //}
                            }

                            if (((CheckinNode)First)._bagsQueue.Count > 0)
                            {
                                current = First;
                                check = false;
                            }
                            break;
                        }

                    case ConveyorNode NextNode when current is ConveyorNode conveyorNode:
                        {
                            if (!conveyorNode.IsEmpty() && NextNode.IsEmpty())
                            {
                                if (NextNode.IsFull == false)
                                {
                                    NextNode.PushBagToConveyorBelt(conveyorNode
                                        .RemoveBagFromConveyorBelt());
                                }
                            }
                            break;
                        }
                }
                if (check)
                {
                    current = current.Next;
                }
            }
            else
            {
                throw new Exception("no simulation made");
            }*/
        }

        public void AddGeneratedBags(List<Bag> bagstoqueue)
        {
            ((CheckinNode)(First)).Push(bagstoqueue);
        }

        public void AddNode(Node nd)
        {
            if (First == null)
            {

                First = nd;
                current = First;

            }
            else
            {
                var current = First;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                nd.Next = current.Next;
                current.Next = nd;
            }
        }

        public void CreateThreads()
        {
            var Nodes = GetAllNodes();
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (i + 1 == Nodes.Count) { break; }
                var currentnode = Nodes[i];
                var nextnode = Nodes[i+1];
                switch (nextnode)
                {
                    case BagSortNode bagSortNode when currentnode is ConveyorNode:
                        ThreadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (!((ConveyorNode) currentnode).IsEmpty())
                                {
                                    Thread.Sleep(700);
                                    bagSortNode.Push(((ConveyorNode) (currentnode)).RemoveBagFromConveyorBelt());
                                }
                            }
                        })
                        { Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType() });
                        break;

                    case ConveyorNode nextConveyorNode when currentnode is ConveyorNode:
                        ThreadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (!(((ConveyorNode)(currentnode)).IsEmpty()) && !nextConveyorNode.IsFull())
                                {
                                    Thread.Sleep(1200);
                                   
                                            nextConveyorNode.PushBagToConveyorBelt(
                                                ((ConveyorNode)(currentnode)).RemoveBagFromConveyorBelt());
                                    
                                }
                            }
                        })
                            { Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType() });
                        break;
                    case ConveyorNode nextConveyorNode when currentnode is CheckinNode checkinNode:

                        ThreadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (!nextConveyorNode.IsFull() && !checkinNode.IsEmpty())
                                {
                                    nextConveyorNode.PushBagToConveyorBelt(checkinNode.Remove());
                                    Thread.Sleep(700);
                                }
                            }
                        })
                            { Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType() });
                        break;
                    case SecurityNode securityNode when currentnode is ConveyorNode :

                        ThreadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (!((ConveyorNode)(currentnode)).IsEmpty())
                                {
                                    Thread.Sleep(1000);
                                    securityNode.Push(((ConveyorNode)(currentnode)).RemoveBagFromConveyorBelt());
                                }
                            }
                        })
                            { Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType() });
                        break;
                    case ConveyorNode nextConveyorNode when currentnode is SecurityNode securityNode:
                        ThreadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (!nextConveyorNode.IsFull())
                                {
                                    Thread.Sleep(700);
                                    nextConveyorNode.PushBagToConveyorBelt(securityNode.ScanBagSecurity());
                                }
                            }
                        })
                            { Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType() });

                        break;
                }
            
            }
        }
        public void AddNode(Node childNode, Node parent)
        {
            if (First == null)
            {
                MessageBox.Show("There is no first node");
            }
            else
            {
                var current = First;

                while (current.Next != null && !(current is BagSortNode))
                {
                    current = current.Next;
                }

                if (current is BagSortNode node)
                {
                    if (node == parent && childNode is ConveyorNode conveyor)
                    {
                        node.ConnectNodeToSorter(conveyor);
                        conveyor.Next = null;
                    }
                    else if (parent is ConveyorNode conv && childNode is TerminalNode terminal)
                    {
                        foreach (ConveyorNode conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (near != parent && near.Next != null)
                            {
                                near = near.Next;
                            }

                            if (near == conv)
                            {
                                near.Next = terminal;
                                break;
                            }
                        }
                    }
                    else if (parent is TerminalNode terminalNode && childNode is ConveyorNode co)
                    {
                        foreach (ConveyorNode conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (near != parent && near.Next != null)
                            {
                                near = near.Next;
                            }

                            if (near == terminalNode)
                            {
                                terminalNode.ConnectNodeToSorter(co);
                                co.Next = near.Next;
                                break;
                            }
                        }
                    }
                    else if (parent is ConveyorNode && childNode is GateNode)
                    {
                        foreach (ConveyorNode conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (!(near is TerminalNode) || near.Next != null)
                            {
                                near = near.Next;
                            }

                            if (near is TerminalNode termNode)
                            {
                                foreach (ConveyorNode s in termNode.ListOfConnectedNodes)
                                {
                                    Node nearNode = s;
                                    while (nearNode != parent && nearNode.Next != null)
                                    {
                                        nearNode = nearNode.Next;
                                    }

                                    if (nearNode == parent)
                                    {
                                        childNode.Next = nearNode.Next;
                                        nearNode.Next = childNode;
                                        break;
                                    }
                                }
                            }

                            if (parent.Next != null)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public List<Node> GetAllNodes()
        {
            List<Node> temp = new List<Node>();
            if (First == null)
            {
                return null;
            }

            Node i = First;

            while (i.Next != null && !(i is BagSortNode))
            {
                temp.Add(i);
                i = i.Next;

            }
            temp.Add(i);
            var node = i as BagSortNode;
            node?.ListOfConnectedNodes.ForEach(cnode1 =>
            {
                Node tmp = cnode1;
                while (!(tmp is TerminalNode))
                {
                    temp.Add(tmp);
                    tmp = tmp.Next;
                }
                temp.Add(tmp);

                ((TerminalNode)tmp).ListOfConnectedNodes.ForEach(cnode2 =>
                    {
                        Node tmp1 = cnode2;
                        while (!(tmp1 is GateNode))
                        {
                            temp.Add(tmp1);
                            tmp1 = tmp1.Next;
                        }
                        temp.Add(tmp1);
                    });
            });
            return temp;
        }
    }
}

