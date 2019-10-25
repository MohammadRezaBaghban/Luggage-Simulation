using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class TerminalNode : Node
    {
        public Terminal Terminal { get; private set; }
        private List<Bag>SuccessfulBags;
        public TerminalNode(Node parentNode,Terminal ts):base(parentNode)
        {
            SuccessfulBags = new List<Bag>();
            Terminal = ts;
        }

        public void AddBags(Bag s)
        {

            SuccessfulBags.Add(s);
        }
        public override string Nodeinfo()
        {
            string sender = "Terminal: " + Terminal.TerminalId.ToString();
            foreach (Bag g in SuccessfulBags)
            {
                sender += g.GetBagInfo();
            }
            
        }
    }
}
