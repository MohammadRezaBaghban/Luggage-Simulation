using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.CustomizedControl
{

    public partial class Conveyor : UserControl
    {
        private List<PictureBox> slots;
        private ConveyorNode conveyor;
        
        public Conveyor()
        {
            InitializeComponent();
            slots = new List<PictureBox>
            {
                Slot1,
                Slot2,
                Slot3,
                Slot4,
                Slot5,
            };
        }

        public void SetConveyor(ConveyorNode cn)
        {
            conveyor = cn;
        }

        public void UpdateTheConveyor(List<Node> nodes)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i] == null)
                {
                    slots[i].Visible = false;
                }
                else
                {
                    slots[i].Visible = true;
                }
            }
        }
    }
}
