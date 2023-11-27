using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.TicTacToeGame.Bot
{
    public class EasyBot : Bot
    {
        public override BotLvL GetBotLvL() => BotLvL.Easy;

        public override (int row, int col) MakeMove(Array2D board)
        {
            return GetRandomMove(board);
        }
    }
}
