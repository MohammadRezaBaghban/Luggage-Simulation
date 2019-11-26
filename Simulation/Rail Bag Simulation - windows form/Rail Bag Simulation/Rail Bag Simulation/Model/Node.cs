using System.Collections.Generic;
using System.Linq;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public abstract class Node
    {
        public Node Next { get; set; } // the next node it refers to; null if there does not exist a next node
        public Node Previous { get; set; }

        protected Queue<Bag> ListOfBagsInQueue => BagsQueue;

        protected List<string> Sender;
        protected readonly Queue<Bag> BagsQueue;

        protected Node()
        {
            Next = null;
            Previous = null;
            BagsQueue = new Queue<Bag>();
            Sender = new List<string>();
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

        public virtual List<string> NodeInfo()
        {
            lock (BagsQueue)
            {
                foreach (var g in BagsQueue.Where(g => !g.IsNull())) Sender.Add(g.GetBagInfo());
            }

            return Sender;
        }

        public int QueueCount => ListOfBagsInQueue.Count;

        public virtual void MoveBagToNextNode()
        {
            if (Next.IsNull()) return;
            while (Next is ConveyorNode next && next.IsFull)
            {
            }

            Next.Push(Remove());
        }
    }
}