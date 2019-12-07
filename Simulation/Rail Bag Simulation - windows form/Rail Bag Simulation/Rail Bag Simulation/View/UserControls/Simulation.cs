﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.CustomizedControl;

namespace Rail_Bag_Simulation.View.UserControls
{
    public partial class Simulation : UserControl
    {
        private List<IConveyor> conveyors;
        public Simulation()
        {
            InitializeComponent();
            conveyors = new List<IConveyor>()
            {
                Cn_CheckIn_To_Security,
                Cn_Security_Sorter,
                Cn_Sorter_To_Terminal1,
                Cn_Sorter_To_Terminal2,
                Cn_Terminal1_To_Gate1,
                Cn_Terminal1_To_Gate2,
                Cn_Terminal2_To_Gate1,
                Cn_Terminal2_To_Gate2,
            };
        }

        public void Map_The_Converyors(List<Node> ls)
        {
            for (int i = 0; i < ls.Count; i++)
            {
                conveyors[i].SetConveyor((ConveyorNode)ls[i]);
            }
        }


        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Simulation_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        public void Update(ConveyorNode conveyorNodeBackend)
        {
            Cn_CheckIn_To_Security.slots.ForEach(box =>
            {
                for (var j = 0; j < conveyorNodeBackend.ListOfBagsInQueue.ToList().Count; j++)
                {
                    Cn_CheckIn_To_Security.slots[j].Visible = conveyorNodeBackend.ListOfBagsInQueue.ToList()[j] != null;
                }
            });
        }
    }
}