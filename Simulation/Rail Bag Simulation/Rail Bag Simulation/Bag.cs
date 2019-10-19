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
        private SuspiciousBagtype? _suspicious;
        private float _weight;
        private Destination _destination;
        private string _terminalAndGate;

        private static Random random = new Random();

        public Bag(SuspiciousBagtype suspicious, float weight, Destination destination, string terminalAndGate)
        {
            this._suspicious = suspicious;
            this._weight = weight;
            this._id = ++_idToGive;
            this._destination = destination;
            this._terminalAndGate = terminalAndGate;
        }

        public Bag(float weight, Destination destination, string terminalAndGate)
        {
            this._suspicious = null;
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

        private static int GetTheSuspiciousBagDistr(int totalNrOfBags, int totalNrOfSuspBags)
        {

            var ResultToTest = Convert.ToInt32((decimal)(totalNrOfBags) / (decimal)totalNrOfSuspBags);
            return ResultToTest;
        }

        public static List<Bag> GenerateBag(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        {
            var bags = new List<Bag>();


            int totalNrOfSuspicious = nbrOfBagsDrugs + nbrOfBagsWeapons + nbrOfBagsFlammable + nbrBagsOthers;

            if (totalNrOfSuspicious > nbrOfBags)
            {
                throw new Exception("Number of suspicious bags exceeds number of bags to be generated");
            }

            var theSuspiciousBagDistr = GetTheSuspiciousBagDistr(nbrOfBags, totalNrOfSuspicious);
            var suspiciousbags =
                GenerateSuspiciousBags(nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);


            for (int i = 0; i <= nbrOfBags; i++)
            {
                //for every suspicious bag to be created, it will be placed after the distribution value.
                if (i % theSuspiciousBagDistr == 0)
                {
                    bags.Add(suspiciousbags[0]);
                    suspiciousbags.RemoveAt(0);
                    continue;
                }

                bags.Add(new Bag(random.Next(10, 22), (Destination) random.Next(1, 12),
                    "T" + random.Next(1, 3) + "G" + random.Next(1, 3)));

            }
            return bags;
        }

        private static List<Bag> GenerateSuspiciousBags(int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable,
            int nbrBagsOthers)
        {
            var templist = new List<Bag>();
            var totalnumber = nbrOfBagsDrugs + nbrBagsOthers + nbrOfBagsFlammable + nbrOfBagsWeapons;
            while (totalnumber > 0)
            {
                if (nbrOfBagsDrugs > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Drug, random.Next(10, 22), (Destination)random.Next(1, 12), "T" + random.Next(1, 3) + "G" + random.Next(1, 3)));
                    nbrOfBagsDrugs--;
                    totalnumber--;
                }

                if (nbrOfBagsWeapons > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Weapons, random.Next(10, 22), (Destination)random.Next(1, 12), "T" + random.Next(1, 3) + "G" + random.Next(1, 3)));
                    nbrOfBagsWeapons--;
                    totalnumber--;

                }

                if (nbrOfBagsFlammable > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Flammables, random.Next(10, 22), (Destination)random.Next(1, 12), "T" + random.Next(1, 3) + "G" + random.Next(1, 3)));
                    nbrOfBagsFlammable--;
                    totalnumber--;

                }

                if (nbrBagsOthers > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Other, random.Next(10, 22), (Destination)random.Next(1, 12), "T" + random.Next(1, 3) + "G" + random.Next(1, 3)));
                    nbrBagsOthers--;
                    totalnumber--;
                }
            }

            return templist;
        }
    }
}
