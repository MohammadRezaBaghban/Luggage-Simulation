using System.Windows.Forms;
using Rail_Bag_Simulation.View;

namespace Rail_Bag_Simulation
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
            LogForm lgForm = new LogForm();
            lgForm.Show();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
           
        }
    }
}
