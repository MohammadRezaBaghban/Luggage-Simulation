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
        LinkedList ll;
        public MainWindow()
        {
            ll = new LinkedList();
             
            ll.AddNode(new Conveyorbelt(15));
            ll.AddNode(new Conveyorbelt(15));
            ll.AddNode(new Conveyorbelt(15));
            ll.AddNode(new Conveyorbelt(15));
            InitializeComponent();
            Node current = ll.First;
        
            Bag.GenerateBag(15,2,0,0,0).ForEach(b => {ll.AddGeneratedBag(b);});

            while (current != null)
            {

                listBox1.Items.Add(current.Nodeinfo());
                current = current.Next;

            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
