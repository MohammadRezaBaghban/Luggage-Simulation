using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Rail_Bag_Simulation
{
    public class LinkedList
    {
        public static bool IsSimulationFinished;
        public static Dictionary<Stopwatch, Bag> TimelyWatchedBagWithStopWatch = new Dictionary<Stopwatch, Bag>();
        private readonly Timer _timer;



        public LinkedList(int speedDelayTime)
        {
            _timer = new Timer(speedDelayTime);
            //ThreadPool.SetMaxThreads(5, 5);
            AssignTimerElapsedFunc();
            OnSimulationFinishedEvent();
        }

        private void AssignTimerElapsedFunc()
        {
            _timer.Elapsed += (sender, args) =>
            {
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
            };
        }

        private void OnSimulationFinishedEvent()
        {
            GateNode.SimulationFinishedEvent += (sender, args) =>
            {
                decimal totalTime = 0;
                IsSimulationFinished = true;
                _timer.Stop();
                TimelyWatchedBagWithStopWatch.Keys.ToList()
                    .ForEach(stopwatch => totalTime += (int) stopwatch.ElapsedMilliseconds);
                totalTime /= 1000;
                AverageTimePerBag = totalTime / TimelyWatchedBagWithStopWatch.Keys.Count;
            };
        }

        /// <summary>
        /// This stops the timer that moveS THE bags
        /// </summary>
        public void PauseSimulation()
        {
            _timer.Stop();
            _timer.Enabled = false;
        }

        public void RunSimulation()
        { 
            _timer.Enabled = true;
            _timer.Start();
        }

        public static Node First { get; private set; }

        public Node Current { get; set; }

        public static decimal AverageTimePerBag { get; private set; } = 0;

        public void MoveBags()
        {
            RunSimulation();
        }

        public void AddGeneratedBags(List<Bag> bagstoqueue)
        {
            var totalNumberOfBags = bagstoqueue.Count;
            var firstQuater = (int)(totalNumberOfBags / 4);
            TimelyWatchedBagWithStopWatch.Add(new Stopwatch(), bagstoqueue[0]);
            if (totalNumberOfBags >= 5)
            {
                AddTimerWithABag(bagstoqueue, firstQuater);
                AddTimerWithABag(bagstoqueue, firstQuater*2);
                AddTimerWithABag(bagstoqueue, firstQuater*3);
                AddTimerWithABag(bagstoqueue, firstQuater*4);
            }

            foreach (var val in TimelyWatchedBagWithStopWatch.Values)
            {
               val.IsObserving = true;
            }

            bagstoqueue.ForEach(bag =>
            {
                TimelyWatchedBagWithStopWatch.FirstOrDefault(pair => pair.Value == bag).Key?.Start();
                First.Push(bag);
            });

        }

        private static void AddTimerWithABag(List<Bag> bagstoqueue, int firstQuater)
        {
            TimelyWatchedBagWithStopWatch.Add(new Stopwatch(), bagstoqueue[firstQuater]);
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
                while (current.GetNext() != null) current = current.GetNext();

                nd.SetNext(current.GetNext());
                current.SetNext(nd);
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

                while (current.GetNext() != null && !(current is BagSortNode)) current = current.GetNext();

                if (!(current is BagSortNode node)) return;
                if (node == parent && childNode is ConveyorNode conveyor)
                {
                    node.ConnectNodeToSorter(conveyor);
                    conveyor.SetNext(null);
                }
                else switch (parent)
                {
                    case ConveyorNode conv when childNode is TerminalNode terminal:
                    {
                        foreach (var conveyorNode in node.ListOfConnectedNodes)
                        {
                            Node near = conveyorNode;
                            while (near != parent && near.GetNext() != null) near = near.GetNext();

                            if (near == conv)
                            {
                                near.SetNext(terminal);
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
                            while (near != parent && near.GetNext() != null) near = near.GetNext();

                            if (near == terminalNode)
                            {
                                terminalNode.ConnectNodeToSorter(co);
                                co.SetNext(near.GetNext());
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
                            while (!(near is TerminalNode) || near.GetNext() != null) near = near.GetNext();
                            foreach (var s in ((TerminalNode) near).ListOfConnectedNodes)
                            {
                                Node nearNode = s;
                                while (nearNode != parent && nearNode.GetNext() != null) nearNode = nearNode.GetNext();

                                if (nearNode != parent) continue;
                                childNode.SetNext(nearNode.GetNext());
                                nearNode.SetNext(childNode);
                                break;
                            }

                            if (parent.GetNext() != null) break;
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

            while (i.GetNext() != null && !(i is BagSortNode))
            {
                temp.Add(i);
                i = i.GetNext();
            }

            temp.Add(i);
            var node = i as BagSortNode;
            node?.ListOfConnectedNodes.ForEach(cnode1 =>
            {
                Node tmp = cnode1;
                while (!(tmp is TerminalNode))
                {
                    temp.Add(tmp);
                    tmp = tmp.GetNext();
                }

                temp.Add(tmp);

                ((TerminalNode) tmp).ListOfConnectedNodes.ForEach(cnode2 =>
                {
                    Node tmp1 = cnode2;
                    while (!(tmp1 is GateNode))
                    {
                        temp.Add(tmp1);
                        tmp1 = tmp1.GetNext();
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