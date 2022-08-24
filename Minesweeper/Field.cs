using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper
{
    public class Field : Button
    {

        private bool isBomb;
        private bool isFlagged;

        private Grid grid;

        private Field UpperLeft;
        private Field Upper;
        private Field UpperRight;
        private Field Left;
        private Field Right;
        private Field LowerLeft;
        private Field Lower;
        private Field LowerRight;

        public Field(bool isBomb, Grid grid)
        {
            this.grid = grid;
            this.isBomb = isBomb;
        }

        public void registerSurroundingFields(int x, int y)
        {

            

        }

    }
}
