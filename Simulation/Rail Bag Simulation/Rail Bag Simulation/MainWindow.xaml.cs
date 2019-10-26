using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;using System;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       Airport airport = new Airport("Schiphol");
        public MainWindow()
        {
           

            
            InitializeComponent();

            airport.StartBagsMovement(5, 1, 1, 0, 0);
            listBox1.Items.Add(airport.Ll.LinkedListInfo());
            Node.log.ForEach(l => { listBox1.Items.Add(l); });




        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
