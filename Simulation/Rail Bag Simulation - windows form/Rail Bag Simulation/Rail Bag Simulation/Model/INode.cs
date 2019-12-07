using System;
using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public interface INode
    {
        Queue<Bag> ListOfBagsInQueue { get; }
        void SetNext(Node value);
        Type GetNextType();
        void Push(Bag b);
        Bag Remove();
        Bag Peek();

        void AddNode(int _ID, Type t, Node nodetoadd);
        void PrintNodes(ref List<Node> Nodes);
        List<string> NodeInfo();
        void MoveBagToNextNode();
        Node GetNext();
    }
}