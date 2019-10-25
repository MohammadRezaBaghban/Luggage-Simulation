using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Terminal
    {
        private readonly char _terminalId;

        public Terminal(char terminalId)
        {
            _terminalId = terminalId;
        }

        public char TerminalId => _terminalId;

    }
}
