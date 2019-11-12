using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Rail_Bag_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel.ViewModel vm;

        private int totalnbrbags;
        private int control, control2 = 0;
        private Node checker = null;
        private bool notnull = false;
        DispatcherTimer dispatcherTimer;

        public MainWindow(/*int nodes*/)
        {
            InitializeComponent();
            //totalnbrbags = nodes;
            //vm = new ViewModel.ViewModel();
            //vm.StartSimulation(totalnbrbags);
            //dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += dispatcherTimer_Tick;
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //dispatcherTimer.Start();

            /*vm.GetEverythingInTheLinkedList().ForEach(p =>
            {
                lock (p)
                {
                    this.Dispatcher?.Invoke(() =>
                    {
                        if (p is CheckinNode ch)
                        {
                            canvas.Children.Add(ch.image);
                            Canvas.SetTop(ch.image, ch.Top);
                            Canvas.SetLeft(ch.image, ch.Left);
                            int total = 0;
                            foreach (Bag bag in ch.BagsQueue)
                            {
                                total += 50;
                                bag.HitboxCanvas = new Canvas
                                {
                                    Name = "t1"
                                };

                                var f = new Image
                                {
                                    Width = 40,
                                    Height = 40,
                                    HorizontalAlignment = HorizontalAlignment.Left,
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Source = new BitmapImage(new Uri("../Resources/luggage.png", UriKind.Relative))
                                };
                                Canvas.SetTop(f, 0);
                                Canvas.SetLeft(f, 0);
                                bag.HitboxCanvas.Children.Add(f);
                                canvas.Children.Add(bag.HitboxCanvas);
                                Canvas.SetTop(bag.HitboxCanvas, ch.Top + 130 + total);
                                Canvas.SetLeft(bag.HitboxCanvas, ch.Left + 100);
                                Canvas.SetZIndex(bag.HitboxCanvas, 6);
                            }
                        }

                        if (p is ConveyorNode con)
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

                        if (p is BagSortNode bs)
                        {
                            canvas.Children.Add(bs.image);
                            Canvas.SetTop(bs.image, bs.Top);
                            Canvas.SetLeft(bs.image, bs.Left);
                            Canvas.SetZIndex(bs.image, 3);
                        }

                        if (p is SecurityNode sn)
                        {
                            canvas.Children.Add(sn.image);
                            Canvas.SetTop(sn.image, sn.Top);
                            Canvas.SetLeft(sn.image, sn.Left);
                            Canvas.SetZIndex(sn.image, 4);
                        }

                        if (p is TerminalNode tm)
                        {
                            canvas.Children.Add(tm.image);
                            Canvas.SetTop(tm.image, tm.Top);
                            Canvas.SetLeft(tm.image, tm.Left);
                            Canvas.SetZIndex(tm.image, 5);
                        }

                        if (p is GateNode gn)
                        {
                            canvas.Children.Add(gn.image);
                            Canvas.SetTop(gn.image, gn.Top);
                            Canvas.SetLeft(gn.image, gn.Left);
                            Canvas.SetZIndex(gn.image, 5);
                        }
                    });
                }
            });*/
            
        }

        public ViewModel.ViewModel Vm => vm;

        private void moveBag(Node s, Bag se, int x, int y)
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

        private void ButtonOpenMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
    }
}
