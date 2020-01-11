using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Grid
    {
        List<Cell> grid_cells;
        public Grid(int rows, int cols)
        {
            grid_cells = new List<Cell>();

            Rows = rows;
            Cols = cols;
        }

        public int Rows { get; set; }
        public int Cols { get; set; }

        public void BuildGrid()
        {

        }

        public void Assign2DArray()
        {
            Grid[,] cell_grid = new Grid[Rows, Cols];
            for (int r = 0; r < Cols; ++r)
            {
                for (int c = 0; c < Rows; ++c)
                {
                    cell_grid[r, c] = new Grid(r, c);
                    grid_cells.Add(new Cell(r, c));
                }
            }
        }
    }
}
