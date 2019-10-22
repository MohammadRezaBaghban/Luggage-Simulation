using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Storage
    {
        private int _storageId;
        private List<Bag> _suspicious;
        public Bag GetBagById(int id) 
        {
            foreach(var bag in _suspicious)
            {
                if(bag.Id == id) { return bag;  } 
            }
            return null;
        }

        public int GetNumberOfBagsInStorage()
        {
            return _suspicious.Count;
        }

        public List<Bag> GetAllSuspiciousBags()
        {
            return _suspicious;
        }

        public void StoreSuspiciousBag(Bag bag)
        {
            _suspicious.Add(bag);
        }
    }
}
