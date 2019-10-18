using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class LinkedList
    {
        private Node first;
        
        public LinkedList(Object obj)
        {
            first = new Node(obj);

        }

        public void AddNode(Object obj)
        {
           
                Node current = first;
                Node newNode = new Node(obj);

                if (first == null)
                {
                    first = newNode;
                }
                else
                {
                    while (current.next != null)
                    {
                        current = current.next;
                    }
                    newNode.next = current.next;
                    current.next = newNode;
                }
            



        }
        public void MoveBags()
        {

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

