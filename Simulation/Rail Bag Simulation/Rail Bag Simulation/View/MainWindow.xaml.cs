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

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel.ViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TbBagsWep_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
