using System;
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

            GateNode.SimulationFinishedEvent += (sender, args) =>
            {

               button1_Click(this,EventArgs.Empty);
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


        public void Update(ConveyorNode conveyorNodeBackend, IConveyor frontEnd)
        {
            List<Bag> ls = conveyorNodeBackend.ListOfBagsInQueue.ToList();
            for (var j = ls.Count - 1; j >= 0; j--)
            {
                frontEnd.slots[j].Visible = ls[j] != null;
            }
            label1.Text = (GateNode.Counter).ToString();

            if ((Airport.TotalNumberOfBags - Storage.GetNumberOfBagsInStorage() ).ToString() == label1.Text)
            {
                try
                {
                    for (var j = 0; j < conveyors.Count; j++)
                    {
                        for (var k = 0; k < conveyors[j].slots.Count; k++)
                        {
                            conveyors[j].slots[k].Visible = false;
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);

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
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            ((Form1)Parent).airport.Ll.RunSimulation();
        }
    }
}