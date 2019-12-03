using System;
using System.Collections.Generic;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    internal class SecurityNode : Node
    {
        public override Bag Remove()
        {
            return ScanBagSecurity();
        }
        private static int _idToGive = 1;
        public SecurityNode()
        {

            Id = ++_idToGive;
        }
        public override List<String> NodeInfo()
        {
            var sender = new List<string> {"Security+"+this.Id+":"};
            sender.AddRange(base.NodeInfo());
            return sender;
        }
        public override void AddNode(int parentid, Type parenttype, Node _nodetoadd)
        {
            if (this.GetType() == parenttype)
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

            if(this.GetNext()!=null)
            this.GetNext().PrintNodes(ref Nodes);
        }
        private Bag ScanBagSecurity()
        {
            Bag b = null;
            try
            {
                lock (ListOfBagsInQueue)
                {
                    b = ListOfBagsInQueue.Dequeue();
                }
            }
            catch (Exception)
            {
                // ignored
            }

            if (b?.GetSecurityStatus() == null)
            {
                return b;
            }

            
            Airport.Storage.StoreSuspiciousBag(b);
            return null;
        }

    }
}
