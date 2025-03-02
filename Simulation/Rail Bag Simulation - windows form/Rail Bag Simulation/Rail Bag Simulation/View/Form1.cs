﻿using System;
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
        Color darkColor = Color.FromArgb(95, 108, 140);
        Color normalColor = Color.FromArgb(105, 119, 155);
        private string whatiwant;
        public Airport airport;
        private int totalDestination = 100;
        bool desitnationPaneShown = false;

        public Form1()
        {
            
            InitializeComponent();
            this.ActiveControl = tb_numberOfBags;
            tb_numberOfBags.Focus();
            whatiwant = "Map2";
            btnConfigurations.BackColor = this.darkColor;
            btnSimulation.BackColor = this.normalColor;
            btnStatistics.BackColor = this.normalColor;
            pbConfigurations.BackColor = this.darkColor;
            pbSimulation.BackColor = this.normalColor;
            pbStatistics.BackColor = this.normalColor;
            btnRunSimulation.Enabled = false;
            numericUpDown1.Maximum = totalDestination;
            numericUpDown2.Maximum = totalDestination;
            numericUpDown3.Maximum = totalDestination;
            numericUpDown4.Maximum = totalDestination;
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
            simulation2.Visible = false;
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
            if(whatiwant == "Map1")
            simulation1.Visible = true;

            if (whatiwant == "Map2")
            simulation2.Visible = true;
            ClearConfigurationData();
        }

        private void BtnStatistics_Click(object sender, System.EventArgs e)
        {
            simulation1.Visible = false;
            simulation2.Visible = false;
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
            simulation2.Visible = false;
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
            simulation2.Visible = false;
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
            var total = tb_numberOfBags.Text;


            try
            {
                var nbrOfBags = Convert.ToInt32(total);
                int nbrOfBagsDrugs = Convert.ToInt32(drugs);
                int nbrOfBagsWeapons = Convert.ToInt32(weapons);
                var nbrOfBagsFlammable = Convert.ToInt32(flammables);
                var nbrBagsOthers = Convert.ToInt32(others);

                var destination1 = (int)numericUpDown1.Value;
                var destination2 = (int)numericUpDown2.Value;
                var destination3 = (int)numericUpDown3.Value;
                var destination4 = (int)numericUpDown4.Value;
                var sumOfPercentages = destination1 + destination2 + destination3 + destination4;
                if (sumOfPercentages > 100)
                {
                    MessageBox.Show("The sum of percentages can not be MORE than 100%\n" +
                        "Please Refine your inputs more percisely");
                }
                else if (sumOfPercentages < 100)
                {
                    MessageBox.Show("The sum of percentages can not LESS than 100%\n" +
                        "Please Refine your inputs more percisely");
                }
                else if (sumOfPercentages==100)
                {
                    if (whatiwant == "Map1")
                    {


                        simulation1.Map_The_Converyors(airport.GetConveyorsList());
                        ShowSimulationPanel();
                    }
                    else if (whatiwant == "Map2")
                    {


                        simulation2.Map_The_Converyors(airport.GetConveyorsList());

                        ShowSimulation2Panel();
                    }

                    if (drugs == "" || weapons == "" || flammables == "" || others == "")
                    {
                        //
                        // To be added
                        //airport.StartBagsMovement(    nbrOfBags, 0, 0, 0, 0, new Dictionary<string, int>());
                    }
                    else
                    {


                        airport.StartBagsMovement(
                        nbrOfBags,
                        nbrOfBagsDrugs,
                        nbrOfBagsWeapons,
                        nbrOfBagsFlammable,
                        nbrBagsOthers,
                        //
                        //Please implement this so that it takes for each gate the number of bags in precentage
                        //e.g ==> the code below, this has to be changed to allow user to select how many percentage
                        //the keys must be obtained From the airport Static Destinations list then allowing the user
                        //to select from them.
                        new Dictionary<string, int>() { { "T1-G1", destination1 }, { "T1-G2", destination2 }, { "T2-G1", destination3 }, { "T2-G2", destination4 } });



                        //throw new NotImplementedException("needs to take the input of the user");
                    }
                }
               
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Please Check All the inputs to be filled correctly");
            }
            
           

            //Dictionary<string, Destination> myDict = airport.DestinationWithGate;
            //List<Destination> l = new List<Destination>(myDict.Values);

            //lbDestination.Text += l[0];
            //lbDestination2.Text += l[1];
            //lbDestination3.Text += l[2];
            //lbDestination4.Text += l[3];



        }
           
        private void ShowSimulationPanel()
        {
            palenlConfigurations.Visible = false;
            simulation1.Visible = true;
            
            panelBorder.Visible = false;
            simulation2.Visible = false;
            panelBorder1.Visible = false;
        }
        private void ShowSimulation2Panel()
        {
            palenlConfigurations.Visible = false;
           simulation2.Visible = true;
           
            panelBorder.Visible = false;
            simulation1.Visible = false;
            panelBorder1.Visible = false;
            simulation2.BringToFront();
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
                catch (ArgumentNullException) { MessageBox.Show("Please Run the simulation First"); }
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
                        
                       airport = new Airport(1200);
                        airport.CreateMapLayout(5);
                        simulation1.Map_The_Converyors(airport.GetConveyorsList());
                        airport.StartBagsMovement(tempList);
                    }
                    listBox1.Items.Add($"{openLog.FileName} has been loaded succcessfully");
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

        private void Map2_Click(object sender, EventArgs e)
        {
            whatiwant = "Map2";
            RbMultipleCheckIn.Checked = true;
            btnRunSimulation.Enabled = true;
        }

        private void Map1_Click(object sender, EventArgs e)
        {
            whatiwant = "Map1";
            btnRunSimulation.Enabled = true;
            RbSingleCheckIn.Checked = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CheckNumericUAndDown();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CheckNumericUAndDown();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            CheckNumericUAndDown();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            CheckNumericUAndDown();
        }

        private void CheckNumericUAndDown()
        {
            /*
            numericUpDown1.Maximum = totalDestination - (numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value);
            numericUpDown2.Maximum = totalDestination - (numericUpDown1.Value + numericUpDown3.Value + numericUpDown4.Value);
            numericUpDown3.Maximum = totalDestination - (numericUpDown1.Value + numericUpDown2.Value + numericUpDown4.Value);
            numericUpDown4.Maximum = totalDestination - (numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value);
            */
        }

        private void tb_nrOfCarts_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShowDestination_Click(object sender, EventArgs e)
        {
            if(RbMultipleCheckIn.Checked || RbSingleCheckIn.Checked)
            {
                var drugs = tb_drugs.Text;
                var weapons = tb_weapons.Text;
                var flammables = tb_flammables.Text;
                var others = tb_Others.Text;
                var total = tb_numberOfBags.Text;

                if (drugs == "" || weapons == "" || flammables == "" || others == "")
                {
                    drugs = "0";
                    weapons = "0";
                    flammables = "0";
                    others = "0";
                }

                if (string.IsNullOrEmpty(total))
                {
                    errorProvider.SetError(tb_numberOfBags, "Please fill the number of bags.");
                }
                else
                {
                    var carts = tb_nrOfCarts.Text;
                    if (string.IsNullOrEmpty(carts))
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
                        if (nbrOfBags < nbrOfBagsDrugs + nbrOfBagsWeapons + nbrOfBagsFlammable + nbrBagsOthers)
                        {
                            MessageBox.Show("The number of suspecios bags cannot be more than the total number of bags.");
                            ClearConfigurationData();
                        }
                        else
                        {
                            btnSaveSimulation.Visible = true;
                            //ShowSimulationPanel();

                            var nbrCarts = Convert.ToInt32(carts);
                            if (nbrCarts > 1000)
                            {
                                nbrCarts = 200;
                            }
                            else if (nbrCarts > 750)
                            {
                                nbrCarts = 400;
                            }
                            else if (nbrCarts > 500)
                            {
                                nbrCarts = 600;
                            }
                            else if (nbrCarts > 250)
                            {
                                nbrCarts = 750;
                            }
                            else
                            {
                                nbrCarts = 900;
                            }


                            airport = new Airport(nbrCarts);

                            if (whatiwant == "Map1")
                            {
                                airport.CreateMapLayout(5);
                            }
                            else if (whatiwant == "Map2")
                            {
                                airport.CreateMapLayoutTwo(5);
                            }

                            Dictionary<string, Destination> myDict = airport.DestinationWithGate;
                            List<Destination> l = new List<Destination>(myDict.Values);
                            if (!desitnationPaneShown)
                            {
                                lbDestination.Text += l[0];
                                lbDestination2.Text += l[1];
                                lbDestination3.Text += l[2];
                                lbDestination4.Text += l[3];
                            }
                            desitnationPaneShown = true;

                            lbDestinatinInfo.Visible = true;
                            numericUpDown1.Visible = true;
                            numericUpDown2.Visible = true;
                            numericUpDown3.Visible = true;
                            numericUpDown4.Visible = true;
                            lbDestinatinInfo.Visible = true;
                            lbDestination.Visible = true;
                            lbDestination2.Visible = true;
                            lbDestination3.Visible = true;
                            lbDestination4.Visible = true;
                            Map1.Visible = true;
                            Map2.Visible = true;
                            btnRunSimulation.Visible = true;

                        }
                    }


                }
            }
            else
            {
                MessageBox.Show("Please Select one of the CheckIn Mode");
            }

        }

      

        private void RbSingleCheckIn_CheckedChanged_1(object sender, EventArgs e)
        {
            whatiwant = "Map1";
            btnRunSimulation.Enabled = true;

        }

        private void RbMultipleCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            whatiwant = "Map2";
            btnRunSimulation.Enabled = true;

        }
    }
}