using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
   public  class Storage
    {
        private static readonly List<Bag> Suspicious=new List<Bag>();
        public Bag GetBagById(int id) 
        {
            foreach(var bag in Suspicious)
            {
                if(bag.Id == id) { return bag;  } 
            }
            return null;
        }

        public static int GetNumberOfBagsInStorage()
        {
            return Suspicious.Count;
        }

        public List<Bag> GetAllSuspiciousBags()
        {
            return Suspicious;
        }

        public void StoreSuspiciousBag(Bag bag)
        {
            Suspicious.Add(bag);
        }

        public override string ToString()
        {
            string sender = "\n Storage \n";
            foreach (Bag bag in Suspicious)
            {
                sender += bag.GetBagInfo() + "\n";
            }
            return sender;
        }
    }
}
