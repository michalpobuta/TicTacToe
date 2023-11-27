using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.TicTacToeGame.Bot
{
    public class MediumBot : Bot
    {
        public override BotLvL GetBotLvL() => BotLvL.Medium;
        public override (int row, int col) MakeMove(Array2D board)
        {
            var blockMove = FindWinningMove(board, 1);
            if (blockMove != null) return blockMove.Value;

            return GetRandomMove(board);
        }

       

    }
}
