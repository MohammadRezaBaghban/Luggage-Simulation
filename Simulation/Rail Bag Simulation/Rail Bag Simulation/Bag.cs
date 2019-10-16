using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Bag
    {

        private static int _idToGive = 100;
        private string _lastSeenLocation;
        private int _id;
        private SuspiciousBagtype _suspicious;
        private float _weight;
        private Destination _destination;
        private string _terminalAndGate;

        public Bag(SuspiciousBagtype suspicious, float weight, Destination destination, string terminalAndGate)
        {
            this._suspicious = suspicious;
            this._weight = weight;
            this._id = ++_idToGive;
            this._destination = destination;
            this._terminalAndGate = terminalAndGate;
        }

        public string GetBagInfo()
        {
            return string.Format($"Id : {_id} Weight: {_weight}  Destination: {_destination} Terminal and Gate: {_terminalAndGate}");
        }

        public void UpdateLastSeenLocation(string newLocation)
        {
            _lastSeenLocation = newLocation;
        } 

        public static List<Bag> GenerateBag(int nbrOfBags, int nrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        {
            List<Bag> bags = new List<Bag>();
            for(int i=0; i <= nbrOfBags; i++)
            {

            }
            return null;
        }
    }
}
