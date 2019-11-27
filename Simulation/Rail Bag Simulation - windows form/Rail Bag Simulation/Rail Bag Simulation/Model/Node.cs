using System.Collections.Generic;
using System.Linq;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public interface INode
    {
        Node Next { get; set; } // the next node it refers to; null if there does not exist a next node
        Queue<Bag> ListOfBagsInQueue { get; }
        void Push(Bag b);
        Bag Remove();
        Bag Peek();
        List<string> NodeInfo();
        void MoveBagToNextNode();
    }

    public class Node : INode
    {
        public Node Next { get; set; } // the next node it refers to; null if there does not exist a next node

        public Queue<Bag> ListOfBagsInQueue => BagsQueue;

        protected readonly Queue<Bag> BagsQueue;

        protected Node()
        {
            Next = null;
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

        public virtual List<string> NodeInfo()
        {
            var sender = new List<string>();
            lock (BagsQueue)
            {
                sender.AddRange(BagsQueue.Where(g => !g.IsNull()).Select(g => g.GetBagInfo()));
            }

            return sender;
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