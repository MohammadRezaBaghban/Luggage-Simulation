using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Rail_Bag_Simulation
{
    class GateNode : Node 
    {
        public Gate Gate { get; }

        public List<Bag> ListOfBags { get; } = new List<Bag>();

        public GateNode(Gate g) : base()
        {
            this.Gate = g;
        }
        public override void Push(Bag g)
        {
            lock (ListOfBags)
            {
                this.ListOfBags.Add(g);
            }
        }

        public override Bag Remove()
        {
            return null;
        }

        public override string Nodeinfo()
        {
            return ListOfBags.Aggregate($"Gate: {Gate.GateNr} \n", (current, g) => current + (g.GetBagInfo() + "\n"));
        }
    }
}


