using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Rail_Bag_Simulation
{
    
    class ConveyorNode : Node
    {
        private static int _idToGive = 100;
        public delegate void IsMove(Node f,Bag s, int x, int y);
        public IsMove MovingHandler;
        public Line conveyorline { get; private set; }
        public bool IsFull { get; private set; }
        public int Id { get; }
        private int _setsize;
        private Queue<Bag> _bagQueue;


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
            lock (_bagQueue)
            {
                return _bagQueue.Count < 1;
            }
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
            lock (_bagQueue)
            {
                if (_bagQueue.Count < _setsize && bagtoqueue != null)
                {
                    _bagQueue.Enqueue(bagtoqueue);
                    MovingHandler?.Invoke(this, bagtoqueue, 1, 0);

                    IsFull = false;
                }
                else
                {
                    IsFull = true;
                }
            }
        }

        public Bag RemoveBagFromConveyorBelt()
        {
            lock (_bagQueue)
            {
                if (_bagQueue.Count < 1)
                    return null;

                Bag bag = _bagQueue.Dequeue();
                if (bag != null)
                {
                    MovingHandler?.Invoke(this.Next, bag, 1, 0);
                }

                IsFull = false;
                return bag;
            }
        }


        public override string Nodeinfo() // change the method to return a list of bags
        {
            string bagqueueinfo = "Conveyor " + Id.ToString() + ": \n";
            foreach (Bag g in ListofBagsinqueue())
            {

                bagqueueinfo += string.Format(g != null ? g.GetBagInfo() + "\n " : " ** \n ");
            }
            return bagqueueinfo;
        }

       
    }
}
