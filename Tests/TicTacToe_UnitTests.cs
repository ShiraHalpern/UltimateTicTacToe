using NUnit.Framework;
using ultimateTicTacToe;
using FluentAssertions;
using System;
using Moq;

namespace Tests
{
    public class TicTacToe_UnitTests
    {

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void IsPlayerWinning_fullRow_shouldReturnTrue(int row)
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            Board board = new Board();
            board[row, 0] = 'X';
            board[row, 1] = 'X';
            board[row, 2] = 'X';

            // Act
            bool isPlayerWinning = game.IsPlayerWinning(board, 'X');

            // Assert
            Assert.AreEqual(true, isPlayerWinning);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void IsPlayerWinning_fullCol_shouldReturnTrue(int col)
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            Board board = new Board();
            board[0, col] = 'X';
            board[1, col] = 'X';
            board[2, col] = 'X';

            // Act
            bool isPlayerWinning = game.IsPlayerWinning(board, 'X');

            // Assert
            Assert.AreEqual(true, isPlayerWinning);
        }

        [TestCase("main")]
        [TestCase("secondary")]
        public void IsPlayerWinning_fullDiagon_shouldReturnTrue(string diagon)
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            Board board = new Board();

            board[1, 1] = 'X';
            if(diagon== "main")
            {
                board[0, 0] = 'X';
                board[2, 2] = 'X';
            }
            else
            {
                board[0, 2] = 'X';
                board[2, 0] = 'X';
            }
            
            // Act
            bool isPlayerWinning = game.IsPlayerWinning(board, 'X');

            // Assert
            Assert.AreEqual(true, isPlayerWinning);
        }

        [Test]
        public void IsPlayerWinning_notWinning_shouldReturnFalse()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            Board board = new Board();
            board[0, 0] = 'X';
            board[1, 0] = 'O';
            board[2, 0] = 'X';

            // Act
            bool isPlayerWinning = game.IsPlayerWinning(board, 'X');

            // Assert
            Assert.AreEqual(false, isPlayerWinning);
        }

        [Test]
        public void SetCell_shouldChangeValueOfCell()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            Board board = new Board();
            
            // Act
            game.SetCell(board, 'X', 1, 1);

            // Assert
            Assert.AreEqual('X', board[1,1]);
        }

        [Test]
        public void IsBoardFull_boardIsFull_ShouldReturnTrue()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            Board board = new Board();
            board[0, 0] = 'X';
            board[0, 1] = 'X';
            board[0, 2] = 'X';
            board[1, 0] = 'X';
            board[1, 1] = 'X';
            board[1, 2] = 'X';
            board[2, 0] = 'X';
            board[2, 1] = 'X';
            board[2, 2] = 'X';

            // Act
            bool isBoardFull = game.IsBoardFull(board);

            // Assert
            Assert.AreEqual(true, isBoardFull);
        }

    }
}