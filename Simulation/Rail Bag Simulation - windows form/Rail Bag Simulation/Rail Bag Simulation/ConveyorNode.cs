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


        public override string NodeInfo() // change the method to return a list of bags
        {
            var bagqueueinfo = "Conveyor " + Id.ToString() + ": \n";
            var listOfBags = ListOfBagsInQueue;
            lock (listOfBags)
            {
                foreach (Bag g in listOfBags)
                {
                    if(g != null){bagqueueinfo += string.Format( g.GetBagInfo() + "\n ");}
                    else
                    {
                        bagqueueinfo += "\n ** \n";
                    }
                }}
            return bagqueueinfo;
        }

        public override void MoveBagToNextNode()
        {
            if(IsEmpty) return;
            if(Next is ConveyorNode next) { 
                if(!next.IsFull)
                {
                    var bag = Remove();
                    if(bag.IsNull())return;
                    Next.Push(bag);
                    return;
                };
                return;
            }

            var bag1 = Remove();
            if(bag1.IsNull())return;
            Next.Push(bag1);
        }

    }
}
