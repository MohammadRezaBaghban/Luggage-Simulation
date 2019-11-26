using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Rail_Bag_Simulation
{
    public class LinkedList
    {
        public static bool IsSimulationFinished;
        private readonly List<Thread> _threadList = new List<Thread>();
        private readonly List<Thread> _threadListAfterBagSort = new List<Thread>();
        private readonly int _delayTime;

        private readonly Timer timer;

        public LinkedList(int speedDelayTime)
        {
            _delayTime = speedDelayTime;
            timer = new Timer(speedDelayTime);
            //ThreadPool.SetMaxThreads(5, 5);

            timer.Elapsed += (sender, args) =>
            {
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
            };
            timer.Enabled = true;
        }

        public static Node First { get; private set; }

        public Node Current { get; set; }

        public void MoveBags()
        {
            timer.Start();
            TerminalNode.SimulationFinishedEvent += (sender, args) =>
            {
                Thread.Sleep(4000);
                timer.Stop();
            };
        }

        public void AddGeneratedBags(List<Bag> bagstoqueue)
        {
            bagstoqueue.ForEach(bag => First.Push(bag));
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

        public void AddNode(Node childNode, Node parent)
        {
            if (First == null)
            {
                MessageBox.Show(@"There is no first node");
            }
            else
            {
                var current = First;

                while (current.Next != null && !(current is BagSortNode)) current = current.Next;

                if (!(current is BagSortNode node)) return;
                if (node == parent && childNode is ConveyorNode conveyor)
                {
                    node.ConnectNodeToSorter(conveyor);
                    conveyor.Next = null;
                }
                else switch (parent)
                {
                    case ConveyorNode conv when childNode is TerminalNode terminal:
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

                        break;
                    }
                    case TerminalNode terminalNode when childNode is ConveyorNode co:
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

                        break;
                    }
                    case ConveyorNode _ when childNode is GateNode:
                    {
                        foreach (var conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (!(near is TerminalNode) || near.Next != null) near = near.Next;
                            foreach (var s in ((TerminalNode) near).ListOfConnectedNodes)
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

                        break;
                    }
                }
            }
        }

        public static List<Node> GetAllNodes()
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

        private static void MakeBagsMoveOneAtATime(object Stateinfo)
        {
            GetAllNodes().ForEach(node => node.MoveBagToNextNode());
        }
    }
}