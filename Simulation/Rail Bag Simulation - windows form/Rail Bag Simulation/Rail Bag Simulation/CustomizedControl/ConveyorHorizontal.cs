using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.View.UserControls;

namespace Rail_Bag_Simulation.CustomizedControl
{
    public partial class ConveyorHorizontal : UserControl, IConveyor
    {
        private ConveyorNode conveyor;
        public List<PictureBox> slots { get; set; }

        public ConveyorHorizontal()
        {
            InitializeComponent();
            slots = new List<PictureBox>
            {
                Slot1,
                Slot2,
                Slot3,
                Slot4,
                Slot5
            };
        }

        public void SetConveyor(ConveyorNode cn)
        {
            conveyor = cn;
            conveyor.OnQueueChangedEventHandler += InvokeUpdateControls;
        }

        public delegate void UpdateControlsDelegate();

        public void InvokeUpdateControls(object sender, EventArgs eventArgs)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlsDelegate(UpdateTheConveyor));
            }
            else
            {
                UpdateTheConveyor();
            }
        }

        public void UpdateTheConveyor()
        {
            
            ((Simulation) Parent).Update(conveyor, this);
            
        }

        private void Slot3_Click(object sender, EventArgs e)
        {

        }
    }
}