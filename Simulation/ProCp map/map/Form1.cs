using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace map
{
    public partial class Form1 : Form
    {
        //Grid grid;
        List<Cell> cellList;
        //List<Drawing> drawings;
        Part selectedPiece;

        int rows;
        int columns;
        //float cellWidth;
        //float cellHeight;

        public Form1()
        {
            InitializeComponent();
            DeactivateRadioButtons();

            cellList = new List<Cell>();
            selectedPiece = Part.EMPTY;
            //cellWidth = (float)this.ClientSize.Width / cols;
            //cellHeight = (float)this.ClientSize.Height / rows;
            //grid = new Grid(rows, cols);
        }


        private void BtnGenerateMap_Click(object sender, EventArgs e)
        {
            rows = (int)NudGridSize.Value;
            columns = (int)NudGridSize.Value;
            InitializeGrid(rows, columns);
            ActivateRadioButtons();
        }

        private void ActivateRadioButtons()
        {
            RbCheckIn.Enabled = true;
            RbGate.Enabled = true;
            RbSecurity.Enabled = true;
            RbTerminal.Enabled = true;
            RbConveyor.Enabled = true;
            RbEmpty.Enabled = true;
        }

        private void DeactivateRadioButtons()
        {
            RbCheckIn.Enabled = false;
            RbGate.Enabled = false;
            RbSecurity.Enabled = false;
            RbTerminal.Enabled = false;
            RbConveyor.Enabled = false;
            RbEmpty.Enabled = false;

        }

        private void InitializeGrid(int nRows, int nColumns)
        {
            gridView.Columns.Clear();
            gridView.ReadOnly = true;
            gridView.BackgroundColor = Color.White;
            gridView.DefaultCellStyle.BackColor = Color.White;
            gridView.Visible = true;

            //adds columns to the grid
            for (int i = 0; i < nColumns; i++)
            {
                gridView.Columns.Add("column " + (i + 1).ToString(), "");
            }
            //adds rows to the grid
            for (int i = 0; i < nRows; i++)
            {
                gridView.Rows.Add();
            }
            //defines size of col
            foreach (DataGridViewColumn c in gridView.Columns)
            {
                c.Width = gridView.Width / gridView.Columns.Count;
            }
            //defines size of row
            foreach (DataGridViewRow r in gridView.Rows)
            {
                r.Height = gridView.Height / gridView.Rows.Count;
            }
            //stores cells in the list based on x and y
            Cell[,] cell_grid = new Cell[rows, columns];
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    Cell c = new Cell(i, j);
                    cell_grid[i, j] = new Cell(i, j);
                    cellList.Add(c);
                }
            }
            
        }


        private Cell GetCell(int row, int column)
        {
            foreach (Cell cell in this.cellList)
            {
                if (cell.Row == row && cell.Column == column)
                {
                    return cell;
                }
            }
            return null;
        }

        private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cell currCell = GetCell(e.RowIndex, e.ColumnIndex);
            Part currentPart = currCell.part;
            Color newColor;
            string part = "CheckIn";

            switch (selectedPiece)
            {
                case Part.CHECKIN:
                    newColor = Color.Green;
                    part = "CheckIn";
                    break;
                case Part.CONVEYORLINE:
                    newColor = Color.Blue;
                    part = "ConveyorLine";
                    break;
                case Part.SECURITY:
                    newColor = Color.Red;
                    part = "Security";
                    break;
                case Part.TERMINAL:
                    newColor = Color.DarkCyan;
                    part = "Terminal";
                    break;
                case Part.GATE:
                    newColor = Color.LightCyan;
                    part = "Gate";
                    break;
                case Part.EMPTY:
                    newColor = Color.White;
                    part = "Empty";
                    break;
                default:
                    newColor = Color.White;
                    break;
            }

            currCell.Type = part; 
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = newColor;
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = newColor;

            MessageBox.Show(currCell.Type);
        }

        private void RbCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            selectedPiece = Part.CHECKIN;
        }
        private void RbSecurity_CheckedChanged(object sender, EventArgs e)
        {
            selectedPiece = Part.SECURITY;

        }
        private void RbTerminal_CheckedChanged(object sender, EventArgs e)
        {
            selectedPiece = Part.TERMINAL;

        }
        private void RbGate_CheckedChanged(object sender, EventArgs e)
        {
            selectedPiece = Part.GATE;

        }
        private void RbConveyor_CheckedChanged(object sender, EventArgs e)
        {
            selectedPiece = Part.CONVEYORLINE;

        }
        private void RbEmpty_CheckedChanged(object sender, EventArgs e)
        {
            selectedPiece = Part.EMPTY;

        }
    }
}
