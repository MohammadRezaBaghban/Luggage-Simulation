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
        private readonly int CountOfLoafsDone = 0 ;

        Timer _timerFlour=new Timer(10000);
        Timer _timerPackage=new Timer(7000);
        Timer _timerLabel=new Timer(5000);

        
        private List<BreadLoaf> Loafs;

        public static EventHandler<FlourEventArgs> FlourStatusChanged;
        public static EventHandler<PackagesEventArgs> PackageStatusChanged;
        public static EventHandler<LabelEventArgs> LabelStatusChanged;

        public GenericBreadFactory(IBreadFactory factory, int countOfNeededLoaf)
        {
            this.factory = factory; 
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

            };



            
            _timerPackage.Elapsed += (sender, args) => { };
            
            
            
            
            _timerLabel.Elapsed += (sender, args) => { };
        }

        public void StartManufacturing()
        {
          _timerPackage.Start();
          _timerFlour.Start();
          _timerLabel.Start();
        }
    }

    internal class FlourEventArgs:EventArgs
    {
        private IFlour flour;

        public FlourEventArgs(IFlour flour)
        {
            this.flour = flour;
        }

        public IFlour Flour => flour;
    }

    internal class PackagesEventArgs : EventArgs
    {
        private IPackage package;

        public PackagesEventArgs(IPackage package)
        {
            this.package = package;
        }

        public IPackage Package => package;
    }

    internal class LabelEventArgs : EventArgs
    {
        private ILabel label;

        public LabelEventArgs(ILabel Label)
        {
            this.label = Label;
        }

        public ILabel Label => label;
    }
}
