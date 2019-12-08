using System;
using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    [Serializable]
    public class Airport
    {

        private readonly bool _isMapCreated = false;
        private static List<Bag> _bagsList;
        public static List<Bag> GetBagList => _bagsList;

        private List<Node> conveyors;
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

        public void StartBagsMovement(List<Bag> bag)
        {
            _bagsList = bag;
            Ll.AddGeneratedBags(_bagsList);
        }



        public void CreateMapLayout(int queueSizeOfBelts)
        {
            if (_isMapCreated) return;
            
            Node checkIn1 = new CheckinNode();
            Node CheckIn_To_Security_Conveyor = new ConveyorNode(queueSizeOfBelts);
            Node cn2 = new CheckinNode();
            Node cn2conveyor2 = new ConveyorNode(queueSizeOfBelts);
            //Node cn3 = new CheckinNode();
            //Node cn3conveyor3 = new ConveyorNode(queueSizeOfBelts);

            Node security = new SecurityNode();

            Node security_Conveyor_To_BagSort = new ConveyorNode(queueSizeOfBelts);
            //Node stconveyoradd = new ConveyorNode(queueSizeOfBelts);
            Node bagSort = new BagSortNode();
            Node bagSort_Conveyor_To_Terminal1 = new ConveyorNode(queueSizeOfBelts);
            Node bagSort_Conveyor_To_Terminal2 = new ConveyorNode(queueSizeOfBelts);
            Node terminal1 = new TerminalNode(new Terminal());
            Node terminal2 = new TerminalNode(new Terminal());
            Node terminal1_Conveyor_To_Gate1 = new ConveyorNode(queueSizeOfBelts);
            Node terminal1_Conveyor_To_Gate2 = new ConveyorNode(queueSizeOfBelts);

            Node t1gate1 = new GateNode(new Gate("G1"));
            Node t1gate2 = new GateNode(new Gate("G2"));
            Node terminal2_Conveyor_To_Gate1 = new ConveyorNode(queueSizeOfBelts);
            Node terminal2_Conveyor_To_Gate2 = new ConveyorNode(queueSizeOfBelts);

            Node t2gate1 = new GateNode(new Gate("G1"));
            Node t2gate2 = new GateNode(new Gate("G2"));

            Ll.AddNode(checkIn1);
            //Ll.AddNode(cn2);
            //Ll.AddNode(cn3);
            Ll.AddNode(checkIn1.Id, checkIn1.GetType(), CheckIn_To_Security_Conveyor);
            //Ll.AddNode(cn2.Id, cn1.GetType(), cn2conveyor2);
            //Ll.AddNode(cn3.Id, cn3.GetType(), cn3conveyor3);
            Ll.AddNode(CheckIn_To_Security_Conveyor.Id, CheckIn_To_Security_Conveyor.GetType(), security);
            // Ll.AddNode(cn2conveyor2.Id, cn2conveyor2.GetType(), security);
            //Ll.AddNode(cn3conveyor3.Id, cn3conveyor3.GetType(), security);
            Ll.AddNode(security.Id, security.GetType(), security_Conveyor_To_BagSort);
            //Added Bagsort to connections 
            Ll.AddNode(security_Conveyor_To_BagSort.Id, security_Conveyor_To_BagSort.GetType(), bagSort);
            //Bagsort connections
            Ll.AddNode(bagSort.Id, bagSort.GetType(), bagSort_Conveyor_To_Terminal1);
            Ll.AddNode(bagSort.Id, bagSort.GetType(), bagSort_Conveyor_To_Terminal2);
            Ll.AddNode(bagSort_Conveyor_To_Terminal1.Id, bagSort_Conveyor_To_Terminal1.GetType(), terminal1);
            Ll.AddNode(bagSort_Conveyor_To_Terminal2.Id, bagSort_Conveyor_To_Terminal2.GetType(), terminal2);
            ////terminal1 gates from bagsort
            Ll.AddNode(terminal1.Id, terminal1.GetType(), terminal1_Conveyor_To_Gate1);
            Ll.AddNode(terminal1.Id, terminal1.GetType(), terminal1_Conveyor_To_Gate2);
            Ll.AddNode(terminal1_Conveyor_To_Gate1.Id, terminal1_Conveyor_To_Gate1.GetType(), t1gate1);
            Ll.AddNode(terminal1_Conveyor_To_Gate2.Id, terminal1_Conveyor_To_Gate2.GetType(), t1gate2);

            ////terminal2 from bagsort
            Ll.AddNode(terminal2.Id, terminal2.GetType(), terminal2_Conveyor_To_Gate1);
            Ll.AddNode(terminal2.Id, terminal2.GetType(), terminal2_Conveyor_To_Gate2);
            Ll.AddNode(terminal2_Conveyor_To_Gate1.Id, terminal2_Conveyor_To_Gate1.GetType(), t2gate1);
            Ll.AddNode(terminal2_Conveyor_To_Gate2.Id, terminal2_Conveyor_To_Gate2.GetType(), t2gate2);
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

            conveyors = new List<Node>()
            {
                CheckIn_To_Security_Conveyor,
                security_Conveyor_To_BagSort,
                bagSort_Conveyor_To_Terminal1,
                bagSort_Conveyor_To_Terminal2,
                terminal1_Conveyor_To_Gate1,
                terminal1_Conveyor_To_Gate2,
                terminal2_Conveyor_To_Gate1,
                terminal2_Conveyor_To_Gate2

            };
        }

        public List<Node> GetConveyorsList() => conveyors;
    }
}