using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rail_Bag_Simulation.CustomizedControl;

namespace Rail_Bag_Simulation
{
    public partial class Map : Form
    {
        Airport airport;
        public List<IConveyor> conveyors;
        public List<Node> nodes;
        public Node curr;
        public Map()
        {
            InitializeComponent();
            airport = new Airport(100);
            nodes = new List<Node>();
            curr = null;
        }

        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            var cursorPosition = this.PointToClient(Cursor.Position);
            

            if (RbCheckIn.Checked)
            {
                PictureBox checkIn = new PictureBox();
                checkIn.Image = Properties.Resources.check_in;
                checkIn.SizeMode = PictureBoxSizeMode.StretchImage;
                checkIn.Location = new Point(cursorPosition.X, cursorPosition.Y);
                checkIn.Height = 90;
                checkIn.Width = 70;

                Controls.Add(checkIn);
                Node checkInNode = airport.CreateCheckIn();
                //nodes.Add(checkInNode);
                curr = checkInNode;
                airport.Ll.AddNode(checkInNode);

                RbCheckIn.Checked = false;
            }
            else if (RbSecurity.Checked)
            {
                PictureBox security = new PictureBox();
                security.Image = Properties.Resources.securityCheckHouse;
                security.SizeMode = PictureBoxSizeMode.StretchImage;
                security.Location = new Point(cursorPosition.X, cursorPosition.Y);
                security.Height = 90;
                security.Width = 70;

                Controls.Add(security);
                Node securityNode = airport.CreateSecurity();
                airport.Ll.AddNode(curr.Id, curr.GetType(), securityNode);

                curr = securityNode;


                RbSecurity.Checked = false;
            }
            else if (RbSorter.Checked)
            {
                PictureBox sorter = new PictureBox();
                sorter.Image = Properties.Resources.sorter1;
                sorter.SizeMode = PictureBoxSizeMode.StretchImage;
                sorter.Location = new Point(cursorPosition.X, cursorPosition.Y);
                sorter.Height = 90;
                sorter.Width = 70;

                Controls.Add(sorter);
                Node bagSortNode = airport.CreateBagSort();
                airport.Ll.AddNode(curr.Id, curr.GetType(), bagSortNode);

                curr = bagSortNode;

                RbSorter.Checked = false;
            }
            else if (RbTerminal.Checked)
            {
                PictureBox terminal = new PictureBox();
                terminal.Image = Properties.Resources.terminal;
                terminal.SizeMode = PictureBoxSizeMode.StretchImage;
                terminal.Location = new Point(cursorPosition.X, cursorPosition.Y);
                terminal.Height = 90;
                terminal.Width = 70;

                Controls.Add(terminal);
                Node terminalNode = airport.CreateTerminal();
                airport.Ll.AddNode(curr.Id, curr.GetType(), terminalNode);

                curr = terminalNode;


                RbTerminal.Checked = false;
            }
            else if (RbGate.Checked)
            {
                PictureBox gate = new PictureBox();
                gate.Image = Properties.Resources.gate;
                gate.SizeMode = PictureBoxSizeMode.StretchImage;
                gate.Location = new Point(cursorPosition.X, cursorPosition.Y);
                gate.Height = 90;
                gate.Width = 70;

                Controls.Add(gate);
                Node gateNode = airport.CreateGate();
                airport.Ll.AddNode(curr.Id, curr.GetType(), gateNode);

                curr = gateNode;


                RbGate.Checked = false;
            }
            else if (RbConveyor.Checked)
            {
                //ConveyorVertical conveyor = new ConveyorVertical();

                //Controls.Add(conveyor);


                RbConveyor.Checked = false;
            }
        }

        private void Map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Doesn't work right now
            Point p = PointToClient(MousePosition);
            this.Controls.Remove(GetChildAtPoint(p));
            GetChildAtPoint(p).Dispose();

            this.Refresh();
        }
    }
}
