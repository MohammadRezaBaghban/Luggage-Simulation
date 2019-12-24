using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public class Storage
    {
        private static readonly List<Bag> Suspicious = new List<Bag>();
        private static readonly List<Bag> NoDestination = new List<Bag>();

        public static int GetNumberOfSuspiciousBagsInStorage()
        {
            return Suspicious.Count;
        }

        public static int GetNumberOfNoDestinationBagsInStorage()
        {
            return  NoDestination.Count;
        }

        public static List<Bag> GetAllSuspiciousBags()
        {
            return Suspicious;
        }

        public  void StoreSuspiciousBag(Bag bag)
        {
            Suspicious.Add(bag);
        }


        public static List<Bag> GetAllNoDestinationBags()
        {
            return NoDestination;
        }

        public  void StoreNoDestinationBag(Bag bag)
        {
            NoDestination.Add(bag);
        }

        public override string ToString()
        {
            var sender = "\n Storage \n";
            foreach (var bag in Suspicious) sender += bag.GetBagInfo() + "\n";
            foreach (var bag in NoDestination) sender += bag.GetBagInfo() + "\n";
            return sender;
        }
    }
}