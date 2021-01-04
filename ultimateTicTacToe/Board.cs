using System;
namespace ultimateTicTacToe
{
    public class Board
    {

        private Cell[,] board = new Cell[3, 3];

        public char this[int row, int col]
        {  
            get
            { 
                return board[row, col].Val;
            }
            set
            {
                board[row, col].Val = value;                 
            }

        }

        public Board() {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = new Cell();
        }

    }
}
