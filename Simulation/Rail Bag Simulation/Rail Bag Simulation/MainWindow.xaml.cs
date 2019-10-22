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
using System.Drawing;
using Color = System.Windows.Media.Color;
using Rectangle = System.Windows.Shapes.Rectangle;

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
            ll.AddNode(new Conveyorbelt());
            ll.AddNode(new Conveyorbelt());
            ll.AddNode(new Conveyorbelt());
            ll.AddNode(new Conveyorbelt());
            InitializeComponent();
            Node current = ll.First;
            int i = 0;
            while (current != null)
            {
                i+=10;
                Rectangle convey = new Rectangle();
           
                convey.Width = 100;
                convey.Height = 50;
                convey.Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray);
      
                convey.SetValue(Grid.RowProperty, i);
                convey.SetValue(Grid.ColumnProperty, 0);
                current = current.Next;

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
