using System;
using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public class CheckinNode : Node
    {
        private static int _idToGive;
        
        
        public CheckinNode()
        {
           
            Id = ++_idToGive;
        }
        public  void Pushcheckinbags(List<Bag> bagsList)
        {
            bagsList.ForEach(p =>
            {
                lock (this.BagsQueue)
                {
                    this.BagsQueue.Enqueue(p);
                }
            });

          
        }
        public override void AddNode(int parentid, Type parenttype, Node _nodetoadd)
        {
            if (parentid == Id && GetType() == parenttype)
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

        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Check-in" + Id + ": "};
            sender.AddRange(base.NodeInfo());
            return sender;
        }
    }
}