﻿using System;
using System.Collections.Generic;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public abstract class Node
    {
       
        public Node Next { get;  set; } // the next node it refers to; null if there does not exist a next node
        public Node Previous { get;  set; }

        protected Queue<Bag> ListOfBagsInQueue => BagsQueue;

        protected string Sender = " ";
        protected readonly Queue<Bag> BagsQueue;

        protected Node()
        {
            Next = null;
            Previous = null;
            BagsQueue = new Queue<Bag>();

        }

        public virtual void Push(Bag b)
        {
            lock (BagsQueue)
            {
                BagsQueue.Enqueue(b);
            }
        }
        public virtual Bag Remove()
        {
            lock (BagsQueue)
            {
                if (BagsQueue.Count < 1)
                    return null;
                var bag = BagsQueue.Dequeue();
                return bag;
            }
        }

        public Bag Peek()
        {
            lock (BagsQueue)
            {
                if (BagsQueue.Count < 1)
                    return null;
                var bag = BagsQueue.Peek();
                return bag;
            }
        }

        public virtual string NodeInfo()
        {
            Sender = " ";
            lock (BagsQueue)
            {
                foreach (Bag g in BagsQueue)
                {
                    Sender += g.GetBagInfo() + "\n";
                }
            }

            return Sender;
        }

        public int QueueCount => ListOfBagsInQueue.Count;

        public virtual void MoveBagToNextNode()
        {
            if (!this.Next.IsNull())
            {
                this.Next.Push(Remove());
            }

            /*if (@from.IsNull()) return;

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
                    if (to.IsNull()) return;
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
            }*/
        }
    }
}

