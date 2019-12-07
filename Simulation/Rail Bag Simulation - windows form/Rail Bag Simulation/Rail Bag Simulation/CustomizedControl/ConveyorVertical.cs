using System.Collections.Generic;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.CustomizedControl
{
    public partial class ConveyorVertical : UserControl
    {
        private List<PictureBox> slots;
        private ConveyorNode conveyor;
        public ConveyorVertical()
        {
            InitializeComponent();
            slots = new List<PictureBox>
            {
                slot1Vert,
                slot2Vert,
                slot3Vert,
                slot4Vert,
                slot5Vert,
            };
        }

        public void SetConveyor(ConveyorNode cn)
        {
            conveyor = cn;
        }

        public void UpdateTheConveyor(List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
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
