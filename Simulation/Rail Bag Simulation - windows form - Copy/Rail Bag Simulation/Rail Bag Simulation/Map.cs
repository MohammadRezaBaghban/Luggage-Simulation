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
        public Node lastSecurity;
        public Node lastBagSort;
        public Node lastTerminal;


        public Map()
        {
            InitializeComponent();
            airport = new Airport(100);
            nodes = new List<Node>();
            curr = null;
            lastSecurity = null;
            lastBagSort = null;
            lastTerminal = null;

            CbToLastNode.Visible = false;
            groupBox1.Visible = false;
            TbTotalBags.Text = "100";
            TbCarts.Text = "3";
            TbFlammables.Text = "0";
            TbWeapons.Text = "0";
            TbDrugs.Text = "0";
            TbOthers.Text = "0";
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
                RbConveyor.Checked = true;
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

                lastSecurity = securityNode;
                curr = securityNode;

                RbSecurity.Checked = false;
                RbConveyor.Checked = true;
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

                lastBagSort = bagSortNode;
                curr = bagSortNode;

                RbSorter.Checked = false;
                RbConveyor.Checked = true;
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

                lastTerminal = terminalNode;
                curr = terminalNode;


                RbTerminal.Checked = false;
                RbConveyor.Checked = true;
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
                
                ConveyorHorizontal conveyor = new ConveyorHorizontal();
                conveyor.Location = new Point(cursorPosition.X, cursorPosition.Y);
                conveyor.Height = 90;
                conveyor.Width = 190;

                Controls.Add(conveyor);
                Node conveyorNode = airport.CreateConveyor();
                conveyor.SetConveyor((ConveyorNode)conveyorNode);
                airport.Ll.AddNode(curr.Id, curr.GetType(), conveyorNode);

                if (curr is CheckinNode)
                {
                    RbSecurity.Checked = true;
                }
                else if (curr is SecurityNode)
                {
                    RbSorter.Checked = true;
                }
                else if (curr is BagSortNode)
                {
                    RbTerminal.Checked = true;
                }
                else if (curr is TerminalNode)
                {
                    RbGate.Checked = true;
                }

                curr = conveyorNode;

                RbConveyor.Checked = false;
            }
            else if (RbConveyorToLastSecurity.Checked)
            {
                ConveyorVertical conveyor = new ConveyorVertical();
                conveyor.Location = new Point(cursorPosition.X, cursorPosition.Y);
                conveyor.Height = 190;
                conveyor.Width = 80;

                Controls.Add(conveyor);
                Node conveyorNode = airport.CreateConveyor();
                conveyor.SetConveyor((ConveyorNode)conveyorNode);
                airport.Ll.AddNode(lastSecurity.Id, lastSecurity.GetType(), conveyorNode);

                curr = conveyorNode;
                RbConveyorToLastSecurity.Checked = false;
                RbSorter.Checked = true;

            }
            else if (RbConveyorToLastBagSort.Checked)
            {
                ConveyorVertical conveyor = new ConveyorVertical();
                conveyor.Location = new Point(cursorPosition.X, cursorPosition.Y);
                conveyor.Height = 190;
                conveyor.Width = 80;

                Controls.Add(conveyor);
                Node conveyorNode = airport.CreateConveyor();
                conveyor.SetConveyor((ConveyorNode)conveyorNode);
                airport.Ll.AddNode(lastBagSort.Id, lastBagSort.GetType(), conveyorNode);

                curr = conveyorNode;

                RbConveyorToLastBagSort.Checked = false;
                RbTerminal.Checked = true;
            }
            else if (RbConveyorToLastTerminal.Checked)
            {
                ConveyorVertical conveyor = new ConveyorVertical();
                conveyor.Location = new Point(cursorPosition.X, cursorPosition.Y);
                conveyor.Height = 190;
                conveyor.Width = 80;

                Controls.Add(conveyor);
                Node conveyorNode = airport.CreateConveyor();
                conveyor.SetConveyor((ConveyorNode)conveyorNode);
                airport.Ll.AddNode(lastTerminal.Id, lastTerminal.GetType(), conveyorNode);

                curr = conveyorNode;

                RbConveyorToLastTerminal.Checked = false;
                RbGate.Checked = true;
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

        private void BtnStart_Click(object sender, EventArgs e)
        {
            int totalBags = Convert.ToInt32(TbTotalBags.Text);
            int carts = Convert.ToInt32(TbCarts.Text);

            int flammables = Convert.ToInt32(TbFlammables.Text);
            int weapons = Convert.ToInt32(TbWeapons.Text);
            int drugs = Convert.ToInt32(TbDrugs.Text);
            int others = Convert.ToInt32(TbOthers.Text);

            //Map the conveyors??
            airport.StartBagsMovement(totalBags, drugs, weapons, flammables, others);
        }


        public void Update(ConveyorNode conveyorNodeBackend, IConveyor frontEnd)
        {
            if (LinkedList.IsSimulationFinished) return;
            var ls = conveyorNodeBackend.ListOfBagsInQueue.ToArray();
            if (conveyorNodeBackend.ListOfBagsInQueue.Count > 0)
            {
                for (var j = 0; j < ls.Length; j++)
                {
                    frontEnd.slots[j].Visible = ls[j] != null;
                }


                label1.Text = (GateNode.Counter).ToString();
                if ((Airport.TotalNumberOfBags != GateNode.Counter + Storage.GetNumberOfBagsInStorage())) return;

            }
        }

        private void CbToLastNode_CheckedChanged(object sender, EventArgs e)
        {
            if ( CbToLastNode.Checked == true)
            {
                groupBox1.Visible = true;
                RbConveyor.Checked = false;

            }
            else 
            { 
                groupBox1.Visible = false;
                RbConveyor.Checked = true;

            }

        }

        private void RbConveyor_CheckedChanged(object sender, EventArgs e)
        {
            if (RbConveyor.Checked)
            {
                CbToLastNode.Visible = true;
            }
            else
            {
                CbToLastNode.Visible = false;
            }

        }
    }
}
