using System;
using System.Linq;

namespace ultimateTicTacToe
{
    public class U_TicTacToe
    {
        string[] subBoards = {"upperLeft", "upperMiddle", "upperRight",
                                   "middleLeft", "centered", "middleRight",
                                   "buttomLeft","buttomMiddle" , "buttomRight"};
        private TicTacToe[,] mainBoard;
        private int currentSubBoard = -1;

        private PlayerFactory factory;
        public Player mainPlayer;
        public Player opponentPlayer;
        public Player currentPlayer;

        public U_TicTacToe(Player mainPlayer, Player opponentPlayer)
        {
            mainBoard = new TicTacToe[3, 3];
            this.InitiolizeBoard(mainBoard);
            this.mainPlayer = mainPlayer;
            this.opponentPlayer = opponentPlayer;
            currentPlayer = mainPlayer;
        }

        public U_TicTacToe()
        {
            mainBoard = new TicTacToe[3, 3];
            this.InitiolizeBoard(mainBoard);
            this.factory = new PlayerFactory();
            mainPlayer = factory.CreatePlayer("HumanPlayer");
            currentPlayer = mainPlayer;
        }

        public void InitiolizeBoard(TicTacToe[,] board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = new TicTacToe();
        }

        public void SwitchPlayer()
        {
            if (currentPlayer == mainPlayer)
                currentPlayer = opponentPlayer;
            else
                currentPlayer = mainPlayer;
        }

        public bool IsPlayerWinning(TicTacToe[,] board, char playerSymbol)
        {
            return
                IsPlayerWinningRow(board, playerSymbol, 0) ||
                IsPlayerWinningRow(board, playerSymbol, 1) ||
                IsPlayerWinningRow(board, playerSymbol, 2) ||
                IsPlayerWinningCol(board, playerSymbol, 0) ||
                IsPlayerWinningCol(board, playerSymbol, 1) ||
                IsPlayerWinningCol(board, playerSymbol, 2) ||
                IsPlayerWinningDiagon(board, playerSymbol);
        }

        public bool IsPlayerWinningRow(TicTacToe[,] board, char playerSymbol, int row)
        {
            return board[row, 0].Winner == playerSymbol &&
                   board[row, 1].Winner == playerSymbol &&
                   board[row, 2].Winner == playerSymbol;
        }

        public bool IsPlayerWinningCol(TicTacToe[,] board, char playerSymbol, int col)
        {
            return board[0, col].Winner == playerSymbol &&
                   board[1, col].Winner == playerSymbol &&
                   board[2, col].Winner == playerSymbol;
        }

        public bool IsPlayerWinningDiagon(TicTacToe[,] board, char playerSymbol)
        {
            bool mainDiagon = board[0, 0].Winner == playerSymbol &&
                              board[1, 1].Winner == playerSymbol &&
                              board[2, 2].Winner == playerSymbol;

            bool secondaryDiagon = board[0, 2].Winner == playerSymbol &&
                                   board[1, 1].Winner == playerSymbol &&
                                   board[2, 0].Winner == playerSymbol;

            return mainDiagon || secondaryDiagon;
        }

        //public void DisplayBoard()
        //{
        //    string boardToString = "=======================================================\n";
        //    for (int outerRow = 0; outerRow < 3; outerRow++)
        //    {
        //        for (int innerRow = 0; innerRow < 3; innerRow++)
        //        {
        //            for (int outerCol = 0; outerCol < 3; outerCol++)
        //            {
        //                for (int innerCol = 0; innerCol < 3; innerCol++)
        //                {
        //                    if(innerCol==0) boardToString += "ǁ";
        //                    else boardToString += "|";
        //                    boardToString += $"   {gameBoard[outerRow, outerCol].gameBoard[innerRow, innerCol]} ";
        //                    if(innerCol==2&&outerCol==2) boardToString += "ǁ";
        //                }
        //            }
        //            boardToString += "\n";
        //            if (innerRow == 2)
        //                boardToString += "=======================================================\n";
        //            else                 
        //                boardToString += "–––––––––––––––––––––––––––––––––––––––––––––––––––––––\n";
        //        }

        //    }

        //    Console.Write(boardToString);
        //}

        public void DisplayBoard()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("=======================================================\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int outerRow = 0; outerRow < 3; outerRow++)
            {
                for (int innerRow = 0; innerRow < 3; innerRow++)
                {
                    for (int outerCol = 0; outerCol < 3; outerCol++)
                    {
                        for (int innerCol = 0; innerCol < 3; innerCol++)
                        {
                            if (innerCol == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("ǁ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else Console.Write("|");
                            if (mainBoard[outerRow, outerCol].gameBoard[innerRow, innerCol] == 'X')
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else
                                Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write( $"   {mainBoard[outerRow, outerCol].gameBoard[innerRow, innerCol]} ");
                            Console.ForegroundColor = ConsoleColor.White;
                            if (innerCol == 2 && outerCol == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("ǁ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    Console.Write( "\n");
                    if (innerRow == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("=======================================================\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else

                        Console.Write( "  –––––––––––––––   –––––––––––––––   –––––––––––––––  \n");
                }

            }

        }

        public void RunGame()
        {
            this.DisplayBoard();
            this.mainPlayer.ChooseSymbol();
            this.opponentPlayer = factory.CreatePlayer(mainPlayer.ChooseOpponentType());
            this.opponentPlayer.Symbol = mainPlayer.Symbol == 'X' ? 'O' : 'X';
           

            for (int i = 0; i < 81; i++)
            {
                if (currentSubBoard != -1 && mainBoard[currentSubBoard / 3, currentSubBoard % 3].IsBoardFull())
                    currentSubBoard = -1;

                if (currentSubBoard==-1) {
                    do
                    {
                        Console.WriteLine("enter sub board index between 0-8");
                        try
                        {
                            currentSubBoard = Convert.ToInt32(Console.ReadLine());
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            currentSubBoard = -1;
                        }
                    } while (currentSubBoard < 0 || currentSubBoard > 8);
                }
                Console.Write("you are currently in the ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{subBoards[currentSubBoard]} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("subBoard");

                int cellIndex;
                do
                {
                    Console.WriteLine($"player {currentPlayer.Symbol} enter cell index between 0-8 ");
                    try
                    {
                        cellIndex = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        cellIndex = -1;
                    }
                    if (cellIndex >= 0 && cellIndex <= 8)
                    {
                        try
                        {
                            mainBoard[currentSubBoard / 3, currentSubBoard % 3].SetCell(currentPlayer.Symbol, cellIndex);
                            currentSubBoard = cellIndex;
                            Console.Clear();
                            this.DisplayBoard();
                            if (IsPlayerWinning(this.mainBoard, currentPlayer.Symbol))
                            {
                                Console.WriteLine($"player {currentPlayer.Symbol} has won the game!!!");
                                break;
                            }
                            this.SwitchPlayer();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            cellIndex = -1;
                        }
                    }
                } while (cellIndex < 0 || cellIndex > 8);

            }
        }

    }

}
