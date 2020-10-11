using System;
namespace ultimateTicTacToe
{
    public class TicTacToe
    {
        private char[,] board = new char[3, 3];

        public char player { set; get; }
        public char winner { set; get; }
        public int countMoves { set; get; }


        public TicTacToe(char starterPlayer)
        {
            player = starterPlayer;
            countMoves = 0;
            InitializeBoard();
        }

        public TicTacToe()
        {
            player = 'X';
            countMoves = 0;
            InitializeBoard();
        }

        public void RunGame()
        {
            Print();
            while (countMoves!=9)
            {
                MakeMove(player);
                Console.Clear();
                Print();
                if (Win())
                {
                    Console.WriteLine($"{player} has won the game!!");
                    winner = player;
                    break;
                }
                SwichTurn();
            }
            Console.WriteLine("DROW!!");
        }

        public void MakeMove(char currentPlayer)
        {
            int row;
            int col;
            bool setSucceed;
            while (true)//while setBoardAtPosition didn't succeed
            {

                row = GetRowFromUsr();
                col = GetColFromUsr();

                setSucceed = SetBoardAtPositionIfAvailable(row, col, currentPlayer);
                if (setSucceed)
                {
                    countMoves++;
                    break;
                }
                else
                    Console.WriteLine("this place is already taken, try again");
            }
             
        }

        public bool SetBoardAtPositionIfAvailable(int row, int col, char val)
        {
            if (board[row, col] == ' ')
            {
                board[row, col] = val;
                return true;
            }
            return false;
        }

        public int GetRowFromUsr()
        {
            while (true)
            {
                try
                {
                    Console.Write("enter a row number:");
                    int row = Convert.ToInt32(Console.ReadLine());
                    if (row == 0 || row == 1 || row == 2)
                        return row;
                }
                catch (Exception)
                {
                    Console.WriteLine("incorrect input");
                }
            }
        }

        public int GetColFromUsr()
        {
            while (true)
            {
                try
                {
                    Console.Write("enter a column number:");
                    int col = Convert.ToInt32(Console.ReadLine());
                    if (col == 0 || col == 1 || col == 2)
                        return col;
                }
                catch (Exception)
                {
                    Console.WriteLine("incorrect input");
                }
            }
        }

        public bool Win()
        {
            return WinsRow(0) || WinsRow(1) || WinsRow(2) || WinsCol(0) || WinsCol(1) || WinsCol(2) || WinsMainDiagon() || WinsSecondaryDiagon();
        }
        public bool WinsRow(int row)
        {
            if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                return true;
            return false;
        }

        public bool WinsCol(int col)
        {
            if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                return true;
            return false;
        }

        public bool WinsMainDiagon()
        {
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;
            return false;
        }

        public bool WinsSecondaryDiagon()
        {
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;
            return false;
        }

        public void SwichTurn()
        {
            if (player == 'X')
                player = 'O';
            else
                player = 'X';
        }

        public void Print()
        {
            //Console.WriteLine("   0   1   2  ");

            PrintLineSeperator();

            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine($"| {board[row, 0]} | {board[row, 1]} | {board[row, 2]} |");
                PrintLineSeperator();

                //Console.WriteLine($"{row}| {board[row, 0]} | {board[row, 1]} | {board[row, 2]} |");
            }


        }

        public void PrintRow(int num)
        {
            switch (num)
            {
                case 0:
                    Console.Write($"| {board[num, 0]} | {board[num, 1]} | {board[num, 2]} |");
                    break;
                case 1:
                    Console.Write($"| {board[num, 0]} | {board[num, 1]} | {board[num, 2]} |");
                    break;
                case 2:
                    Console.Write($"| {board[num, 0]} | {board[num, 1]} | {board[num, 2]} |");
                    break;
                default:
                    Console.WriteLine("line is not existed in game board");
                    break;
            }

        }

        public void PrintLineSeperator()
        {
            Console.WriteLine(" ----------- ");
        }

        public void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    board[row, col] = ' ';
        }


    }
}
