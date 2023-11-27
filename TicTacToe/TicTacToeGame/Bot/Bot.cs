using System;

namespace TicTacToe.TicTacToeGame.Bot
{
    public abstract class Bot
    {
        Random random = new Random();
        public abstract (int row, int col) MakeMove(Array2D board);

        public abstract BotLvL GetBotLvL();

        protected (int row, int col) GetRandomMove(Array2D board) 
        {
            {
                var emptyCells = new List<(int row, int col)>();
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == 0)
                        {
                            emptyCells.Add((i, j));
                        }
                    }
                }

                if (emptyCells.Count == 0)
                {
                    throw new InvalidOperationException("No more moves available.");
                }
                int index = random.Next(emptyCells.Count);
                return emptyCells[index];
            }
        }

        protected (int row, int col)? FindWinningMove(Array2D board, int playerNumber)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 0)
                    {
                        board[row, col] = playerNumber;
                        if (CheckWin(board, playerNumber))
                        {
                            board[row, col] = 0;
                            return (row, col);
                        }
                        board[row, col] = 0;
                    }
                }
            }
            return null;
        }

        protected bool CheckWin(Array2D board, int playerNumber)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == playerNumber && board[i, 1] == playerNumber && board[i, 2] == playerNumber)
                    return true;
                if (board[0, i] == playerNumber && board[1, i] == playerNumber && board[2, i] == playerNumber)
                    return true;
            }
            if (board[0, 0] == playerNumber && board[1, 1] == playerNumber && board[2, 2] == playerNumber)
                return true;
            if (board[0, 2] == playerNumber && board[1, 1] == playerNumber && board[2, 0] == playerNumber)
                return true;

            return false;
        }
    }
}
