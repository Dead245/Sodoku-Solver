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
        public bool validateNewBoard(List<string> board) {
            
            
            //x is column | y is row

            //Checks Rows
            for (int y = 0; y < 9; y++)
            {
                HashSet<string> rowVal = new HashSet<string>();
                for (int x = 0; x < 9; x++)
                {
                    int position = (y * 9) + x;
                    if (!rowVal.Add(board[position]) && board[position] != "") {
                        return false;
                    }
                }
                
            }

            //Checks Columns
            for (int y = 0; y < 9; y++)
            {
                HashSet<string> rowVal = new HashSet<string>();
                for (int x = 0; x < 9; x++)
                {
                    int position = (x * 9) + y;
                    if (!rowVal.Add(board[position]) && board[position] != "")
                    {
                        return false;
                    }
                }

            }

            //Checks Grids
            for (int i = 1; i <= 9; i++)
            {
                checkSubGrid(i);
            }


            return true;
        }

        private bool checkSubGrid(int subGridNum) {
            double gridPoint;
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
