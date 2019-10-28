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


namespace Rail_Bag_Simulation.View
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {

        private int bagsnr;

        public LogWindow(int bags)
        {
 
            bagsnr = bags;
            InitializeComponent();




            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(500);
               
                    ViewModel.ViewModel.ll.GetAllNodes().ForEach(p => { listBox1.Items.Add(p.Nodeinfo()); });
                
            });




        }
        private void moveBag(Bag s, int x, int y)
        {

        }

    }
}
