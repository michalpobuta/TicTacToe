using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.TicTacToeGame.Bot
{
    public class EasyBot : IBot
    {
        private Random random = new Random();

        public (int row, int col) MakeMove(Array2D board)
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
}
