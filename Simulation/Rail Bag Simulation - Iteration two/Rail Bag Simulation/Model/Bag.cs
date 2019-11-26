using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows;
using System.Windows.Media;

namespace Rail_Bag_Simulation
{
    public class Bag
    {
        private static int _idToGive = 100;

        private SuspiciousBagtype? _suspicious;

        public string LastSeenLocation { get; set; }

        public int Id { get; set; }
        public SuspiciousBagtype SuspiciousBagtype { get { return (SuspiciousBagtype) _suspicious; } set { _suspicious = value; } }
        public Destination Destination { get; set; }
        public float Weight { get; set; }
        public string TerminalAndGate { get; set; }



        private static readonly Random Random = new Random();

        public Bag(SuspiciousBagtype suspicious, float weight, Destination destination, string terminalAndGate)
        {
            this._suspicious = suspicious;
            this.Weight = weight;
            this.Id = ++_idToGive;
            this.Destination = destination;
            this.TerminalAndGate = terminalAndGate;
           

        }
        public Bag(float weight, Destination destination, string terminalAndGate)
        {
            this._suspicious = null;
            this.Weight = weight;
            this.Id = ++_idToGive;
            this.Destination = destination;
            this.TerminalAndGate = terminalAndGate;
        }


        public string GetBagInfo()
        {
            return string.Format($"Id : {Id} Weight: {Weight}  Destination: {Destination} Terminal and Gate: {TerminalAndGate}");
        }

        public void UpdateLastSeenLocation(string newLocation)
        {
            LastSeenLocation = newLocation;
        }

        private static int GetTheSuspiciousBagDistr(int totalNrOfBags, int totalNrOfSuspBags)
        {
            if (totalNrOfSuspBags == 0)
            {
                return 0;
            }
            var resultToTest = Convert.ToInt32((decimal)(totalNrOfBags) / (decimal)totalNrOfSuspBags);
            return resultToTest;
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


            for (var i = 0; i < nbrOfBags; i++)
            {
                //for every suspicious bag to be created, it will be placed after the distribution value.
                if (theSuspiciousBagDistr != 0 && i % theSuspiciousBagDistr == 0 && suspiciousbags.Count>0)
                {
                    bags.Add(suspiciousbags[0]);
                    suspiciousbags.RemoveAt(0);
                    continue;
                }
                bags.Add(new Bag(Random.Next(10, 22), (Destination) Random.Next(1, 12),
                    "T" + Random.Next(1, 3) + "-"+"G" + Random.Next(1, 3)));
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
                    templist.Add(new Bag(SuspiciousBagtype.Drug, Random.Next(10, 22), (Destination)Random.Next(1, 12), "T" + Random.Next(1, 3) + "-" + "G" + Random.Next(1, 3)));
                    nbrOfBagsDrugs--;
                    totalnumber--;
                }

                if (nbrOfBagsWeapons > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Weapons, Random.Next(10, 22), (Destination)Random.Next(1, 12), "T" + Random.Next(1, 3)+ "-" + "G" + Random.Next(1, 3)));
                    nbrOfBagsWeapons--;
                    totalnumber--;

                }

                if (nbrOfBagsFlammable > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Flammables, Random.Next(10, 22), (Destination)Random.Next(1, 12), "T" + Random.Next(1, 3) + "-" +"G" + Random.Next(1, 3)));
                    nbrOfBagsFlammable--;
                    totalnumber--;

                }

                if (nbrBagsOthers > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Other, Random.Next(10, 22), (Destination)Random.Next(1, 12), "T" + Random.Next(1, 3) + "-" + "G" + Random.Next(1, 3)));
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
