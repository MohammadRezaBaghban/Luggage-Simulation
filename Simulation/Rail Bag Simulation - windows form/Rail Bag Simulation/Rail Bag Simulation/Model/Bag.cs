﻿using System;
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

        public Bag(SuspiciousBagtype suspicious, float weight)
        {
            _suspicious = suspicious;
            Weight = weight;
            Id = ++_idToGive;
        }

        public Bag(float weight)
        {
            _suspicious = null;
            Weight = weight;
            Id = ++_idToGive;
        }

        public string LastSeenLocation { get; private set; }

        public int Id { get; }

        public SuspiciousBagtype SuspiciousBagtype
        {
            get => (SuspiciousBagtype) _suspicious;
            set => _suspicious = value;
        }

        public float Weight { get; set; }
        public string TerminalAndGate { get; private set; }

        public static List<Bag> returnGeneratedBags() { return bags; }


        public string GetBagInfo()
        {
            return string.Format(
                $" \n Id : {Id} Weight: {Weight} Terminal and Gate: {TerminalAndGate}");
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
                    templist.Add(new Bag(SuspiciousBagtype.Drug, Random.Next(10, 22)));
                    nbrOfBagsDrugs--;
                    totalnumber--;
                }

                if (nbrOfBagsWeapons > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Weapons, Random.Next(10, 22)));
                    nbrOfBagsWeapons--;
                    totalnumber--;
                }

                if (nbrOfBagsFlammable > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Flammables, Random.Next(10, 22)));
                    nbrOfBagsFlammable--;
                    totalnumber--;
                }

                if (nbrBagsOthers > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Other, Random.Next(10, 22)));
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

        public static List<Bag> GenerateBag(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons,
            int nbrOfBagsFlammable, int nbrBagsOthers, Dictionary<string , int> percentagesOfBagsPerGateDictionary)
        {
            bags = new List<Bag>();


            var totalNrOfSuspicious =
                GetTotalNrOfSuspicious(nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);

            if (totalNrOfSuspicious > nbrOfBags)
                throw new Exception("Number of suspicious bags exceeds number of bags to be generated");

            MakeBagsWithSuspiciousIncluded(nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers, totalNrOfSuspicious);

            AssignGatesToBags(percentagesOfBagsPerGateDictionary);

            return bags;
        }

        private static void MakeBagsWithSuspiciousIncluded(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons,
            int nbrOfBagsFlammable, int nbrBagsOthers, int totalNrOfSuspicious)
        {
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

                bags.Add(new Bag(Random.Next(10, 22)));
            }
        }

        private static void AssignGatesToBags(Dictionary<string, int> percentagesOfBagsPerGateDictionary)
        {
            int lastIndexToContinueFrom = 0;
            int totalPercentage = 0;
            foreach (var value in percentagesOfBagsPerGateDictionary.Values)
            {
                totalPercentage += value;
            }

            totalPercentage = 100 - totalPercentage;
            foreach (KeyValuePair<string, int> keyValuePair in percentagesOfBagsPerGateDictionary)
            {
                //there could be a bag for the last bag
                for (var i = 0; i < Convert.ToInt32(Airport.TotalNumberOfBags*((decimal)keyValuePair.Value/100)); i++)
                {
                    if(bags.Count == lastIndexToContinueFrom) { return;}
                    bags[lastIndexToContinueFrom].TerminalAndGate = keyValuePair.Key;
                    
                    lastIndexToContinueFrom++;
                }
            }

            for (var i = 0; i < Convert.ToInt32(Airport.TotalNumberOfBags * ((decimal)totalPercentage / 100)); i++)
            {
                bags[lastIndexToContinueFrom].TerminalAndGate =null;
                lastIndexToContinueFrom++;
            }


        }
    }
}