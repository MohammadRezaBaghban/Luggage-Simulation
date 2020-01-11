using System;
using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public class SecurityNode : Node
    {
        private static int _idToGive;

        public SecurityNode()
        {
            Id = ++_idToGive;
        }

        public override Bag Remove()
        {
            return ScanBagSecurity();
        }

        public override List<string> NodeInfo()
        {
            var sender = new List<string> {"Security " + Id + ":"};
            sender.AddRange(base.NodeInfo());
            return sender;
        }

        public override void AddNode(int parentid, Type parenttype, Node _nodetoadd)
        {
            if (GetType() == parenttype)
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

        private Bag ScanBagSecurity()
        {
            Bag b = null;
            try
            {
                lock (BagsQueue)
                {
                    b = base.Remove();
                }
            }
            catch (Exception)
            {
                // ignored
            }

            if (b?.GetSecurityStatus() == null) return b;


            Airport.Storage.StoreSuspiciousBag(b);
            return null;
        }
    }
}