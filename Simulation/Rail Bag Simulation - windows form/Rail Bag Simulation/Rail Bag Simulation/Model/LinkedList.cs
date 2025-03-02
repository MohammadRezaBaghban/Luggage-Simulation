﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Timer = System.Timers.Timer;

namespace Rail_Bag_Simulation
{
    public class LinkedList
    {
        /*use a map dictionary to store a shadow copy of the linked list storing the ids of the nodes */

        /*basically to add the idea of having more control over adding the destination */
        
        public static bool IsSimulationFinished;
        public static Dictionary<Stopwatch, Bag> TimelyWatchedBagWithStopWatch = new Dictionary<Stopwatch, Bag>();
        private Timer _timer;

        public LinkedList(int speedDelayTime)
        {
            _timer = new Timer(speedDelayTime);
            
            //ThreadPool.SetMaxThreads(5, 5);

            _timer.Elapsed += (sender, args) =>
            {
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
                ThreadPool.QueueUserWorkItem(MakeBagsMoveOneAtATime);
            };

            GateNode.SimulationFinishedEvent += (sender, args) =>
            {
                decimal totalTime = 0;
                IsSimulationFinished = true;
                _timer.Stop();
                foreach (var stopwatch in TimelyWatchedBagWithStopWatch.Keys)
                {
                    stopwatch.Stop();
                }
                TimelyWatchedBagWithStopWatch.Keys.ToList()
                    .ForEach(stopwatch => totalTime += (int) stopwatch.ElapsedMilliseconds);
                totalTime /= 1000;
                AverageTimePerBag = totalTime / TimelyWatchedBagWithStopWatch.Keys.Count;
            };
        }

        public static List<CheckinNode> First { get; } = new List<CheckinNode>();


        public Node Current { get; set; }

        public static decimal AverageTimePerBag { get; private set; }

        public void MoveBags()
        {
            RunSimulation();
        }

        public void AddGeneratedBags(List<Bag> bagstoqueue)
        {
            var counter = 0;
            var totalNumberOfBags = bagstoqueue.Count;
            var firstQuater = totalNumberOfBags / 4;
            TimelyWatchedBagWithStopWatch.Add(new Stopwatch(), bagstoqueue[0]);
            if (totalNumberOfBags >= 5)
            {
                AddTimerWithABag(bagstoqueue, firstQuater);
                AddTimerWithABag(bagstoqueue, firstQuater * 2);
                AddTimerWithABag(bagstoqueue, firstQuater * 3);
                AddTimerWithABag(bagstoqueue, firstQuater * 4 - 1);
            }

            foreach (var val in TimelyWatchedBagWithStopWatch.Values) val.IsObserving = true;

            bagstoqueue.ForEach(bag =>
            {
                counter++;
                TimelyWatchedBagWithStopWatch.FirstOrDefault(pair => pair.Value == bag).Key?.Start();

                First[0].Push(bag);
            });

            Thread.Sleep(200);
            MoveBags();
        }

        private static void AddTimerWithABag(List<Bag> bagstoqueue, int firstQuater)
        {
            TimelyWatchedBagWithStopWatch.Add(new Stopwatch(), bagstoqueue[firstQuater]);
        }

        public void AddNode(Node node)
        {
            if (node is CheckinNode checkin)
            {
                First.Add(checkin);
            }

        }

        public void AddNode(int id, Type t, Node nodetoadd)
        {
            if (First.Count == 0 || nodetoadd is CheckinNode)
                First.Add((CheckinNode) nodetoadd);
            else
                foreach (Node s in First)
                    s.AddNode(id, t, nodetoadd);
        }


        public static List<Node> GetAllNodes()
        {
            var check = new List<Node>();
            for (var i = 0; i <= First.Count - 1; i++)
            {
                Node current = First[i];
                while (!(current is SecurityNode))
                {
                    check.Add(current);
                    current = current.GetNext();
                }
            }

            foreach (Node first in First) first.PrintNodes(ref check);
            return check;
        }

        private void MakeBagsMoveOneAtATime(object Stateinfo)
        {
            GetAllNodes().ForEach(node => node.MoveBagToNextNode());
        }


        /// <summary>
        ///     This stops the timer that moveS THE bags
        /// </summary>
        public void PauseSimulation()
        {
            if (_timer == null) return;
            _timer.Stop();
            _timer.Enabled = false;
        }

        public void RunSimulation()
        {
            if (_timer == null) return;
            _timer.Enabled = true;
            _timer.Start();
        }


        public void DestroySimulation()
        {
            PauseSimulation();
            _timer = null;
        }
    }
}