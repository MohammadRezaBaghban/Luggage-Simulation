namespace Rail_Bag_Simulation.ViewModel
{
    internal class LoggerControlViewModel
    {
        public static int NumberOfBags;

        public static LinkedList LL => Airport.Ll;

        public static Airport Airport { get; private set; }

        public void StartSimulation(int totalbags, int delayTime)
        {
            NumberOfBags = totalbags;
            Airport = new Airport(delayTime);
            CreateMap(5);
            Airport.StartBagsMovement(totalbags, 25, 0, 0, 0);
            Airport.Ll.MoveBags();
        }

        public void CreateMap(int m)
        {
            Airport.CreateMapLayout(m);
        }
    }
}