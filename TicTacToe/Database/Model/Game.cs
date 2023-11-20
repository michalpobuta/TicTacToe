using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.TicTacToeGame.Bot;

namespace TicTacToe.Database.Model
{
    public class Game
    {
        public int Id { get; set; }
        public User User { get; set; }
        public BotLvL BotLvL { get; set; }
        public long GameDate { get; set; }
        public bool? IsUserWinner { get; set; }
        public bool IsGameFinised { get; set; }
        public ICollection<GameMove> GameMoves { get; set; }
    }
}
