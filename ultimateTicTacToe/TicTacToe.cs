using System;
namespace ultimateTicTacToe
{
    public class TicTacToe
    {

        public Board gameBoard;
        private int movesCounter;
        private char winner;
        
        private int setedCellRowOfCurrentMove;
        private int setedCellColOfCurrentMove;

        public char Winner { get => winner; set => winner = value; }
       
        public TicTacToe() {
            gameBoard = new Board();
            movesCounter = 0;
            winner = ' ';
        }

        public bool IsPlayerWinning(char playerSymbol)
        {
            return this.IsPlayerWinning(this.gameBoard, playerSymbol);
        }

        public bool IsPlayerWinning(Board board, char playerSymbol)
        {
            return
                IsPlayerWinningDiagon(board, playerSymbol) ||
                IsPlayerWinningRow(board, playerSymbol, 0) ||
                IsPlayerWinningRow(board, playerSymbol, 1) ||
                IsPlayerWinningRow(board, playerSymbol, 2) ||
                IsPlayerWinningCol(board, playerSymbol, 0) ||
                IsPlayerWinningCol(board, playerSymbol, 1) ||
                IsPlayerWinningCol(board, playerSymbol, 2);
            /*int differanceBetweenLastSetedCellIndxes = Math.Abs(setedCellRowOfCurrentMove - setedCellColOfCurrentMove);
            bool lastSetedCellIsOnDiagon = (differanceBetweenLastSetedCellIndxes == 0 || differanceBetweenLastSetedCellIndxes == 2);

            if (lastSetedCellIsOnDiagon)
            {
                return IsPlayerWinningDiagon(playerSymbol, gameBoard);
            }
            return IsPlayerWinningRow(setedCellRowOfCurrentMove, playerSymbol, gameBoard) ||
                IsPlayerWinningCol(setedCellColOfCurrentMove, playerSymbol, gameBoard);*/
        
        }
        
        public void SetCell(char playerSymbol, int cell)
        {
            this.SetCell(this.gameBoard, playerSymbol, cell/3, cell%3);
        }

        public void SetCell(Board board, char playerSymbol, int row, int col)
        {
            board[row, col] = playerSymbol;
        }

        public bool IsBoardFull()
        {
            return IsBoardFull(this.gameBoard);
        }


        public bool IsBoardFull(Board board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j] == ' ')
                        return false;
            return true;

        }

        public bool IsPlayerWinningDiagon(Board board, char playerSymbol)
        {
            return board[0, 0] == playerSymbol && board[1, 1] == playerSymbol && board[2, 2] == playerSymbol ||
                board[0, 2] == playerSymbol && board[1, 1] == playerSymbol && board[2, 0] == playerSymbol;
        }

        public bool IsPlayerWinningRow(Board board, char playerSymbol, int row)
        {
            try
            {
                if (board[row, 0] == playerSymbol && board[row, 1] == playerSymbol && board[row, 2] == playerSymbol)
                    return true;
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool IsPlayerWinningCol(Board board, char playerSymbol, int col)
        {
            try
            {
                if (board[0, col] == playerSymbol && board[1, col] == playerSymbol && board[2, col] == playerSymbol)
                    return true;
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        /*

        public void SetCell(int row, int col, Symbol symbol)
        {
            gameBoard[row, col] = symbol;
            setedCellRowOfCurrentMove = row;
            setedCellColOfCurrentMove = col;
        }

      
    */
    }
}
