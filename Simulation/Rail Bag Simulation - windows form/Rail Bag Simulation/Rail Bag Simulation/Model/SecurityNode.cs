using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Rail_Bag_Simulation.Model;

namespace Rail_Bag_Simulation
{
    public class SecurityNode : Node
    {
        private static int _idToGive;




        private static Dictionary<Destination?, Dictionary<SuspiciousBagtype, int>> nbrOfSuspiciousBagPerDestination;
        public static Dictionary<Destination , int> destinationDistribution;
        public SecurityNode()
        {
            Id = ++_idToGive;
            destinationDistribution = new Dictionary<Destination, int>();
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

        public Bag ScanBagSecurity()
        {
            if (nbrOfSuspiciousBagPerDestination==null)
            {
                nbrOfSuspiciousBagPerDestination=new Dictionary<Destination?, Dictionary<SuspiciousBagtype, int>>();
                Airport.Destinations.Values.ToList().ForEach(destination =>
                {
                    // need to be fixed the items are being added twice
                    nbrOfSuspiciousBagPerDestination.Add(destination,new Dictionary<SuspiciousBagtype, int>
                    {           
                        {SuspiciousBagtype.Flammables, 0},
                        {SuspiciousBagtype.Drug, 0},
                        {SuspiciousBagtype.Other, 0},
                        {SuspiciousBagtype.Weapons, 0},

                    });
                    destinationDistribution.Add(destination,0);
                });
            }
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

            if (!b.IsNull())
            {
                foreach (var destination in Airport.Destinations.Where(destination =>
                    destination.Key == b.TerminalAndGate))
                {
                    destinationDistribution[destination.Value]++;
                }
            }

            {
                
            }

            if (b?.GetSecurityStatus() == null) return b;

            SuspiciousBagCategoryPerDestination(b);
            Airport.Storage.StoreSuspiciousBag(b);

           
            return b;
        }

        public static Dictionary<Destination?, Dictionary<SuspiciousBagtype, int>> getDicDestinationBag() 
        {
            return nbrOfSuspiciousBagPerDestination;
        }


        public void SuspiciousBagCategoryPerDestination(Bag g)
        {
            Bag b = g;
            Destination? d;

            foreach (var destination in Airport.Destinations.Where(destination => destination.Key == b.TerminalAndGate))
            {
                d = destination.Value;

                
                    Destination? firstOrDefault = nbrOfSuspiciousBagPerDestination.Keys.SingleOrDefault(pair => pair == d);
                    if(firstOrDefault.IsNull())return;
                    switch (b.SuspiciousBagtype)
                    {
                        case SuspiciousBagtype.Drug:
                        {

                            nbrOfSuspiciousBagPerDestination[firstOrDefault][SuspiciousBagtype.Drug]++;

                            break;
                        }
                        case SuspiciousBagtype.Flammables:
                        {
                            nbrOfSuspiciousBagPerDestination[firstOrDefault][SuspiciousBagtype.Flammables]++;
                            break;
                        }
                        case SuspiciousBagtype.Weapons:
                        {
                            nbrOfSuspiciousBagPerDestination[firstOrDefault][SuspiciousBagtype.Weapons]++;
                            break;
                        }
                        default:
                        {
                            nbrOfSuspiciousBagPerDestination[firstOrDefault][SuspiciousBagtype.Other]++;
                            break;
                        }
                    }
              
            }
        }
    }
}