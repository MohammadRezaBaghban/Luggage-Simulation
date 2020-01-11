using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rail_Bag_Simulation
{
    class Cell
    {
        public Part part;
        public Cell(int row, int col)
        {
            //SetWidthAndHeigth(width, heigth);
            Column = col;
            Row = row;
            part = Part.EMPTY;
        }

        public int Column { get; set; }
        public int Row { get; set; }
        public float CellWidth { get; set; }
        public float CellHeigth { get; set; }
        public string Type { get; set; }


        public void SetWidthAndHeigth(float width, float heigth)
        {
            CellWidth = width;
            CellHeigth = heigth;
        }
    }
}
