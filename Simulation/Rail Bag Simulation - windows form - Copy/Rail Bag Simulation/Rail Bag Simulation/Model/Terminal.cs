namespace Rail_Bag_Simulation
{
    internal class Terminal
    {
        private static int _terminalIdNext;

        public Terminal()
        {
            TerminalId = ++_terminalIdNext;
        }

        public int TerminalId { get; }
    }
}