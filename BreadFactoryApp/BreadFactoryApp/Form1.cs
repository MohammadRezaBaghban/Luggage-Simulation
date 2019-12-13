using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadFactoryApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void btnManufacture_Click(object sender, EventArgs e)
        {
            int nbrOfLoafsToBeManufatured=0;
            nbrOfLoafsToBeManufatured = Convert.ToInt32(tbToBeManufactured.Text);
            if (rbBrownBread.Checked)
            {

            }
            else if (rbWhiteBread.Checked)
            {

            }
            else {
                MessageBox.Show("Please select the type of bread to be manufactured");
            }
        }
    }
}
