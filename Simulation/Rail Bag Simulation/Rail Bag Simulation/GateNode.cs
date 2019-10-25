using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    class GateNode : Node 
    {
        public Gate Gate { get; private set; }
        private List<Bag> _listofBags = new List<Bag>();
        
        public List<Bag> ListOfBags => _listofBags;
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
            string allbags = this.Gate.GateNr +":";
            foreach (Bag g in ListOfBags)
            {
                allbags += string.Format(g != null ? g.GetBagInfo() + "\n " : " ** \n ");
            }
            return allbags;
        }
    }
}


