namespace Rail_Bag_Simulation
{
    public class Terminal
    {
        public static int _terminalIdNext;

        public Terminal()
        {
            TerminalId = ++_terminalIdNext;
        }

        public int TerminalId { get; }
    }
}