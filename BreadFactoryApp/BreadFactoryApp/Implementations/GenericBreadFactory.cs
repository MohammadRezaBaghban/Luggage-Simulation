using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BreadFactoryApp.Implementations;
using BreadFactoryApp.Interfaces;
using Timer = System.Timers.Timer;

namespace BreadFactoryApp
{
    class GenericBreadFactory
    {
        private IBreadFactory factory;
        private bool ManufacturingComplete;
        private readonly int CountOfNeededLoaf;
        private int CountOfLoafsDone = 0 ;

        Timer _timerFlour=new Timer(10000);
        Timer _timerPackage=new Timer(7000);
        Timer _timerLabel=new Timer(5000);

        
        private Queue<BreadLoaf> Loafs;
        private Stack<IFlour> flours;
        private Stack<IPackage> packages;
        private Stack<ILabel> labels;

        public static EventHandler<FlourEventArgs> FlourStatusChanged;
        public static EventHandler<PackagesEventArgs> PackageStatusChanged;
        public static EventHandler<LabelEventArgs> LabelStatusChanged;

        public GenericBreadFactory(IBreadFactory factory, int countOfNeededLoaf)
        {
            this.factory = factory; 

            Loafs= new Queue<BreadLoaf>();
            flours = new Stack<IFlour>();
            labels = new Stack<ILabel>();
            packages = new Stack<IPackage>();

            CountOfNeededLoaf = countOfNeededLoaf;

            _timerFlour.Elapsed += (sender, args) =>
            {
                var bakingFlour = factory.CreateBakingFlour();

                bakingFlour.Prepare();
                FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
                Thread.Sleep(2000);

                bakingFlour.Mix();
                FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
                Thread.Sleep(2000);


                bakingFlour.Freeze();
                FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
                Thread.Sleep(2000);


                bakingFlour.UnFreeze();
                FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
                Thread.Sleep(2000);

                bakingFlour.Bake();
                FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
                Thread.Sleep(2000);

                bakingFlour.Slice();
                FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
                Thread.Sleep(2000);

                flours.Push(bakingFlour);
                CountOfLoafsDone++;


            };



            
            _timerPackage.Elapsed += (sender, args) =>
            {
                var package = factory.CreatePackage();

                package.Pack();
                PackageStatusChanged?.Invoke(this, new PackagesEventArgs(package));
                Thread.Sleep(2000);

                package.Seal();
                PackageStatusChanged?.Invoke(this, new PackagesEventArgs(package));
                Thread.Sleep(2000);

                packages.Push(package);
                CountOfLoafsDone++;
            };
            
            
            
            
            _timerLabel.Elapsed += (sender, args) =>
            {
                var label = factory.CreateLabel();

                label.PrintIngredients();
                label.PrintExpiryDate();
                label.PrintCertification();
                LabelStatusChanged?.Invoke(this, new LabelEventArgs(label));
                labels.Push(label);
                CountOfLoafsDone++;

                Thread.Sleep(2000);
            };

            Task.Factory.StartNew(() =>
            {
                while (!ManufacturingComplete)
                {
                    if (labels.Count > 0 && flours.Count > 0 & packages.Count > 0)
                    {
                        var loaf= new BreadLoaf();
                        loaf.setLabel(labels.Pop());
                        loaf.setPackage(packages.Pop());
                        loaf.setFlour(flours.Pop());
                        Loafs.Enqueue(loaf);

                        Thread.Sleep(2000);
                    }

                    if (countOfNeededLoaf == CountOfLoafsDone)
                    {
                        ManufacturingComplete = true;
                    }
                }
            });
        }

        public void StartManufacturing()
        {
          _timerPackage.Start();
          _timerFlour.Start();
          _timerLabel.Start();
        }

        public void StopManufacturing()
        {
            _timerPackage.Stop();
            _timerFlour.Stop();
            _timerLabel.Stop();
            ManufacturingComplete = true;
        }   
    }
}
