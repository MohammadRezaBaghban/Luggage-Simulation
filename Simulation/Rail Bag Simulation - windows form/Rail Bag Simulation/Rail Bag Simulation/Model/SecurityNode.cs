using System;
using System.Collections.Generic;
using System.Linq;

namespace Rail_Bag_Simulation
{
    public class SecurityNode : Node
    {
        private static int _idToGive;




        public static Dictionary<Destination, Dictionary<SuspiciousBagtype, int>> nbrOfSuspiciousBagPerDestination = new
            Dictionary<Destination, Dictionary<SuspiciousBagtype, int>>();

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
            if (GetType() == parenttype && parentid==Id)
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

        public  Bag ScanBagSecurity()
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

           // SuspiciousBagCategoryPerDestination(b);
            Airport.Storage.StoreSuspiciousBag(b);

           
            return b;
        }

        public static Dictionary<Destination, Dictionary<SuspiciousBagtype, int>> getDicDestinationBag() 
        {
            return nbrOfSuspiciousBagPerDestination;
        }


        /*public void SuspiciousBagCategoryPerDestination(Bag g)
        {
            Bag b = g;
            Destination d;
            int drugs=0;
            int flammable=0;
            int weapons = 0;
            int others = 0;

            foreach (var destination in Airport.Destinations)
            {
                if (destination.Key == b.TerminalAndGate)
                {
                    d = destination.Value;

                    foreach (var i in Bag.returnListOfSuspiciousBags())
                    {
                        if (i.SuspiciousBagtype == SuspiciousBagtype.Drug)
                        {
                            drugs++;
                        }
                        else if (i.SuspiciousBagtype == SuspiciousBagtype.Flammables)
                        {
                            flammable++;
                        }
                        else if (i.SuspiciousBagtype == SuspiciousBagtype.Weapons)
                        {
                            weapons++;
                        }
                        else {others++;}
                    }
                }
            }

                //nbrOfSuspiciousBagPerDestination.FirstOrDefault().Key;
                    //Go through the first dictionary and find the keyValuePair,
                    //if(d == key){
                    //          go through the sub dictionary and find drug
                    //if(value.key == drug){
                    //valvue.value++;
                    //}
            
            
        }*/

    }
}