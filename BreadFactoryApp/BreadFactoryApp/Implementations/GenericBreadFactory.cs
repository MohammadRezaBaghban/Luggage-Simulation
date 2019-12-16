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
        private readonly int _countOfNeededLoaf;
        private int _countOfLoafsDone = 0 ;

        Timer _timerFlour=new Timer(6000);
        Timer _timerPackage=new Timer(4000);
        Timer _timerLabel=new Timer(2000);

        private int _countOfFlourDone = 0;
        private int _countOfLabelsDone = 0;
        private int _countOfPackagesDone = 0;
        
        private readonly Queue<BreadLoaf> _loafs;
        private readonly Stack<IFlour> _flours;
        private readonly Stack<IPackage> _packages;
        private readonly Stack<ILabel> _labels;

        public static EventHandler<FlourEventArgs> FlourStatusChanged;
        public static EventHandler<PackagesEventArgs> PackageStatusChanged;
        public static EventHandler<LabelEventArgs> LabelStatusChanged;
        public static EventHandler<LoafsEventArgs> LoafsUpdated;

        public GenericBreadFactory(IBreadFactory factory, int countOfNeededLoaf)
        {
            this.factory = factory; 

            _loafs= new Queue<BreadLoaf>();
            _flours = new Stack<IFlour>();
            _labels = new Stack<ILabel>();
            _packages = new Stack<IPackage>();

            
            _countOfNeededLoaf = countOfNeededLoaf;

            _timerFlour.Elapsed += (sender, args) =>
            {
                if (ManufacturingComplete || _countOfFlourDone == _countOfNeededLoaf) { _timerFlour.Stop(); return; }
                DoFlour();
            };


            _timerPackage.Elapsed += (sender, args) =>
            {
                if(_countOfPackagesDone == _countOfNeededLoaf||ManufacturingComplete  ) {_timerPackage.Stop(); return;}

                DoPackage();
            };


            _timerLabel.Elapsed += (sender, args) =>
            {
                if(ManufacturingComplete || _countOfLabelsDone== _countOfNeededLoaf) {_timerLabel.Stop(); return;}
                
                DoLabel();
                Thread.Sleep(2000);
            };

            
        }

        private void DoPackage()
        {
            var package = factory.CreatePackage();

            package.Pack();
            PackageStatusChanged?.Invoke(this, new PackagesEventArgs(package));
            Thread.Sleep(2000);

            package.Seal();
            _countOfPackagesDone++;
            _packages.Push(package);
            PackageStatusChanged?.Invoke(this, new PackagesEventArgs(package));


        }

        private void DoLabel()
        {
            var label = factory.CreateLabel();
            label.PrintIngredients();
            label.PrintExpiryDate();
            label.PrintCertification();
            _countOfLabelsDone++;
            _labels.Push(label);
            LabelStatusChanged?.Invoke(this, new LabelEventArgs(label));

        }

        private void DoFlour()
        {
            var bakingFlour = factory.CreateBakingFlour();

            bakingFlour.Prepare();
            FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
            Thread.Sleep(500);

            bakingFlour.Mix();
            FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
            Thread.Sleep(1000);


            bakingFlour.Freeze();
            FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
            Thread.Sleep(1000);


            bakingFlour.UnFreeze();
            FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
            Thread.Sleep(1000);

            bakingFlour.Bake();
            FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));
            Thread.Sleep(2000);

            bakingFlour.Slice();

            _flours.Push(bakingFlour);
            _countOfFlourDone++;
            FlourStatusChanged?.Invoke(this, new FlourEventArgs(bakingFlour));

        }


        public Queue<BreadLoaf> Loafs => _loafs;

        public void StartManufacturing()
        {
            if (_countOfNeededLoaf == 1)
            {
                DoFlour();
                DoLabel();
                DoPackage();
                DoLoaf();

                return;
            }

            _timerFlour.Start();
            _timerPackage.Start();
            _timerLabel.Start();
            while (!ManufacturingComplete)
            {
                if (_labels.Count > 0 && _flours.Count > 0 && _packages.Count > 0)
                {
                    DoLoaf();
                }

                if (_countOfLoafsDone >= _countOfNeededLoaf)
                {
                    StopManufacturing();
                    ManufacturingComplete = true;
                }
            }
        }

        private void DoLoaf()
        {
            var loaf = new BreadLoaf();
            loaf.setLabel(_labels.Pop());
            loaf.setPackage(_packages.Pop());
            loaf.setFlour(_flours.Pop());
            _loafs.Enqueue(loaf);
            _countOfLoafsDone++;

            LoafsUpdated?.Invoke(this, new LoafsEventArgs(loaf));
        }

        public void StopManufacturing()
        {
            
            _timerPackage.Stop();
            _timerLabel.Stop();
            _timerFlour.Stop();
            ManufacturingComplete = true;
        }
    }
}
