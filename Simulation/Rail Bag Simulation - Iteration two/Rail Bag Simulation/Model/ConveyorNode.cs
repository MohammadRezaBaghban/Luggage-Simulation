using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    
    class ConveyorNode : Node
    {
        private static int _idToGive = 100;
        public delegate void IsMove(Node f,Bag s, int x, int y);
        public IsMove MovingHandler;
        public Line conveyorline { get; private set; }
        public int Id { get; }
        private int _setsize;
        private Queue<Bag> _bagQueue;
        private bool _isEmpty = true;
        private bool _isFull = false;


        public ConveyorNode(int setsize,int X1,int X2,int Y1,int Y2,int top,int left):base(top,left)
        {
            _setsize = setsize;
            Id = ++_idToGive;
            _bagQueue = new Queue<Bag>(_setsize);
            conveyorline = new Line
            {
                Stroke = System.Windows.Media.Brushes.White,
                X1 = X1,
                X2 = X2,
                Y1 = Y1,
                Y2 = Y2,
                StrokeThickness = 30,
            };
        }

        public bool IsEmpty()
        {
            return _isEmpty;
        }
        public bool IsFull()
        {
            return _isFull;
        }
        public Queue<Bag> ListofBagsinqueue()
        {
            lock (_bagQueue)
            {
                return _bagQueue;
            }
        }
        public void PushBagToConveyorBelt(Bag bagtoqueue)
        {
            if (bagtoqueue == null) return;
            lock (_bagQueue)
            {
                if (_bagQueue.Count >= _setsize) return;
                _bagQueue.Enqueue(bagtoqueue);
                _isEmpty = false;
                MovingHandler?.Invoke(this, bagtoqueue, 1, 0);
                var count = _bagQueue.Count;
                if (count < _setsize-1) _bagQueue.Enqueue(null);
                if (count == _setsize)_isFull = true;

            }
        }

        public Bag RemoveBagFromConveyorBelt()
        {
            if (_bagQueue.Count < 1){ _isEmpty = true; return null; }

        var bag = _bagQueue.Dequeue();
            _isFull = false;
            if (bag != null)
            {
                MovingHandler?.Invoke(this.Next, bag, 1, 0);
            }
            return bag;
        }


        public override string Nodeinfo() // change the method to return a list of bags
        {
            string bagqueueinfo = "Conveyor " + Id.ToString() + ": \n";
            var listOfBags = ListofBagsinqueue();
            lock (listOfBags)
            {
                foreach (Bag g in listOfBags)
                {
                    if(g != null){bagqueueinfo += string.Format(g != null ? g.GetBagInfo() + "\n " : " ** \n ");}
                    else
                    {
                        bagqueueinfo += "\n ** \n";
                    }
                }}
            return bagqueueinfo;
        }

       
    }
}
