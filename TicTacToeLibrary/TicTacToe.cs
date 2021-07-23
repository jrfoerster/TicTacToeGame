using System.Collections.Generic;
using System.Linq;

namespace TicTacToeLibrary
{
    public enum Square
    {
        X,
        O,
        Empty
    }

    public class TicTacToe
    {
        private readonly Square[] _squares = new Square[9];
        private int _moveCount = 0;

        public TicTacToe()
        {
            for (int i = 0; i < _squares.Length; i++)
            {
                _squares[i] = Square.Empty;
            }
        }

        public List<Square> GetSquares()
        {
            return _squares.ToList();
        }

        public bool ChangeSquare(int index, Square square)
        {
            if (square == Square.Empty)
            {
                return false;
            }
            if (index >= 0 && index < _squares.Length)
            {
                if (_squares[index] == Square.Empty)
                {
                    _squares[index] = square;
                    _moveCount++;
                    return true;
                }
            }
            return false;
        }

        public bool GameHasNoMoreMoves()
        {
            return _moveCount == _squares.Length;
        }

        public bool GameIsWon()
        {
            return CheckRows() || CheckColumns() || CheckDiagonals();
        }

        private bool CheckRows()
        {
            return Check(0, 1, 2)
                || Check(3, 4, 5)
                || Check(6, 7, 8);
        }

        private bool CheckColumns()
        {
            return Check(0, 3, 6)
                || Check(1, 4, 7)
                || Check(2, 5, 8);
        }

        private bool CheckDiagonals()
        {
            return Check(0, 4, 8)
                || Check(2, 4, 6);
        }

        private bool Check(int a, int b, int c)
        {
            return Check(_squares[a], _squares[b], _squares[c]);
        }

        private bool Check(Square one, Square two, Square three)
        {
            return one != Square.Empty && one == two && one == three;
        }
    }
}