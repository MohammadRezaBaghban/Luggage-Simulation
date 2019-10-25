using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class BagSortNode : Node
    {
        

        public BagSortNode()
        {
            DelayTime = 10;
        }

        public void PassBag(Bag g)
        {
            ((ConveyorNode) determineNextNode(g)).Conveyor.Push(g);
            Thread.Sleep(DelayTime);
        }

        private Node determineNextNode(Bag g)
        {
            Node tnode = null;
            ListOfConnectedNodes.ForEach(p=>
            {
                if (!(p is ConveyorNode node)) return;
                if (!(node.Next is TerminalNode terminalNode)) return;
                
                
                String St = g.TerminalAndGate;
                int pFrom = St.IndexOf("T") + "T".Length;
                int pTo = St.LastIndexOf("G");
                var result = St.Substring(pFrom, pTo - pFrom);
                
                if (terminalNode.Terminal.TerminalId.ToString() == result)
                {
                    tnode= node;
                }
            });
            return tnode;
        }


        public override string Nodeinfo()
        {
            throw new NotImplementedException();
        }
    }
}