using System;
using System.Collections.Generic;
using System.Linq;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public interface INode
    {
        Queue<Bag> ListOfBagsInQueue { get; }
        void SetNext(Node value);
        Type GetNextType();
        void Push(Bag b);
        Bag Remove();
        Bag Peek();
        List<string> NodeInfo();
        void MoveBagToNextNode();
        Node GetNext();
    }

    public class QueueEventArgs : EventArgs
    {
        public List<Bag> ListOfBags { get; set; }
    }

    public class Node : INode
    {
        protected readonly Queue<Bag> BagsQueue;
        private Node _next;
        public EventHandler<QueueEventArgs> OnQueueChangedEventHandler;

        protected Node()
        {
            SetNext(null);
            BagsQueue = new Queue<Bag>();
        }

        public int QueueCount => ListOfBagsInQueue.Count;

        public void SetNext(Node value)
        {
            _next = value;
        }

        public Type GetNextType()
        {
            return _next.GetType();
        }

        public Node GetNext()
        {
            return _next;
        }

        public Queue<Bag> ListOfBagsInQueue => BagsQueue;

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

        public virtual List<string> NodeInfo()
        {
            var sender = new List<string>();
            lock (BagsQueue)
            {
                sender.AddRange(BagsQueue.Where(g => !g.IsNull()).Select(g => g.GetBagInfo()));
            }

            return sender;
        }

        public virtual void MoveBagToNextNode()
        {
            if (GetNext().IsNull()) return;
            while (GetNext() is ConveyorNode next && next.IsFull)
            {
            }

            GetNext().Push(Remove());
        }
    }
}