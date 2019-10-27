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
    class LinkedList
    {
        public Node First { get; private set; }
        public bool IsSimulationFinished = false;
        private List<Node> lastnodes;
        public LinkedList()
        {
            lastnodes = new List<Node>();
            First = null;
        }



        public void  MoveBags(int totalnr)
        {
            var thread1 = new Thread((() =>
            { 
                if (TerminalNode.counter + Storage.GetNumberOfBagsInStorage() == totalnr) {
                    IsSimulationFinished = true;
                }
            }));
            thread1.Start();

            if (First != null)
            {
                var current = First;
                while (current.Next != null && !(current is BagSortNode))
                {
                    bool check = true;
                    switch (current.Next)
                    {
                        case ConveyorNode NextNode when current is CheckinNode checkidNode:
                            {
                                Thread thread = new Thread((() =>
                                {
                                   
                                        while (checkidNode._bagsQueue.Count > 0 && NextNode.Conveyor.IsEmpty())
                                        {
                                            NextNode.Conveyor.PushBagToConveyorBelt(checkidNode.Remove());
                                            Node.log.Add("Added bag to " + NextNode.Conveyor.Id);
                                        }
                                    
                                }));

                                thread.Start();

                                break;
                            }

                        case SecurityNode nextNode when current is ConveyorNode conveyorNode:
                            {
                                Thread thread = new Thread((() =>
                                {
                                    while (((ConveyorNode)nextNode.Next).Conveyor.IsEmpty()||!(conveyorNode.Conveyor.IsEmpty()))
                                    {
                                        nextNode.ScanBagSecurity(conveyorNode.Conveyor.RemoveBagFromConveyorBelt());
                                        Node.log.Add("Added bag to " + ((ConveyorNode)nextNode.Next).Conveyor.Id);
                                    }
                                }));

                                thread.Start();
                                break;
                            }

                        case BagSortNode node when current is ConveyorNode conveyorNode:
                            {

                                var thread = new Thread((() =>
                                {
                                    while (!conveyorNode.Conveyor.IsEmpty())
                                    {
                                        var tbag = conveyorNode.Conveyor.RemoveBagFromConveyorBelt();


                                        if (tbag != null)
                                        {
                                            node.PassBag(tbag);
                                        }
                                    }

                                    check = true;

                                }));
                                if (((CheckinNode)First)._bagsQueue.Count() > 0 && TerminalNode.counter + Storage.GetNumberOfBagsInStorage() != totalnr)
                                {
                                    check = false;
                                }
                               
                                thread.Start();
                                
                                break;
                            }

                        case ConveyorNode NextNode when current is ConveyorNode conveyorNode://err 1
                            {
                                var thread = new Thread((() =>
                                {
                                    if (!conveyorNode.Conveyor.IsEmpty()&&NextNode.Conveyor.IsEmpty())
                                    {
                                        if (NextNode.Conveyor.IsFull == false)
                                        {
                                            NextNode.Conveyor.PushBagToConveyorBelt(conveyorNode.Conveyor
                                                .RemoveBagFromConveyorBelt());
                                        }
                                    }
                                }));
                                thread.Start();
                                break;
                            }

                    }

                    if (check)
                    {
                        current = current.Next;
                    }
                    else
                    {
                       MoveBags(totalnr);
                    }

                    
                }
            }
            else
            {
                throw new Exception("no simulation made");
            }
        }



        public void AddGeneratedBags(List<Bag> bagstoqueue)
        {

            ((CheckinNode)(First)).Push(bagstoqueue);


            if (First.Next != null)
            {
                MoveBags(bagstoqueue.Count);
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

        public  string LinkedListInfo()
        {
            string sender = "";

            var current = First;
            while (current.Next != null && !(current is BagSortNode))
            {
                sender += current.Nodeinfo();
                current = current.Next;
            }

          
            if ((current is BagSortNode))
            {
                sender += current.Nodeinfo();
            }

             

            return sender;
        }
    }
}

