using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Rail_Bag_Simulation
{
    class CheckinNode : Node
    {
        public override string NodeInfo()
        {
            string sender = "Check in: \n"+ base.NodeInfo();
            return sender;
        }

        public int QueueCount => BagsQueue.Count;
        internal bool IsEmpty()
        {
            lock (BagsQueue)
            {
                return QueueCount < 1;
            }
        }
    }
}
