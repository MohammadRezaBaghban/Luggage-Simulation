using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public class LinkedList
    {
        public static bool IsSimulationFinished;
        private readonly Dictionary<Node, Node> distinatioNodes = new Dictionary<Node, Node>();
        private readonly List<Thread> ThreadList = new List<Thread>();

        private Node current;
        public Node First { get; private set; }

        public void MoveBags(int totalnr)
        {
            var t1 = new Thread(() =>
            {
                while (TerminalNode.counter + Storage.GetNumberOfBagsInStorage() == totalnr)
                    IsSimulationFinished = true;
            });
            t1.Start();
            CreateThreads();

            foreach (var t in ThreadList) t.Start();

            /*if (First != null)
            {
                var t2 = new Thread(() =>
                {
                    while (current.Next == null || current is GateNode) return;
                });

                var check = true;
                switch (current.Next)
                {
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
                }
                if (check)
                {
                    current = current.Next;
                }
            }
            */
        }

        public void AddGeneratedBags(List<Bag> bagstoqueue)
        {
            ((CheckinNode) First).Push(bagstoqueue);
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
                while (current.Next != null) current = current.Next;

                nd.Next = current.Next;
                current.Next = nd;
            }
        }

        public void CreateThreads()
        {
            Node currentnode;
            Node nextnode;

            var Nodes = GetAllNodes();
            for (var i = 0; i < Nodes.Count; i++)
            {
                if (i + 1 == Nodes.Count) break;
                currentnode = Nodes[i];
                nextnode = Nodes[i + 1];
                switch (nextnode)
                {
                    case BagSortNode bagSortNode when currentnode is ConveyorNode:
                        ThreadList.Add(new Thread(() =>
                            {
                                while (!IsSimulationFinished)
                                    if (!((ConveyorNode) currentnode).IsEmpty())
                                    {
                                        Thread.Sleep(700);
                                        var b = ((ConveyorNode) currentnode).RemoveBagFromConveyorBelt();
                                        if(b.IsNotNull()){bagSortNode.Push(b);}
                                    }
                            })
                            {Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType()});
                        break;

                    case ConveyorNode nextConveyorNode when currentnode is ConveyorNode:
                        ThreadList.Add(new Thread(() =>
                            {
                                while (!IsSimulationFinished)
                                    if (!((ConveyorNode) currentnode).IsEmpty() && !nextConveyorNode.IsFull())
                                    {
                                        Thread.Sleep(1200); 
                                        var b = ((ConveyorNode)currentnode).RemoveBagFromConveyorBelt();
                                        if (b.IsNotNull()) { nextConveyorNode.PushBagToConveyorBelt(b); }
                                    }
                            })
                            {Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType()});
                        break;
                    case ConveyorNode nextConveyorNode when currentnode is CheckinNode checkinNode:

                        ThreadList.Add(new Thread(() =>
                            {
                                while (!IsSimulationFinished)
                                    if (!nextConveyorNode.IsFull() && !checkinNode.IsEmpty())
                                    {
                                        var b = checkinNode.Remove();
                                        if (b.IsNotNull()) { nextConveyorNode.PushBagToConveyorBelt(b); }
                                        Thread.Sleep(700);
                                    }
                            })
                            {Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType()});
                        break;
                    case SecurityNode securityNode when currentnode is ConveyorNode:

                        ThreadList.Add(new Thread(() =>
                            {
                                while (!IsSimulationFinished)
                                    if (!((ConveyorNode) currentnode).IsEmpty())
                                    {
                                        Thread.Sleep(1000);
                                        var b = ((ConveyorNode)currentnode).RemoveBagFromConveyorBelt();
                                        if (b.IsNotNull()) { securityNode.Push(b); }
                                    }
                            })
                            {Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType()});
                        break;
                    case ConveyorNode nextConveyorNode when currentnode is SecurityNode securityNode:
                        ThreadList.Add(new Thread(() =>
                            {
                                while (!IsSimulationFinished)
                                    if (!nextConveyorNode.IsFull())
                                    {
                                        var b = securityNode.ScanBagSecurity();
                                        if (b.IsNotNull()) { nextConveyorNode.PushBagToConveyorBelt(b); }
                                        Thread.Sleep(700);
                                      
                                    }
                            })
                            {Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType()});
                        break;
                }

                if (currentnode is BagSortNode bsNode)
                {
                    ThreadList.Add(new Thread(() =>
                    {
                        while (!IsSimulationFinished)
                        {
                            var nodeToSendTheBagTo = bsNode.determineNextNode(out var b);
                            if (!nodeToSendTheBagTo.IsNotNull() || !b.IsNotNull() || ((ConveyorNode) nodeToSendTheBagTo).IsFull()) continue;
                            Thread.Sleep(1000);
                            ((ConveyorNode)nodeToSendTheBagTo).PushBagToConveyorBelt(b);
                        }
                    }) {
                            Name = "Current Node " + currentnode.GetType() + " Next Node is " + nextnode.GetType()});
                            
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

                while (current.Next != null && !(current is BagSortNode)) current = current.Next;

                if (current is BagSortNode node)
                {
                    if (node == parent && childNode is ConveyorNode conveyor)
                    {
                        node.ConnectNodeToSorter(conveyor);
                        conveyor.Next = null;
                    }
                    else if (parent is ConveyorNode conv && childNode is TerminalNode terminal)
                    {
                        foreach (var conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (near != parent && near.Next != null) near = near.Next;

                            if (near == conv)
                            {
                                near.Next = terminal;
                                break;
                            }
                        }
                    }
                    else if (parent is TerminalNode terminalNode && childNode is ConveyorNode co)
                    {
                        foreach (var conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (near != parent && near.Next != null) near = near.Next;

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
                        foreach (var conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (!(near is TerminalNode) || near.Next != null) near = near.Next;

                            if (near is TerminalNode termNode)
                                foreach (var s in termNode.ListOfConnectedNodes)
                                {
                                    Node nearNode = s;
                                    while (nearNode != parent && nearNode.Next != null) nearNode = nearNode.Next;

                                    if (nearNode == parent)
                                    {
                                        childNode.Next = nearNode.Next;
                                        nearNode.Next = childNode;
                                        break;
                                    }
                                }

                            if (parent.Next != null) break;
                        }
                    }
                }
            }
        }

        public List<Node> GetAllNodes()
        {
            var temp = new List<Node>();
            if (First == null) return null;

            var i = First;

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

                ((TerminalNode) tmp).ListOfConnectedNodes.ForEach(cnode2 =>
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