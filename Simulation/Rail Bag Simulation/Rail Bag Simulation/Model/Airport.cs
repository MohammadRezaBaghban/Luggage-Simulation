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
        private string _name;
        private readonly Dictionary<Gate, Destination> _gateDestinations= new Dictionary<Gate, Destination>();
        private readonly List<Bag> _bagsList = new List<Bag>();
        private static Storage _storage=new Storage(); 
        private List<Terminal> _terminal = new List<Terminal>();

        private bool IsMapCreated = false;
        
        private ConveyorNode ConveyorNode;
        private BagSortNode BagSortNode;
        private TerminalNode t;
        private GateNode GateNode;

        public static Storage Storage => _storage;

        public List<Node> ListOfNodes => LinkedList.GetAllNodes();

        public Airport(string name)
        {
            _name = name;
        }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable, int nbrBagsOthers)
        { 
          
            LinkedList.AddGeneratedBags(Bag.GenerateBag( nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable, nbrBagsOthers));
        }

        public void CreateMapLayout(int QueueSizeOfBelts)
        {

            if (IsMapCreated)
            {
                return;
            }

            Setsize = QueueSizeOfBelts;
       

            LinkedList.AddNode(new CheckinNode(213,10));

            LinkedList.AddNode(ConveyorNode = new ConveyorNode(Setsize,205,0,0,0,295,160));
            
            LinkedList.AddNode(new SecurityNode(246,355));

            LinkedList.AddNode(ConveyorNode = new ConveyorNode(Setsize,200,0,0,0,295,435));

            BagSortNode = new BagSortNode(257,630);

            LinkedList.AddNode(BagSortNode);



            LinkedList.AddNode(ConveyorNode = new ConveyorNode(Setsize, 270, 0, -180, 0, 280, 701), BagSortNode);


            t = new TerminalNode(new Terminal("T1"),70,952);

            LinkedList.AddNode(t, ConveyorNode);

            
            LinkedList.AddNode(ConveyorNode = new ConveyorNode(Setsize, 88, 0, 40, 0, 148, 1002), t);


            GateNode = new GateNode(new Gate("G1"),148,1114);
            LinkedList.AddNode(GateNode, ConveyorNode);


            

            LinkedList.AddNode(ConveyorNode = new ConveyorNode(Setsize, 270, 0, 270, 0, 316, 701), BagSortNode);

            t = new TerminalNode(new Terminal("T2"),536,952);
            LinkedList.AddNode(t, ConveyorNode);

           
            LinkedList.AddNode(ConveyorNode = new ConveyorNode(Setsize, 90, 0, 0, 40, 500, 1027), t);

            GateNode = new GateNode(new Gate("G1"),426,1128);
            LinkedList.AddNode(GateNode, ConveyorNode);

          
        }

        public Bag GetBagById(int bagId)
        {
            return null;
        }
    }
}
