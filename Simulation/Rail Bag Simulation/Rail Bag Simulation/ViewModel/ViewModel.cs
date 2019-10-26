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

        public string Name
        {
            get
            {
                return  name; 
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int NumberOfBags
        {
            get
            {
                return numberOfBags;
            }
            set
            {
                numberOfBags = value;
                OnPropertyChanged("NumberOfBags");
            }
        }
        public int NrOfSusBagsGuns
        {
            get
            {
                return nrOfSusBagsGuns;
            }
            set
            {
                nrOfSusBagsGuns = value;
                OnPropertyChanged("NrOfSusBagsGuns");
            }
        }
        public int NrOfSusBagsDrugs
        {
            get
            {
                return nrOfSusBagsDrugs;
            }
            set
            {
                nrOfSusBagsDrugs = value;
                OnPropertyChanged("NrOfSusBagsDrugs");
            }
        }
        public int NrOfSusBagsFlamable
        {
            get
            {
                return nrOfSusBagsFlamable;
            }
            set
            {
               nrOfSusBagsFlamable = value;
               OnPropertyChanged("NrOfSusBagsFlamable");
            }
        }
        public int NrOfSusBagsOthers
        {
            get
            {
                return nrOfSusBagsOthers;
            }
            set
            {
                nrOfSusBagsOthers = value;
                OnPropertyChanged("NrOfSusBagsOthers");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsPossible()
        {
            return NumberOfBags - (NrOfSusBagsOthers + NrOfSusBagsGuns + NrOfSusBagsFlamable + NrOfSusBagsDrugs) >= 0;
        }
    }
}
