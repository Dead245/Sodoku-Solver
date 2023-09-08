using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SodokuSolver
{
    internal class Validator
    {
        //Find all # in board and check to see if any overlap the row, column, or 3x3 grid
        public bool validateNewBoard(char[,] board) {


            //Check Rows & Columns & Subgrids for Duplicate Numbers
            var rowSet = new HashSet<char>();
            var columnSet = new HashSet<char>();
            var boxSet = new HashSet<char>();
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {       //Row Check
                    if (!rowSet.Add(board[x,y]) && board[x,y] != ' ') {
                        return false;
                    }   //Column Check
                    if (!columnSet.Add(board[y,x]) && board[y,x] != ' ') {
                        return false;
                    }   //Subgrid Check
                    if (!boxSet.Add(board[(int)(3 * Math.Floor(y / 3.0) + Math.Floor(x / 3.0)), ((y * 3) % 9) + (x % 3)]) && 
                        board[(int)(3 * Math.Floor(y / 3.0) + Math.Floor(x / 3.0)), ((y * 3) % 9) + (x % 3)] != ' ') {
                        return false;
                    }
                }
                rowSet.Clear();
                columnSet.Clear();
                boxSet.Clear();
            }

            


            return true;
        }

        //Assuming row/column starts as a range of 0-8
        private int findSubGrid(int column, int row) {
            //Gives what % of 9 is each int
            column = column / 9;
            row = row / 9;

            //Checks where the % lies and sets it to that range of 1/2/3
            switch (column) {
                case int n when (n < 0.33):
                    column = 1;
                    break;

                case int n when (n >= 0.33 && n < 0.66):
                    column = 2;
                    break;

                case int n when (n < 1):
                    column = 3;
                    break;
            }

            switch (row)
            {
                case int n when (n < 0.33):
                    row = 1;
                    break;

                case int n when (n >= 0.33 && n < 0.66):
                    row = 2;
                    break;

                case int n when (n < 1):
                    row = 3;
                    break;
            }

            return ((row - 1) * 3) + column;
        }
    
    }
}
