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

        public delegate void UpdateControlsDelegate(object o, EventArgs eventArgs);

        public void InvokeUpdateControls(object sender, EventArgs eventArgs)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlsDelegate(UpdateTheConveyor));
            }
            else
            {
                UpdateTheConveyor(this, EventArgs.Empty);
            }
        }

        public void UpdateTheConveyor(object o, EventArgs eventArgs)
        {
            /*lock (conveyor.ListOfBagsInQueue)
            {
                /*for (var i = 0; i < conveyor.ListOfBagsInQueue.ToList().Count; i++)
                { 
                   slots[i].Visible = conveyor.ListOfBagsInQueue.ToList()[i] != null;
                }#1#

               
            }*/
            ((Simulation) Parent).Update(conveyor);
        }
    }
}