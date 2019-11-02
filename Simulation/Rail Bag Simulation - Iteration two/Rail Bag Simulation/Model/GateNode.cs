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
        public Gate Gate { get; private set; }

        public static string control;
        public Image image { get; private set; }
        public List<Bag> ListOfBags { get; } = new List<Bag>();

        public GateNode(Gate g,int top, int left) : base(top, left)
        {
            this.Gate = g;
            image = new Image
            {
                Width = 80,
                Height = 80,
                Source = new BitmapImage(new Uri("../../Resources/gate.png", UriKind.Relative))
            };
        }
        public void AddBag(Bag g)
        {
            lock (ListOfBags)
            {
                this.ListOfBags.Add(g);
            }
        }
        public override string Nodeinfo()
        {
            return ListOfBags.Aggregate($"Gate: {Gate.GateNr} \n", (current, g) => current + (g.GetBagInfo() + "\n"));
        }

        
    }
}


