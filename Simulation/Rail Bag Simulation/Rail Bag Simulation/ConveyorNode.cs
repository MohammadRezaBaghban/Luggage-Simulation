﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class ConveyorNode : Node
    {
       
        public Conveyorbelt Conveyor { get; private set; }

        public NextStop Nextstop => _nextstop;

        private NextStop _nextstop;
        public Node Endgate;
        public ConveyorNode(Conveyorbelt conveyorbelt)
        {
            this.Conveyor = conveyorbelt;
        }
        public void Setstop()
        {
            if (Next is CheckpointNode)
            {
                if(((CheckpointNode)Next).Checkpoint is Gate)
                {
                    this._nextstop = NextStop.Gate;
                }
            }
            else
            {
                _nextstop = NextStop.Conveyor;
            }
        }
        public override string Nodeinfo()
        {
           return Conveyor.Id.ToString() 
               + ": "+ Conveyor.ToString();
        }
    }
}
