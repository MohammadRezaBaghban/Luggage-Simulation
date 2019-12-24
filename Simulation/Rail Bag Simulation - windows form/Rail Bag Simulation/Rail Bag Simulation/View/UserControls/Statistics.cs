using System;
using System.Windows.Forms;
using LiveCharts; 
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Threading;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Rail_Bag_Simulation.View.UserControls
{
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Successful Bags",
                    Values = new ChartValues<double> {updateChartSuccessfullBags()}
                },
                new PieSeries
                {
                    Title = "Suspicious Bags",
                    Values = new ChartValues<double> {updateChartFailedBags()}
                }
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
            Thread.Sleep(1000);

            // Start of the DataGrid
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            dt.Columns.Add("Percentile Nbr.");
            dt.Columns.Add("Time Taken To Reach Gate Per Second");

            if (!LinkedList.IsSimulationFinished) return;
            for (int i = 0; i < LinkedList.TimelyWatchedBagWithStopWatch.Keys.ToList().Count; i++)
            {
                dt.Rows.Add(new object[]
                    {i, LinkedList.TimelyWatchedBagWithStopWatch.Keys.ToList()[i].ElapsedMilliseconds / 1000});
            }

            dt.Rows.Add(new object[] { "Average", LinkedList.AverageTimePerBag });
          
        }
        private double updateChartSuccessfullBags()
        {
            return (double)GateNode.Counter;
        }
        private double updateChartFailedBags()
        {
            return (double)Storage.GetNumberOfSuspiciousBagsInStorage();
        }

        private List<int> returnDestinationSuspiciousBagsCategory()
        {
            int drugs = 0;
            int flammable = 0;
            int weapons = 0;
            int others = 0;
            List<int> temp = new List<int>();

            foreach (var i in Bag.returnGeneratedBags())
            {
                if (i.SuspiciousBagtype == SuspiciousBagtype.Drug)
                {
                    drugs++;
                    temp.Add(drugs);
                }
                else if (i.SuspiciousBagtype == SuspiciousBagtype.Flammables)
                {
                    flammable++;
                    temp.Add(flammable);
                }
                else if (i.SuspiciousBagtype == SuspiciousBagtype.Weapons)
                {
                    weapons++;
                    temp.Add(weapons);
                }
                else { others++; temp.Add(others); }
            }

            return temp;

        }

        private void btnDestinationSuspiciousBagsCategory_Click(object sender, EventArgs e)
        {
            dataGridDestinationSuspicousBagsCategory.Visible = true;
          


            // Start of the DataGrid
            dataGridDestinationSuspicousBagsCategory.AutoResizeColumns();
            dataGridDestinationSuspicousBagsCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataTable dt = new DataTable();
            dataGridDestinationSuspicousBagsCategory.DataSource = dt;
            dt.Columns.Add("Destination");
            dt.Columns.Add("Category");
            dt.Columns.Add("# Suspicious Bags");

            // TO DO : Make the fields in the data grid clickable and see other rows

            foreach (var i in SecurityNode.getDicDestinationBag())
            {
                var dataRow = dt.Rows.Add(new object[] {i.Key});
                foreach (var i1 in i.Value)
                {
                    var dataRow1 = dt.Rows.Add(new object[] {null,i1.Key, i1.Value});

                }
            }

        }
    }
}