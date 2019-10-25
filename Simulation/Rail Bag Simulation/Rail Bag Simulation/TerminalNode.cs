using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {
        public Terminal Terminal { get; set; }
        private List<Node> _listOfConnectedNodes = new List<Node>();
        public List<Node> ListOfConnectedNodes => _listOfConnectedNodes;

        public override string Nodeinfo()
        {
            throw new NotImplementedException();
        }
    }
}
