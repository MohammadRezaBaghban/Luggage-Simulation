using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public class LinkedList
    {
        public static bool IsSimulationFinished;
        private readonly List<Thread> _threadList = new List<Thread>();
        private readonly List<Thread> _threadListAfterBagSort = new List<Thread>();
        private readonly int _delayTime;

        public LinkedList(int speedDelayTime)
        { 
            _delayTime = speedDelayTime;
        }

        public Node First { get; private set; }

        public Node Current { get; set; }

        public void MoveBags()
        {
            TerminalNode.SimulationFinishedEvent += (sender, args) =>
            {
                Thread.Sleep(2000);
                IsSimulationFinished = true;
            };

            CreateThreads();

            foreach (var t in _threadList) t.Start();
            Thread.Sleep(_delayTime);
            foreach (var t in _threadListAfterBagSort) t.Start();
        }

        public void AddGeneratedBags(List<Bag> bagstoqueue)
        {
            ((CheckinNode)First).Push(bagstoqueue);
        }

        public void AddNode(Node nd)
        {
            if (First == null)
            {
                First = nd;
                Current = First;
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
                        var currentnode2 = currentnode;
                        var node = bagSortNode;
                        _threadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (((ConveyorNode) currentnode2).IsEmpty) continue;
                                Thread.Sleep(_delayTime);

                                var b = ((ConveyorNode)currentnode2).Remove();
                                if (!b.IsNull())
                                {
                                    node.Push(b);
                                }
                            }
                        })
                        {
                            Name = "Current Node " + currentnode.GetType() + " Next Node is " +
                                   nextnode.GetType(),
                            Priority = ThreadPriority.Lowest,
                            IsBackground = true
                        });
                        CreateAfterSortThreads(ref bagSortNode);

                        break;

                    case ConveyorNode nextConveyorNode when currentnode is ConveyorNode:
                        var currentnode3 = currentnode;
                        _threadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (!((ConveyorNode)currentnode3).IsEmpty&& !nextConveyorNode.IsFull)
                                {
                                    Thread.Sleep(_delayTime);

                                    var b = ((ConveyorNode)currentnode3).Remove();
                                    if (!b.IsNull())
                                    {
                                        nextConveyorNode.Push(b);
                                    }
                                }
                            }
                        })
                        {
                            Name = "Current Node " + currentnode.GetType() + " Next Node is " +
                                   nextnode.GetType(),Priority = ThreadPriority.Lowest, IsBackground = true
                        });
                        break;
                    case ConveyorNode nextConveyorNode when currentnode is CheckinNode checkinNode:

                        _threadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                                if (!nextConveyorNode.IsFull&& !checkinNode.IsEmpty())
                                {
                                    var b = checkinNode.Remove();
                                    if (!b.IsNull())
                                    {
                                        nextConveyorNode.Push(b);
                                    }
                                    Thread.Sleep(_delayTime);
                                }
                        })
                        {
                            Name = "Current Node " + currentnode.GetType() + " Next Node is " +
                                   nextnode.GetType(),
                            Priority = ThreadPriority.Lowest,
                            IsBackground = true
                        });
                        break;
                    case SecurityNode securityNode when currentnode is ConveyorNode:

                        var currentnode1 = currentnode;
                        _threadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                            {
                                if (!((ConveyorNode)currentnode1).IsEmpty)
                                {
                                    Thread.Sleep(_delayTime);
                                    var b = ((ConveyorNode)currentnode1).Remove();
                                    if (!b.IsNull())
                                    {
                                        securityNode.Push(b);
                                    }
                                }
                            }
                        })
                        {
                            Name = "Current Node " + currentnode.GetType() + " Next Node is " +
                                   nextnode.GetType(),
                            Priority = ThreadPriority.Lowest,
                            IsBackground = true
                        });
                        break;
                    case ConveyorNode nextConveyorNode when currentnode is SecurityNode securityNode:
                        _threadList.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                                if (!nextConveyorNode.IsFull)
                                {
                                    var b = securityNode.Remove();
                                    if (!b.IsNull())
                                    {
                                        nextConveyorNode.Push(b);
                                    }
                                    Thread.Sleep(_delayTime);
                                }
                        })
                        {
                            Name = "Current Node " + currentnode.GetType() + " Next Node is " +
                                   nextnode.GetType(),
                            Priority = ThreadPriority.Lowest,
                            IsBackground = true
                        });
                        break;
                }
            }

        }

        private void CreateAfterSortThreads(ref BagSortNode bsnodeRef)
        {
            Node SortNodeCurrent = bsnodeRef;
            Node nextnode = null;
            if (SortNodeCurrent != null && SortNodeCurrent is BagSortNode bsNode)
            {
                nextnode = bsNode.DetermineNextNode(out Bag bReceived);
                _threadList.Add(new Thread(() =>
                {
                    var bagSortNodeCopy = bsNode;
                    var nodeToSendTheBagTo = nextnode;
                    while (!IsSimulationFinished)
                    {
                        if (nodeToSendTheBagTo.IsNull())
                        {
                            nodeToSendTheBagTo = bagSortNodeCopy.DetermineNextNode(out bReceived);
                        }

                        if (nodeToSendTheBagTo.IsNull() || bReceived.IsNull() ||
                            ((ConveyorNode) nodeToSendTheBagTo).IsFull) continue;
                        Thread.Sleep(_delayTime);
                        ((ConveyorNode) nodeToSendTheBagTo)?.Push(bReceived);
                        nodeToSendTheBagTo = null;
                    }
                }){ Priority = ThreadPriority.Lowest, IsBackground = true });
                bsNode.ListOfConnectedNodes.ForEach(cnode1 =>
                            {
                                Node tmp = cnode1;
                                Node tmpNext = tmp.Next;
                                while (!(tmpNext is TerminalNode))
                                {
                                    var tmp1 = tmp;
                                    var next = tmpNext;
                                    _threadListAfterBagSort.Add(new Thread(() =>
                                    {
                                        while (!IsSimulationFinished)
                                            if (!((ConveyorNode)tmp1).IsEmpty&&
                                                !((ConveyorNode)next).IsFull)
                                            {
                                                Thread.Sleep(_delayTime);

                                                var bagFromConveyorBelt = (tmp1).Remove();
                                                if (!bagFromConveyorBelt.IsNull())
                                                {
                                                    (next).Push(bagFromConveyorBelt);
                                                }
                                            }
                                    })
                                    {
                                        Name = "Current Node " + tmp1.GetType() + " Next Node is " +
                                               next.GetType(),
                                        Priority = ThreadPriority.Lowest,
                                        IsBackground = true
                                    });
                                    tmp = tmpNext;
                                    tmpNext = tmp.Next;
                                }
                                var tmp2 = tmp;
                                var node2 = tmpNext;
                                _threadListAfterBagSort.Add(new Thread(() => {
                                        while (!IsSimulationFinished)
                                            if (!((ConveyorNode)tmp2).IsEmpty)
                                            { 
                                                Thread.Sleep(_delayTime);
                                                var bb = ((ConveyorNode)tmp2).Remove();
                                                if (!bb.IsNull())
                                                {
                                                    ((TerminalNode)node2).Push(bb);
                                                }
                                            }
                                    })
                                { Name = "Current Node " + tmp.GetType() + " Next Node is " + tmpNext.GetType(),Priority = ThreadPriority.Lowest, IsBackground = true });
                                tmp = tmpNext;
                                CreateThreadsAfterTerminal(ref tmp);
                            });
            }
        }

        public void CreateThreadsAfterTerminal(ref Node n)
        {
            Bag bReceivedInTerminal =null;
            var tmpNext111 = ((TerminalNode)n)?.DetermineNextConveyorNode(out bReceivedInTerminal);
            var currentTerminal = n;
            _threadListAfterBagSort.Add(new Thread(() =>
            {
                var terminalNodeCopy = (TerminalNode)currentTerminal;
                var nodeToSendTheBagTo = tmpNext111;
                while (!IsSimulationFinished)
                {
                    if (nodeToSendTheBagTo.IsNull())
                    {
                        nodeToSendTheBagTo = terminalNodeCopy?.DetermineNextConveyorNode(out bReceivedInTerminal);
                    }

                    if (nodeToSendTheBagTo.IsNull() || bReceivedInTerminal.IsNull() ||
                        // ReSharper disable once PossibleNullReferenceException
                        ((ConveyorNode) nodeToSendTheBagTo).IsFull) continue;
                    Thread.Sleep(_delayTime);
                    ((ConveyorNode)nodeToSendTheBagTo)?.Push(bReceivedInTerminal);
                    nodeToSendTheBagTo = null;
                }
            })
            { Priority = ThreadPriority.Lowest, IsBackground = true });

            ((TerminalNode)currentTerminal)?.ListOfConnectedNodes.ForEach(cnode2 =>
            {
                Node tmp1 = cnode2;
                Node tmpNext1 = cnode2.Next;
                while (!(tmpNext1 is GateNode))
                {
                    var tmp3 = tmp1;
                    var next1 = tmpNext1;
                    _threadListAfterBagSort.Add(new Thread(() =>
                    {
                        while (!IsSimulationFinished)
                            if (!((ConveyorNode)tmp3).IsEmpty &&
                                !((ConveyorNode)next1).IsFull)
                            {
                                Thread.Sleep(400);
                                var bb = ((ConveyorNode)tmp3).Remove();
                                if (!bb.IsNull())
                                {
                                    ((ConveyorNode)next1).Push(bb);
                                }
                            }
                    })
                    {
                        Name = "Current Node " + tmp3.GetType() + " Next Node is " +
                               next1.GetType(),
                        Priority = ThreadPriority.Lowest,
                        IsBackground = true
                    });
                    tmp1 = tmpNext1;
                    tmpNext1 = tmp1.Next;
                }

                {
                    var node = (ConveyorNode) tmp1;
                    var tmpNext2 = tmpNext1;
                    _threadListAfterBagSort.Add(new Thread(() =>
                        {
                            while (!IsSimulationFinished)
                                if (!node.IsEmpty)
                                { 
                                    Thread.Sleep(_delayTime);
                                    var bb = node.Remove();
                                    if (!bb.IsNull())
                                    {
                                        ((GateNode)tmpNext2).Push(bb);
                                    }
                                }
                        })
                        { Name = "Current Node " + node.GetType() + " Next Node is " + tmpNext2.GetType(), Priority = ThreadPriority.Lowest, IsBackground = true });
                }
            });
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
                            foreach (var s in ((TerminalNode)near).ListOfConnectedNodes)
                            {
                                    Node nearNode = s;
                                    while (nearNode != parent && nearNode.Next != null) nearNode = nearNode.Next;

                                    if (nearNode != parent) continue;
                                    childNode.Next = nearNode.Next;
                                    nearNode.Next = childNode;
                                    break;
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

        private void MoveBag(ref Node from, ref Node to)
        {
            if (@from.IsNull()) return;

            if (@from is ConveyorNode fromConveyorNode)
            {
                if (fromConveyorNode.IsEmpty)
                {
                    return;
                }
            }

            if (@to is ConveyorNode toConveyorNode)
            {
                if (toConveyorNode.IsFull)
                {
                    return;
                }
            }

            switch (@from)
            {
                case BagSortNode bagSortNode:
                {
                    to = bagSortNode.DetermineNextNode(out var g);
                    if(to.IsNull())return;
                    to.Push(g);
                    return;
                }
                case TerminalNode terminalNode:
                {
                    to = terminalNode.DetermineNextConveyorNode(out var g);
                    if (to.IsNull()) return;
                    to.Push(g);
                    return;
                }
                default:
                    if (to.IsNull()) return;
                    to.Push(@from.Remove());
                    break;
            }
        }
    }
}