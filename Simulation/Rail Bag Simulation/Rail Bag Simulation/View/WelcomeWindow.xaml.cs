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
using Rail_Bag_Simulation.ViewModel;

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        private Rail_Bag_Simulation.ViewModel.ViewModel vm = new Rail_Bag_Simulation.ViewModel.ViewModel();
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
            MessageBox.Show(Bag.GenerateBag(13, 2, 2, 0, 1).ToString());

        }

        private void PistolButton_Checked(object sender, RoutedEventArgs e)
        {
            if (vm.IsPossible())
            {
                this.pistol.Visibility = Visibility.Visible;
            }
        }

        private void CigaretteBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (vm.IsPossible())
            {
                this.cigarette.Visibility = Visibility.Visible;
            }
        }

        private void FlameBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (vm.IsPossible())
            {
                this.flame.Visibility = Visibility.Visible;
            }
        }

        private void WarningBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (vm.IsPossible())
            {
                this.warning.Visibility = Visibility.Visible;
            }
        }

        private void WarningBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            this.warning.Visibility = Visibility.Hidden;
        }

        private void FlameBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            this.flame.Visibility = Visibility.Hidden;
        }

        private void CigaretteBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            this.cigarette.Visibility = Visibility.Hidden;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.pistol.Visibility = Visibility.Hidden;
        }

        private void Pistol_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 0 && i <= 50;
        }

        private void Cigarette_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private void Flame_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private void Warning_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
    }
}
