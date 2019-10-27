using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string name;
        private int numberOfBags;
        private int nrOfSusBagsGuns;
        private int nrOfSusBagsDrugs;
        private int nrOfSusBagsFlamable;
        private int nrOfSusBagsOthers;

        Airport airport = new Airport("Schiphol");

        public void StartSimulation()
        {
            airport.StartBagsMovement(numberOfBags, 1, 0, 0, 0);
        }

        public LinkedList GetEverythingInTheLinkedList()
        {
            return airport.Ll;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int NumberOfBags
        {
            get => numberOfBags;
            set
            {
                numberOfBags = value;
                OnPropertyChanged("NumberOfBags");
            }
        }
        public int NrOfSusBagsGuns
        {
            get => nrOfSusBagsGuns;
            set
            {
                nrOfSusBagsGuns = value;
                OnPropertyChanged("NrOfSusBagsGuns");
            }
        }
        public int NrOfSusBagsDrugs
        {
            get => nrOfSusBagsDrugs;
            set
            {
                nrOfSusBagsDrugs = value;
                OnPropertyChanged("NrOfSusBagsDrugs");
            }
        }
        public int NrOfSusBagsFlamable
        {
            get => nrOfSusBagsFlamable;
            set
            {
               nrOfSusBagsFlamable = value;
               OnPropertyChanged("NrOfSusBagsFlamable");
            }
        }
        public int NrOfSusBagsOthers
        {
            get => nrOfSusBagsOthers;
            set
            {
                nrOfSusBagsOthers = value;
                OnPropertyChanged("NrOfSusBagsOthers");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsPossible()
        {
            return NumberOfBags - (NrOfSusBagsOthers + NrOfSusBagsGuns + NrOfSusBagsFlamable + NrOfSusBagsDrugs) >= 0;
        }


    }
}
