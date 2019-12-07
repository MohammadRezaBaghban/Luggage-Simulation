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

        public void CreateMapLayout(int queueSizeOfBelts)
        {
            if (_isMapCreated) return;

            _setSize = queueSizeOfBelts;

            Node cn1 = new CheckinNode();
            Node CheckIn_To_Security_Conveyor = new ConveyorNode(queueSizeOfBelts);
            Node cn2 = new CheckinNode();
            Node cn2conveyor2 = new ConveyorNode(queueSizeOfBelts);
            //Node cn3 = new CheckinNode();
            //Node cn3conveyor3 = new ConveyorNode(queueSizeOfBelts);

            Node security = new SecurityNode();

            Node stconveyor4 = new ConveyorNode(queueSizeOfBelts);
            //Node stconveyoradd = new ConveyorNode(queueSizeOfBelts);
            Node bagsort = new BagSortNode();
            Node bsconveyor5 = new ConveyorNode(queueSizeOfBelts);
            Node bsconveyor6 = new ConveyorNode(queueSizeOfBelts);
            Node terminal1 = new TerminalNode(new Terminal());
            Node terminal2 = new TerminalNode(new Terminal());
            Node t1conveyor7 = new ConveyorNode(queueSizeOfBelts);
            Node t1conveyor8 = new ConveyorNode(queueSizeOfBelts);

            Node t1gate1 = new GateNode(new Gate("G1"));
            Node t1gate2 = new GateNode(new Gate("G2"));
            Node t2conveyor7 = new ConveyorNode(queueSizeOfBelts);
            Node t2conveyor8 = new ConveyorNode(queueSizeOfBelts);

            Node t2gate1 = new GateNode(new Gate("G1"));
            Node t2gate2 = new GateNode(new Gate("G2"));
            Ll.AddNode(cn1);
            Ll.AddNode(cn2);
            //Ll.AddNode(cn3);
            Ll.AddNode(cn1.Id, cn1.GetType(), CheckIn_To_Security_Conveyor);
            Ll.AddNode(cn2.Id, cn1.GetType(), cn2conveyor2);
            //Ll.AddNode(cn3.Id, cn3.GetType(), cn3conveyor3);
            Ll.AddNode(CheckIn_To_Security_Conveyor.Id, CheckIn_To_Security_Conveyor.GetType(), security);
            Ll.AddNode(cn2conveyor2.Id, cn2conveyor2.GetType(), security);
            //Ll.AddNode(cn3conveyor3.Id, cn3conveyor3.GetType(), security);
            Ll.AddNode(security.Id, security.GetType(), stconveyor4);
            //Added Bagsort to connections 
            Ll.AddNode(stconveyor4.Id, stconveyor4.GetType(), bagsort);
            //Bagsort connections
            Ll.AddNode(bagsort.Id, bagsort.GetType(), bsconveyor5);
            Ll.AddNode(bagsort.Id, bagsort.GetType(), bsconveyor6);
            Ll.AddNode(bsconveyor5.Id, bsconveyor5.GetType(), terminal1);
            Ll.AddNode(bsconveyor6.Id, bsconveyor6.GetType(), terminal2);
            ////terminal1 gates from bagsort
            Ll.AddNode(terminal1.Id, terminal1.GetType(), t1conveyor7);
            Ll.AddNode(terminal1.Id, terminal1.GetType(), t1conveyor8);
            Ll.AddNode(t1conveyor7.Id, t1conveyor7.GetType(), t1gate1);
            Ll.AddNode(t1conveyor8.Id, t1conveyor8.GetType(), t1gate2);

            ////terminal2 from bagsort
            Ll.AddNode(terminal2.Id, terminal2.GetType(), t2conveyor7);
            Ll.AddNode(terminal2.Id, terminal2.GetType(), t2conveyor8);
            Ll.AddNode(t2conveyor7.Id, t2conveyor7.GetType(), t2gate1);
            Ll.AddNode(t2conveyor8.Id, t2conveyor8.GetType(), t2gate2);
            //Ll.AddNode(stconveyor4.Id, stconveyor4.GetType(), stconveyoradd);
            //Node cn4 = new CheckinNode();
            //Node cn4conveyor4 = new ConveyorNode(queueSizeOfBelts);
            //Node security1 = new SecurityNode();
            //Node st1conveyor4 = new ConveyorNode(queueSizeOfBelts);

            //Ll.AddNode(cn4);
            //Ll.AddNode(cn4.Id, cn4.GetType(), cn4conveyor4);
            //Ll.AddNode(cn4conveyor4.Id, cn4conveyor4.GetType(), security1);
            //Ll.AddNode(security1.Id, security1.GetType(), st1conveyor4);
            //Ll.AddNode(st1conveyor4.Id, stconveyor4.GetType(), bagsort);
        }
    }
}