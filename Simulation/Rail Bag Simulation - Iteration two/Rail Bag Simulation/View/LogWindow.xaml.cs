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

        private int bagsnr;
        
        private DispatcherTimer dispatcherTimer;
        public LogWindow(int bags)
        {
            
            dispatcherTimer = new DispatcherTimer();
   
            bagsnr = bags;
      
            InitializeComponent();
          

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,500);
            dispatcherTimer.Start();
            
            
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           
            if (!LinkedList.IsSimulationFinished)
            {

                listBox1.Items.Clear();
                ViewModel.ViewModel.LL.GetAllNodes().ForEach(p => listBox1.Items.Add(p.Nodeinfo()));
                listBox1.Items.Add("** Bags In Storage ***");
                Airport.Storage.GetAllSuspiciousBags().ForEach(
                    bag => { listBox1.Items.Add(bag.GetBagInfo()); });
            }
            else
            {
              
                dispatcherTimer.Stop();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
