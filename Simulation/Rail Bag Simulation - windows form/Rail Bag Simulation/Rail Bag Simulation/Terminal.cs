using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Terminal
    {
        private readonly string _terminalId;

        public Terminal(string terminalId)
        {
            _terminalId = terminalId;
        }

        public string TerminalId => _terminalId;
    }
}
