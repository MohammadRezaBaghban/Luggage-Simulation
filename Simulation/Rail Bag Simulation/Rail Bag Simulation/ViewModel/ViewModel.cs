using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation.ViewModel
{
    public class ViewModel
    {
        private Airport airport = new Airport("Eindhoven");

        public string Name
        {
            get
            {
                return this.airport.Name;
            }
            set
            {
                this.airport.Name = value;
            }
        }

        public int NumberOfBags
        {
            get
            {
                return this.airport.NumberOfBags;
            }
            set
            {
                this.airport.NumberOfBags = value | 0;
            }
        }
        public int NrOfSusBagsGuns
        {
            get
            {
                return this.airport.NrOfSusBagsDrugs;
            }
            set
            {
                this.NrOfSusBagsDrugs = value | 0;
            }
        }
        public int NrOfSusBagsDrugs
        {
            get
            {
                return this.airport.NrOfSusBagsDrugs;
            }
            set
            {
                this.airport.NrOfSusBagsDrugs = value | 0;
            }
        }
        public int NrOfSusBagsFlamable
        {
            get
            {
                return this.airport.NrOfSusBagsFlamable;
            }
            set
            {
                this.airport.NrOfSusBagsFlamable = value | 0;
            }
        }
        public int NrOfSusBagsOthers
        {
            get
            {
                return this.airport.NrOfSusBagsOthers;
            }
            set
            {
                this.airport.NrOfSusBagsOthers = value | 0;
            }
        }

        public bool IsPossible()
        {
            return NumberOfBags - (NrOfSusBagsOthers + NrOfSusBagsGuns + NrOfSusBagsFlamable + NrOfSusBagsDrugs) >= 0;
        }
    }
}
