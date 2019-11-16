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
        private readonly Dictionary<Gate, Destination> _gateDestinations= new Dictionary<Gate, Destination>();
        private readonly List<Bag> _bagsList = new List<Bag>();
        private bool IsMapCreated = false;
        
        private ConveyorNode ConveyorNode;
        private BagSortNode BagSortNode;
        private TerminalNode t;
        private GateNode GateNode;

        public static Storage Storage { get; } = new Storage();

        public List<Node> ListOfNodes => LL.GetAllNodes();
        public LinkedList LL { get; } = new LinkedList(500);
        public Airport(string name)
        {
            _name = name;
        }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        { 
          
            LL.AddGeneratedBags(Bag.GenerateBag( nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers));
        }

        public void CreateMapLayout(int QueueSizeOfBelts)
        {

            if (IsMapCreated)
            {
                return;
            }

            Setsize = QueueSizeOfBelts;
       

            LL.AddNode(new CheckinNode(213,10));

            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize,205,0,0,0,295,160));

            LL.AddNode(new SecurityNode(246,355));

            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize,200,0,0,0,295,435));

            BagSortNode = new BagSortNode(257,630);

            LL.AddNode(BagSortNode);



            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize, 270, 0, -180, 0, 280, 701), BagSortNode);
    


            t = new TerminalNode(new Terminal("T1"),70,952);

            LL.AddNode(t, ConveyorNode);


            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize, 88, 0, 40, 0, 148, 1002), t);


            GateNode = new GateNode(new Gate("G1"),148,1114);
            LL.AddNode(GateNode, ConveyorNode);

            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize, 90, 0, 0, 40, 500, 1027), t);

            GateNode = new GateNode(new Gate("G2"), 426, 1128);
            LL.AddNode(GateNode, ConveyorNode);


            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize, 270, 0, 270, 0, 316, 701), BagSortNode);

            t = new TerminalNode(new Terminal("T2"),536,952);
            LL.AddNode(t, ConveyorNode);


            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize, 90, 0, 0, 40, 500, 1027), t);

            GateNode = new GateNode(new Gate("G1"),426,1128);
            LL.AddNode(GateNode, ConveyorNode);
            LL.AddNode(ConveyorNode = new ConveyorNode(Setsize, 90, 0, 0, 40, 500, 1027), t);

            GateNode = new GateNode(new Gate("G2"), 426, 1128);
            LL.AddNode(GateNode, ConveyorNode);


        }

        public Bag GetBagById(int bagId)
        {
            return null;
        }
    }
}
