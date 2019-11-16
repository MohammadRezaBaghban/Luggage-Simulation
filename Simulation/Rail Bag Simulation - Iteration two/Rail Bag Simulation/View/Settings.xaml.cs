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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rail_Bag_Simulation.ViewModel;
using Rail_Bag_Simulation.View;

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        
        public Settings()
        {
          
            InitializeComponent();
        }

        private void BtnStartSimulation_OnClick(object sender, RoutedEventArgs e)
        {
            if (tbNrOfBags.Text == null)
            {
                lbNumberofBags.Visibility = Visibility.Visible;
            }
            else
            {
               
                MainWindow.vm.StartSimulation(MainWindow.vm.NumberOfBags);
                LogWindow logWindow = new LogWindow(Convert.ToInt32(this.tbNrOfBags.Text));
                logWindow.Show();
                mainGrid.Visibility = Visibility.Hidden;

            }
        }

    }
}
