using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.CustomizedControl
{
    public partial class ConveyorHorizontal : UserControl
    {
        private ConveyorNode conveyor;
        private readonly List<PictureBox> slots;

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
            conveyor.OnQueueChangedEventHandler += UpdateTheConveyor;
        }

        public void UpdateTheConveyor(Object o, EventArgs eventArgs)
        {
            lock (conveyor.ListOfBagsInQueue)
            {
                for (var i = 0; i < conveyor.ListOfBagsInQueue.ToList().Count; i++)
                    slots[i].Visible = conveyor.ListOfBagsInQueue.ToList()[i] != null;
            }
        }
    }
}