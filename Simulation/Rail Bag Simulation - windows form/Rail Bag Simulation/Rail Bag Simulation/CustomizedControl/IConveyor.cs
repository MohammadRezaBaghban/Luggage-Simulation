using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.CustomizedControl
{
    public interface IConveyor
    {
        void SetConveyor(ConveyorNode cn);

        List<PictureBox> slots { get; set; }
    }
}
