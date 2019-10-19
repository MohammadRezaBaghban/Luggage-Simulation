using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class ConveyorNode : Node
    {
       
        public Conveyorbelt conveyor { get; private set; }
        public NextStop stopcheck;
        public Node endgate;
        public ConveyorNode(Conveyorbelt conveyorbelt)
        {
            this.conveyor = conveyorbelt;
        }
        public void setstop()
        {
            if (next is CheckpointNode)
            {
                if(((CheckpointNode)next).Checkpoint is Gate)
                {
                    this.stopcheck = NextStop.Gate;
                }
            }
            else
            {
                stopcheck = NextStop.Conveyor;
            }
        }
        public override string Nodeinfo()
        {
           return conveyor.ID.ToString() + ": "+ conveyor.ToString();
        }
    }
}
