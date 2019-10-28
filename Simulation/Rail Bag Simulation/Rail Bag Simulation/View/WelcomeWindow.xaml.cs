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
using Rail_Bag_Simulation.View;

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        
        private ViewModel.ViewModel vm = new ViewModel.ViewModel();
        public WelcomeWindow()
        {
            InitializeComponent();
        }


        private void btnRunSimulation_Click(object sender, RoutedEventArgs e)
        {
            if (tbNrOfBags.Text == "")
            {
                lbNumberofBags.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow mainWindow = new MainWindow(Convert.ToInt32(this.tbNrOfBags.Text));
                LogWindow logWindow = new LogWindow(Convert.ToInt32(this.tbNrOfBags.Text));
           
                this.Close();
                //this.DataContext = mainWindow.
                mainWindow.tbBagsNum.Text = this.tbNrOfBags.Text;
               
                int totalSuspBags = Convert.ToInt32(this.pistol.Text)
                                    + Convert.ToInt32(this.flame.Text)
                                    + Convert.ToInt32(this.cigarette.Text)
                                    + Convert.ToInt32(this.warning.Text);
                mainWindow.tbTotalSuspBags.Text = totalSuspBags.ToString();
                mainWindow.tbBagsWep.Text = this.pistol.Text;
                mainWindow.tbBagsFlam.Text = this.flame.Text;
                mainWindow.tbBagsDrug.Text = this.cigarette.Text;
                mainWindow.tbBagsOther.Text = this.warning.Text;
                mainWindow.Show();
                logWindow.Show();
            }
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
            return int.TryParse(str, out i) && i > 0 && i <= 10000;
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

        private void TbNrOfBags_MouseEnter(object sender, MouseEventArgs e)
        {
            lbNumberofBags.Visibility = Visibility.Hidden;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
