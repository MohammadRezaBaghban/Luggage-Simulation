using System.Collections.Generic;


namespace Rail_Bag_Simulation
{
    public class Airport
    {
        private static int _setSize;
        private List<Bag> _bagsList;
        private readonly bool _isMapCreated = false;
        
        private ConveyorNode _conveyorNode;
        private BagSortNode _bagSortNode;
        private TerminalNode t;
        private GateNode _gateNode;
        private readonly LinkedList _ll;
        private static int _totalNumberOfBags = 0;

        public static Storage Storage { get; } = new Storage();

        public static List<Node> ListOfNodes => LinkedList.GetAllNodes();

        public LinkedList Ll => _ll;

        public static int TotalNumberOfBags => _totalNumberOfBags;

        public Airport(int speedDelay)
        {
            _ll = new LinkedList(speedDelay);
        }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        {
            _totalNumberOfBags = nbrOfBags;
            _bagsList = Bag.GenerateBag(nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);
            Ll.AddGeneratedBags(_bagsList);
        }

        public void CreateMapLayout(int queueSizeOfBelts)
        {

            if (_isMapCreated)
            {
                return;
            }

            _setSize = queueSizeOfBelts;
       

            Ll.AddNode(new CheckinNode());

            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize));

            Ll.AddNode(new SecurityNode());

            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize));

            _bagSortNode = new BagSortNode();

            Ll.AddNode(_bagSortNode);



            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize), _bagSortNode);
    


            t = new TerminalNode(new Terminal());

            Ll.AddNode(t, _conveyorNode);
            


            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);


            _gateNode = new GateNode(new Gate("G1"));
            Ll.AddNode(_gateNode, _conveyorNode);

            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);

            _gateNode = new GateNode(new Gate("G2"));
            Ll.AddNode(_gateNode, _conveyorNode);


            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize), _bagSortNode);

            t = new TerminalNode(new Terminal());
            Ll.AddNode(t, _conveyorNode);


            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);

            _gateNode = new GateNode(new Gate("G1"));
            Ll.AddNode(_gateNode, _conveyorNode);
            Ll.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);

            _gateNode = new GateNode(new Gate("G2"));
            Ll.AddNode(_gateNode, _conveyorNode);

        }
    }
}
