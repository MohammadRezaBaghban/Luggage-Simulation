using System.Collections.Generic;
using System.Linq;
using Rail_Bag_Simulation.Model;
using System;

namespace Rail_Bag_Simulation
{
    
    class ConveyorNode : Node
    {
        private static int _idToGive = 100;
     
        private readonly int _setsize;
        public ConveyorNode(int setsize)
        {
            _setsize = setsize;
            Id = ++_idToGive;
        }

        public bool IsEmpty { get; private set; } = true;
        public bool IsFull { get; private set; } = false;
        
        public override void Push(Bag bagtoqueue)
        {
            if (bagtoqueue.IsNull()) return;
            lock (BagsQueue)
            {
                if (BagsQueue.Count >= _setsize) return;
                BagsQueue.Enqueue(bagtoqueue);
                IsEmpty = false;
                var count = BagsQueue.Count;
                if (count < _setsize-1) BagsQueue.Enqueue(null);
                if (count == _setsize)IsFull = true;
                OnQueueChangedEventHandler?.Invoke(this, new QueueEventArgs { ListOfBags = BagsQueue.ToList() });


            }
        }

        public override void AddNode(int parentid,Type parenttype,Node _nodetoadd)
        {
            if (parentid == Id && this.GetType() == parenttype && this.GetNext() != _nodetoadd)
            {
                _nodetoadd.SetNext(this.GetNext());
                this.SetNext(_nodetoadd);
            }
            else
            {
                if (this.GetNext() != null)
                    GetNext().AddNode(parentid, parenttype, _nodetoadd);
            }
            
        }
        public override void PrintNodes(ref List<Node> Nodes)
        {
            if (!Nodes.Contains(this))
            Nodes.Add(this);

            if (GetNext()!=null)
            this.GetNext().PrintNodes(ref Nodes);
        }

        public override Bag Remove()
        {
            lock (BagsQueue)
            {
                if (BagsQueue.Count < 1)
                {
                    IsEmpty = true;
                    return null;
                }

                var bag = BagsQueue.Dequeue(); 
                IsFull = false;
                OnQueueChangedEventHandler?.Invoke(this, new QueueEventArgs { ListOfBags = BagsQueue.ToList() });
                return bag;
            }
        }


        public override List<string> NodeInfo() // change the method to return a list of bags
        {
            var sender = new List<string> {"Conveyor " + Id};
            sender.AddRange(base.NodeInfo());
            return sender;
        }

        public override void MoveBagToNextNode()
        {
            if(IsEmpty) return;
            if(GetNext() is ConveyorNode next && next.IsFull) return;

            var bag = Remove();
            if(bag.IsNull())return;
            GetNext().Push(bag);
        }

    }
}
