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

        public void LoadData()
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



            var desStatstics = SecurityNode.destinationDistribution;
            pieChart2.Series = new SeriesCollection
            {

                new PieSeries
                {

                    Title = $"{desStatstics.Keys.ElementAt(0).ToString()}",
                    Values = new ChartValues<double> { desStatstics.Values.ElementAt(0)}
                },new PieSeries
                {

                    Title = $"{desStatstics.Keys.ElementAt(1).ToString()}",
                    Values = new ChartValues<double> { desStatstics.Values.ElementAt(1)}
                }, new PieSeries
                {

                    Title = $"{desStatstics.Keys.ElementAt(2).ToString()}",
                    Values = new ChartValues<double> { desStatstics.Values.ElementAt(2) }
                },new PieSeries
                {

                    Title = $"{desStatstics.Keys.ElementAt(3).ToString()}",
                    Values = new ChartValues<double> { desStatstics.Values.ElementAt(3) }
                }
            };

            pieChart2.LegendLocation = LegendLocation.Right;


            dataGridDestinationSuspicousBagsCategory.Visible = true;



            // Start of the DataGrid
            dataGridDestinationSuspicousBagsCategory.AutoResizeColumns();
            dataGridDestinationSuspicousBagsCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataTable dt2 = new DataTable();
            dataGridDestinationSuspicousBagsCategory.DataSource = dt2;
            dt2.Columns.Add("Destination");
            dt2.Columns.Add("Category");
            dt2.Columns.Add("# Suspicious Bags");

            // TO DO : Make the fields in the data grid clickable and see other rows

            foreach (var i in SecurityNode.getDicDestinationBag())
            {
                var dataRow = dt2.Rows.Add(new object[] { i.Key });
                foreach (var i1 in i.Value)
                {
                    var dataRow1 = dt2.Rows.Add(new object[] { null, i1.Key, i1.Value });

                }
            }

        }

        
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
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
            
        }
    }
}