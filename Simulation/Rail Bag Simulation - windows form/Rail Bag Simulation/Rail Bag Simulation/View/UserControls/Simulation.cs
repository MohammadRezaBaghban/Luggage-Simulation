using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.View.UserControls
{
    public partial class Simulation : UserControl
    {
        private List<UserControl> conveyors;
        public Simulation()
        {
            InitializeComponent();
            conveyors = new List<UserControl>()
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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Simulation_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}