using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Rail_Bag_Simulation
{
    internal class GateNode : Node
    {
        public static EventHandler SimulationFinishedEvent;

        public static int Counter;

        public GateNode(Gate g)
        {
            Gate = g;
        }

        public Gate Gate { get; }

        public override List<string> NodeInfo()
        {
            var sender = new List<string>
            {
                $"Gate: {Gate.GateNr}"
            };
            sender.AddRange(base.NodeInfo());
            return sender;
        }

        public override void Push(Bag b)
        {
            base.Push(b);
            if (b.IsObserving) LinkedList.TimelyWatchedBagWithStopWatch.First(pair => pair.Value == b).Key.Stop();
            VerifyBagsCount();
        }

        public override void PrintNodes(ref List<Node> Nodes)
        {
            if (!Nodes.Contains(this))
                Nodes.Add(this);
        }

        public override void MoveBagToNextNode()
        {
        }

        private void VerifyBagsCount()
        {
            Counter++;
            if (Counter + Storage.GetNumberOfBagsInStorage() < Airport.TotalNumberOfBags) return;
            Thread.Sleep(1000);
            SimulationFinishedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}