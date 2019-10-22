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
        LinkedList ll;
        public MainWindow()
        {
            //ll = new LinkedList();
            //ll.AddNode(new Conveyorbelt());
        
            //ll.AddNode(new Conveyorbelt());
         
            //ll.AddNode(new Conveyorbelt());
        
            //ll.AddNode(new Conveyorbelt());

            //ll.AddNode(new Conveyorbelt());

            //ll.AddNode(new Conveyorbelt());

            InitializeComponent();
            //Node current = ll.First;
         

            //foreach (Bag s in Bag.GenerateBag(7, 0, 0, 0, 0))
            //{
            //    ll.AddGeneratedBag(s);
            //}
            //while (current != null)
            //{
            //listBox1.Items.Add(current.Nodeinfo());

            //    current = current.Next;
            //}
        }

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    ll.MoveBags();
        //    Node current = ll.First;
        //    while (current != null)
        //    {
        //        listBox1.Items.Add(current.Nodeinfo());

        //        current = current.Next;
        //    }
        //}
    }
}
