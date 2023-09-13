using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    internal class Solver
    {
        public char[,] Solve(char[,] board)
        {
            if (board == null) return null;
            backtrack(board, 0, 0);
            return board;
        }
        private bool backtrack(char[,] board, int x, int y)
        {
            if (y == 9) {
                y = 0;
                x++;
                if (x == 9) {
                    return true;
                }
            }

            if (board[x,y] != ' ')
                return backtrack(board, x, y + 1);

            for (char z = '1'; z <= '9'; z++)
            {
                if (isValid(board, x, y, z))
                {
                    board[x,y] = z;
                    if (backtrack(board, x, y + 1)) {
                        return true;
                    }
                    else board[x,y] = ' ';
                }
            }

            return false;
        }
        private bool isValid(char[,] board, int x, int y, char val)
        {

            //Check if value is present in the row
            for (int i = 0; i < 9; i++) {
                if (board[x, i] == val) { 
                    return false;
                }
            }

            //Check if value is present in column
            for (int j = 0; j < 9; j++) {
                if (board[j, y] == val) {
                    return false;
                }
            }

            //Check for the value in subgrid
            int subX = x / 3;
            int subY = y / 3;
            for (int a = 0; a < 3; a++) {
                for (int b = 0; b < 3; b++) {
                    if (val == board[3 * subX + a, 3 * subY + b]){
                        return false;
                    }
                }
            }

            return true;

        }

    }
}
