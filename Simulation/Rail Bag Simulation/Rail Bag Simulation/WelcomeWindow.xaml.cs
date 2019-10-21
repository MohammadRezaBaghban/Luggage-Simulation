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

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }


        private void btnRunSimulation_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();

            mainWindow.Show();
        }

        /// <summary>
        /// The back-end guys can debug here :)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebug_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PistolButton_Checked(object sender, RoutedEventArgs e)
        {
            this.pistol.Visibility = Visibility.Visible;
        }

        private void CigaretteBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.cigarette.Visibility = Visibility.Visible;

        }

        private void FlameBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.flame.Visibility = Visibility.Visible;

        }

        private void WarningBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.warning.Visibility = Visibility.Visible;    
        }

        private void WarningBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            this.warning.Visibility = Visibility.Hidden;
        }
    }
}
