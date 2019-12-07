using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Rail_Bag_Simulation.CustomizedControl
{
    public partial class ConveyorVertical : UserControl, IConveyor
    {
        private ConveyorNode conveyor;
        public readonly List<PictureBox> slots;

        public ConveyorVertical()
        {
            InitializeComponent();
            slots = new List<PictureBox>
            {
                slot1Vert,
                slot2Vert,
                slot3Vert,
                slot4Vert,
                slot5Vert
            };
        }

        public void SetConveyor(ConveyorNode cn)
        {
            conveyor = cn;
            conveyor.OnQueueChangedEventHandler += InvokeUpdateControls;
        }

        public delegate void UpdateControlsDelegate(object o, EventArgs eventArgs);

        public void InvokeUpdateControls(object sender, EventArgs eventArgs)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ConveyorHorizontal.UpdateControlsDelegate(UpdateTheConveyor));
            }
            else
            {
                UpdateTheConveyor(this, EventArgs.Empty);
            }
        }

        public void UpdateTheConveyor(object o, EventArgs eventArgs)
        {
            lock (conveyor.ListOfBagsInQueue)
            {
                for (var i = 0; i < conveyor.ListOfBagsInQueue.ToList().Count; i++)
                {
                    slots[i].Visible = conveyor.ListOfBagsInQueue.ToList()[i] != null;
                }
            }
        }
    }
}