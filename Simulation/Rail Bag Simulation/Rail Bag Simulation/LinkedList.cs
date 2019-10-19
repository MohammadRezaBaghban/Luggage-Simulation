using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class LinkedList
    {
        public Node first { get; private set; }
        private Node lastnode1, lastnode2;
        public LinkedList()
        {
            first = null;
        }

        public void MoveBags()
        {
            if (first != null)
            {
                Node current = first;
                while (current.next != null)
                {
                 
                    if (current.next is ConveyorNode && current is ConveyorNode)
                    {
                        if(((ConveyorNode)current).conveyor.isFull == true && ((ConveyorNode)current.next).conveyor.isFull ==false)
                        {
                            ((ConveyorNode)current.next).conveyor.Push(((ConveyorNode)current).conveyor.Remove());
                         
                        }    
                    }
                    else if (current.next is CheckpointNode && current is ConveyorNode)
                    {
                        if (((ConveyorNode)current).conveyor.isFull == true && ((CheckpointNode)current.next).bagtocheck == null)
                        {
                            ((CheckpointNode)current.next).setBag(((ConveyorNode)current).conveyor.Remove());
                           
                        }
                      
                    }
                    else if (current.next is ConveyorNode && current is CheckpointNode)
                    {
                        if (((CheckpointNode)current).bagtocheck != null && ((ConveyorNode)current.next).conveyor.isFull == false)
                        {
                            ((ConveyorNode)current.next).conveyor.Push(((CheckpointNode)current).bagtocheck);
                            ((CheckpointNode)current).setBag(null);
                        }
                    }
                    

                    current = current.next;
                }
            }
            else
            {
                throw new Exception("no simulation made");
            }
        }
        public void AddGeneratedBag(Bag Bagtoqueue)
        {
            if (first != null)
            {
                if (first is ConveyorNode)
                {
                    if (((ConveyorNode)first).conveyor.isFull == true)
                    {
                        MoveBags();
                    }
                  ((ConveyorNode)first).conveyor.Push(Bagtoqueue);

                }
                   
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
                if (first == null)
                {
                    first = newNode;
                }
                else
                {
                Node current = first;
                while (current.next != null)
                    {
                        current = current.next;
                    }
                    newNode.next = current.next;
                    current.next = newNode;
                }
            



        }
    
        public void RemoveNode()
        {
            Node current = first;
            
                    while (current.next.next != null)
                    {
                         current = current.next;
                    }
            current.next = null;

        }
            

    }
}

