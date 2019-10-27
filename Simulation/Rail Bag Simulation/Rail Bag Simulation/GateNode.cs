using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    class GateNode : Node
    {
        public static string control;
        public Gate Gate { get; private set; }

        public List<Bag> ListOfBags { get; } = new List<Bag>();

        public GateNode(Gate g)
        {
            this.Gate = g;
        }
        public void AddBag(Bag g)
        {
            this.ListOfBags.Add(g);
        }
        public override string Nodeinfo()
        {
            string allbags = this.Gate.GateNr +": \n";
            
            foreach (Bag g in ListOfBags)
            {
                allbags += string.Format(g != null ? g.GetBagInfo() + "\n " : " ** \n ");
            }

            control += allbags;
            return allbags;
        }

        
    }
}


