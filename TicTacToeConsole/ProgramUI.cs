using System;
using System.Collections.Generic;
using TicTacToeLibrary;

namespace TicTacToeConsole
{
    class ProgramUI
    {
        public void Run()
        {
            do
            {
                LoopGame();
            } while (IsPlayingAgain());
        }

        private bool IsPlayingAgain()
        {
            var exitKey = ConsoleKey.Escape;
            Console.Write($"Press any key to play again. Press {exitKey} to exit");
            var input = Console.ReadKey();
            return input.Key != exitKey;
        }

        private void LoopGame()
        {
            var game = new Game();

            do
            {
                ViewTicTacToe(game);

                int index = GetIndexToPlace(game.PlayerSquare);
                game.ChangeSquare(index);

                if (game.IsWon)
                {
                    ViewTicTacToe(game);
                    Console.WriteLine($"{game.PlayerSquare} Wins!");
                }
                else if (game.HasNoMoreMoves)
                {
                    ViewTicTacToe(game);
                    Console.WriteLine("Tie Game!");
                }
            } while (game.IsActive);
        }

        private int GetIndexToPlace(Square square)
        {
            Console.Write($"Enter the Square Number (1-9) to add an {square}: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index))
            {
                return index - 1;  // Asking for (1-9), but TicTacToe index starts at 0
            }
            else
            {
                return -1;  // This value is not valid, TicTacToe will not change
            }
        }

        private void ViewTicTacToe(Game game)
        {
            Console.Clear();
            PrintTicTacToe(game);
            Console.WriteLine();
        }

        private void PrintTicTacToe(Game game)
        {
            IReadOnlyList<Square> squares = game.Squares;

            Console.WriteLine($" {StringOf(squares[0])} | {StringOf(squares[1])} | {StringOf(squares[2])} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {StringOf(squares[3])} | {StringOf(squares[4])} | {StringOf(squares[5])} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {StringOf(squares[6])} | {StringOf(squares[7])} | {StringOf(squares[8])} ");
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