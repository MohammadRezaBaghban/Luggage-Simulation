using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Airport
    {
        private string _name;
        private readonly Dictionary<Gate, Destination> _gateDestinations= new Dictionary<Gate, Destination>();
        private readonly List<Bag> _bagsList = new List<Bag>();
        private static Storage _storage=new Storage(); 
        private List<Terminal> _terminal = new List<Terminal>();
        //private readonly LinkedList _linkedConveyorBeltList = new LinkedList();

        public static Storage Storage => _storage;
        public Airport(string name)
        {
            _name = name;
        }

        public bool CheckIn(List<Bag> bags)
        {

            return true;
        }

        public Bag GetBagById(int bagId)
        {
            return null;
        }
    }
}
