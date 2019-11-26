using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Rail_Bag_Simulation.ViewModel;

namespace Rail_Bag_Simulation.View
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            var vm = new LoggerControlViewModel();
            vm.StartSimulation(43);
            var timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0,0,500)};
            timer.Tick += (sender, args) => {
                lbLog.Items.Clear();
                    LinkedList.GetAllNodes()
                        .ForEach(p => p.NodeInfo()
                            .ForEach(s => lbLog.Items.Add(s)));


                    lbLog.Items.Add("*** Bags In Storage ***");
                    Airport.Storage.GetAllSuspiciousBags().ForEach(
                        bag => {
                            lbLog.Items.Add(bag.GetBagInfo());

                        });
                    lbLog.SetSelected(lbLog.Items.Count-1,true);
                };
            timer.Start();
            TerminalNode.SimulationFinishedEvent += (sender, args) =>
            {
                Thread.Sleep(1000);
                timer.Stop();
            };
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
