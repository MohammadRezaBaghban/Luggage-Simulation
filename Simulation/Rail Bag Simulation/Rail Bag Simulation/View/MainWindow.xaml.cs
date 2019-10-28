using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
        private delegate void Bagmover(Canvas s ,object sender, EventArgs e);
        private  Bagmover bagEventHandler;
        private int totalnmbags;
        private double x,y;
        private DispatcherTimer timer;

        private List<Node> tmpNodes;
        
        public MainWindow( int nodes)
        {
           // totalnmbags = nodes;
           //vm = new ViewModel.ViewModel();
           //vm.StartSimulation(totalnmbags);
           // InitializeComponent();
           // timer = new DispatcherTimer();
            

           //vm.GetEverythingInTheLinkedList().ForEach(p =>
           //{
           //    if (p is CheckinNode ch)
           //    {
           //        canvas.Children.Add(ch.image);
           //        Canvas.SetTop(ch.image, ch.Top);
           //        Canvas.SetLeft(ch.image, ch.Left);
           //        foreach (Bag bag in ch._bagsQueue)
           //        {
           //            bag.HitboxCanvas = new Canvas
           //            {
           //                Name = "t1"
           //            };
           //            Image f = new Image
           //            {
           //                Width = 40,
           //                Height = 40,
           //                HorizontalAlignment = HorizontalAlignment.Left,
           //                VerticalAlignment = VerticalAlignment.Center,
           //                Source = new BitmapImage(new Uri("../Resources/luggage.png", UriKind.Relative))

           //            };
           //            Canvas.SetTop(f, 0);
           //            Canvas.SetLeft(f, 0);
           //            bag.HitboxCanvas.Children.Add(f);
           //            canvas.Children.Add(bag.HitboxCanvas);
           //            Canvas.SetTop(bag.HitboxCanvas, ch.Top);
           //            Canvas.SetLeft(bag.HitboxCanvas, ch.Left);
           //        }
           //    }
           //    if (p is ConveyorNode con)
           //    {
           //       con.MovingHandler+= new ConveyorNode.IsMove(moveBag);
           //        canvas.Children.Add(con.conveyorline);
           //        Canvas.SetTop(con.conveyorline, con.Top);
           //        Canvas.SetLeft(con.conveyorline, con.Left);
           //    }
           //    if (p is BagSortNode bs)
           //    {
           //        canvas.Children.Add(bs.image);
           //        Canvas.SetTop(bs.image, bs.Top);
           //        Canvas.SetLeft(bs.image, bs.Left);
           //    }
           //    if (p is SecurityNode sn)
           //    {
           //        canvas.Children.Add(sn.image);
           //        Canvas.SetTop(sn.image, sn.Top);
           //        Canvas.SetLeft(sn.image, sn.Left);
           //    }
           //    if (p is TerminalNode tm)
           //    {
           //        canvas.Children.Add(tm.image);
           //        Canvas.SetTop(tm.image, tm.Top);
           //        Canvas.SetLeft(tm.image, tm.Left);
           //    }
           //    if (p is GateNode gn)
           //    {
           //        canvas.Children.Add(gn.image);
           //        Canvas.SetTop(gn.image, gn.Top);
           //        Canvas.SetLeft(gn.image, gn.Left);
           //    }
           //});

          
            InitializeComponent();
        }
      
        private void moveBag(Bag se,int x, int y)
        {
            int movex = x;
            int movey = y;
           
            timer.Tick += (s, e) =>
            {
                Canvas.SetLeft(se.HitboxCanvas, x += 1);
                if (y != 0)
                {
                    Canvas.SetTop(se.HitboxCanvas, y++);
                }
            };
        

        }

        public void ShowBags()
        {
            tmpNodes = vm?.GetEverythingInTheLinkedList();
            DispatcherTimer dispatcher = new DispatcherTimer();

            tmpNodes.ForEach(node =>
                    {
                        if (node is GateNode checkinNode)
                        {

                            foreach (Bag g in checkinNode.ListOfBags)
                            {
                                
                                
                                
                                
                                dispatcher.Tick += (sender, e) =>
                                {
                                    
                                       
                                            Canvas.SetLeft(g.HitboxCanvas, y += 4);
                                        
                                    
                                };
                                dispatcher.Interval = new TimeSpan(0, 0, 0, 2);
                                dispatcher.Start();

                             

                            }
                        }
                    });
                
                


        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TbBagsWep_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ViewModel.ll.MoveBags(totalnmbags);
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            // this.bag.Margin = new Thickness(0, 25, 25, 25);

        }
    }
}
