using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rail_Bag_Simulation.CustomizedControl;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.View.UserControls
{
    public partial class Simulation2 : UserControl
    {
        public List<IConveyor> conveyors;
        public Simulation2()
        {
            InitializeComponent();
            conveyors = new List<IConveyor>()
            {
                CheckIn1_To_Security1_Conveyor,
                CheckIn2_To_Security2_Conveyor,
                CheckIn3_To_Security3_Conveyor,
                security1_Conveyor_To_BagSort,
                security2_Conveyor_To_BagSort,
                security3_Conveyor_To_BagSort,
                bagSort_Conveyor_To_Terminal1,
                bagSort_Conveyor_To_Terminal2,
                terminal1_Conveyor_To_Gate1,
                terminal1_Conveyor_To_Gate2,
                terminal1_Conveyor_To_Gate3,
                terminal1_Conveyor_To_Gate4,
                terminal1_Conveyor_To_Gate5,
                terminal2_Conveyor_To_Gate1,
                terminal2_Conveyor_To_Gate2,
                terminal2_Conveyor_To_Gate3,
                terminal2_Conveyor_To_Gate4,
                terminal2_Conveyor_To_Gate5
            };
            foreach (Control c in this.Controls)
            {
                if (c is ConveyorHorizontal horizontal)
                {
                    horizontal.initializeSlots();
                }
                if (c is ConveyorVertical vertical)
                {
                    vertical.initializeSlots();
                }
            }

            GateNode.SimulationFinishedEvent += (sender, args) =>
            {

                button1_Click(this, EventArgs.Empty);
            };
        } 
        public void Map_The_Converyors(List<Node> ls)
        {
            for (int i = 0; i < ls.Count; i++)
            {
                
                conveyors[i].SetConveyor((ConveyorNode)ls[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                for (var j = 0; j < conveyors.Count - 1; j++)
                {
                    for (var k = 0; k < conveyors[j].slots.Count - 1; k++)
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
            if (LinkedList.IsSimulationFinished) return;
            var ls = conveyorNodeBackend.ListOfBagsInQueue.ToArray();
            if (conveyorNodeBackend.ListOfBagsInQueue.Count > 0)
            {
                for (var j = 0; j < ls.Length-1; j++)
                {
                    frontEnd.slots[j].Visible = ls[j] != null;
                }


                label1.Text = (GateNode.Counter).ToString();
               
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            ((Form1)Parent).airport.Ll.PauseSimulation();
        }

        private void btnPowerOut_Click(object sender, EventArgs e)
        {
            ((Form1)Parent).airport.Ll.DestroySimulation();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ((Form1)Parent).airport.Ll.RunSimulation();
        }
    }
}
