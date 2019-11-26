using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Rail_Bag_Simulation
{
    public partial class LogControl : UserControl
    {
        public LogControl()
        {
            InitializeComponent();
          
           
            Timer timer=new Timer(1000);
            timer.Enabled = true;
            timer.Elapsed += (sender, args) => { lbLog.Items.Clear(); };
            timer.Start();
        }

        private void lbLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
