using System;
using System.Collections.Generic;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public class ConveyorNode : Node
    {
        private static int _idToGive = 100;

        private readonly int _setsize;

        public ConveyorNode(int setsize)
        {
            _setsize = setsize;
            Id = ++_idToGive;
        }

        public bool IsEmpty { get; private set; } = true;
        public bool IsFull { get; private set; }

        public override void Push(Bag bagtoqueue)
        {
            if (bagtoqueue.IsNull()) return;
            lock (BagsQueue)
            {
                if (BagsQueue.Count >= _setsize) return;
                BagsQueue.Enqueue(bagtoqueue);
                IsEmpty = false;
                var count = BagsQueue.Count;
                if (count < _setsize - 1) BagsQueue.Enqueue(null);
                if (count == _setsize) IsFull = true;

            }
            OnQueueChangedEventHandler?.Invoke(this, EventArgs.Empty);
        }

        public override void AddNode(int parentid, Type parenttype, Node _nodetoadd)
        {
            if (parentid == Id && GetType() == parenttype && GetNext() != _nodetoadd)
            {
                _nodetoadd.SetNext(GetNext());
                SetNext(_nodetoadd);
            }
            else
            {
                if (GetNext() != null)
                    GetNext().AddNode(parentid, parenttype, _nodetoadd);
            }
        }

        public override void PrintNodes(ref List<Node> Nodes)
        {
            if (!Nodes.Contains(this))
                Nodes.Add(this);

            if (GetNext() != null)
                GetNext().PrintNodes(ref Nodes);
        }

        public override Bag Remove()
        {
            Bag bag;
            lock (BagsQueue)
            {
                if (BagsQueue.Count < 1)
                {
                    IsEmpty = true;
                    return null;
                }

                bag = BagsQueue.Dequeue();
                IsFull = false;
            }
            OnQueueChangedEventHandler?.Invoke(this, EventArgs.Empty);
            return bag;
            
        }


        public override List<string> NodeInfo() // change the method to return a list of bags
        {
            var sender = new List<string> {"ConveyorHorizontal " + Id};
            sender.AddRange(base.NodeInfo());
            return sender;
        }

        public override void MoveBagToNextNode()
        {
            if (IsEmpty) return;
            if (GetNext() is ConveyorNode next && next.IsFull) return;

            var bag = Remove();
           

            if (bag.IsNull()) return;
            GetNext().Push(bag);

        }
    }
}