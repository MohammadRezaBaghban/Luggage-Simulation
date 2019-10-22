using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class BagSortNode : Node
    {
        

        public BagSortNode()
        {
            DelayTime = 10;
        }

        public Bag SortBag(Bag g)
        {
            if (true)
            {
                
            }
        }

        private Node determineNextNode(Bag g)
        {

            ListOfConnectedNodes.ForEach(p=>
            {
                if (p is ConveyorNode node)
                {
                    if(node.Conveyor.)
                }
            });
        }


        public override string Nodeinfo()
        {
            throw new NotImplementedException();
        }
    }
}