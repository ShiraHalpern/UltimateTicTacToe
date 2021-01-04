using System;
using FluentAssertions;
using NUnit.Framework;
using ultimateTicTacToe;
namespace Tests
{
    public class Board_UnitTests
    {
        /*[TestCase(2, 2)]
        [TestCase(1, 0)]
        public void Setter_WhenPlaceIsFilled_ShouldThrowAnException(int row, int col)
        {
            // Arrange
            var board = new Board();
            board[row, col] = CellStatus.X;

            // Act
            Action action = () => board[row, col] = CellStatus.O;

            // Assert
            action.Should().Throw<Exception>().WithMessage("this cell is already filled");
        }*/


        /*[TestCase(3, 1)]
        [TestCase(4, 5)]
        public void Setter_WhenIndexNotValid_ShouldThrowAnException(int row, int col)
        {
            // Arrange
            var board = new Board();

            // Act
            Symbol cellStat;
            Action action = () => cellStat = board[row, col];

            // Assert
            action.Should().Throw<IndexOutOfRangeException>();
        }

        [TestCase(3, 1)]
        [TestCase(4, 5)]
        public void Getter_WhenIndexNotValid_ShouldThrowAnException(int row, int col)
        {
            // Arrange
            var board = new Board();

            // Act
            Symbol cellStat;
            Action action = () => cellStat = board[row, col];

            // Assert
            action.Should().Throw<IndexOutOfRangeException>();
        }*/

    }
}
