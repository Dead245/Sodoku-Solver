using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    internal class Solver
    {
        public char[,] Solve(char[,] board) {
            char[,] solvedBoard = board;
            

            return solvedBoard;
        }

        private bool isValid(char[,] board,int x,int y,int z)
        {
            board[x, y] = (char) z;

            var rowSet = new HashSet<char>();
            var columnSet = new HashSet<char>();
            var boxSet = new HashSet<char>();
            for (int i = 0; i < 9; i++)
            {
                //Row Check
                if (!rowSet.Add(board[i, y]) && board[x, i] != ' ')
                {
                    return false;
                }
                //Column Check
                if (!columnSet.Add(board[x, i]) && board[i, y] != ' ')
                {
                    return false;
                }
                
            }
            rowSet.Clear();
            columnSet.Clear();
            boxSet.Clear();
            return true;
        }
    
    }
}
