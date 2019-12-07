using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.View
{
    public partial class Configurations : Form
    {
        public Configurations()
        {
            InitializeComponent();
        }

        private void btnSaveSimulation_Click(object sender, EventArgs e)
        {
            using (FileStream stream = new FileStream("C:\\mysecretfile.txt", FileMode.Create))
            {
                BinaryFormatter bw = new BinaryFormatter();
                bw.Serialize(stream, Airport.GetBagList);
            }

        }

        private void btnLoadSimulation_Click(object sender, EventArgs e)
        {

        }
    }
}
