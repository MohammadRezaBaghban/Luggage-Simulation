using System;
using System.Windows.Forms;
using Rail_Bag_Simulation.View;
using Rail_Bag_Simulation.View.UserControls;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public partial class Form1 : Form
    {
        StatisticsForm stat = new StatisticsForm();
        
        //string fileName = "../../config.txt";


        Color darkColor = Color.FromArgb(95, 108, 140);
        Color normalColor = Color.FromArgb(105, 119, 155);
        public Airport airport;
        public Form1()
        {
            
            InitializeComponent();
            stat.Show();

            btnConfigurations.BackColor = this.darkColor;
            btnSimulation.BackColor = this.normalColor;
            btnStatistics.BackColor = this.normalColor;
            pbConfigurations.BackColor = this.darkColor;
            pbSimulation.BackColor = this.normalColor;
            pbStatistics.BackColor = this.normalColor;
            
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void btnRunSimulation_Click(object sender, EventArgs e)
        { 
            ShowSimulationPanel();

            airport = new Airport(500);
            airport.CreateMapLayout(5);

            simulation1.Map_The_Converyors(airport.GetConveyorsList());

            /*airport.StartBagsMovement(
            Convert.ToInt32(tb_numberOfBags.Text),
                Convert.ToInt32(tb_drugs.Text),
                Convert.ToInt32(tb_weapons.Text),
                Convert.ToInt32(tb_flammables.Text),
                Convert.ToInt32(tb_Others.Text)
            );*/

            airport.StartBagsMovement(
                38,2,1,3,3
            );



        }

        private void ShowSimulationPanel()
        {
            palenlConfigurations.Visible = false;
            simulation1.Visible = true;
            panelBorder.Visible = false;
            panelBorder1.Visible = false;
        }

        private void btnSaveSimulation_Click(object sender, EventArgs e)
        {
            saveLog = new SaveFileDialog();
            saveLog.Filter = "Text Files (*.txt)|*.txt";
            saveLog.DefaultExt = "txt";
            saveLog.AddExtension = true;
            saveLog.Title = "Select config file";
            if (saveLog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;
                try
                {
                    fs = new FileStream(saveLog.FileName, FileMode.Create, FileAccess.Write);
                    bf = new BinaryFormatter();
                    bf.Serialize(fs, Airport.GetBagList);

                }
                catch (SerializationException) { MessageBox.Show("Error opening/creating file"); }
                finally 
                { 
                    if (fs != null) 
                    { 
                        fs.Close();
                    }
                }
            }
        }

        private void btnLoadSimulation_Click(object sender, EventArgs e)
        {
            openLog = new OpenFileDialog();
            openLog.Filter = "Text Files (*.txt)|*.txt";
            openLog.DefaultExt = "txt";
            openLog.AddExtension = true;
            openLog.Title = "Select config file";
            if (openLog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;

                List<Bag> tempList;

                fs = new FileStream(openLog.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                bf = new BinaryFormatter();
                try
                {
                    tempList = (List<Bag>)bf.Deserialize(fs);
                    this.ShowSimulationPanel();
                    if (airport == null)
                    {
                        airport = new Airport(500);
                        airport.CreateMapLayout(5);
                        simulation1.Map_The_Converyors(airport.GetConveyorsList());
                    }
                }
                catch (SerializationException) { MessageBox.Show("Something wrong with serialization"); }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }
    }
}