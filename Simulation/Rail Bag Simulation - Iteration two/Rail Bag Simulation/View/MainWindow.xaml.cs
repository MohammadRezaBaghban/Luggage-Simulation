using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int nodes)
        {
            Vm = new ViewModel.ViewModel();
            Vm.StartSimulation(nodes);

            InitializeComponent();
           
            Thread.Sleep(2000);
          
        }

        public ViewModel.ViewModel Vm { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            // this.bag.Margin = new Thickness(0, 25, 25, 25);

        }
    }
}
