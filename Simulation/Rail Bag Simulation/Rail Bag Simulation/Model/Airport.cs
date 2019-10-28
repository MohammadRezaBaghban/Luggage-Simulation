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
        public LinkedList _ll;
        private ConveyorNode ConveyorNode;
        private BagSortNode BagSortNode;
        private TerminalNode t;
        private GateNode GateNode;

        public static Storage Storage => _storage;

        public List<Node> ListOfNodes => _ll.GetAllNodes();

        public Airport(string name)
        {
            _name = name;
        }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        { 
            CreateMapLayout(4);
            _ll.AddGeneratedBags(Bag.GenerateBag( nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers));
        }

        public void CreateMapLayout(int QueueSizeOfBelts)
        {

            if (IsMapCreated)
            {
                return;
            }

            Setsize = QueueSizeOfBelts;
            _ll = new LinkedList();

            _ll.AddNode(new CheckinNode(213,10));

            _ll.AddNode(ConveyorNode = new ConveyorNode(Setsize,205,0,0,0,295,160));
            
            _ll.AddNode(new SecurityNode(246,355));

            _ll.AddNode(ConveyorNode = new ConveyorNode(Setsize,200,0,0,0,295,435));

            BagSortNode = new BagSortNode(257,691);

            _ll.AddNode(BagSortNode);

            


            _ll.AddNode(ConveyorNode = new ConveyorNode(Setsize, 270, 0, 0, 180, 99, 704), BagSortNode);


            t = new TerminalNode(new Terminal("T1"),70,952);

            _ll.AddNode(t, ConveyorNode);

            
            _ll.AddNode(ConveyorNode = new ConveyorNode(Setsize, 88, 0, 40, 0, 148, 1002), t);


            GateNode = new GateNode(new Gate("G1"),148,1114);
            _ll.AddNode(GateNode, ConveyorNode);


            

            _ll.AddNode(ConveyorNode = new ConveyorNode(Setsize, 270, 0, 270, 0, 316, 701), BagSortNode);

            t = new TerminalNode(new Terminal("T2"),536,952);
            _ll.AddNode(t, ConveyorNode);

           
            _ll.AddNode(ConveyorNode = new ConveyorNode(Setsize, 90, 0, 0, 40, 500, 1027), t);

            GateNode = new GateNode(new Gate("G1"),426,1128);
            _ll.AddNode(GateNode, ConveyorNode);

          
        }

        public Bag GetBagById(int bagId)
        {
            return null;
        }
    }
}
