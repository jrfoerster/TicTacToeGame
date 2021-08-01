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
                Play();
            } while (IsPlayingAgain());
        }

        private bool IsPlayingAgain()
        {
            var exitKey = ConsoleKey.Escape;
            Console.Write($"Press any key to play again. Press {exitKey} to exit: ");
            var input = Console.ReadKey();
            return input.Key != exitKey;
        }

        private void Play()
        {
            var game = new Game();
            Loop(game);
            EndOf(game);
        }

        private void Loop(Game game)
        {
            var writer = new SquareWriter(game.Squares);
            writer.WriteSquares();

            do
            {             
                int index = GetIndexToPlace(game.PlayerSquare);
                game.ChangeSquare(index);
                writer.WriteSquares();
            } while (game.IsActive);          
        }

        private void EndOf(Game game)
        {
            if (game.IsWon)
            {
                Console.WriteLine($"{game.PlayerSquare} Wins!");
            }
            else if (game.HasNoMoreMoves)
            {
                Console.WriteLine("Tie Game!");
            }
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
    }
}