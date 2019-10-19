using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class CheckpointNode : Node
    {

        private object _checkpoint;
         public Bag bagtocheck { get; private set; }
        public object Checkpoint { get { return _checkpoint; } 
            private set { if (!(value is Conveyorbelt)) 
                { _checkpoint = value; } 
                else
                { 
                    throw new Exception("This node cannot store conveyorbelts"); 
                }
            } 
        }
        public CheckpointNode(object checkpoint) : base()
        {
            this.Checkpoint = checkpoint;
            
        }
        public void setBag(Bag g)
        {
            this.bagtocheck = g;
        }
        public override string Nodeinfo()
        {
            return "("+ _checkpoint.ToString()+")Bag in checkpoint: " +bagtocheck;
        }
    }
}
