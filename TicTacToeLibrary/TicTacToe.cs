using System.Collections.Generic;

namespace TicTacToeLibrary
{
    public class TicTacToe
    {
        private readonly Square[] _squares = new Square[9];
        private int _moveCount = 0;

        public IReadOnlyList<Square> Squares => _squares;
        public bool IsWon => WinCondition.Check(_squares);
        public bool HasNoMoreMoves => _moveCount == _squares.Length;

        public TicTacToe()
        {
            for (int i = 0; i < _squares.Length; i++)
            {
                _squares[i] = Square.Empty;
            }
        }

        public bool ChangeSquare(int index, Square square)
        {
            if (IndexIsInBounds(index) && CurrentSquareIsEmpty(index) && ReplacementSquareIsNotEmpty(square))
            {
                _squares[index] = square;
                _moveCount++;
                return true;
            }
            return false;
        }

        private bool IndexIsInBounds(int index)
        {
            return (index >= 0) && (index < _squares.Length);
        }

        private bool CurrentSquareIsEmpty(int index)
        {
            return _squares[index] == Square.Empty;
        }

        private bool ReplacementSquareIsNotEmpty(Square square)
        {
            return square != Square.Empty;
        }
    }
}