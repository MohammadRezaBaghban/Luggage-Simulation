using System;
using System.Collections.Generic;

namespace Rail_Bag_Simulation
{
    [Serializable]
    public class Airport
    {
        public static int BagsCountTotalArrived;

        private readonly bool _isMapCreated = false;
        public static int[] destinationStatistics;

        private List<Node> conveyors;

        public Airport(int speedDelay)
        {
            Ll = new LinkedList(speedDelay);
            destinationStatistics = new int[12];
        }

        public static List<Bag> GetBagList { get; private set; }

        public static Storage Storage { get; } = new Storage();

        public static List<Node> ListOfNodes => LinkedList.GetAllNodes();

        public LinkedList Ll { get; }

        public static int TotalNumberOfBags { get; private set; }

        public void StartBagsMovement(int nbrOfBags, int nbrOfBagsDrugs, int nbrOfBagsWeapons, int nbrOfBagsFlammable,
            int nbrBagsOthers)
        {
            TotalNumberOfBags = nbrOfBags;
            GetBagList = Bag.GenerateBag(nbrOfBags, nbrOfBagsDrugs, nbrOfBagsWeapons, nbrOfBagsFlammable,
                nbrBagsOthers);
            foreach (var bag in GetBagList)
            {
                destinationStatistics[(int)bag.Destination] += 1;

            }

            Ll.AddGeneratedBags(GetBagList);
        }
        public void StartBagsMovement(List<Bag> bag)
        {
            GetBagList = bag;
            Ll.AddGeneratedBags(GetBagList);
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

            conveyors = new List<Node>
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

        public void CreateMapLayoutTwo(int queueSizeOfBelts)
        {
            //3 check ins 3 security 1 bag sort 2 terminals 5 gates
            if (_isMapCreated) return;

            //Create Check in One then conveyor to Security 1 then security 1 then conveyor to BagSort
            Node checkIn1 = new CheckinNode();
            Node CheckIn1_To_Security1_Conveyor = new ConveyorNode(queueSizeOfBelts);
            Node security1 = new SecurityNode();
            Node security1_Conveyor_To_BagSort = new ConveyorNode(queueSizeOfBelts);

            //Create Check in Two then conveyor to Security 2 then security 2 then conveyor to BagSort
            Node checkIn2 = new CheckinNode();
            Node CheckIn2_To_Security2_Conveyor = new ConveyorNode(queueSizeOfBelts);
            Node security2 = new SecurityNode();
            Node security2_Conveyor_To_BagSort = new ConveyorNode(queueSizeOfBelts);

            //Create Check in Three then conveyor to Security 3 then security 3 then conveyor to BagSort
            Node checkIn3 = new CheckinNode();
            Node CheckIn3_To_Security3_Conveyor = new ConveyorNode(queueSizeOfBelts);
            Node security3 = new SecurityNode();
            Node security3_Conveyor_To_BagSort = new ConveyorNode(queueSizeOfBelts);

            //Create BagSort
            Node bagSort = new BagSortNode();

            //Create conveyor from bagSort to terminal 1 and Terminal 1
            Node bagSort_Conveyor_To_Terminal1 = new ConveyorNode(queueSizeOfBelts);
            Node terminal1 = new TerminalNode(new Terminal());

            //Create conveyor from terminal 1 to gate 1 and gate 1
            Node terminal1_Conveyor_To_Gate1 = new ConveyorNode(queueSizeOfBelts);
            Node t1gate1 = new GateNode(new Gate("G1"));

            //Create conveyor from terminal 1 to gate 2 and gate 2
            Node terminal1_Conveyor_To_Gate2 = new ConveyorNode(queueSizeOfBelts);
            Node t1gate2 = new GateNode(new Gate("G2"));

            //Create conveyor from terminal 1 to gate 3 and gate 3
            Node terminal1_Conveyor_To_Gate3 = new ConveyorNode(queueSizeOfBelts);
            Node t1gate3 = new GateNode(new Gate("G3"));

            //Create conveyor from terminal 1 to gate 4 and gate 4
            Node terminal1_Conveyor_To_Gate4 = new ConveyorNode(queueSizeOfBelts);
            Node t1gate4 = new GateNode(new Gate("G4"));

            //Create conveyor from terminal 1 to gate 5 and gate 5
            Node terminal1_Conveyor_To_Gate5 = new ConveyorNode(queueSizeOfBelts);
            Node t1gate5 = new GateNode(new Gate("G5"));

            //Create conveyor from bagSort to terminal 2 and Terminal 2
            Node bagSort_Conveyor_To_Terminal2 = new ConveyorNode(queueSizeOfBelts);
            Node terminal2 = new TerminalNode(new Terminal());

            //Create conveyor from terminal 2 to gate 1 and gate 1
            Node terminal2_Conveyor_To_Gate1 = new ConveyorNode(queueSizeOfBelts);
            Node t2gate1 = new GateNode(new Gate("G1"));

            //Create conveyor from terminal 2 to gate 2 and gate 2
            Node terminal2_Conveyor_To_Gate2 = new ConveyorNode(queueSizeOfBelts);
            Node t2gate2 = new GateNode(new Gate("G2"));

            //Create conveyor from terminal 2 to gate 3 and gate 3
            Node terminal2_Conveyor_To_Gate3 = new ConveyorNode(queueSizeOfBelts);
            Node t2gate3 = new GateNode(new Gate("G3"));

            //Create conveyor from terminal 2 to gate 4 and gate 4
            Node terminal2_Conveyor_To_Gate4 = new ConveyorNode(queueSizeOfBelts);
            Node t2gate4 = new GateNode(new Gate("G4"));

            //Create conveyor from terminal 2 to gate 5 and gate 5
            Node terminal2_Conveyor_To_Gate5 = new ConveyorNode(queueSizeOfBelts);
            Node t2gate5 = new GateNode(new Gate("G5"));


            //Add checkIn1 -> conveyorToSecurity1 -> security 1 -> conveyorToBagSort -> bagSort
            Ll.AddNode(checkIn1);
            Ll.AddNode(checkIn1.Id, checkIn1.GetType(), CheckIn1_To_Security1_Conveyor);
            Ll.AddNode(CheckIn1_To_Security1_Conveyor.Id, CheckIn1_To_Security1_Conveyor.GetType(), security1);
            Ll.AddNode(security1.Id, security1.GetType(), security1_Conveyor_To_BagSort);
            Ll.AddNode(security1_Conveyor_To_BagSort.Id, security1_Conveyor_To_BagSort.GetType(), bagSort);

            //Add checkIn2 -> conveyorToSecurity2 -> security 2 -> conveyorToBagSort -> bagSort
            Ll.AddNode(checkIn2);
            Ll.AddNode(checkIn2.Id, checkIn2.GetType(), CheckIn2_To_Security2_Conveyor);
            Ll.AddNode(CheckIn2_To_Security2_Conveyor.Id, CheckIn2_To_Security2_Conveyor.GetType(), security2);
            Ll.AddNode(security2.Id, security2.GetType(), security2_Conveyor_To_BagSort);
            Ll.AddNode(security2_Conveyor_To_BagSort.Id, security2_Conveyor_To_BagSort.GetType(), bagSort);

            //Add checkIn3 -> conveyorToSecurity3 -> security 3 -> conveyorToBagSort -> bagSort
            Ll.AddNode(checkIn3);
            Ll.AddNode(checkIn3.Id, checkIn3.GetType(), CheckIn3_To_Security3_Conveyor);
            Ll.AddNode(CheckIn3_To_Security3_Conveyor.Id, CheckIn3_To_Security3_Conveyor.GetType(), security3);
            Ll.AddNode(security3.Id, security3.GetType(), security3_Conveyor_To_BagSort);
            Ll.AddNode(security3_Conveyor_To_BagSort.Id, security3_Conveyor_To_BagSort.GetType(), bagSort);

            //Add conveyorToTerminal1 -> terminal 1 ( -> conveyor to gate 1 to 5 -> gate 1 to 5)
            Ll.AddNode(bagSort.Id, bagSort.GetType(), bagSort_Conveyor_To_Terminal1);
            Ll.AddNode(bagSort_Conveyor_To_Terminal1.Id, bagSort_Conveyor_To_Terminal1.GetType(), terminal1);

            Ll.AddNode(terminal1.Id, terminal1.GetType(), terminal1_Conveyor_To_Gate1);
            Ll.AddNode(terminal1_Conveyor_To_Gate1.Id, terminal1_Conveyor_To_Gate1.GetType(), t1gate1);

            Ll.AddNode(terminal1.Id, terminal1.GetType(), terminal1_Conveyor_To_Gate2);
            Ll.AddNode(terminal1_Conveyor_To_Gate2.Id, terminal1_Conveyor_To_Gate2.GetType(), t1gate2);

            Ll.AddNode(terminal1.Id, terminal1.GetType(), terminal1_Conveyor_To_Gate3);
            Ll.AddNode(terminal1_Conveyor_To_Gate3.Id, terminal1_Conveyor_To_Gate3.GetType(), t1gate3);

            Ll.AddNode(terminal1.Id, terminal1.GetType(), terminal1_Conveyor_To_Gate4);
            Ll.AddNode(terminal1_Conveyor_To_Gate4.Id, terminal1_Conveyor_To_Gate4.GetType(), t1gate4);

            Ll.AddNode(terminal1.Id, terminal1.GetType(), terminal1_Conveyor_To_Gate5);
            Ll.AddNode(terminal1_Conveyor_To_Gate5.Id, terminal1_Conveyor_To_Gate5.GetType(), t1gate5);

            //Add conveyorToTerminal2 -> terminal 2 ( -> conveyor to gate 1 to 5 -> gate 1 to 5)
            Ll.AddNode(bagSort.Id, bagSort.GetType(), bagSort_Conveyor_To_Terminal2);
            Ll.AddNode(bagSort_Conveyor_To_Terminal2.Id, bagSort_Conveyor_To_Terminal2.GetType(), terminal2);

            Ll.AddNode(terminal2.Id, terminal2.GetType(), terminal2_Conveyor_To_Gate1);
            Ll.AddNode(terminal2_Conveyor_To_Gate1.Id, terminal2_Conveyor_To_Gate1.GetType(), t2gate1);

            Ll.AddNode(terminal2.Id, terminal2.GetType(), terminal2_Conveyor_To_Gate2);
            Ll.AddNode(terminal2_Conveyor_To_Gate2.Id, terminal2_Conveyor_To_Gate2.GetType(), t2gate2);

            Ll.AddNode(terminal2.Id, terminal2.GetType(), terminal2_Conveyor_To_Gate3);
            Ll.AddNode(terminal2_Conveyor_To_Gate3.Id, terminal2_Conveyor_To_Gate3.GetType(), t2gate3);

            Ll.AddNode(terminal2.Id, terminal2.GetType(), terminal2_Conveyor_To_Gate4);
            Ll.AddNode(terminal2_Conveyor_To_Gate4.Id, terminal2_Conveyor_To_Gate4.GetType(), t2gate4);

            Ll.AddNode(terminal2.Id, terminal2.GetType(), terminal2_Conveyor_To_Gate5);
            Ll.AddNode(terminal2_Conveyor_To_Gate5.Id, terminal2_Conveyor_To_Gate5.GetType(), t2gate5);
        }
        public void CreateMapLayoutThree(int queueSizeOfBelts)
        {
            //2 checkins per security 2 securities 1 bagsort 2 terminals with 2 gates each
        }
    }
}