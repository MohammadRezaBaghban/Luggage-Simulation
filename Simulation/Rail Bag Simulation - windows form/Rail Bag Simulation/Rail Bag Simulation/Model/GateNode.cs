﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Rail_Bag_Simulation
{
    class GateNode : Node 
    {
        public Gate Gate { get; }
        public static EventHandler SimulationFinishedEvent;

        public static int Counter;

        public GateNode(Gate g)
        {
            Gate = g;
        }

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
            VerifyBagsCount();
        }

        public override void MoveBagToNextNode()
        {
        }

        private void VerifyBagsCount()
        {
            Counter++;
            if (Counter + Storage.GetNumberOfBagsInStorage() < Airport.TotalNumberOfBags) return;
            Thread.Sleep(1000); SimulationFinishedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}


