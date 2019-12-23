namespace Rail_Bag_Simulation
{
    public class Terminal
    {
        private static int _terminalIdNext;

        public Terminal()
        {
            TerminalId = ++_terminalIdNext;
        }

        public int TerminalId { get; }
    }
}