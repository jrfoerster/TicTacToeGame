using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicTacToeLibrary;

namespace UnitTests
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod]
        public void TicTacToe_NewGame_SquaresAreEmpty()
        {
            var board = new TicTacToe();
            foreach (var square in board.Squares)
            {
                Console.WriteLine(square);
                Assert.AreEqual(square, Square.Empty);
            }
        }

        [DataTestMethod]
        [DataRow(Square.X)]
        [DataRow(Square.O)]
        public void TicTacToe_ChangeSquareFromEmpty_ReturnsTrue(Square square)
        {
            var board = new TicTacToe();
            bool condition = board.ChangeSquare(0, square);
            Assert.IsTrue(condition);
        }

        [DataTestMethod]
        [DataRow(Square.X)]
        [DataRow(Square.O)]
        [DataRow(Square.Empty)]
        public void TicTacToe_ChangeSquareFromX_ReturnsFalse(Square square)
        {
            var board = new TicTacToe();
            int index = 0;
            board.ChangeSquare(index, Square.X);
            bool condition = board.ChangeSquare(index, square);
            Assert.IsFalse(condition);
        }

        [DataTestMethod]
        [DataRow(Square.X)]
        [DataRow(Square.O)]
        [DataRow(Square.Empty)]
        public void TicTacToe_ChangeSquareFromO_ReturnsFalse(Square square)
        {
            var board = new TicTacToe();
            int index = 0;
            board.ChangeSquare(index, Square.O);
            bool condition = board.ChangeSquare(index, square);
            Assert.IsFalse(condition);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(9)]
        [DataRow(int.MaxValue)]
        [DataRow(int.MinValue)]
        public void TicTacToe_ChangeSquareIndexOutOfBounds_ReturnsFalse(int index)
        {
            var board = new TicTacToe();
            var square = Square.X;
            bool condition = board.ChangeSquare(index, square);
            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void TicTacToe_ChangeSquareToEmpty_ReturnsFalse()
        {
            var board = new TicTacToe();
            int index = 0;
            bool condition = board.ChangeSquare(index, Square.Empty);
            Assert.IsFalse(condition);
        }

        [DataTestMethod]
        [DataRow(0, 1, 2)]
        [DataRow(3, 4, 5)]
        [DataRow(6, 7, 8)]
        public void TicTacToe_GameIsWonRow_ReturnsTrue(params int[] indexes)
        {
            bool condition = CheckIndexesForWin(indexes);
            Assert.IsTrue(condition);
        }

        [DataTestMethod]
        [DataRow(0, 3, 6)]
        [DataRow(1, 4, 7)]
        [DataRow(2, 5, 8)]
        public void TicTacToe_GameIsWonColumn_ReturnsTrue(params int[] indexes)
        {
            bool condition = CheckIndexesForWin(indexes);
            Assert.IsTrue(condition);
        }

        [DataTestMethod]
        [DataRow(0, 4, 8)]
        [DataRow(2, 4, 6)]
        public void TicTacToe_GameIsWonDiagonal_ReturnsTrue(params int[] indexes)
        {
            bool condition = CheckIndexesForWin(indexes);
            Assert.IsTrue(condition);
        }

        private bool CheckIndexesForWin(int[] indexes)
        {
            var boardX = new TicTacToe();
            var boardO = new TicTacToe();
            foreach (int index in indexes)
            {
                boardX.ChangeSquare(index, Square.X);
                boardO.ChangeSquare(index, Square.O);
            }
            return boardX.IsWon && boardO.IsWon;
        }

        [TestMethod]
        public void TicTacToe_NewGameIsWon_ReturnsFalse()
        {
            var board = new TicTacToe();
            bool condition = board.IsWon;
            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void TicTacToe_NewGameHasNoMoreMoves_ReturnsFalse()
        {
            var board = new TicTacToe();
            bool condition = board.HasNoMoreMoves;
            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void TicTacToe_GameHasNoMoreMoves_ReturnsTrue()
        {
            var board = new TicTacToe();
            board.ChangeSquare(0, Square.O);
            board.ChangeSquare(1, Square.X);
            board.ChangeSquare(2, Square.O);
            board.ChangeSquare(3, Square.X);
            board.ChangeSquare(4, Square.O);
            board.ChangeSquare(5, Square.X);
            board.ChangeSquare(6, Square.X);
            board.ChangeSquare(7, Square.O);
            board.ChangeSquare(8, Square.X);
            bool condition = board.HasNoMoreMoves;
            Assert.IsTrue(condition);
        }
    }
}