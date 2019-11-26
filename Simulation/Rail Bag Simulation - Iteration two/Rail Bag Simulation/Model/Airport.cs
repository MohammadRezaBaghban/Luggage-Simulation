using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace Rail_Bag_Simulation
{
    public class Airport
    {
        private static int _setSize;
        private readonly string _name;
        private List<Bag> _bagsList;
        private readonly bool _isMapCreated = false;
        
        private ConveyorNode _conveyorNode;
        private BagSortNode _bagSortNode;
        private TerminalNode t;
        private GateNode _gateNode;
        private static int _totalNumberOfBags = 0;

        public static Storage Storage { get; } = new Storage();

        public static List<Node> ListOfNodes => LinkedList.GetAllNodes();
        public LinkedList LL { get; } = new LinkedList(400);

        public static int TotalNumberOfBags => _totalNumberOfBags;

        public Airport(string name)
        {
            _name = name;
        }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        {
            this._totalNumberOfBags = nbrOfBags;
            _bagsList = Bag.GenerateBag(nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);
            LL.AddGeneratedBags(_bagsList);
        }

        public void CreateMapLayout(int QueueSizeOfBelts)
        {

            if (_isMapCreated)
            {
                return;
            }

            _setSize = QueueSizeOfBelts;
       

            LL.AddNode(new CheckinNode());

            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize));

            LL.AddNode(new SecurityNode());

            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize));

            _bagSortNode = new BagSortNode();

            LL.AddNode(_bagSortNode);



            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize), _bagSortNode);
    


            t = new TerminalNode(new Terminal());

            LL.AddNode(t, _conveyorNode);
            


            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);


            _gateNode = new GateNode(new Gate("G1"));
            LL.AddNode(_gateNode, _conveyorNode);

            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);

            _gateNode = new GateNode(new Gate("G2"));
            LL.AddNode(_gateNode, _conveyorNode);


            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize), _bagSortNode);

            t = new TerminalNode(new Terminal());
            LL.AddNode(t, _conveyorNode);


            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);

            _gateNode = new GateNode(new Gate("G1"));
            LL.AddNode(_gateNode, _conveyorNode);
            LL.AddNode(_conveyorNode = new ConveyorNode(_setSize), t);

            _gateNode = new GateNode(new Gate("G2"));
            LL.AddNode(_gateNode, _conveyorNode);

        }
    }
}
