using System;
using System.Windows.Forms;
using Rail_Bag_Simulation.View;
using Rail_Bag_Simulation.View.UserControls;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel;

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
            this.ActiveControl = tb_numberOfBags;
            tb_numberOfBags.Focus();

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
            btnSaveSimulation.Visible = false;
            ClearConfigurationData();
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
            btnSaveSimulation.Visible = true;
            ClearConfigurationData();
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
            btnSaveSimulation.Visible = false;
            ClearConfigurationData();
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
            btnSaveSimulation.Visible = false;
        }

        private void PbSimulation_Click(object sender, System.EventArgs e)
        {
            btnSaveSimulation.Visible = true;
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
            btnSaveSimulation.Visible = false;
        }

        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            var drugs = tb_drugs.Text;
            var weapons = tb_weapons.Text;
            var flammables = tb_flammables.Text;
            var others = tb_Others.Text;
            if (drugs == "" || weapons == "" || flammables == "" || others == "")
            {
                drugs = "0";
                weapons = "0";
                flammables = "0";
                others = "0";
            }

            var total = tb_numberOfBags.Text;
            if (string.IsNullOrEmpty(total))
            {
                errorProvider.SetError(tb_numberOfBags, "Please fill the number of bags.");
            }
            else
            {
                var carts = tb_nrOfCarts.Text;
                if(string.IsNullOrEmpty(carts))
                {
                    errorProvider.SetError(tb_nrOfCarts, "Please fill the number of cards");
                }
                else
                {
                    var nbrOfBags = Convert.ToInt32(total);
                    int nbrOfBagsDrugs = Convert.ToInt32(drugs);
                    int nbrOfBagsWeapons = Convert.ToInt32(weapons);
                    var nbrOfBagsFlammable = Convert.ToInt32(flammables);
                    var nbrBagsOthers = Convert.ToInt32(others);
                    if(nbrOfBags < nbrOfBagsDrugs + nbrOfBagsWeapons + nbrOfBagsFlammable + nbrBagsOthers)
                    {
                        MessageBox.Show("The number of suspecios bags cannot be more than the total number of bags.");
                        ClearConfigurationData();
                    }
                    else
                    {
                        btnSaveSimulation.Visible = true;
                        ShowSimulationPanel();


                        var nbrCarts = Convert.ToInt32(carts);
                        if (nbrCarts > 1000)
                        {
                            nbrCarts = 200;
                        }
                        else if(nbrCarts>750)
                        {
                            nbrCarts = 400;
                        }
                        else if (nbrCarts > 500)
                        {
                            nbrCarts = 600;
                        }
                        else if (nbrCarts > 250)
                        {
                            nbrCarts =750;
                        }
                        else
                        {
                            nbrCarts = 900;
                        }

                        
                        airport = new Airport(1000);
                        airport.CreateMapLayout(5);

                        simulation1.Map_The_Converyors(airport.GetConveyorsList());

                        if (drugs == "" || weapons == "" || flammables == "" || others == "")
                        {
                            airport.StartBagsMovement(
                                nbrOfBags, 0, 0, 0, 0);
                        }
                        else
                        {
                            airport.StartBagsMovement(
                                nbrOfBags,
                                nbrOfBagsDrugs,
                                nbrOfBagsWeapons,
                                nbrOfBagsFlammable,
                                nbrBagsOthers);
                        }

                        btnSimulation.BackColor = this.darkColor;
                        btnConfigurations.BackColor = this.normalColor;
                        btnStatistics.BackColor = this.normalColor;
                        pbSimulation.BackColor = this.darkColor;
                        pbConfigurations.BackColor = this.normalColor;
                        pbStatistics.BackColor = this.normalColor;
                    }
                }
            }
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



        private void Tb_nrOfCarts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Tb_flammables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Tb_weapons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Tb_drugs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Tb_Others_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Tb_numberOfBags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void ClearConfigurationData()
        {
            errorProvider.Dispose();
            tb_numberOfBags.Clear();
            tb_nrOfCarts.Clear();
            tb_flammables.Clear();
            tb_Others.Clear();
            tb_weapons.Clear();
            tb_drugs.Clear();
        }
    }
}