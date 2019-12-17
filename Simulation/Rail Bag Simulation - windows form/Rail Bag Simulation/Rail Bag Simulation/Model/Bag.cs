using System;
using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    [Serializable]
    public class Bag
    {
        private static int _idToGive;


        private static readonly Random Random = new Random();

        private SuspiciousBagtype? _suspicious;

        private static List<Bag> bags = new List<Bag>();
        public bool IsObserving;

        public Bag(SuspiciousBagtype suspicious, float weight, Destination destination, string terminalAndGate)
        {
            _suspicious = suspicious;
            Weight = weight;
            Id = ++_idToGive;
            Destination = destination;
            TerminalAndGate = terminalAndGate;
        }

        public Bag(float weight, Destination destination, string terminalAndGate)
        {
            _suspicious = null;
            Weight = weight;
            Id = ++_idToGive;
            Destination = destination;
            TerminalAndGate = terminalAndGate;
        }

        public string LastSeenLocation { get; private set; }

        public int Id { get; }

        public SuspiciousBagtype SuspiciousBagtype
        {
            get => (SuspiciousBagtype) _suspicious;
            set => _suspicious = value;
        }

        public Destination Destination { get; set; }
        public float Weight { get; set; }
        public string TerminalAndGate { get; set; }


        public string GetBagInfo()
        {
            return string.Format(
                $" \n Id : {Id} Weight: {Weight}  Destination: {Destination} Terminal and Gate: {TerminalAndGate}");
        }

        public void UpdateLastSeenLocation(string newLocation)
        {
            LastSeenLocation = newLocation;
        }

        private static int GetTheSuspiciousBagDistr(int totalNrOfBags, int totalNrOfSuspBags)
        {
            if (totalNrOfSuspBags == 0) return 0;
            var resultToTest = Convert.ToInt32(totalNrOfBags / (decimal) totalNrOfSuspBags);
            return resultToTest;
        }

        public static List<Bag> GenerateBag(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons,
            int nbrOfBagsFlammable, int nbrBagsOthers)
        {
            bags = new List<Bag>();


            var totalNrOfSuspicious =
                GetTotalNrOfSuspicious(nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);

            if (totalNrOfSuspicious > nbrOfBags)
                throw new Exception("Number of suspicious bags exceeds number of bags to be generated");

            var theSuspiciousBagDistr = GetTheSuspiciousBagDistr(nbrOfBags, totalNrOfSuspicious);
            var suspiciousbags =
                GenerateSuspiciousBags(nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);


            for (var i = 0; i < nbrOfBags; i++)
            {
                //for every suspicious bag to be created, it will be placed after the distribution value.
                if (theSuspiciousBagDistr != 0 && i % theSuspiciousBagDistr == 0 && suspiciousbags.Count > 0)
                {
                    bags.Add(suspiciousbags[0]);
                    suspiciousbags.RemoveAt(0);
                    continue;
                }

                bags.Add(new Bag(Random.Next(10, 22), (Destination) Random.Next(1, 12),
                    "T" + Random.Next(1, 3) + "-" + "G" + Random.Next(1, 6)));
            }

            return bags;
        }

        private static int GetTotalNrOfSuspicious(int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable,
            int nbrBagsOthers)
        {
            var totalNrOfSuspicious = nbrOfBagsDrugs + nbrOfBagsWeapons + nbrOfBagsFlammable + nbrBagsOthers;
            return totalNrOfSuspicious;
        }

        private static List<Bag> GenerateSuspiciousBags(int nbrOfBagsDrugs, int nbrOfBagsWeapons,
            int nbrOfBagsFlammable,
            int nbrBagsOthers)
        {
            var templist = new List<Bag>();
            var totalnumber =
                GetTotalNrOfSuspicious(nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);
            while (totalnumber > 0)
            {
                if (nbrOfBagsDrugs > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Drug, Random.Next(10, 22), (Destination) Random.Next(1, 12),
                        "T" + Random.Next(1, 3) + "-" + "G" + Random.Next(1, 3)));
                    nbrOfBagsDrugs--;
                    totalnumber--;
                }

                if (nbrOfBagsWeapons > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Weapons, Random.Next(10, 22),
                        (Destination) Random.Next(1, 12), "T" + Random.Next(1, 3) + "-" + "G" + Random.Next(1, 3)));
                    nbrOfBagsWeapons--;
                    totalnumber--;
                }

                if (nbrOfBagsFlammable > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Flammables, Random.Next(10, 22),
                        (Destination) Random.Next(1, 12), "T" + Random.Next(1, 3) + "-" + "G" + Random.Next(1, 3)));
                    nbrOfBagsFlammable--;
                    totalnumber--;
                }

                if (nbrBagsOthers > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Other, Random.Next(10, 22), (Destination) Random.Next(1, 12),
                        "T" + Random.Next(1, 3) + "-" + "G" + Random.Next(1, 3)));
                    nbrBagsOthers--;
                    totalnumber--;
                }
            }

            return templist;
        }

        public SuspiciousBagtype? GetSecurityStatus()
        {
            return _suspicious;
        }

    }
}