using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Rail_Bag_Simulation.View
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {

        private int bagsnr;
        private ViewModel.ViewModel vm;
        private DispatcherTimer dispatcherTimer;
        public LogWindow(int bags)
        {
            vm = new ViewModel.ViewModel();
            dispatcherTimer = new DispatcherTimer();
   
            bagsnr = bags;
      
            InitializeComponent();
          

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,500);
            dispatcherTimer.Start();
            
            
            
        }
        private void moveBag(Bag s, int x, int y)
        {

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           
            if (!LinkedList.IsSimulationFinished)
            {
                listBox1.Items.Clear();
                    LinkedList.MoveBags(bagsnr);

                LinkedList.GetAllNodes().ForEach(p =>
                    listBox1.Items.Add(p.Nodeinfo()));
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
