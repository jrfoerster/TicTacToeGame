using System;
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

        public IReadOnlyList<Square> GetSquares()
        {
            return _squares;
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

        //private bool CheckRows()
        //{
        //    int length = (int)Math.Sqrt(_squares.Length);
        //    bool output = false;
        //    for (int row = 0; row < length; row++)
        //    {
        //        var indexes = new int[length];
        //        for (int col = 0; col < length; col++)
        //        {
        //            int index = row * length + col;
        //            Console.WriteLine(index);
        //            indexes[col] = index;                 
        //        }
        //        output |= Check(indexes);
        //    }
        //    return output;
        //}

        //private bool CheckColumns()
        //{
        //    int length = (int)Math.Sqrt(_squares.Length);
        //    bool output = false;
        //    for (int row = 0; row < length; row++)
        //    {
        //        var indexes = new int[length];
        //        for (int col = 0; col < length; col++)
        //        {
        //            int index = col * length + row;
        //            Console.WriteLine(index);
        //            indexes[col] = index;              
        //        }
        //        output |= Check(indexes);
        //    }
        //    return output;
        //}

        private bool Check(int a, int b, int c)
        {
            return Check(_squares[a], _squares[b], _squares[c]);
        }

        private bool Check(Square one, Square two, Square three)
        {
            return (one != Square.Empty) && (one == two) && (one == three);
        }

        //private bool Check(params int[] indexes)
        //{
        //    int firstIndex = indexes[0];
        //    Square first = _squares[firstIndex];
        //    bool output = first != Square.Empty;
        //    if (output)
        //    {
        //        for (int i = 1; i < indexes.Length; i++)
        //        {
        //            int index = indexes[i];
        //            output &= first == _squares[index];
        //        }
        //    }
        //    return output;
        //}

        //private bool Check(params Square[] squares)
        //{
        //    Square one = squares[0];
        //    bool output = one != Square.Empty;
        //    if (output)
        //    {
        //        for (int i = 1; i < squares.Length; i++)
        //        {
        //            output &= one == squares[i];
        //        }
        //    }
        //    return output;
        //}
    }
}