using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.ViewModel;

namespace Rail_Bag_Simulation.View
{
    public partial class LogForm : Form
    {
        private readonly BindingList<string> _lbLogDataSource;

        public LogForm()
        {
            InitializeComponent();
            var vm = new LoggerControlViewModel();
            var timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 1000)};
            _lbLogDataSource = new BindingList<string>();

            vm.StartSimulation(100, 500);
            lbLog.DataSource = _lbLogDataSource;
            timer.Tick += (sender, args) =>
            {
                if (LinkedList.IsSimulationFinished) timer.Stop();
                UpdateDataSource();
            };
            timer.Start();
        }

        private void UpdateDataSource()
        {
            //_lbLogDataSource.Clear();
            LinkedList.GetAllNodes()
                .ForEach(p => p.NodeInfo()
                    .ForEach(s => _lbLogDataSource.Add(s)));

            _lbLogDataSource.Add("*** Bags In Storage ***");
            Airport.Storage.GetAllSuspiciousBags().ForEach(
                bag => { _lbLogDataSource.Add(bag.GetBagInfo()); });
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}