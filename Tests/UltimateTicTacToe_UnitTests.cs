using NUnit.Framework;
using ultimateTicTacToe;
using FluentAssertions;
using System;
using Moq;

namespace Tests
{
    public class UltimateTicTacToe_UnitTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void IsPlayerWinning_fullRow_shouldReturnTrue(int row)
        {
            // Arrange
            var game = new U_TicTacToe();
            var board = new TicTacToe[3, 3];
            game.InitiolizeBoard(board);

            char playerSymbol = 'X';
            board[row, 0].Winner = playerSymbol;
            board[row, 1].Winner = playerSymbol;
            board[row, 2].Winner = playerSymbol;

            //// Act
            bool isPlayerWinning = game.IsPlayerWinning(board, 'X');

            //// Assert
            Assert.AreEqual(true, isPlayerWinning);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void IsPlayerWinning_fullCol_shouldReturnTrue(int col)
        {
            // Arrange
            var game = new U_TicTacToe();
            var board = new TicTacToe[3, 3];
            game.InitiolizeBoard(board);

            char playerSymbol = 'X';
            board[0, col].Winner = playerSymbol;
            board[1, col].Winner = playerSymbol;
            board[2, col].Winner = playerSymbol;

            //// Act
            bool isPlayerWinning = game.IsPlayerWinning(board, 'X');

            //// Assert
            Assert.AreEqual(true, isPlayerWinning);
        }

        [TestCase("main")]
        [TestCase("secondary")]
        public void IsPlayerWinning_fullDiagon_shouldReturnTrue(string diagon)
        {
            // Arrange
            var game = new U_TicTacToe();
            var board = new TicTacToe[3, 3];
            game.InitiolizeBoard(board);

            char playerSymbol = 'X';
            board[1, 1].Winner = playerSymbol;
            if(diagon == "main")
            {
                board[0,0].Winner = playerSymbol;
                board[2,2].Winner = playerSymbol;
            }
            else
            {
                board[0, 2].Winner = playerSymbol;
                board[2, 0].Winner = playerSymbol;
            }

            //// Act
            bool isPlayerWinning = game.IsPlayerWinning(board, 'X');

            //// Assert
            Assert.AreEqual(true, isPlayerWinning);
        }

        [Test]
        public void SwitchPlayer_shouldSetCurrentPlayerToOpponent()
        {
            var game = new U_TicTacToe();
            game.mainPlayer = new HumanPlayer('X');
            game.opponentPlayer = new HumanPlayer('O');
            game.currentPlayer = game.mainPlayer;
            game.SwitchPlayer();

            Assert.AreEqual(true, game.currentPlayer == game.opponentPlayer);
        }

        [Test]
        public void SwitchPlayer_shouldSetCurrentPlayerToMainPlayer()
        {
            var game = new U_TicTacToe();
            game.mainPlayer = new HumanPlayer('X');
            game.opponentPlayer = new HumanPlayer('O');
            game.currentPlayer = game.opponentPlayer;
            game.SwitchPlayer();

            Assert.AreEqual(true, game.currentPlayer == game.mainPlayer);
        }
        
    }

}