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
        private static int Setsize;
        private readonly string _name;
        private List<Bag> _bagsList;
        private readonly bool IsMapCreated = false;
        
        private ConveyorNode _conveyorNode;
        private BagSortNode _bagSortNode;
        private TerminalNode t;
        private GateNode _gateNode;

        public static Storage Storage { get; } = new Storage();

        public List<Node> ListOfNodes => LL.GetAllNodes();
        public LinkedList LL { get; } = new LinkedList(500);
        public Airport(string name)
        {
            _name = name;
        }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        {
            _bagsList = Bag.GenerateBag(nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers);
            LL.AddGeneratedBags(_bagsList);
        }

        public void CreateMapLayout(int QueueSizeOfBelts)
        {

            if (IsMapCreated)
            {
                return;
            }

            Setsize = QueueSizeOfBelts;
       

            LL.AddNode(new CheckinNode());

            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize));

            LL.AddNode(new SecurityNode());

            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize));

            _bagSortNode = new BagSortNode();

            LL.AddNode(_bagSortNode);



            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize), _bagSortNode);
    


            t = new TerminalNode(new Terminal());

            LL.AddNode(t, _conveyorNode);
            


            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize), t);


            _gateNode = new GateNode(new Gate("G1"));
            LL.AddNode(_gateNode, _conveyorNode);

            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize), t);

            _gateNode = new GateNode(new Gate("G2"));
            LL.AddNode(_gateNode, _conveyorNode);


            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize), _bagSortNode);

            t = new TerminalNode(new Terminal());
            LL.AddNode(t, _conveyorNode);


            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize), t);

            _gateNode = new GateNode(new Gate("G1"));
            LL.AddNode(_gateNode, _conveyorNode);
            LL.AddNode(_conveyorNode = new ConveyorNode(Setsize), t);

            _gateNode = new GateNode(new Gate("G2"));
            LL.AddNode(_gateNode, _conveyorNode);

        }
    }
}
