using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.View.UserControls;

namespace Rail_Bag_Simulation.CustomizedControl
{
    [Serializable]
    public partial class ConveyorVertical : UserControl, IConveyor
    {
        private ConveyorNode conveyor;
        public List<PictureBox> slots { get; set; }


        public ConveyorVertical()
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
        public void initializeSlots()
        {
            slots = new List<PictureBox>
            {
                slot1Vert,
                slot2Vert,
                slot3Vert,
                slot4Vert,
                slot5Vert
            };
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
    }
}