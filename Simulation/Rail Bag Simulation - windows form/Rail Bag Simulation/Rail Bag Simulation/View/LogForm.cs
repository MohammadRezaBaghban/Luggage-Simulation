using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.ViewModel;

namespace Rail_Bag_Simulation.View
{
    public partial class LogForm : Form
    {
        private BindingList<string> _lbLogDataSource;

        public LogForm()
        {
            InitializeComponent();
            var vm = new LoggerControlViewModel();
            var timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0,0,1000)};
            _lbLogDataSource = new BindingList<string>();
            vm.StartSimulation(603);
            lbLog.DataSource = _lbLogDataSource;
            timer.Tick += (sender, args) =>
            { 
                if (LinkedList.IsSimulationFinished) { timer.Stop();}
                UpdateDataSource();
               
            };
            timer.Start();

        }

        private void UpdateDataSource()
        {
            _lbLogDataSource.Clear();
            LinkedList.GetAllNodes()
                .ForEach(p => p.NodeInfo()
                    .ForEach(s => _lbLogDataSource.Add(s)));

            _lbLogDataSource.Add("*** Bags In Storage ***");
            Airport.Storage.GetAllSuspiciousBags().ForEach(
                bag => { _lbLogDataSource.Add(bag.GetBagInfo()); });
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
