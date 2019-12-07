﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rail_Bag_Simulation.CustomizedControl
{
    public partial class ConveyorVertical : UserControl
    {
        private ConveyorNode conveyor;
        private readonly List<PictureBox> slots;

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