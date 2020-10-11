using NUnit.Framework;
using ultimateTicTacToe;
namespace Tests
{
    public class TicTacToe_UnitTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestWinsRow_RowFull_ReturnsTrue()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');
            game.SetBoardAtPositionIfAvailable(0, 1, 'X');
            game.SetBoardAtPositionIfAvailable(0, 2, 'X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestWinsRow_EmptyRow_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsRow_PlayerFilledLeft_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsRow_PlayerFilledMiddle_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 1, 'X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsRow_PlayerFilledRight_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 2, 'X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsRow_PlayerFilledLeftAndMiddle_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');
            game.SetBoardAtPositionIfAvailable(0, 1, 'X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsRow_PlayerFilledLeftAndRight_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');
            game.SetBoardAtPositionIfAvailable(0, 2, 'X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsRow_PlayerFilledMiddleAndRight_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 1, 'X');
            game.SetBoardAtPositionIfAvailable(0, 2, 'X');

            //act
            bool result = game.WinsRow(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsCol_ColFull_ReturnsTrue()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');
            game.SetBoardAtPositionIfAvailable(1, 0, 'X');
            game.SetBoardAtPositionIfAvailable(2, 0, 'X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestWinsCol_EmptyCol_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsCol_PlayerFilledTop_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsCol_PlayerFilledMiddle_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(1, 0, 'X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsCol_PlayerFilledBottom_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(2, 0, 'X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsCol_PlayerFilledTopAndMiddle_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');
            game.SetBoardAtPositionIfAvailable(1, 0, 'X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsCol_PlayerFilledMiddleAndBottom_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(1, 0, 'X');
            game.SetBoardAtPositionIfAvailable(2, 0, 'X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestWinsCol_PlayerFilledTopAndBottom_ReturnsFalse()
        {
            //arrange
            TicTacToe game = new TicTacToe('X');
            game.SetBoardAtPositionIfAvailable(0, 0, 'X');
            game.SetBoardAtPositionIfAvailable(2, 0, 'X');

            //act
            bool result = game.WinsCol(0);

            //assert
            Assert.IsFalse(result);
        }

    }
}