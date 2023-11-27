using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.TicTacToeGame.Bot
{
    public class HardBot : Bot
    {
        public override BotLvL GetBotLvL() => BotLvL.Hard;
        public override (int row, int col) MakeMove(Array2D board)
        {
            var winMove = FindWinningMove(board, 2);
            if (winMove != null) return winMove.Value;

            var blockMove = FindWinningMove(board, 1);
            if (blockMove != null) return blockMove.Value;

            return GetRandomMove(board);
        }
    }
}
