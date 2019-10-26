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
        private static int Setsize;
        private string _name;
        private readonly Dictionary<Gate, Destination> _gateDestinations= new Dictionary<Gate, Destination>();
        private readonly List<Bag> _bagsList = new List<Bag>();
        private static Storage _storage=new Storage(); 
        private List<Terminal> _terminal = new List<Terminal>();

        private bool IsMapCreated = false;
        private LinkedList _ll;
        private ConveyorNode ConveyorNode;
        private BagSortNode BagSortNode;
        private TerminalNode t;
        private GateNode GateNode;

        public static Storage Storage => _storage;

        public LinkedList Ll => _ll;

        public Airport(string name)
        {
            _name = name;
        }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        { 
            CreateMapLayout(5);
            _ll.AddGeneratedBags(Bag.GenerateBag( nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers));
        }

        private void CreateMapLayout(int QueueSizeOfBelts)
        {
            if (IsMapCreated)
            {
                return;
            }

            Setsize = QueueSizeOfBelts;
            _ll = new LinkedList();

            _ll.AddNode(new CheckinNode());

            _ll.AddNode(new ConveyorNode(new Conveyorbelt(Setsize)));

            _ll.AddNode(new SecurityNode());

            _ll.AddNode(new ConveyorNode(new Conveyorbelt(Setsize)));

            BagSortNode = new BagSortNode();

            _ll.AddNode(BagSortNode);

            ConveyorNode = new ConveyorNode(new Conveyorbelt(Setsize));


            _ll.AddNode(ConveyorNode, BagSortNode);


            t = new TerminalNode(new Terminal("T1"));

            _ll.AddNode(t, ConveyorNode);

            ConveyorNode = new ConveyorNode(new Conveyorbelt(Setsize));
            _ll.AddNode(ConveyorNode, t);


            GateNode = new GateNode(new Gate("G1"));
            _ll.AddNode(GateNode, ConveyorNode);


            ConveyorNode = new ConveyorNode(new Conveyorbelt(Setsize));

            _ll.AddNode(ConveyorNode, BagSortNode);

            t = new TerminalNode(new Terminal("T2"));
            _ll.AddNode(t, ConveyorNode);

            ConveyorNode = new ConveyorNode(new Conveyorbelt(Setsize));
            _ll.AddNode(ConveyorNode, t);

            GateNode = new GateNode(new Gate("G1"));
            _ll.AddNode(GateNode, ConveyorNode);

            IsMapCreated = true;
        }

        public Bag GetBagById(int bagId)
        {
            return null;
        }
    }
}
