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
        public LogWindow(int bags)
        {
            vm = new ViewModel.ViewModel();
            
   
            bagsnr = bags;
            vm.StartSimulation(bagsnr);
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
           
            
                ViewModel.ViewModel.ll.GetAllNodes().ForEach(p=>
                    listBox1.Items.Add(p.Nodeinfo()));
            
            
        }
        private void moveBag(Bag s, int x, int y)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
          
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            vm.airport._ll.MoveBags(bagsnr);
            vm.GetEverythingInTheLinkedList().ForEach(p=>
                listBox1.Items.Add(p.Nodeinfo()));
        }
    }
}
