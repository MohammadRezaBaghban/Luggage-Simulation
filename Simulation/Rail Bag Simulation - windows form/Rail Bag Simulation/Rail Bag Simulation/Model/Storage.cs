using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public class Storage
    {
        private static readonly List<Bag> Suspicious = new List<Bag>();

        public static int GetNumberOfBagsInStorage()
        {
            return Suspicious.Count;
        }

        public static List<Bag> GetAllSuspiciousBags()
        {
            return Suspicious;
        }

        public void StoreSuspiciousBag(Bag bag)
        {
            Suspicious.Add(bag);
        }

        public override string ToString()
        {
            var sender = "\n Storage \n";
            foreach (var bag in Suspicious) sender += bag.GetBagInfo() + "\n";
            return sender;
        }
    }
}