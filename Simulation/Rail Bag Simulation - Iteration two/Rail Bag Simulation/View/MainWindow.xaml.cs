using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Rail_Bag_Simulation.ViewModel;
using Rail_Bag_Simulation;

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel.ViewModel vm;
        Settings settings = new Settings(); 

        private int totalnbrbags;
        private int control, control2 = 0;
        private Node checker = null;
        private bool notnull = false;
        DispatcherTimer dispatcherTimer;

        public MainWindow(/*int nodes*/)
        {

            //totalnbrbags = nodes;
            //vm = new ViewModel.ViewModel();
            //vm.StartSimulation(totalnbrbags);


            InitializeComponent();

            //totalnbrbags = nodes;
            //vm = new ViewModel.ViewModel();
            //vm.StartSimulation(totalnbrbags);
            //dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += dispatcherTimer_Tick;
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //dispatcherTimer.Start();

           //vm.GetEverythingInTheLinkedList().ForEach(node =>
           // {
           //     lock (node)
           //     {
           //         this.Dispatcher?.Invoke(() =>
           //         {
           //             if (node is CheckinNode checkinNode)
           //             {
           //                 var image = checkinNode.image;
           //                 canvas.Children.Add(image);
           //                 Canvas.SetTop(image, checkinNode.Top);
           //                 Canvas.SetLeft(image, checkinNode.Left);
                           
           //                 int total = 0;
           //                 foreach (Bag bag in checkinNode.BagsQueue)
           //                 {
           //                     total += 50;
           //                     bag.HitboxCanvas= new Canvas
           //                     {
           //                         Name = "t1"
           //                     };

           //                     var f = new Image
           //                     {
           //                         Width = 40,
           //                         Height = 40,
           //                         HorizontalAlignment = HorizontalAlignment.Left,
           //                         VerticalAlignment = VerticalAlignment.Center,
           //                         Source = new BitmapImage(new Uri("../Resources/luggage.png", UriKind.Relative))
           //                     };
           //                     Canvas.SetTop(f, 0);
           //                     Canvas.SetLeft(f, 0);
           //                     bag.HitboxCanvas.Children.Add(f);
           //                     canvas.Children.Add(bag.HitboxCanvas);
           //                     /*Canvas.SetTop(bag.HitboxCanvas, checkinNode.Top + 130 + total);
           //                     Canvas.SetLeft(bag.HitboxCanvas, checkinNode.Left + 100);
           //                     Canvas.SetZIndex(bag.HitboxCanvas, 6);*/
           //                 }
           //             }

                        /*if (node is ConveyorNode con)
                        {
                            // con.MovingHandler += (moveBag);
                            con.MovingHandler += (s, se, x, y) =>
                            {
                                this.Dispatcher?.Invoke(() =>
                                {
                                    lock (s)
                                    {
                                        lock (se)
                                        {

                                            if (s is GateNode)
                                            {
                                                if (s == checker)
                                                {
                                                    Canvas.SetTop(se.HitboxCanvas, s.Top + 50 + control2);
                                                    Canvas.SetLeft(se.HitboxCanvas, s.Left);
                                                    control2 += 40;
                                                }
                                                else
                                                {
                                                    Canvas.SetTop(se.HitboxCanvas, s.Top + 50 + control);
                                                    Canvas.SetLeft(se.HitboxCanvas, s.Left);
                                                    control += 40;
                                                }

                                                if (notnull == false)
                                                {
                                                    checker = s;
                                                }
                                            }
                                            else
                                            {
                                                Canvas.SetTop(se.HitboxCanvas, s.Top);
                                                Canvas.SetLeft(se.HitboxCanvas, s.Left);
                                            }

                                            if (checker != null)
                                            {
                                                notnull = true;
                                            }
                                        }
                                    }
                                });
                            };
                            canvas.Children.Add(con.conveyorline);
                            Canvas.SetTop(con.conveyorline, con.Top);
                            Canvas.SetLeft(con.conveyorline, con.Left);
                            Canvas.SetZIndex(con.conveyorline, 2);
                        }

                        if (node is BagSortNode bs)
                        {
                            canvas.Children.Add(bs.image);
                            Canvas.SetTop(bs.image, bs.Top);
                            Canvas.SetLeft(bs.image, bs.Left);
                            Canvas.SetZIndex(bs.image, 3);
                        }

                        if (node is SecurityNode sn)
                        {
                            canvas.Children.Add(sn.image);
                            Canvas.SetTop(sn.image, sn.Top);
                            Canvas.SetLeft(sn.image, sn.Left);
                            Canvas.SetZIndex(sn.image, 4);
                        }

                        if (node is TerminalNode tm)
                        {
                            canvas.Children.Add(tm.image);
                            Canvas.SetTop(tm.image, tm.Top);
                            Canvas.SetLeft(tm.image, tm.Left);
                            Canvas.SetZIndex(tm.image, 5);
                        }

                        if (node is GateNode gn)
                        {
                            canvas.Children.Add(gn.image);
                            Canvas.SetTop(gn.image, gn.Top);
                            Canvas.SetLeft(gn.image, gn.Left);
        //                    Canvas.SetZIndex(gn.image, 5);
        //                }*/
        //            });
        //        }

        //    });*/
            

        //    });
        //}

        //public ViewModel.ViewModel Vm => vm;

        //private void MoveBag(Node currentNode, Bag currentBag)
        //{
        //    lock (currentNode)
        //    {
        //        lock (currentBag)
        //        {

        //            if (currentNode is GateNode)
        //            {
        //                if (currentNode == checker)
        //                {
        //                    Canvas.SetTop(currentBag.HitboxCanvas, currentNode.Top + 50 + control2);
        //                    Canvas.SetLeft(currentBag.HitboxCanvas, currentNode.Left);
        //                    control2 += 40;
        //                }
        //                else
        //                {
        //                    Canvas.SetTop(currentBag.HitboxCanvas, currentNode.Top + 50 + control);
        //                    Canvas.SetLeft(currentBag.HitboxCanvas, currentNode.Left);
        //                    control += 40;
        //                }

        //                if (notnull == false)
        //                {
        //                    checker = currentNode;
        //                }
        //            }
        //            else
        //            {
        //                Canvas.SetTop(currentBag.HitboxCanvas, currentNode.Top);
        //                Canvas.SetLeft(currentBag.HitboxCanvas, currentNode.Left);
        //            }

        //            if (checker != null)
        //            {
        //                notnull = true;
        //            }
        //        }
        //    }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
        }

        private void TbBagsWep_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            // this.bag.Margin = new Thickness(0, 25, 25, 25);

        }

        private void ButtonCloseMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ItemHome_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void ItemCreate_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = settings;
        }

        private void ButtonOpenMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
    }
}
