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
        private ConveyorNode nd;
        private BagSortNode bg;
        private TerminalNode t;
        private GateNode gr;
        public MainWindow()
        {
            ll = new LinkedList();

            ll.AddNode(new ConveyorNode(new Conveyorbelt(5)));
            ll.AddNode(new ConveyorNode(new Conveyorbelt(5)));
             bg = new BagSortNode();
           ll.AddNode(bg);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, bg);
            t = new TerminalNode(new Terminal("T1"));
            ll.AddNode(t, nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G1"));
            ll.AddNode(gr,nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G2"));
            ll.AddNode(gr, nd);

            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G3"));
            ll.AddNode(gr, nd);

            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, bg);
            t = new TerminalNode(new Terminal("T2"));
            ll.AddNode(t, nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G1"));
            ll.AddNode(gr, nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G2"));
            ll.AddNode(gr, nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G3"));
            ll.AddNode(gr, nd);


            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, bg);
            t = new TerminalNode(new Terminal("T3"));
            ll.AddNode(t, nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G1"));
            ll.AddNode(gr, nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G2"));
            ll.AddNode(gr, nd);
            nd = new ConveyorNode(new Conveyorbelt(5));
            ll.AddNode(nd, t);
            gr = new GateNode(new Gate("G3"));
            ll.AddNode(gr, nd);

            foreach (Bag g in Bag.GenerateBag(10, 0, 0, 0, 0))
            {
               // ll.AddGeneratedBag(g);
            }

            InitializeComponent();


            listBox1.Items.Add(ll.LinkedListInfo());
               

            


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
