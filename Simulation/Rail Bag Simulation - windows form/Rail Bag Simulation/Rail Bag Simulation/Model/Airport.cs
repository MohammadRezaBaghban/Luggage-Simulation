using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    public class Airport
    {
        private static int _setSize;
        private readonly bool _isMapCreated = false;
        private List<Bag> _bagsList;
        private BagSortNode _bagSortNode;

        private ConveyorNode _conveyorNode;
        private GateNode _gateNode;
        private TerminalNode t;

        public Airport(int speedDelay)
        {
            Ll = new LinkedList(speedDelay);
        }

        public static Storage Storage { get; } = new Storage();

        public static List<Node> ListOfNodes => LinkedList.GetAllNodes();

        public LinkedList Ll { get; }

        public static int TotalNumberOfBags { get; private set; }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable,
            int nbrBagsOthers)
        {
            TotalNumberOfBags = nbrOfBags;
            _bagsList = Bag.GenerateBag(nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);
            Ll.AddGeneratedBags(_bagsList);
        }

        public void PauseSimulation()
        {
            Ll.PauseSimulation();
        }

        public void ContinueSimulation()
        {
            Ll.RunSimulation();
        }


        public void DestroySimulation()
        {
            Ll.DestroySimulation();
        }

        public void CreateMapLayout(int queueSizeOfBelts)
        {
            if (_isMapCreated) return;

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