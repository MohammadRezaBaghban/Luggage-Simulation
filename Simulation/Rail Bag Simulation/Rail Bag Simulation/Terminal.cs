using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Terminal
    {
        private char _terminalID;

        public Terminal(char terminalId)
        {
            _terminalID = terminalId;
        }

        public char TerminalId => _terminalID;

    }
}
