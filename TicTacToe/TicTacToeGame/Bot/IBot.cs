namespace TicTacToe.TicTacToeGame.Bot
{
    public interface IBot
    {
        (int row, int col) MakeMove(Array2D board);
    }
}
