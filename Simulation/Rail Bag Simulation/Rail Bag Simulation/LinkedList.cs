using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class LinkedList
    {
        public Node First { get; private set; }
        private Node _lastnode1, _lastnode2;
        public LinkedList()
        {
            First = null;
        }

        public void MoveBags()
        {
            if (First != null)
            {
                var current = First;
                while (current.Next != null)
                {
                    switch (current.Next)
                    {
                        case ConveyorNode node when current is ConveyorNode:
                        {
                            if( node.Conveyor.IsFull ==false)
                            {
                                node.Conveyor.Push(((ConveyorNode)current).Conveyor.Remove());
                            }
                            break;
                        }

                        case BagSortNode node when current is ConveyorNode:
                        {
                            if (((ConveyorNode)current).Conveyor.IsFull)
                            {
                                node.PassBag(((ConveyorNode)current).Conveyor.Remove());
                           
                            }

                            break;
                        }
                        case ConveyorNode node when current is CheckpointNode:
                        {
                            if (((CheckpointNode)current).Bagtocheck != null && node.Conveyor.IsFull == false)
                            {
                                node.Conveyor.Push(((CheckpointNode)current).Bagtocheck);
                                ((CheckpointNode)current).SetBag(null);
                            }

                            break;
                        }
                    }
                    current = current.Next;
                }
            }
            else
            {
                throw new Exception("no simulation made");
            }
        }
        public void AddGeneratedBag(Bag bagtoqueue)
        {
            if (First != null)
            {
                if (!(First is ConveyorNode node)) return;
                if (node.Conveyor.IsFull)
                {
                    MoveBags();
                }

                
                ((ConveyorNode)node).Conveyor.Push(bagtoqueue);
                
            }
            else
            {
                throw new Exception("no simulation made");
            }
        }
        public void AddNode(object obj)
        {
            Node newNode;
            if (obj is Conveyorbelt)
            {
                 newNode = new ConveyorNode((Conveyorbelt)obj);
            }
            else
            {
                newNode = new CheckpointNode(obj);
            }
            if (First == null)
            {
                First = newNode;
            }
            else
            {
                var current = First;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }
    
        public void RemoveNode()
        {
            var current = First;
            
                    while (current.Next.Next != null)
                    {
                         current = current.Next;
                    }
            current.Next = null;
        }
    }
}

