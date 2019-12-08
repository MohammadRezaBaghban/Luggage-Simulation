using System;
using System.Windows.Forms;
using LiveCharts; 
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Threading;
using System.Data;
using System.Linq;

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

            pieChart1.LegendLocation = LegendLocation.Right;
            Thread.Sleep(1000);

            // Start of the DataGrid
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            dt.Columns.Add("Percentile #.");
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
            return (double)Storage.GetNumberOfBagsInStorage();
        }
    }
}