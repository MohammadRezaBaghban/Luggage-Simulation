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
        public Canvas HitboxCanvas { get;  set; }

        
        public Image image { get; private set; }
        private string _lastSeenLocation;
        private int _id;
        private SuspiciousBagtype? _suspicious;
        private float _weight;
        private Destination _destination;
        private string _terminalAndGate;
        
        public string LastSeenLocation{get{return _lastSeenLocation; } set{ _lastSeenLocation = value;}}
        public int Id{get { return _id; }set { _id = value; }}
        public SuspiciousBagtype SuspiciousBagtype { get { return (SuspiciousBagtype) _suspicious; } set { _suspicious = value; } }
        public Destination Destination { get { return _destination; } set { _destination = value; } }
        public float Weight{get { return _weight; }set { _weight = value; }}
        public string TerminalAndGate{get { return _terminalAndGate; } set { _terminalAndGate = value; }}
     


        private static Random _random = new Random();

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
                bags.Add(new Bag(_random.Next(10, 22), (Destination) _random.Next(1, 12),
                    "T" + _random.Next(1, 3) + "-"+"G" + "1"));
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
                    templist.Add(new Bag(SuspiciousBagtype.Drug, _random.Next(10, 22), (Destination)_random.Next(1, 12), "T" + _random.Next(1, 3) + "-" + "G" + "1"));
                    nbrOfBagsDrugs--;
                    totalnumber--;
                }

                if (nbrOfBagsWeapons > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Weapons, _random.Next(10, 22), (Destination)_random.Next(1, 12), "T" + _random.Next(1, 3)+ "-" + "G" + "1"));
                    nbrOfBagsWeapons--;
                    totalnumber--;

                }

                if (nbrOfBagsFlammable > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Flammables, _random.Next(10, 22), (Destination)_random.Next(1, 12), "T" + _random.Next(1, 3) + "-" +"G" + "1"));
                    nbrOfBagsFlammable--;
                    totalnumber--;

                }

                if (nbrBagsOthers > 0)
                {
                    templist.Add(new Bag(SuspiciousBagtype.Other, _random.Next(10, 22), (Destination)_random.Next(1, 12), "T" + _random.Next(1, 3) + "-" + "G" + "1"));
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
