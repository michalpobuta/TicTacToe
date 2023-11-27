using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.TicTacToeGame
{
    public interface ITicTacToeGame
    {
        int GetPiece(int row, int col);
        bool MakeMove(int row, int col);
        (int row, int col)? MakeMoveForBot(Bot.Bot bot);
        public void ChangePlayer();
        public int CheckResult();
        public Tuple<int, WinType> GetWinInfo();
        public Point GetLastMove();
        void Reset();
    }
}