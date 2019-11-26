using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation.ViewModel
{
    class LoggerControlViewModel
    {
        private string name;
        public static int numberOfBags;
        private int nrOfSusBagsGuns;
        private int nrOfSusBagsDrugs;
        private int nrOfSusBagsFlamable;
        private int nrOfSusBagsOthers;


        private static Airport _airport;
        public static LinkedList LL => _airport.LL;


        public void StartSimulation(int totalbags
        )
        {
            numberOfBags = totalbags;
            _airport = new Airport("Schiphol");
            CreateMap(5);
            _airport.StartBagsMovement(totalbags, 3, 1, 0, 0);
            _airport.LL.MoveBags();

        }

        public void CreateMap(int m)
        {
            _airport.CreateMapLayout(m);
        }

        public static Airport Airport => _airport;

    }
}
