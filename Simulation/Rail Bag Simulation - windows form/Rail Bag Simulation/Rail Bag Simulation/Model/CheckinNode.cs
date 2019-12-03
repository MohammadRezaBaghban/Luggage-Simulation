using System.Collections.Generic;
using Rail_Bag_Simulation.Model;
using System;


namespace Rail_Bag_Simulation
{
    public class CheckinNode : Node
    {
        private static int _idToGive = 1;
        public CheckinNode() => Id = ++_idToGive;
        public override void AddNode(int parentid, Type parenttype, Node _nodetoadd)
        {
           
            if (parentid == this.Id&& this.GetType() == parenttype)
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

            if (this.GetNext()!=null)
            this.GetNext().PrintNodes(ref Nodes);
        }
        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Check-in" +this.Id+": "};
            sender.AddRange(base.NodeInfo());
            return sender;
        }
    }
}
