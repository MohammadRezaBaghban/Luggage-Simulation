using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rail_Bag_Simulation
{
    class LinkedList
    {
        public Node First { get; private set; }
        private List<Node> lastnodes;
        public LinkedList()
        {
            lastnodes = new List<Node>();
            First = null;
        }

        public void MoveBags()
        {

            if (First != null)
            {
                ConveyorNode tmpConveyor = null;

                var current = First;
                while (current.Next != null && !(current is BagSortNode))
                {
                 

                    switch (current.Next)
                    {

                        case ConveyorNode NextNode when current is CheckinNode checkidNode:
                        {
                          
                                NextNode.Conveyor.PushBagToConveyorBelt(checkidNode.Remove());
                                Node.log.Add("Added bag to " + NextNode.Conveyor.Id);
                                
                            break;
                        } 

                        case SecurityNode nextNode when current is ConveyorNode conveyorNode:
                        {
                            nextNode.ScanBagSecurity(conveyorNode.Conveyor.RemoveBagFromConveyorBelt());
                            break;
                        }

                        case BagSortNode node when current is ConveyorNode conveyorNode:
                        {
                            var tbag = conveyorNode.Conveyor.RemoveBagFromConveyorBelt();
                            while (tbag == null && !conveyorNode.Conveyor.IsEmpty())
                            {
                                tbag = conveyorNode.Conveyor.RemoveBagFromConveyorBelt();
                            }
                            if (tbag != null) node.PassBag(tbag);
                            break;
                        }

                        case ConveyorNode NextNode when current is ConveyorNode conveyorNode:
                        {
                            if (NextNode.Conveyor.IsFull == false)
                            { 
                                NextNode.Conveyor.PushBagToConveyorBelt(conveyorNode.Conveyor.RemoveBagFromConveyorBelt());
                            }
                            break;
                            }


                        
                    }

                    current = current.Next;
                }


            }
            else
            {
                throw new Exception("no simulation made");
            }
        }
        public void AddGeneratedBag(Bag bagtoqueue)
        {
            ((CheckinNode)(First))._bagsQueue.Enqueue(bagtoqueue);


            if (First.Next != null)
            {
                MoveBags();
            }
            else
            {
                throw new Exception("no simulation made");
            }
        }
        public void AddNode(Node nd)
        {
            if (First == null)
            {

                First = nd;

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


        public void RemoveNode()
        {
            var current = First;

            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        public string LinkedListInfo()
        {
            string sender = "";

            var current = First;
            while (current.Next != null && !(current is BagSortNode))
            {
                sender += current.Nodeinfo();
                current = current.Next;
            }

            if (current is BagSortNode node)
            {

                sender += node.Nodeinfo();
                if (node.ListOfConnectedNodes.Count >= 1)
                {
                    foreach (ConveyorNode checkNode in node.ListOfConnectedNodes)
                    {
                        Node check = checkNode;
                        sender += check.Nodeinfo();
                        while (check.Next != null)
                        {

                            check = check.Next;
                            sender += check.Nodeinfo();
                        }

                        if (check is TerminalNode coNode)
                        {
                            foreach (ConveyorNode conveyorNode in coNode.ListOfConnectedNodes)
                            {
                                Node conveyorcheck = conveyorNode;
                            
                                sender += conveyorcheck.Nodeinfo();
                                while (conveyorcheck.Next != null)
                                {

                                    conveyorcheck = conveyorcheck.Next;
                                    sender += conveyorcheck.Nodeinfo();
                                }
                            }
                        }
                    }
                }

            }

            return sender;
        }
    }
}

