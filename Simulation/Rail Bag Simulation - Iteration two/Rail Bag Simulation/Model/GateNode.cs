using System;
using System.Collections.Generic;
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
            this.ListOfBags.Add(g);
        }
        public override string Nodeinfo()
        {
            string allbags = this.Gate.GateNr +": \n";
            control = "";
            foreach (Bag g in ListOfBags)
            {
                allbags += string.Format(g != null ? g.GetBagInfo() + "\n " : " ** \n ");
            }
            control += allbags;
            return allbags;
        }

        
    }
}


