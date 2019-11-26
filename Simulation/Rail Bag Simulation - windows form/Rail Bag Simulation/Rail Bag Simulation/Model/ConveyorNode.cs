using System.Collections.Generic;
using System.Linq;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    
    class ConveyorNode : Node
    {
        private static int _idToGive = 100;
        public int Id { get; }
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
            if (bagtoqueue == null) return;
            lock (BagsQueue)
            {
                if (BagsQueue.Count >= _setsize) return;
                BagsQueue.Enqueue(bagtoqueue);
                IsEmpty = false;
                var count = BagsQueue.Count;
                if (count < _setsize-1) BagsQueue.Enqueue(null);
                if (count == _setsize)IsFull = true;

            }
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
             return bag;
            }
        }


        public override List<string> NodeInfo() // change the method to return a list of bags
        {
            Sender.Clear();

            Sender.Add("Conveyor " + Id);
            base.NodeInfo();
            return Sender;
        }

        public override void MoveBagToNextNode()
        {
            if(IsEmpty) return;
            if(Next is ConveyorNode next && next.IsFull) return;

            var bag = Remove();
            if(bag.IsNull())return;
            Next.Push(bag);
        }

    }
}
