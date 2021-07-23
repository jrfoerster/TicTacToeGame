using System;
using System.Collections.Generic;
using TicTacToeLibrary;

namespace TicTacToeConsole
{
    class ProgramUI
    {
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                LoopGame();
                isRunning = IsPlayingAgain();
            }
            Console.WriteLine();
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
            var board = new TicTacToe();
            bool isPlayerX = true;
            bool isLoopingGame = true;

            while (isLoopingGame)
            {
                ViewTicTacToe(board);

                Square playerSquare = isPlayerX ? Square.X : Square.O;
                int index = GetIndexToPlace(playerSquare);

                bool wasChanged = board.ChangeSquare(index, playerSquare);
                if (wasChanged == false)
                {
                    continue;  // Start the game loop over again without changing anything
                }

                if (board.GameIsWon())
                {
                    ViewTicTacToe(board);
                    Console.WriteLine($"{playerSquare} Wins!");
                    isLoopingGame = false;
                }
                else if (board.GameHasNoMoreMoves())
                {
                    ViewTicTacToe(board);
                    Console.WriteLine($"Tie Game!");
                    isLoopingGame = false;
                }

                isPlayerX = !isPlayerX;
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

        private void ViewTicTacToe(TicTacToe board)
        {
            Console.Clear();
            PrintTicTacToe(board);
            Console.WriteLine();
        }

        private void PrintTicTacToe(TicTacToe board)
        {
            List<Square> squares = board.GetSquares();

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