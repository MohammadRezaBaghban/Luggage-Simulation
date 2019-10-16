using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Bag
    {
<<<<<<< HEAD
        
=======

        private static int _idToGive = 100;
        private string _lastSeenLocation;
        private int _id;
        private SuspiciousBagtype _suspicious;
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

            var ResultToTest = Convert.ToDouble((totalNrOfBags - totalNrOfSuspBags) / totalNrOfSuspBags);
            var FirstDigitAfterDot = ResultToTest - (int) ResultToTest;
                FirstDigitAfterDot = Math.Round(FirstDigitAfterDot, 1, MidpointRounding.AwayFromZero);
                if (FirstDigitAfterDot < 0.5)
                {
                    return Convert.ToInt32(ResultToTest);
                }
                else
                {
                    return Convert.ToInt32(ResultToTest) - 1;
                }
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


            for(int i=0; i <= nbrOfBags; i++)
            {
                //for every suspicious bag to be created, it will be placed after the distribution value.
                if (i % theSuspiciousBagDistr == 0)
                {
                    
                }
            }
            return null;
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
                    templist.Add(new Bag(SuspiciousBagtype.Drug, random.Next(10,22), (Destination)random.Next(1,12), "T"+ random.Next(1,3)+"G"+random.Next(1,3)));
                    nbrOfBagsDrugs--;
                }
            }

            return null;
        }
>>>>>>> 54d705e62b12b4cfad5e13a7a44bbf015c889ba4
    }
}
