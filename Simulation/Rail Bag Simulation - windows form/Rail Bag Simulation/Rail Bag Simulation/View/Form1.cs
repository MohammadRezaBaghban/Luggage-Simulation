using System.Windows.Forms;
using Rail_Bag_Simulation.View;
using Rail_Bag_Simulation.View.UserControls;
using System.Drawing;

namespace Rail_Bag_Simulation
{
    public partial class Form1 : Form
    {
        Color darkColor = Color.FromArgb(95, 108, 140);
        Color normalColor = Color.FromArgb(105, 119, 155);
        public Form1()
        {
            InitializeComponent();
            
            var lgForm = new LogForm();
            lgForm.Show();
            this.Hide();

            btnConfigurations.BackColor = this.darkColor;
            btnSimulation.BackColor = this.normalColor;
            btnStatistics.BackColor = this.normalColor;
            pbConfigurations.BackColor = this.darkColor;
            pbSimulation.BackColor = this.normalColor;
            pbStatistics.BackColor = this.normalColor;

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
           
        }

        private void PictureBox5_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void BtnConfigurations_Click(object sender, System.EventArgs e)
        {
            palenlConfigurations.Visible = true;
            panelBorder.Visible = true;
            panelBorder1.Visible = true;
            simulation1.Visible = false;
            statistics1.Visible = false;
            btnConfigurations.BackColor = this.darkColor;
            btnSimulation.BackColor = this.normalColor;
            btnStatistics.BackColor = this.normalColor;
            pbConfigurations.BackColor = this.darkColor;
            pbSimulation.BackColor = this.normalColor;
            pbStatistics.BackColor = this.normalColor;
        }

        private void BtnSimulation_Click(object sender, System.EventArgs e)
        {
            simulation1.Visible = true;
            statistics1.Visible = false;
            palenlConfigurations.Visible = false;
            panelBorder.Visible = false;
            panelBorder1.Visible = false;
            btnSimulation.BackColor = this.darkColor;
            btnConfigurations.BackColor = this.normalColor;
            btnStatistics.BackColor = this.normalColor;
            pbSimulation.BackColor = this.darkColor;
            pbConfigurations.BackColor = this.normalColor;
            pbStatistics.BackColor = this.normalColor;
        }

        private void BtnStatistics_Click(object sender, System.EventArgs e)
        {
            simulation1.Visible = false;
            statistics1.Visible = true;
            palenlConfigurations.Visible = false;
            panelBorder.Visible = false;
            panelBorder1.Visible = false;
            btnStatistics.BackColor = this.darkColor;
            btnConfigurations.BackColor = this.normalColor;
            btnSimulation.BackColor = this.normalColor;
            pbStatistics.BackColor = this.darkColor;
            pbConfigurations.BackColor = this.normalColor;
            pbSimulation.BackColor = this.normalColor;
        }

        private void PbConfigurations_Click(object sender, System.EventArgs e)
        {
            palenlConfigurations.Visible = true;
            panelBorder.Visible = true;
            panelBorder1.Visible = true;
            simulation1.Visible = false;
            statistics1.Visible = false;
            btnConfigurations.BackColor = this.darkColor;
            btnSimulation.BackColor = this.normalColor;
            btnStatistics.BackColor = this.normalColor;
            pbConfigurations.BackColor = this.darkColor;
            pbSimulation.BackColor = this.normalColor;
            pbStatistics.BackColor = this.normalColor;
        }

        private void PbSimulation_Click(object sender, System.EventArgs e)
        {

        }

        private void PbStatistics_Click(object sender, System.EventArgs e)
        {
            simulation1.Visible = false;
            statistics1.Visible = true;
            palenlConfigurations.Visible = false;
            panelBorder.Visible = false;
            panelBorder1.Visible = false;
            btnStatistics.BackColor = this.darkColor;
            btnConfigurations.BackColor = this.normalColor;
            btnSimulation.BackColor = this.normalColor;
            pbStatistics.BackColor = this.darkColor;
            pbConfigurations.BackColor = this.normalColor;
            pbSimulation.BackColor = this.normalColor;
        }
    }
}
