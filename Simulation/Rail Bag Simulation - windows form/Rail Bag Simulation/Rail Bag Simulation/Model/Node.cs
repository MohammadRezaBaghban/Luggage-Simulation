using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public  class Node : INode
    {
        protected  readonly Queue<Bag> BagsQueue;
        private Node _next;
        public EventHandler OnQueueChangedEventHandler;

        protected Node()
        {
            SetNext(null);
            BagsQueue = new Queue<Bag>();
        }

        public int Id { get; set; }

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

        public virtual void AddNode(int parentid, Type parenttype, Node _nodetoadd)
        {
            //this is to satisfy virtual method
        }

        public virtual void PrintNodes(ref List<Node> Nodes)
        {
            GetNext().PrintNodes(ref Nodes);
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
            lock (BagsQueue)
            {
                if (GetNext().IsNull()) return;
                if (GetNext() is ConveyorNode next && next.IsFull)
                {
                    return;
                }

                GetNext().Push(Remove());
            }
        }
    }
}