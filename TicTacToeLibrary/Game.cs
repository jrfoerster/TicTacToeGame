using System.Collections.Generic;

namespace TicTacToeLibrary
{
    public class Game
    {
        private readonly TicTacToe _board = new TicTacToe();
        private bool _isPlayerX = true;

        public IReadOnlyList<Square> Squares => _board.Squares;
        public Square PlayerSquare => _isPlayerX ? Square.X : Square.O;
        public bool IsActive { get; private set; } = true;
        public bool IsWon { get; private set; } = false;
        public bool HasNoMoreMoves { get; private set; } = false;

        public bool ChangeSquare(int index)
        {
            bool wasChanged = _board.ChangeSquare(index, PlayerSquare);
            if (wasChanged)
            {
                UpdateProperties();
                SwitchPlayer();
            }
            return wasChanged;
        }

        private void UpdateProperties()
        {
            IsWon = _board.IsWon;
            HasNoMoreMoves = _board.HasNoMoreMoves;
            IsActive = (IsWon == false) && (HasNoMoreMoves == false);
        }

        private void SwitchPlayer()
        {
            if (IsWon == false)
            {
                _isPlayerX = !_isPlayerX;
            }
        }
    }
}
