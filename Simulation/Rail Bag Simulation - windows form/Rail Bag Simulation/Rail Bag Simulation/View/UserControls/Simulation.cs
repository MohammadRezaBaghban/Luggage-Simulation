﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.CustomizedControl;

namespace Rail_Bag_Simulation.View.UserControls
{
    public partial class Simulation : UserControl
    {
        public List<IConveyor> conveyors;
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

            foreach (Control c in this.Controls)
            {
                if (c is ConveyorHorizontal horizontal)
                {
                    horizontal.initializeSlots();
                } 
                if(c is ConveyorVertical vertical)
                {
                    vertical.initializeSlots();
                }
            }

            GateNode.SimulationFinishedEvent += (sender, args) =>
            {

               button1_Click(this,EventArgs.Empty);
            };
        }

        public void Map_The_Converyors(List<Node> ls)
        {
            for (int i = 0; i < ls.Count-1; i++)
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

           // if ((Airport.TotalNumberOfBags > GateNode.Counter + Storage.GetNumberOfSuspiciousBagsInStorage() + Storage.GetNumberOfNoDestinationBagsInStorage())) return;
            try
            {
                for (var j = 0; j < conveyors.Count-1; j++)
                {
                    for (var k = 0; k < conveyors[j].slots.Count-1; k++)
                    {
                        //conveyors[j].slots[k].Visible = false;
                        var j1 = j;
                        var k1 = k;
                        conveyors[j].slots[k].BeginInvoke(new Action(() =>
                        {
                            conveyors[j1].slots[k1].Visible = false;
                        }));
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }


        public void Update(ConveyorNode conveyorNodeBackend, IConveyor frontEnd)
        {
            if(LinkedList.IsSimulationFinished)return;
            var ls = conveyorNodeBackend.ListOfBagsInQueue.ToArray();
            if (conveyorNodeBackend.ListOfBagsInQueue.Count > 0)
            {label1.Text = (GateNode.Counter).ToString();
                for (var j = 0; j < ls.Length-1; j++)
                {
                    frontEnd.slots[j].Visible = ls[j]!= null;
                }
            }
        }

        private void Cn_CheckIn_To_Security_Load(object sender, EventArgs e)
        {

        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            ((Form1)Parent).airport.Ll.PauseSimulation();
        }

        private void BtnPowerOut_Click(object sender, EventArgs e)
        {
            ((Form1)Parent).airport.Ll.DestroySimulation();
            MessageBox.Show("Power Outage Has Been Happened! Simulation Stop!");
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            ((Form1)Parent).airport.Ll.RunSimulation();
        }
    }
}