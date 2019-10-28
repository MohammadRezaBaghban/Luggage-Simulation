﻿using System;
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
        public bool IsSimulationFinished = false;
        private List<Node> lastnodes;
        public LinkedList()
        {
            lastnodes = new List<Node>();
            First = null;
        }



        public void MoveBags(int totalnr)
        {
           
                if (TerminalNode.counter + Storage.GetNumberOfBagsInStorage() == totalnr)
                {
                    IsSimulationFinished = true;
                }
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
                               
                                    while (checkidNode._bagsQueue.Count > 0 && NextNode.IsFull==false)
                                    {
                                        
                                        NextNode.PushBagToConveyorBelt(checkidNode.Remove());
                                        Node.log.Add("Added bag to " + NextNode.Id);
                                    }



                                    break;
                            }

                        case SecurityNode nextNode when current is ConveyorNode conveyorNode:
                            {
                             
                                
                                    while (((ConveyorNode)nextNode.Next).IsEmpty() || !(conveyorNode.IsEmpty()))
                                    {
                                
                                        nextNode.ScanBagSecurity(conveyorNode.RemoveBagFromConveyorBelt());
                                        Node.log.Add("Added bag to " + ((ConveyorNode)nextNode.Next).Id);
                                    }

                                    break;
                            }

                        case BagSortNode node when current is ConveyorNode conveyorNode:
                            {

                          
                                    while (!conveyorNode.IsEmpty() && !IsSimulationFinished)
                                    {
                                        var tbag = conveyorNode.RemoveBagFromConveyorBelt();


                                        if  (tbag != null)
                                        {
                                      


                                            node.PassBag(tbag);
                                        }
                                    }

                                    check = true;

                                if (((CheckinNode)First)._bagsQueue.Any() && TerminalNode.counter + Storage.GetNumberOfBagsInStorage() != totalnr)
                                {
                                    check = false;
                                }

                            

                                break;
                            }

                        case ConveyorNode NextNode when current is ConveyorNode conveyorNode://err 1
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

        public string LinkedListInfo()
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

