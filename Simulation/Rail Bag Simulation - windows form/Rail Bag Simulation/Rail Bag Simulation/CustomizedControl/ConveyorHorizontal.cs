using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                if (Parent is Simulation2 parent2)
                {
                    (parent2).Update(conveyor, this);
                }
                else if (Parent is Simulation parent1)
                {
                    (parent1).Update(conveyor, this);
                }
            }

        }
        public void initializeSlots()
        {
            slots = new List<PictureBox>
            {
                Slot1,
                Slot2,
                Slot3,
                Slot4,
                Slot5
            };
        }

        private void Slot3_Click(object sender, EventArgs e)
        {

        }
    }
}