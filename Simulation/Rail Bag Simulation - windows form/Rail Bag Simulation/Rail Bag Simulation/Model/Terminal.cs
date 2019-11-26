namespace Rail_Bag_Simulation
{
    class Terminal
    {
        private static int _terminalIdNext = 0;

        public Terminal()
        {
            TerminalId= ++_terminalIdNext;
        }

        public int TerminalId { get; }

    }
}
