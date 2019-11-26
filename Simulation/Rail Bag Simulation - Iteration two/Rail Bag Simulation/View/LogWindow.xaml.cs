using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Rail_Bag_Simulation.ViewModel;

namespace Rail_Bag_Simulation.View
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        private readonly DispatcherTimer dispatcherTimer;

        public LogWindow(int bags)
        {
            dispatcherTimer = new DispatcherTimer();
            InitializeComponent();
            var vm = new ViewModel.ViewModel();
            vm.StartSimulation(vm.NumberOfBags);
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,500);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!LinkedList.IsSimulationFinished)
            {
                listBox1.Items.Clear();
                LinkedList.GetAllNodes().ForEach(p => listBox1.Items.Add(p.NodeInfo()));
                listBox1.Items.Add("** Bags In Storage ***");
                Airport.Storage.GetAllSuspiciousBags().ForEach(
                    bag => { listBox1.Items.Add(bag.GetBagInfo()); });
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }
    }
}
