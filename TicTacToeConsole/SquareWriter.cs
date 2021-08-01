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

        public void Write()
        {
            Console.Clear();
            WriteSquares();
            Console.WriteLine();
        }

        private void WriteSquares()
        {
            Console.WriteLine($" {StringOf(0)} | {StringOf(1)} | {StringOf(2)} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {StringOf(3)} | {StringOf(4)} | {StringOf(5)} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {StringOf(6)} | {StringOf(7)} | {StringOf(8)} ");
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