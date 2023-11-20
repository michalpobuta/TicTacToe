using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.TicTacToeGame
{
    public interface ITicTacToeGame
    {
        int GetPiece(int row, int col);
        bool MakeMove(int row, int col);
        bool MakeMoveForBot(IBot bot);
        public void ChangePlayer();
        public int CheckResult();
        public Point GetLastMove();
        void Reset();
    }
}