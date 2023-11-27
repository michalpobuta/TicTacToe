using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.TicTacToeGame.Bot
{
    public class BotFactory
    {
        public Bot CreateBot(BotLvL lvl) => lvl switch
        {
            BotLvL.Easy => new EasyBot(),
            BotLvL.Medium => new MediumBot(),
            BotLvL.Hard => new HardBot(),
            _ => throw new NotImplementedException()
        };
    }
}
