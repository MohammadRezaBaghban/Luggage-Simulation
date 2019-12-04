using System;
using System.Windows.Forms;
using Rail_Bag_Simulation.View;

namespace Rail_Bag_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();

            var lgForm = new LogForm();
            lgForm.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}