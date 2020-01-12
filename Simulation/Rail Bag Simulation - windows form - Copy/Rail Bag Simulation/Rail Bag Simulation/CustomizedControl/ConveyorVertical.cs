using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.View.UserControls;

namespace Rail_Bag_Simulation.CustomizedControl
{
    public partial class ConveyorVertical : UserControl, IConveyor
    {
        private ConveyorNode conveyor;
        public List<PictureBox> slots { get; set; }


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


        public delegate void UpdateControlsDelegate();

        public void InvokeUpdateControls(object sender, EventArgs eventArgs)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ConveyorHorizontal.UpdateControlsDelegate(UpdateTheConveyor));
            }
            else
            {
                UpdateTheConveyor();
            }
        }

        public void UpdateTheConveyor()
        {
          lock (conveyor.ListOfBagsInQueue)
            {
                ((Map) Parent).Update(conveyor, this);
            }

        }
    }
}