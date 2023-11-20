using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Database.Model;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Database.Factories
{
    public class GameFactory
    {
        public static Game CreateGame(User user, BotLvL botLvL,ICollection<GameMove> gameMoves,bool isGameFinished, bool isUserWinner) 
        {
            return new Game() { User = user, BotLvL = botLvL, GameDate= DateTime.Now.Ticks, GameMoves = gameMoves, Id=0, IsGameFinised = isGameFinished, IsUserWinner = isUserWinner };
        }
    }
}
