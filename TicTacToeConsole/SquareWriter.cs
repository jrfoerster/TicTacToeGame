using System;
using System.Collections.Generic;
using TicTacToeLibrary;

namespace TicTacToeConsole
{
    internal class SquareWriter
    {
        private readonly IReadOnlyList<Square> _squares;

        public SquareWriter(IReadOnlyList<Square> squares)
        {
            _squares = squares;
        }

        public void WriteSquares()
        {
            Console.Clear();
            WriteAll();
            Console.WriteLine();
        }

        private void WriteAll()
        {
            WriteRow(0, 1, 2);
            WriteRowSeparator();
            WriteRow(3, 4, 5);
            WriteRowSeparator();
            WriteRow(6, 7, 8);
        }

        private void WriteRow(int a, int b, int c)
        {
            string x = StringOf(a);
            string y = StringOf(b);
            string z = StringOf(c);
            Console.WriteLine($" {x} | {y} | {z} ");
        }

        private void WriteRowSeparator()
        {
            Console.WriteLine("-----------");
        }

        private string StringOf(int index)
        {
            return StringOf(_squares[index]);
        }

        private string StringOf(Square square)
        {
            if (square == Square.Empty)
            {
                return " ";
            }
            else
            {
                return square.ToString();
            }
        }
    }
}